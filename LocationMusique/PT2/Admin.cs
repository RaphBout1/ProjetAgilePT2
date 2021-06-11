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
        private readonly static string logAdmin = "admin";
        private HashSet<ALBUMS> albumsUS8 = new HashSet<ALBUMS>();
        private bool purgeModeOn = true;
        private bool listeabonneVisible = false;

        public Admin()
        {
            InitializeComponent();
            listerAbonnés();
            desactiverCasier();
            albumsUS8 = albumPasEmpruntesDepuis1An();
        }
        /// <summary>
        /// Renvoie une liste d'abonnée ayant un emprunt non rendu en retard de 10 jours sur la date de rendue attendue.
        /// </summary>
        /// <returns>La Liste en question.</returns>
        public List<ABONNÉS> enRetard()
        {
            listBoxGlobale.Items.Clear();
            List<ABONNÉS> enretard10 = new List<ABONNÉS>();
            var listemprunt = from l in musiqueSQL.EMPRUNTER select l;
            foreach (EMPRUNTER e in listemprunt)
            {
                if (e.enRetard())
                {
                    enretard10.Add(e.ABONNÉS);
                    listBoxGlobale.Items.Add(e.ABONNÉS);

                }
            }
            Refresh();
            return enretard10;
        }

        private void LivreEmprunteProlongé()
        {
            listBoxGlobale.Items.Clear();
            var lesLivresEmpruntes =
                   from m in musiqueSQL.EMPRUNTER
                   select m;

            foreach (EMPRUNTER m in lesLivresEmpruntes)
            {
                if (!(m.DATE_EMPRUNT.AddMonths(1).AddDays(m.ALBUMS.GENRES.DÉLAI).CompareTo(m.DATE_RETOUR_ATTENDUE.AddMonths(1)) >= 0) && m.DATE_RETOUR == null) //à vérifier
                {
                    listBoxGlobale.Items.Add(m);
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
            DateTime ilYAUnAn = DateTime.UtcNow.AddYears(-1);
            return (from e in musiqueSQL.EMPRUNTER
                    where e.DATE_EMPRUNT.CompareTo(ilYAUnAn) >= 0
                    group e by e.CODE_ALBUM into newGroup
                    orderby newGroup.Count() descending
                    select (from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == newGroup.Key select a).FirstOrDefault()).Take(10).ToList();
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

        /// <summary>
        /// liste dans une listBox les abonnés purgeables
        /// </summary>
        private void abonnésAPurger()
        {
            listBoxGlobale.Items.Clear();
            DateTime dateactuelle = DateTime.UtcNow.AddYears(-1);
            var dates = from e in musiqueSQL.EMPRUNTER group e by e.CODE_ABONNÉ into newGroup select new { newGroup.Key, derniereDate = newGroup.Max(d => d.DATE_EMPRUNT) };
            foreach (var kv in dates)
            {
                if (DateTime.UtcNow.AddYears(-1).CompareTo(kv.derniereDate) > 0)
                {
                    ABONNÉS aPurger = (from ab in musiqueSQL.ABONNÉS where ab.CODE_ABONNÉ == kv.Key select ab).First();
                    listBoxGlobale.Items.Add(aPurger);
                }
            }
            Refresh();
        }

        /// <summary>
        /// Purge de la base de donnée l'abonné correspondant à ce code abonné ainsi que tous ses emprunts
        /// </summary>
        /// <param name="codeAbonné"></param> le CODE_ABONNE dans la base de l'abonné à purger
        public void purgerAbonné(int codeAbonné)
        {
            ABONNÉS aPurger = (from l in musiqueSQL.ABONNÉS where l.CODE_ABONNÉ == codeAbonné select l).First();
            if (aPurger != null)
            {
                (from e in musiqueSQL.EMPRUNTER where e.CODE_ABONNÉ == aPurger.CODE_ABONNÉ select e).ToList().ForEach(e => musiqueSQL.EMPRUNTER.Remove(e));
                musiqueSQL.ABONNÉS.Remove(aPurger);
                musiqueSQL.SaveChanges();
            }
            else
            {
                throw new databaseException("Cet abonné n'existe pas dans la base.");
            }

        }

        private void purgebutton_Click(object sender, EventArgs e)
        {
            try
            {
                ABONNÉS a = (ABONNÉS)listBoxGlobale.SelectedItem;
                purgerAbonné(a.CODE_ABONNÉ);
                purgebutton.Enabled = false;
                abonnésAPurger();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + Environment.NewLine + "Annulation.");
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            purgebutton.Enabled = true;
        }

        /**
         * retourne l'ensemble des albums dont la dernière date d'emprunt remonte à plus d'un an (ou n'a jamais été emprunté)
         */
        public HashSet<ALBUMS> albumPasEmpruntesDepuis1An()
        {
            HashSet<ALBUMS> albumPasEmprunter1An = new HashSet<ALBUMS>();
            var albumsJamaisEmpruntés = (from a in musiqueSQL.ALBUMS select a).ToList().Except(from e in musiqueSQL.EMPRUNTER select e.ALBUMS).ToList();
            albumsJamaisEmpruntés.ForEach(a => albumPasEmprunter1An.Add(a));
            DateTime dateactuelle = DateTime.UtcNow.AddYears(-1);
            var dates = from e in musiqueSQL.EMPRUNTER group e by e.CODE_ALBUM into newGroup select new { newGroup.Key, derniereDate = newGroup.Max(d => d.DATE_EMPRUNT) };
            foreach (var kv in dates)
            {
                if (DateTime.UtcNow.AddYears(-1).CompareTo(kv.derniereDate) > 0)
                {
                    albumPasEmprunter1An.Add((from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == kv.Key select a).First());
                }
            }
            return albumPasEmprunter1An;
        }

        /*
         * Liste les abonnés
         */
        private void listerAbonnés()
        {
            var abonnés = from a in musiqueSQL.ABONNÉS orderby a.NOM_ABONNÉ select a;
            foreach (ABONNÉS a in abonnés)
            {
                listBoxAbonnés.Items.Add(a);
            }
        }

        private void changerMdp()
        {
            ABONNÉS a = (ABONNÉS)listBoxAbonnés.SelectedItem;
            ChangerMdp changementMdp = new ChangerMdp((from abo in musiqueSQL.ABONNÉS where abo.LOGIN_ABONNÉ == logAdmin select abo).First());
            if (changementMdp.ShowDialog() == DialogResult.OK)
            {
                a.PASSWORD_ABONNÉ = changementMdp.nouveauMdp;
                musiqueSQL.SaveChanges();
            }
        }

        /// <summary>
        /// Affiche le nombre d'album emprunte par titre d'album 
        /// </summary>
        /// <param album></param> 
        private int nombreEmprunt(ALBUMS album)
        {
            DateTime date = DateTime.UtcNow.AddYears(-1);
            var q = (from e in musiqueSQL.EMPRUNTER
                     join a in musiqueSQL.ALBUMS on e.CODE_ALBUM equals a.CODE_ALBUM
                     where e.DATE_EMPRUNT > date && e.CODE_ALBUM == album.CODE_ALBUM
                     select e.DATE_EMPRUNT);
            int i = q.Count();
            return i;
        }

        /// <summary>
        /// Vide et remplit la listeboxglobale avec les 10 albums les plus populaires
        /// </summary>
        private void remplir10pluspopulaires()
        {
            listBoxGlobale.Items.Clear();
            foreach (ALBUMS i in DixPlusVue())
            {
                listBoxGlobale.Items.Add(i.ToString() + nombreEmprunt(i));
            }
        }
        /// <summary>
        /// Vide et remplit la listeboxglobale avec les albums non empruntés depuis 1 an.
        /// </summary>
        private void remplirAlbumsPasEmpruntes1An()
        {
            listBoxGlobale.Items.Clear();
            foreach (ALBUMS i in albumPasEmpruntesDepuis1An())
            {
                listBoxGlobale.Items.Add(i);
            }
        }

        /// <summary>
        /// Insère dans une liste l'ensemble des allées disponibles
        /// </summary>
        private void listerAllées()
        {
            listBoxAllée.Items.Clear();
            var allees = from a in musiqueSQL.ALBUMS group a by a.ALLÉE_ALBUM into intAllees orderby intAllees.Key select intAllees.Key;
            foreach (string s in allees)
            {
                listBoxAllée.Items.Add(s.Trim());
            }
        }

        /// <summary>
        /// Rend invisible l'ensemble des éléments liés à l'allée et au casier des disques.
        /// </summary>
        public void desactiverCasier()
        {
            listBoxAllée.Visible = false;
            listBoxCasier.Visible = false;
            labelAllée.Visible = false;
            labelCasier.Visible = false;
            buttonCasier.Visible = false;
        }

        private void Pluspopulairebutton_Click(object sender, EventArgs e)
        {
            remplir10pluspopulaires();
            purgeModeOn = false;
            Refresh();
            desactiverCasier();
            purgebutton.Enabled = false;
        }

        private void moinsPopulaireButton_Click(object sender, EventArgs e)
        {
            remplirAlbumsPasEmpruntes1An();
            purgeModeOn = false;
            Refresh();
            desactiverCasier();
            purgebutton.Enabled = false;
        }

        private void purgerModeButton_Click(object sender, EventArgs e)
        {
            abonnésAPurger();
            purgeModeOn = true;
            Refresh();

        }

        private void listBoxGlobale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (purgeModeOn)
            {
                purgebutton.Enabled = true;
            }
        }

        private void enRetardButton_Click(object sender, EventArgs e)
        {
            enRetard();
            purgeModeOn = false;
            purgebutton.Enabled = false;
            desactiverCasier();
            Refresh();
        }

        private void prolongesButton_Click(object sender, EventArgs e)
        {
            LivreEmprunteProlongé();
            purgeModeOn = false;
            purgebutton.Enabled = false;
            desactiverCasier();
            Refresh();
        }

        private void listeAbonnés_Click(object sender, EventArgs e)
        {
            listeabonneVisible = !listeabonneVisible;
            listBoxAbonnés.Visible = listeabonneVisible;
            Refresh();
        }

        private void buttonChangerMdp_Click(object sender, EventArgs e)
        {
            changerMdp();
        }

        private void listBoxAbonnés_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonChangerMdp.Enabled = true;
        }

        private void listBoxCasier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCasier.SelectedItem != null)
            {
                buttonCasier.Visible = true;
            }
            else
            {
                buttonCasier.Visible = false;
            }
        }

        private void buttonAllée_Click(object sender, EventArgs e)
        {
            listerAllées();
            listBoxAllée.Visible = true;
            labelAllée.Visible = true;
        }

        private void listBoxAllée_SelectedIndexChanged(object sender, EventArgs e)
        {
            var allée = listBoxAllée.SelectedItem;
            if (allée != null)
            {
                listBoxCasier.Visible = true;
                labelCasier.Visible = true;
                listBoxCasier.Items.Clear();
                var casiers = from a in musiqueSQL.ALBUMS where a.ALLÉE_ALBUM == allée.ToString() group a by a.CASIER_ALBUM into casier select casier.Key;
                foreach (int i in casiers)
                {
                    listBoxCasier.Items.Add(i);
                }
            } else
            {
                buttonCasier.Visible = false;
            }
        }

        private void buttonCasier_Click(object sender, EventArgs e)
        {
            listBoxGlobale.Items.Clear();
            int numCasier = Convert.ToInt32(listBoxCasier.SelectedItem);
            string allée = listBoxAllée.SelectedItem.ToString();
            var albums = from a in musiqueSQL.ALBUMS
                         join emp in musiqueSQL.EMPRUNTER on a.CODE_ALBUM equals emp.CODE_ALBUM
                         where a.ALLÉE_ALBUM == allée && a.CASIER_ALBUM == numCasier && emp.DATE_RETOUR == null
                         select a;
            foreach (ALBUMS a in albums)
            {
                if (!listBoxGlobale.Items.Contains(a))
                {
                    listBoxGlobale.Items.Add(a);
                }
            }
        }
    }
}
