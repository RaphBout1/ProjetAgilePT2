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
    public class US8
    {
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        public ABONNÉS abonné1;
        public ABONNÉS abonné2;
        public Admin user;
        public ALBUMS album1;
        public ALBUMS album2;
        public EMPRUNTER emprunt1;
        public EMPRUNTER emprunt2;
        public EMPRUNTER emprunt3;
        public EMPRUNTER emprunt4;
        public List<EMPRUNTER> listeAlbumsNonEmpruntés;

        /*
         * Test de l'US3, si un emprunt n'a jamais été prolongé, on rajoute 1 mois à la date de retour attendue, si oui, ne fait rien.
         */
        public void initTest()
        {
            abonné1 = (from a in musiqueSQL.ABONNÉS where a.CODE_ABONNÉ == 6 select a).FirstOrDefault();
            abonné2 = (from a in musiqueSQL.ABONNÉS where a.CODE_ABONNÉ == 7 select a).FirstOrDefault();
            user = new Admin();

            album1 = (from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == 700 select a).FirstOrDefault();
            album2 = (from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == 701 select a).FirstOrDefault();

            emprunt1 = new EMPRUNTER();
            emprunt1.CODE_ABONNÉ = 6;
            emprunt1.ALBUMS = album1;
            emprunt1.DATE_EMPRUNT = DateTime.Parse("8/6/2019 8:30:15 AM");
            emprunt1.DATE_RETOUR_ATTENDUE = emprunt1.DATE_EMPRUNT.AddDays(album1.GENRES.DÉLAI);
            emprunt1.DATE_RETOUR = DateTime.Parse("9/6/2019 8:30:15 AM");
            musiqueSQL.EMPRUNTER.Add(emprunt1);

            emprunt2 = new EMPRUNTER();
            emprunt2.CODE_ABONNÉ = 7;
            emprunt2.ALBUMS = album1;
            emprunt2.DATE_EMPRUNT = DateTime.Parse("9/7/2019 8:30:15 AM");
            emprunt2.DATE_RETOUR_ATTENDUE = emprunt2.DATE_EMPRUNT.AddDays(album2.GENRES.DÉLAI).AddMonths(1);
            emprunt2.DATE_RETOUR = DateTime.Parse("10/7/2019 8:30:15 AM");
            musiqueSQL.EMPRUNTER.Add(emprunt2);

            emprunt3 = new EMPRUNTER();
            emprunt3.CODE_ABONNÉ = 7;
            emprunt3.ALBUMS = album2;
            emprunt3.DATE_EMPRUNT = DateTime.Parse("8/6/2019 8:30:15 AM");
            emprunt3.DATE_RETOUR_ATTENDUE = emprunt1.DATE_EMPRUNT.AddDays(album1.GENRES.DÉLAI);
            emprunt3.DATE_RETOUR = DateTime.Parse("9/6/2019 8:30:15 AM");
            musiqueSQL.EMPRUNTER.Add(emprunt3);

            emprunt4 = new EMPRUNTER();
            emprunt4.CODE_ABONNÉ = 6;
            emprunt4.ALBUMS = album2;
            emprunt4.DATE_EMPRUNT = DateTime.Parse("5/2/2021 8:30:15 AM");
            emprunt4.DATE_RETOUR_ATTENDUE = emprunt2.DATE_EMPRUNT.AddDays(album2.GENRES.DÉLAI).AddMonths(1);
            emprunt4.DATE_RETOUR = DateTime.Parse("6/2/2021 8:30:15 AM");
            musiqueSQL.EMPRUNTER.Add(emprunt4);
            musiqueSQL.SaveChanges();
        }

        [TestMethod]
        public void testAlbumsNonEmpruntés()
        {
            initTest();
            HashSet<ALBUMS> albumPasEmprunter1An = user.albumPasEmpruntesDepuis1An();
            musiqueSQL.SaveChanges();
            Assert.IsTrue(albumPasEmprunter1An.Contains((from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == album1.CODE_ALBUM select a).First()));
            musiqueSQL.EMPRUNTER.Remove(emprunt1);
            musiqueSQL.EMPRUNTER.Remove(emprunt2);
            musiqueSQL.EMPRUNTER.Remove(emprunt3);
            musiqueSQL.EMPRUNTER.Remove(emprunt4);
        }
    }
}