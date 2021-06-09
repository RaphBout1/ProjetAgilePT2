﻿using System;
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
        private HashSet<ALBUMS> albumsUS8 = new HashSet<ALBUMS>();

        public Admin()
        {
            InitializeComponent();
            enRetard();
            LivreEmprunteProlongé();
            abonnésAPurger();
            listerAbonnés();
            albumsUS8 = albumPasEmpruntesDepuis1An();
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
                        compteurBoucle++;
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
                        compteurBoucle--;
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
            listBox3.Items.Clear();
            abonnésPurgeables.Clear();
            DateTime dateactuelle = DateTime.UtcNow.AddYears(-1);
            var dates = from e in musiqueSQL.EMPRUNTER group e by e.CODE_ABONNÉ into newGroup select new { newGroup.Key, derniereDate = newGroup.Max(d => d.DATE_EMPRUNT) };
            foreach (var kv in dates)
            {
                if (DateTime.UtcNow.AddYears(-1).CompareTo(kv.derniereDate) > 0)
                {
                    ABONNÉS aPurger = (from ab in musiqueSQL.ABONNÉS where ab.CODE_ABONNÉ == kv.Key select ab).First();
                    abonnésPurgeables.Add(aPurger);
                    listBox3.Items.Add(aPurger);
                }
            }
            Refresh();
        }

        public void purgerAbonné(int codeAbonné)
        {
            var query = from l in musiqueSQL.ABONNÉS where l.CODE_ABONNÉ == codeAbonné select l;
            ABONNÉS x = query.First();
            musiqueSQL.ABONNÉS.Remove(x);
            musiqueSQL.SaveChanges();
            abonnésAPurger();
        }

        /**
         * retourne l'ensemble des albums dont la dernière date d'emprunt remonte à plus d'un an
         */
        public HashSet<ALBUMS> albumPasEmpruntesDepuis1An()
        {
            HashSet<ALBUMS> albumPasEmprunter1An = new HashSet<ALBUMS>();
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
            foreach(ABONNÉS a in abonnés)
            {
                listBoxAbonnés.Items.Add(a.NOM_ABONNÉ + a.PRÉNOM_ABONNÉ);
            }
        }

        private void purgebutton_Click(object sender, EventArgs e)
        {
            ABONNÉS a = (ABONNÉS)listBox3.SelectedItem;
            purgerAbonné(a.CODE_ABONNÉ);
            purgebutton.Enabled = false;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            purgebutton.Enabled = true;
        }
    }
}
