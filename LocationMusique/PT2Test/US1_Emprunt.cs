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
    public class US1_Emprunt
    {
        UtilisateurUSEmprunt utilisateurEmpruntTest;
        ABONNÉS abonneTest;
        ALBUMS albumTest;
        MusiquePT2_DEntities testSQL = new MusiquePT2_DEntities();

        /// <summary>
        /// Test de l'US1, on crée un abonné, on lui fait faire un emprunt et on vérifie que celui-ci a bien été enregistré.
        /// </summary>
        [TestMethod]
        public void testEmprunt()
        {
            InitialisationGlobale();
            utilisateurEmpruntTest.creerEmprunt(abonneTest.CODE_ABONNÉ, albumTest.CODE_ALBUM, DateTime.UtcNow, DateTime.UtcNow.AddDays(albumTest.GENRES.DÉLAI));
            Assert.AreEqual(true, RetrouveEmprunt());
        }

        
        #region Initialisation
        /// <summary>
        /// initialise l'abonné crée et un emprunt d'un album pour celui-ci.
        /// </summary>
        private void InitialisationGlobale()
        {
            ImportAbonne();
            ImportAlbum();
        }
        #region abonné
        private void InitialiseAbonne()
        {
            abonneTest = new ABONNÉS();
            abonneTest.NOM_ABONNÉ = "Test | US1_Emprunt";
            abonneTest.PRÉNOM_ABONNÉ = "Test | US1_Emprunt";
            abonneTest.LOGIN_ABONNÉ = "Test | US1_Emprunt";
            abonneTest.PASSWORD_ABONNÉ = "Test | US1_Emprunt";
            abonneTest.CODE_PAYS = 1;
            testSQL.ABONNÉS.Add(abonneTest);
            testSQL.SaveChanges();
        }
        private void ImportAbonne()
        {
            var abonne = from a in testSQL.ABONNÉS
                         where a.PRÉNOM_ABONNÉ == "Test | US1_Emprunt"
                         && a.LOGIN_ABONNÉ == "Test | US1_Emprunt"
                         select a;
            foreach (ABONNÉS a in abonne) { abonneTest = a; }
            utilisateurEmpruntTest = new UtilisateurUSEmprunt(abonneTest);
        }
        #endregion

        #region Album
        private void ImportAlbum()
        {
            var album = from a in testSQL.ALBUMS
                        where a.CODE_ALBUM == 500
                        select a;
            foreach (ALBUMS a in album) { albumTest = a; }
        }
        #endregion
        #endregion

        /// <summary>
        /// Cherche l'emprunt crée par le test dans la base de données.
        /// </summary>
        /// <returns>true si l'emprunt existe bien, false sinon.</returns>
        private bool RetrouveEmprunt()
        {
            var emprunt = from e in testSQL.EMPRUNTER
                          where e.CODE_ABONNÉ == abonneTest.CODE_ABONNÉ
                          && e.CODE_ALBUM == albumTest.CODE_ALBUM
                          select e;
            foreach (EMPRUNTER e in emprunt) { if (e != null) { return true; } }
            return false;
        }
    }
}
