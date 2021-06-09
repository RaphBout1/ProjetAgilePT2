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
    public class US5
    {

        /// <summary>
        /// Test par une méthode sûre que la liste d'abo en retard est bien la bonne
        /// </summary>
        [TestMethod]
        public void TestAboVraimentEnRetard()
        {
            Admin a = new Admin();
            MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
            List<ABONNÉS> enretardtest = a.enRetard();
            var Abo1 = from l in musiqueSQL.ABONNÉS select l;
            List<ABONNÉS> enretardfixe = new List<ABONNÉS>();
            foreach(ABONNÉS i in Abo1)
            {
                foreach(EMPRUNTER l in i.EMPRUNTER)
                {
                    if(l.DATE_RETOUR == null && DateTime.Today.CompareTo(l.DATE_RETOUR_ATTENDUE.AddDays(10)) > 0)
                    {
                        enretardfixe.Add(i);
                        
                    }
                }
            }
            foreach(ABONNÉS i in enretardfixe)
            {
                Assert.IsTrue(enretardtest.Contains(i));
                Console.WriteLine(i);
            }
        }
        /// <summary>
        /// Test si la liste renvoyer par le programme de membres en retards et la liste de la base des membres en retards contiennent le même nombre d'élements.
        /// </summary>
        [TestMethod]
        public void TestAboPasEnRetard()
        {

            Admin a = new Admin();
            MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
            List<ABONNÉS> enretardtest = a.enRetard();
            var Abo1 = from l in musiqueSQL.ABONNÉS select l;
            List<ABONNÉS> enretardfixe = new List<ABONNÉS>();
            foreach (ABONNÉS i in Abo1)
            {
                foreach (EMPRUNTER l in i.EMPRUNTER)
                {
                    if (l.DATE_RETOUR == null && DateTime.Today.CompareTo(l.DATE_RETOUR_ATTENDUE.AddDays(10)) > 0)
                    {
                        enretardfixe.Add(i);
                        
                    }
                }
            }
            int Nombredabopasenretard = Abo1.Count() - enretardtest.Count();
            int Nombredabopasenretardtheo = Abo1.Count() - enretardfixe.Count();
            Assert.AreEqual(Nombredabopasenretardtheo, Nombredabopasenretard);
        }
    }
}
