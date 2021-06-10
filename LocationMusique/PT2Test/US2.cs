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
    public class US2
    {
        MusiquePT2_DEntities TestSQL = new MusiquePT2_DEntities();
        ABONNÉS abonneTest;
        EMPRUNTER empruntTest;
        EMPRUNTER empruntTest2;
        EMPRUNTER empruntTest3;
        Utilisateur utilisateur;


        #region init Sans Implémenter base
        /// <summary>
        /// Initialise les attribut en cherchant les éléments directement dans la base
        /// </summary>
        private void initTotal()
        {
            var abonne = from a in TestSQL.ABONNÉS
                         where a.LOGIN_ABONNÉ == "Test"
                            && a.NOM_ABONNÉ == "Test"
                            && a.PRÉNOM_ABONNÉ == "Test"
                         select a;
            foreach (ABONNÉS a in abonne)
            {
                abonneTest = a;
            }
            utilisateur = new Utilisateur(abonneTest);


            /*var emprunt = from e in TestSQL.EMPRUNTER
                          where e.CODE_ABONNÉ == abonneTest.CODE_ABONNÉ
                             && e.CODE_ALBUM == 500
                          select e;
            foreach (EMPRUNTER e in emprunt)
            {
                empruntTest = e;
            }
            emprunt = from e in TestSQL.EMPRUNTER
                      where e.CODE_ABONNÉ == abonneTest.CODE_ABONNÉ
                         && e.CODE_ALBUM == 480
                      select e;
            foreach (EMPRUNTER e in emprunt)
            {
                empruntTest2 = e;
            }
            emprunt = from e in TestSQL.EMPRUNTER
                      where e.CODE_ABONNÉ == abonneTest.CODE_ABONNÉ
                         && e.CODE_ALBUM == 514
                      select e;
            foreach (EMPRUNTER e in emprunt)
            {
                empruntTest3 = e;
            }*/
        }
        #endregion

        #region initialisation des attribut
        /// <summary>
        /// Initialise un abonné et l'implente dans la base de donnée
        /// A utiliser si l'abonné test a été supprimé
        /// </summary>
        private void initAboTest()
        {
            abonneTest = new ABONNÉS();
            abonneTest.CODE_PAYS = 1;
            abonneTest.LOGIN_ABONNÉ = "Test";
            abonneTest.PASSWORD_ABONNÉ = "Test";
            abonneTest.PRÉNOM_ABONNÉ = "Test";
            abonneTest.NOM_ABONNÉ = "Test";
            TestSQL.ABONNÉS.Add(abonneTest);
            
            var abonne = from a in TestSQL.ABONNÉS
                         where a.LOGIN_ABONNÉ == "Test" 
                            && a.NOM_ABONNÉ == "Test" 
                            && a.PRÉNOM_ABONNÉ == "Test"
                         select a;
            foreach(ABONNÉS a in abonne)
            {
                abonneTest = a;
            }
            utilisateur = new Utilisateur(abonneTest);
        }
        /// <summary>
        /// Initialise trois emprunts de la part de l'abonné test
        /// A utiliser si les emprunts ont été supprimé
        /// </summary>
        private void initEmprunt()
        {
            empruntTest = new EMPRUNTER();
            empruntTest.CODE_ABONNÉ = abonneTest.CODE_ABONNÉ;
            empruntTest.CODE_ALBUM = 500;
            empruntTest.DATE_EMPRUNT = DateTime.UtcNow;
            empruntTest.DATE_RETOUR_ATTENDUE = empruntTest.DATE_EMPRUNT.AddDays(15);
            TestSQL.EMPRUNTER.Add(empruntTest);
            var emprunt = from e in TestSQL.EMPRUNTER
                         where e.CODE_ABONNÉ == abonneTest.CODE_ABONNÉ
                            && e.CODE_ALBUM == 500
                         select e;
            foreach (EMPRUNTER e in emprunt)
            {
                empruntTest = e;
            }

            empruntTest2 = new EMPRUNTER();
            empruntTest2.CODE_ABONNÉ = abonneTest.CODE_ABONNÉ;
            empruntTest2.CODE_ALBUM = 480;
            empruntTest2.DATE_EMPRUNT = DateTime.UtcNow;
            empruntTest2.DATE_RETOUR_ATTENDUE = empruntTest.DATE_EMPRUNT.AddDays(15);
            TestSQL.EMPRUNTER.Add(empruntTest2);
            emprunt = from e in TestSQL.EMPRUNTER
                          where e.CODE_ABONNÉ == abonneTest.CODE_ABONNÉ
                             && e.CODE_ALBUM == 480
                          select e;
            foreach (EMPRUNTER e in emprunt)
            {
                empruntTest2 = e;
            }

            empruntTest3 = new EMPRUNTER();
            empruntTest3.CODE_ABONNÉ = abonneTest.CODE_ABONNÉ;
            empruntTest3.CODE_ALBUM = 514;
            empruntTest3.DATE_EMPRUNT = DateTime.UtcNow;
            empruntTest3.DATE_RETOUR_ATTENDUE = empruntTest.DATE_EMPRUNT.AddDays(15);
            TestSQL.EMPRUNTER.Add(empruntTest3);
            emprunt = from e in TestSQL.EMPRUNTER
                          where e.CODE_ABONNÉ == abonneTest.CODE_ABONNÉ
                             && e.CODE_ALBUM == 514
                          select e;
            foreach (EMPRUNTER e in emprunt)
            {
                empruntTest3 = e;
            }
            TestSQL.SaveChanges();
        }
        #endregion

        #region Test
        /// <summary>
        /// Teste la fonctionnalité de la méthode ActualiseListeEmprunté()
        /// </summary>
        [TestMethod]
        public void TestActualiseListeEmprunté()
        {
            //initTotal();
            initAboTest();
            initEmprunt();            
            int empruntATrouver = 3;
            Assert.AreEqual(empruntATrouver, utilisateur.NouveauxEmprunts().Count);
            //nettoyageBase();
        }
        #endregion

        #region nettoyage de la base
        /// <summary>
        /// Permet de nettoyer la base
        /// </summary>
        private void nettoyageBase()
        {
            if (TestSQL.EMPRUNTER.Equals(empruntTest)) 
            { 
                TestSQL.EMPRUNTER.Remove(empruntTest); 
            }
            if (TestSQL.EMPRUNTER.Equals(empruntTest2)) { TestSQL.EMPRUNTER.Remove(empruntTest2); }
            if (TestSQL.EMPRUNTER.Equals(empruntTest3)) { TestSQL.EMPRUNTER.Remove(empruntTest3); }
            if (TestSQL.ABONNÉS.Equals(abonneTest)) { TestSQL.ABONNÉS.Remove(abonneTest); }
            TestSQL.SaveChanges();
        }
        #endregion
    }
}
