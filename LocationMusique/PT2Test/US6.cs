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
    public class US6
    {
        /// <summary>
        /// Créer un abonné, lui ajoute un emprunt datant d'un an puis le purge pour tester cette opération
        /// </summary>
        [TestMethod]
        public void AbonnéBienPurgé()
        {
            MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
            Admin a = new Admin();
            Inscription.abonner("purgeman","purge","France","purge4","purge2","purge2");
            ABONNÉS uti = (from b in musiqueSQL.ABONNÉS where b.LOGIN_ABONNÉ == "purge4" select b).First();
            UtilisateurUSEmprunt u = new UtilisateurUSEmprunt(uti);
            US14Rendre rendre = new US14Rendre(uti);
            u.creerEmprunt(uti.CODE_ABONNÉ,65,DateTime.Today.AddYears(-10), DateTime.Today.AddYears(-10).AddDays(10));
            EMPRUNTER emprunt = (from g in musiqueSQL.EMPRUNTER where g.CODE_ABONNÉ == uti.CODE_ABONNÉ select g).First();
            musiqueSQL.SaveChanges();
            rendre.rendreEmprunt(emprunt);
            a.purgerAbonné(uti.CODE_ABONNÉ);
            var verifempruntsuprr = from j in musiqueSQL.EMPRUNTER where j.CODE_ABONNÉ == uti.CODE_ABONNÉ && j.CODE_ALBUM == 65 select j;
            Assert.AreEqual(0, verifempruntsuprr.Count());
            var verifabosuppr = from h in musiqueSQL.ABONNÉS where h.CODE_ABONNÉ == uti.CODE_ABONNÉ select h;
            Assert.AreEqual(0, verifabosuppr.Count());
        }
    }
}
