using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PT2;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PT2Test
{
    [TestClass]
    public class inscriptionTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ABONNÉS a = new ABONNÉS
            {
                CODE_PAYS = 1,
                LOGIN_ABONNÉ = "test",
                NOM_ABONNÉ = "test",
                PRÉNOM_ABONNÉ = "test",
                PASSWORD_ABONNÉ = "test"
            };
            var aDb = (from ab in Inscription.musiqueSQL.ABONNÉS where ab.LOGIN_ABONNÉ == a.LOGIN_ABONNÉ select ab).FirstOrDefault();
            if (aDb != null)
            {
                Inscription.musiqueSQL.ABONNÉS.Remove(aDb);
            }
            Assert.IsFalse(Inscription.musiqueSQL.ABONNÉS.Contains(aDb));
            Inscription.abonner("test", "test", "France", "test", "test");
            Assert.IsTrue(Inscription.musiqueSQL.ABONNÉS.Contains(aDb));
        }
    }
}
