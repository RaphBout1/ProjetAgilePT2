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
    public class US9
    {
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        public ABONNÉS abonné;
        public Utilisateur user;
        public ALBUMS album1;
        public ALBUMS album2;
        public ALBUMS album3;
        public EMPRUNTER emprunt1;
        public EMPRUNTER emprunt2;
        public EMPRUNTER emprunt3;
        public List<EMPRUNTER> listeEmprunts;



        /// <summary>
        /// Test de l'US9, prolonge tous les emprunts qui n'ont pas déjà été prolongés de l'abonné.
        /// </summary>
        [TestMethod]
        public void testEmpruntProlongé()
        {
            //Test 1 : les deux premiers emprunts de cet abonné test sont prolongeables, le troisieme ne l'est pas, donc il n'est pas comptabilisé.
            resetEmprunt();
            var mesEmprunts = (from em in musiqueSQL.EMPRUNTER where (em.CODE_ABONNÉ == abonné.CODE_ABONNÉ) select em).ToList();
            int nbProlonges = 0;
            foreach (EMPRUNTER em in mesEmprunts)
            {
                if (user.empruntProlongeable(em))
                {
                    nbProlonges++;
                }
            }
            Assert.IsTrue(nbProlonges == 2);

        }

        /// <summary>
        /// réinitialise toutes les variables utilisées pendant le test (abonné concerné, emprunts des albums utilisés)
        /// </summary>
        public void resetEmprunt()
        {
            abonné = (from a in musiqueSQL.ABONNÉS where a.CODE_ABONNÉ == 6 select a).FirstOrDefault();
            user = new Utilisateur(abonné);

            album1 = (from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == 580 select a).FirstOrDefault();
            album2 = (from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == 581 select a).FirstOrDefault();
            album3 = (from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == 582 select a).FirstOrDefault();


            emprunt1 = new EMPRUNTER();
            emprunt1.CODE_ABONNÉ = 6;
            emprunt1.ALBUMS = album1;
            emprunt1.DATE_EMPRUNT = DateTime.Parse("8/6/2021 8:30:15 AM");
            emprunt1.DATE_RETOUR_ATTENDUE = emprunt1.DATE_EMPRUNT.AddDays(album1.GENRES.DÉLAI);
            emprunt1.DATE_RETOUR = null;

            emprunt2 = new EMPRUNTER();
            emprunt2.CODE_ABONNÉ = 6;
            emprunt2.ALBUMS = album2;
            emprunt2.DATE_EMPRUNT = DateTime.Parse("8/6/2021 8:30:15 AM");
            emprunt2.DATE_RETOUR_ATTENDUE = emprunt2.DATE_EMPRUNT.AddDays(album2.GENRES.DÉLAI);
            emprunt2.DATE_RETOUR = null;

            emprunt3 = new EMPRUNTER();
            emprunt3.CODE_ABONNÉ = 6;
            emprunt3.ALBUMS = album3;
            emprunt3.DATE_EMPRUNT = DateTime.Parse("8/6/2021 8:30:15 AM");
            emprunt3.DATE_RETOUR_ATTENDUE = emprunt3.DATE_EMPRUNT.AddDays(album3.GENRES.DÉLAI).AddMonths(1);
            emprunt3.DATE_RETOUR = null;

            musiqueSQL.EMPRUNTER.Add(emprunt1);
            musiqueSQL.EMPRUNTER.Add(emprunt2);
            musiqueSQL.EMPRUNTER.Add(emprunt3);
        }
    }
}
