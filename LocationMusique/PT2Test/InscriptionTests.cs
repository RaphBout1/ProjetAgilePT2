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
        [TestMethod]
        public void TestMethod1()
        {
            MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
            Admin admin = new Admin();
            string login = "test";
            var aDb = (from ab in musiqueSQL.ABONNÉS where ab.LOGIN_ABONNÉ == login select ab).FirstOrDefault();
            if (aDb != null)
            {
                admin.purgerAbonné(aDb.CODE_ABONNÉ);
                musiqueSQL.SaveChanges();
            }
            aDb = (from ab in musiqueSQL.ABONNÉS where ab.LOGIN_ABONNÉ == login select ab).FirstOrDefault();
            Assert.IsTrue(aDb == null);
            Inscription.abonner("test", "test", "France", "test", "test");
            musiqueSQL.SaveChanges();
            aDb = (from ab in musiqueSQL.ABONNÉS where ab.LOGIN_ABONNÉ == login select ab).FirstOrDefault();
            Assert.IsFalse(aDb == null);
        }
    }
}
