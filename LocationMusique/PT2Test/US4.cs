using System;
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
    public class US4
    {
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        public ABONNÉS abonné1;
        public ABONNÉS abonné2;
        public Admin user;
        public UtilisateurUSEmprunt emprunter1;
        public UtilisateurUSEmprunt emprunter2;
        public ALBUMS album1;
        public ALBUMS album2;
        public EMPRUNTER emprunt1;
        public EMPRUNTER emprunt2;
        public EMPRUNTER emprunt3;
        public EMPRUNTER emprunt4;
        public List<EMPRUNTER> listeAlbumsNonEmpruntés;
        

        /*
         * Test de l'US4, test 2 emprunts, l'un prologé et l'autre non
         */
        public void initTest()
        {

            emprunter1.creerEmprunt(abonné1.CODE_ABONNÉ, album1.CODE_ALBUM, DateTime.Parse("10/6/2019 8:30:15 AM"), DateTime.Parse("10/6/2019 8:30:15 AM").AddMonths(1).AddDays(album1.GENRES.DÉLAI));
            emprunter2.creerEmprunt(abonné2.CODE_ABONNÉ, album2.CODE_ALBUM, DateTime.Parse("10/6/2019 8:30:15 AM"), DateTime.Parse("10/6/2019 8:30:15 AM").AddDays(album2.GENRES.DÉLAI));
            emprunt1 = (from e in musiqueSQL.EMPRUNTER where e.CODE_ABONNÉ == abonné1.CODE_ABONNÉ && e.CODE_ALBUM == album1.CODE_ALBUM select e).First();
            emprunt2 = (from e in musiqueSQL.EMPRUNTER where e.CODE_ABONNÉ == abonné2.CODE_ABONNÉ && e.CODE_ALBUM == album2.CODE_ALBUM select e).First();

        }

        [TestMethod]
        public void testAlbumsNonEmpruntés()
        {
            initaliserVariables();
            initTest();
            List<EMPRUNTER> albumPasEmprunter1An = user.LivreEmprunteProlongé();
            musiqueSQL.SaveChanges();
            Assert.IsTrue(albumPasEmprunter1An.Contains(emprunt1));
            Assert.IsFalse(albumPasEmprunter1An.Contains(emprunt2));

        }

        public void initaliserVariables()
        {
            abonné1 = (from a in musiqueSQL.ABONNÉS where a.CODE_ABONNÉ == 6 select a).FirstOrDefault();
            abonné2 = (from a in musiqueSQL.ABONNÉS where a.CODE_ABONNÉ == 7 select a).FirstOrDefault();
            user = new Admin();
            emprunter1 = new UtilisateurUSEmprunt(abonné1);
            emprunter2 = new UtilisateurUSEmprunt(abonné2);

            album1 = (from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == 702 select a).FirstOrDefault();
            album2 = (from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == 703 select a).FirstOrDefault();
        }
    }
}