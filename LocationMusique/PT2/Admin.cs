using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT2
{
    public partial class Admin : Form
    {
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();

        private HashSet<ABONNÉS> abonnésPurgeables = new HashSet<ABONNÉS>();

        public Admin()
        {
            InitializeComponent();
            enRetard();
            LivreEmprunteProlongé();
            abonnésAPurger();

        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        public List<ABONNÉS> enRetard()
        {
            List<ABONNÉS> enretard10 = new List<ABONNÉS>();
            var listemprunt = from l in musiqueSQL.EMPRUNTER select l;
            foreach (EMPRUNTER e in listemprunt)
            {
                if (e.enRetard())
                {
                    enretard10.Add(e.ABONNÉS);
                    listBox1.Items.Add(e.ABONNÉS);

                }
            }
            Refresh();
            return enretard10;
        }

        private void LivreEmprunteProlongé()
        {
            var lesLivresEmpruntes =
                   from m in musiqueSQL.EMPRUNTER
                   select m;

            foreach (EMPRUNTER m in lesLivresEmpruntes)
            {
                if (!(m.DATE_EMPRUNT.AddMonths(1).AddDays(m.ALBUMS.GENRES.DÉLAI).CompareTo(m.DATE_RETOUR_ATTENDUE.AddMonths(1)) >= 0) && m.DATE_RETOUR == null) //à vérifier
                {
                    listBox2.Items.Add(m);
                }

            }

            Refresh();
        }


        /// <summary>
        /// Méthode permettant renvoyant une liste d'album
        /// Cette dernière contient les 10 albums les plus empruntés de la base
        /// </summary>
        /// <returns> une List<ALBUMS> ne contenant que les 10 albums les plus vues</returns>
        public List<ALBUMS> DixPlusVue()
        {
            List<ALBUMS> lesDixPlusEmprunte = new List<ALBUMS>();
            lesDixPlusEmprunte.Clear();
            var lesAlbums = from a in musiqueSQL.ALBUMS
                            select a;
            foreach (ALBUMS a in lesAlbums)
            {
                a.EmpruntAnnee();
                if (a.nmbEmpruntEnUnAn > 0)
                {
                    int compteurBoucle;
                    bool placeTrouver = false;
                    //Rempli la liste en comparant à partir du plus vue
                    //Permet de remplir la liste quand elle n'est pas pleine (inférieur à 10)
                    if (lesDixPlusEmprunte.Count() < 10)
                    {
                        compteurBoucle = 0;
                        while (!placeTrouver && compteurBoucle < 10)
                        {
                            if (lesDixPlusEmprunte.Count() <= compteurBoucle)
                            {
                                lesDixPlusEmprunte.Add(a);
                                placeTrouver = true;
                            }
                            else if (lesDixPlusEmprunte[compteurBoucle].EMPRUNTER.Count() <= a.EMPRUNTER.Count())
                            {
                                placeTrouver = true;
                                DecaleDroiteAlbum(lesDixPlusEmprunte, a, compteurBoucle, lesDixPlusEmprunte.Count());
                            }
                            compteurBoucle++;
                        }
                    }
                    //Remplie la liste en comparant à partir du moins vue
                    else
                    {
                        compteurBoucle = 9;
                        while (!placeTrouver && compteurBoucle > 0)
                        {
                            if (!(lesDixPlusEmprunte[compteurBoucle].EMPRUNTER.Count() < a.EMPRUNTER.Count()))
                            {
                                placeTrouver = true;
                                if (compteurBoucle != 9) { DecaleDroiteAlbum(lesDixPlusEmprunte, a, compteurBoucle, 10); }
                            }
                            compteurBoucle--;
                        }
                    }
                }
                        
            }
            return lesDixPlusEmprunte;
        }
        /// <summary>
        /// Permet d'effectuer un décalage droite dans une List<ALBUMS>
        /// en indiquant l'objet à placer après décalage et son index
        /// </summary>
        /// <param name="la"> la liste devant subir le décalage</param>
        /// <param name="a"> l'album a placé dans la liste</param>
        /// <param name="index"> l'index où doit être placé le nouveaux albums</param>
        /// <paramref name="finDecalage"> l'index où délimitant la fin du tableau voulu
        private static void DecaleDroiteAlbum(List<ALBUMS> la, ALBUMS a, int index, int finDecalage)
        {
            for (int compteurInverse = finDecalage; compteurInverse > index; compteurInverse--)
            {
                if (compteurInverse == finDecalage)
                {
                    la.Add(la[compteurInverse - 1]);
                }
                else
                {
                    la[compteurInverse] = la[compteurInverse - 1];
                }

            }
            la[index] = a;
            la.Remove(la[finDecalage]);
        }

        private void abonnésAPurger()
        {
            DateTime dateactuelle = DateTime.UtcNow.AddYears(-1);
            var abonnés = from e in musiqueSQL.EMPRUNTER
                          join alb in musiqueSQL.ALBUMS on e.CODE_ALBUM equals alb.CODE_ALBUM
                          join abo in musiqueSQL.ABONNÉS on e.CODE_ABONNÉ equals abo.CODE_ABONNÉ
                          where e.DATE_EMPRUNT.CompareTo(dateactuelle) <= 0
                          select abo;
            foreach (ABONNÉS a in abonnés)
                if (!abonnésPurgeables.Contains(a))
                {
                    abonnésPurgeables.Add(a);
                    listBox3.Items.Add(a);
                }
            Refresh();
        }



        private void purgerAbonné(int codeAbonné)
        {
            abonnésAPurger();
            
                
                    var query = from l in musiqueSQL.ABONNÉS where l.CODE_ABONNÉ == codeAbonné select l;
                    ABONNÉS x = query.First();
                    musiqueSQL.ABONNÉS.Remove(x);
                    musiqueSQL.SaveChanges();
                
            
        }

        private void purgebutton_Click(object sender, EventArgs e)
        {
            ABONNÉS a = (ABONNÉS)listBox3.SelectedItem;
            purgerAbonné(a.CODE_ABONNÉ);
        }
    }
}
