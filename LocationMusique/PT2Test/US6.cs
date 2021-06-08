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
        [TestMethod]
        public void AbonnéBienPurgé()
        {
            MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
            Admin a = new Admin();
            Inscription j = new Inscription();
            
            j.abonner("purgeman","purge","France","purge2","purge2");
            ABONNÉS uti = (from b in musiqueSQL.ABONNÉS where b.LOGIN_ABONNÉ == "purge2" select b).First();
            UtilisateurUSEmprunt u = new UtilisateurUSEmprunt(uti);
            u.creerEmprunt(uti.CODE_ABONNÉ,65,DateTime.Today.AddYears(-10), DateTime.Today.AddYears(-10).AddDays(10));
            
        }
    }
}
