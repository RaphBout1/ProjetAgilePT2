using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PT2;

namespace PT2Test
{
    [TestClass]
    public class US7
    {
        MusiquePT2_DEntities TestSQL = new MusiquePT2_DEntities();
        private List<ABONNÉS> listeAbonneTest = new List<ABONNÉS>();
        private List<ALBUMS> listeAlbums = new List<ALBUMS>();

        #region import 10 album
        /// <summary>
        /// Charge 10 albums pour le test
        /// </summary>
        private void InitAlbum()
        {
            for (int nmbAlbum = 0; nmbAlbum < 5; nmbAlbum++)
            {
                var dixAlbum = from a in TestSQL.ALBUMS
                               where a.CODE_ALBUM == (nmbAlbum + 75)
                               select a;
                foreach (ALBUMS a in dixAlbum)
                {
                    listeAlbums.Add(a);
                }
            }

        }
        #endregion
        #region initialise un emprunt massif d'album
        /// <summary>
        /// Permet de récupérer les 75 abonnées test
        /// </summary>
        private void InitListeAbonneTest()
        {
            var abonne = from a in TestSQL.ABONNÉS
                         where a.NOM_ABONNÉ.Contains("Test | ")
                         select a;
            foreach (ABONNÉS a in abonne)
            {
                listeAbonneTest.Add(a);
            }
        }
        /// <summary>
        /// Initialise 75 abonné dans la base de donnée
        /// </summary>
        private void InitAbonneEmprunteur()
        {
            for(int nmbAbo=0; nmbAbo<75; nmbAbo++)
            {
                ABONNÉS abo = new ABONNÉS();
                abo.CODE_PAYS = 1;
                abo.NOM_ABONNÉ = "Test | " + nmbAbo;
                abo.PRÉNOM_ABONNÉ = "Test | " + nmbAbo;
                abo.LOGIN_ABONNÉ = "Test | " + nmbAbo;
                abo.PASSWORD_ABONNÉ = "Test | " + nmbAbo;
                TestSQL.ABONNÉS.Add(abo);
            }
            TestSQL.SaveChanges();
            InitListeAbonneTest();
        }
        
        private void EmpruntMassifAlbum()
        {
            InitListeAbonneTest();
            //InitAbonneEmprunteur();
            for(int nmbEmprunt=74; nmbEmprunt>-1; nmbEmprunt--)
            {
                #region 1er emprunt
                EMPRUNTER emprunt1 = new EMPRUNTER();
                emprunt1.CODE_ABONNÉ = listeAbonneTest[nmbEmprunt].CODE_ABONNÉ;
                emprunt1.CODE_ALBUM = listeAlbums[0].CODE_ALBUM;
                emprunt1.DATE_EMPRUNT = DateTime.UtcNow.AddYears(nmbEmprunt);
                emprunt1.DATE_RETOUR_ATTENDUE = emprunt1.DATE_EMPRUNT.AddDays(listeAlbums[0].GENRES.DÉLAI);
                emprunt1.DATE_RETOUR = emprunt1.DATE_RETOUR_ATTENDUE;
                #endregion
                #region 2nd emprunt
                if (nmbEmprunt < 60)
                {
                    EMPRUNTER emprunt2 = new EMPRUNTER();
                    emprunt2.CODE_ABONNÉ = listeAbonneTest[nmbEmprunt].CODE_ABONNÉ;
                    emprunt2.CODE_ALBUM = listeAlbums[1].CODE_ALBUM;
                    emprunt2.DATE_EMPRUNT = DateTime.UtcNow.AddYears(nmbEmprunt);
                    emprunt2.DATE_RETOUR_ATTENDUE = emprunt2.DATE_EMPRUNT.AddDays(listeAlbums[1].GENRES.DÉLAI);
                    emprunt2.DATE_RETOUR = emprunt2.DATE_RETOUR_ATTENDUE;
                }
                #endregion
                #region 3eme emprunt
                if (nmbEmprunt < 50)
                {
                    EMPRUNTER emprunt3 = new EMPRUNTER();
                    emprunt3.CODE_ABONNÉ = listeAbonneTest[nmbEmprunt].CODE_ABONNÉ;
                    emprunt3.CODE_ALBUM = listeAlbums[2].CODE_ALBUM;
                    emprunt3.DATE_EMPRUNT = DateTime.UtcNow.AddYears(nmbEmprunt);
                    emprunt3.DATE_RETOUR_ATTENDUE = emprunt3.DATE_EMPRUNT.AddDays(listeAlbums[2].GENRES.DÉLAI);
                    emprunt3.DATE_RETOUR = emprunt3.DATE_RETOUR_ATTENDUE;
                }
                #endregion
                #region 4eme emprunt
                if (nmbEmprunt < 40)
                {
                    EMPRUNTER emprunt4 = new EMPRUNTER();
                    emprunt4.CODE_ABONNÉ = listeAbonneTest[nmbEmprunt].CODE_ABONNÉ;
                    emprunt4.CODE_ALBUM = listeAlbums[3].CODE_ALBUM;
                    emprunt4.DATE_EMPRUNT = DateTime.UtcNow.AddYears(nmbEmprunt);
                    emprunt4.DATE_RETOUR_ATTENDUE = emprunt4.DATE_EMPRUNT.AddDays(listeAlbums[3].GENRES.DÉLAI);
                    emprunt4.DATE_RETOUR = emprunt4.DATE_RETOUR_ATTENDUE;
                }
                #endregion
                #region 5eme emprunt
                if (nmbEmprunt < 30)
                {
                    EMPRUNTER emprunt5 = new EMPRUNTER();
                    emprunt5.CODE_ABONNÉ = listeAbonneTest[nmbEmprunt].CODE_ABONNÉ;
                    emprunt5.CODE_ALBUM = listeAlbums[4].CODE_ALBUM;
                    emprunt5.DATE_EMPRUNT = DateTime.UtcNow.AddYears(nmbEmprunt);
                    emprunt5.DATE_RETOUR_ATTENDUE = emprunt5.DATE_EMPRUNT.AddDays(listeAlbums[4].GENRES.DÉLAI);
                    emprunt5.DATE_RETOUR = emprunt5.DATE_RETOUR_ATTENDUE;
                }
                #endregion
            }
        }
        #endregion

        #region Test de fonctionnalité
        [TestMethod]
        public void test10PlusEmprunte()
        {
            InitAlbum();
            EmpruntMassifAlbum();
            Admin admin = new Admin();
            List<ALBUMS> listeATester = admin.DixPlusVue();
            Assert.AreEqual(listeAlbums[0], listeATester[0]);
            Assert.AreEqual(listeAlbums[1], listeATester[1]);
            Assert.AreEqual(listeAlbums[2], listeATester[2]);
            Assert.AreEqual(listeAlbums[3], listeATester[3]);
            Assert.AreEqual(listeAlbums[4], listeATester[4]);

        }

        #endregion
    }
}
