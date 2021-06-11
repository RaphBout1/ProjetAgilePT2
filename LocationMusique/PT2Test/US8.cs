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
        public UtilisateurUSEmprunt emprunter1;
        public UtilisateurUSEmprunt emprunter2;
        public ALBUMS album1;
        public ALBUMS album2;
        
        /// <summary>
        /// Test de l'US8, vérifie qu'un album avec un dernier emprunt datant d'il y a plus d'un an est bien reconnu comme tel et affiché dans une liste.
        /// </summary>
        [TestMethod]
        public void testAlbumsNonEmpruntés()
        {
            initaliserVariables();
            HashSet<ALBUMS> albumPasEmprunter1An = user.albumPasEmpruntesDepuis1An();
            musiqueSQL.SaveChanges();
            Assert.IsTrue(albumPasEmprunter1An.Contains(album1));

        }

        /// <summary>
        /// initialise les variables pour le test, avec un emprunt datant de plus d'un an
        /// </summary>
        public void initaliserVariables()
        {
            abonné1 = (from a in musiqueSQL.ABONNÉS where a.CODE_ABONNÉ == 6 select a).FirstOrDefault();
            abonné2 = (from a in musiqueSQL.ABONNÉS where a.CODE_ABONNÉ == 9 select a).FirstOrDefault();
            user = new Admin();

            album1 = (from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == 700 select a).FirstOrDefault();
            album2 = (from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == 701 select a).FirstOrDefault();

            emprunter1 = new UtilisateurUSEmprunt(abonné1);
            emprunter2 = new UtilisateurUSEmprunt(abonné2);
            emprunter1.creerEmprunt(abonné1.CODE_ABONNÉ, album1.CODE_ALBUM, DateTime.Parse("10/6/2019 8:30:15 AM"), DateTime.Parse("11/6/2019 8:30:15 AM"));
            emprunter2.creerEmprunt(abonné2.CODE_ABONNÉ, album2.CODE_ALBUM, DateTime.Parse("10/6/2019 8:30:15 AM"), DateTime.Parse("11/6/2019 8:30:15 AM"));
        }
    }
}