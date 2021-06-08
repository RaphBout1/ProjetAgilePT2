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
    class US5
    {

        [TestMethod]
        public void TestMethod1()
        {
            Admin a = new Admin();
            MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
            List<ABONNÉS> enretardtest = a.enRetard();
            var Abo1 = from l in musiqueSQL.ABONNÉS select l;
            Assert.IsTrue(enretardtest.Contains(Abo1.First()));

        }
    }
}
