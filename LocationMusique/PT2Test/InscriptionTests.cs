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
    public class InscriptionTests
    {
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        Admin admin = new Admin();
        private string testLogin = "testInscription";
        [TestMethod]

        /**
         * Test si une inscription dans la base de donnée d'un abonné qui n'existe pas encore dans cette base et avec des attributs valides fonctionne
         */
        public void TestInscriptionLambda()
        {
            var aDb = (from ab in musiqueSQL.ABONNÉS where ab.LOGIN_ABONNÉ == testLogin select ab).FirstOrDefault();
            if (aDb != null)
            {
                admin.purgerAbonné(aDb.CODE_ABONNÉ);
                musiqueSQL.SaveChanges();
            }
            aDb = (from ab in musiqueSQL.ABONNÉS where ab.LOGIN_ABONNÉ == testLogin select ab).FirstOrDefault();
            Assert.IsTrue(aDb == null);
            Inscription.abonner("test", "test", "France", testLogin, "test", "test");
            musiqueSQL.SaveChanges();
            aDb = (from ab in musiqueSQL.ABONNÉS where ab.LOGIN_ABONNÉ == testLogin select ab).FirstOrDefault();
            Assert.IsFalse(aDb == null);
        }

        /**
         * Vérifie qu'une inscription à partir d'un login déjà existant retourne une exception
         */
        [TestMethod]
        [ExpectedException(typeof(InformationsInvalidesException))]
        public void TestInscriptionMemeLogin()
        {
            var aDb = (from ab in musiqueSQL.ABONNÉS where ab.LOGIN_ABONNÉ == testLogin select ab).FirstOrDefault();
            if (aDb == null)
            {
                Inscription.abonner("test", "test", "France", testLogin, "test", "test");
                musiqueSQL.SaveChanges();
            }
            Inscription.abonner("test", "test", "France", testLogin, "test", "test");
            musiqueSQL.SaveChanges();
        }

        /**
         * Vérifie qu'une inscription avec un nom vide retourne une exception
         */
        [TestMethod]
        [ExpectedException(typeof(InformationsInvalidesException))]
        public void TestInscriptionNomVide()
        {
            var aDb = (from ab in musiqueSQL.ABONNÉS where ab.LOGIN_ABONNÉ == testLogin select ab).FirstOrDefault();
            if (aDb != null)
            {
                admin.purgerAbonné(aDb.CODE_ABONNÉ);
                musiqueSQL.SaveChanges();
            }
            Inscription.abonner("", "test", "France", testLogin, "test", "test");
            musiqueSQL.SaveChanges();
        }

        /**
         * Vérifie qu'une inscription avec un prenom vide retourne une exception
         */
        [TestMethod]
        [ExpectedException(typeof(InformationsInvalidesException))]
        public void TestInscriptionPrenomVide()
        {
            var aDb = (from ab in musiqueSQL.ABONNÉS where ab.LOGIN_ABONNÉ == testLogin select ab).FirstOrDefault();
            if (aDb != null)
            {
                admin.purgerAbonné(aDb.CODE_ABONNÉ);
                musiqueSQL.SaveChanges();
            }
            Inscription.abonner("test", "", "France", testLogin, "test", "test");
            musiqueSQL.SaveChanges();
        }

        /**
         * Vérifie qu'une inscription avec un pays que la base de donnée ne connait pas retourne une exception
         */
        [TestMethod]
        [ExpectedException(typeof(InformationsInvalidesException))]
        public void TestInscriptionPaysInvalide()
        {
            var aDb = (from ab in musiqueSQL.ABONNÉS where ab.LOGIN_ABONNÉ == testLogin select ab).FirstOrDefault();
            if (aDb != null)
            {
                admin.purgerAbonné(aDb.CODE_ABONNÉ);
                musiqueSQL.SaveChanges();
            }
            Inscription.abonner("test", "test", "PaysInvalide", testLogin, "test", "test");
            musiqueSQL.SaveChanges();
        }
    }
}
