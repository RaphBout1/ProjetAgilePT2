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
    public class US3
    {
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        public ABONNÉS abonné;
        public Utilisateur user;
        public ALBUMS album1;
        public ALBUMS album2;
        public EMPRUNTER emprunt1;
        public EMPRUNTER emprunt2;
        public List<EMPRUNTER> listeEmprunts;

        public void resetEmprunt()
        {
            abonné = (from a in musiqueSQL.ABONNÉS where a.CODE_ABONNÉ == 6 select a).FirstOrDefault();
            user = new Utilisateur(abonné);

            album1 = (from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == 1 select a).FirstOrDefault();
            album2 = (from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == 2 select a).FirstOrDefault();

            emprunt1 = new EMPRUNTER();
            emprunt1.CODE_ABONNÉ = 1;
            emprunt1.ALBUMS = album1;
            emprunt1.DATE_EMPRUNT = DateTime.Parse("8/6/2021 8:30:15 AM");
            emprunt1.DATE_RETOUR_ATTENDUE = emprunt1.DATE_EMPRUNT.AddDays(album1.GENRES.DÉLAI);
            emprunt1.DATE_RETOUR = null;

            emprunt2 = new EMPRUNTER();
            emprunt2.CODE_ABONNÉ = 1;
            emprunt2.ALBUMS = album2;
            emprunt2.DATE_EMPRUNT = DateTime.Parse("8/6/2021 8:30:15 AM");
            emprunt2.DATE_RETOUR_ATTENDUE = emprunt2.DATE_EMPRUNT.AddDays(album2.GENRES.DÉLAI).AddMonths(1);
            emprunt2.DATE_RETOUR = null;

            listeEmprunts = new List<EMPRUNTER>();
        }

        /*
         * Test de l'US3, si un emprunt n'a jamais été prolongé, on rajoute 1 mois à la date de retour attendue, si oui, ne fait rien.
         */
        [TestMethod]
        public void testEmpruntProlongé()
        {
            /**
            //Test 1 : si un emprunt n'a jamais été fait, fonctionne
            resetEmprunt();
            Assert.IsTrue(user.empruntProlongeable(emprunt1, album1));
            //Test 2 : si un emprunt a déjà été fait, ne fonctionne pas 
            resetEmprunt();
            Assert.IsFalse(user.empruntProlongeable(emprunt2, album2));
            */
        }
    }
}