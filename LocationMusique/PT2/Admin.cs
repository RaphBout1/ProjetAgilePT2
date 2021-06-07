using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT2
{
    public partial class Admin : Form
    {
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        private ABONNÉS utilisateurCourant;
        private HashSet<ABONNÉS> abonnésPurgeables = new HashSet<ABONNÉS>();
        HashSet<ALBUMS> lesPlusEmprunté = new HashSet<ALBUMS>();
        public Admin()
        {
            InitializeComponent();
            enRetard();
            listeAbonnésPurgeables();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        public List<ABONNÉS> enRetard()
        {
            List<ABONNÉS> enretard10 = new List<ABONNÉS>();
            var listemprunt = from l in musiqueSQL.EMPRUNTER select l;
            foreach(EMPRUNTER e in listemprunt)
            {
                if (e.enRetard())
                {
                    enretard10.Add(e.ABONNÉS);
                    listeRetard.Items.Add(e.ABONNÉS.NOM_ABONNÉ.ToString() + " " + e.ABONNÉS.PRÉNOM_ABONNÉ.ToString());
                    
                }
            }
            Refresh();
            return enretard10;
        }

        private void LivreEmprunteProlongé()
        {
            if (utilisateurCourant != null)
            {
                var lesLivresEmpruntes =
                    from m in musiqueSQL.EMPRUNTER
                    select m;

                foreach (EMPRUNTER m in lesLivresEmpruntes)
                {
                    if (m.DATE_EMPRUNT.AddDays(m.ALBUMS.GENRES.DÉLAI).CompareTo(m.DATE_RETOUR_ATTENDUE) < 0 && m.DATE_RETOUR == null) //à vérifier
                    {
                        listeRetard.Items.Add(m.ABONNÉS.NOM_ABONNÉ.ToString() + " " + m.ABONNÉS.PRÉNOM_ABONNÉ.ToString());
                    }

                }
            }
        }

        public void DixPlusVue()
        {
            lesPlusEmprunté.Clear();
            var lesAlbums = from a in musiqueSQL.ALBUMS select a;
            foreach (ALBUMS a in lesAlbums)
            {
                if (lesPlusEmprunté.Count() <= 10)
                {
                    lesPlusEmprunté.Add(a);
                }
                else
                {
                    foreach (ALBUMS pe in lesPlusEmprunté)
                    {
                        if (a.EMPRUNTER.Count > pe.EMPRUNTER.Count)
                        {
                            lesPlusEmprunté.Remove(pe);
                            lesPlusEmprunté.Add(a);
                        }
                    }
                }
            }
        }

        private void abonnésAPurger()
        {
            DateTime date = DateTime.UtcNow.AddYears(-1);
            var abonnés = from e in musiqueSQL.EMPRUNTER
                          join alb in musiqueSQL.ALBUMS on e.CODE_ALBUM equals alb.CODE_ALBUM
                          join abo in musiqueSQL.ABONNÉS on e.CODE_ABONNÉ equals abo.CODE_ABONNÉ
                          where e.DATE_EMPRUNT < date
                          select abo;
            if (abonnés != null) { 
                foreach (ABONNÉS a in abonnés)
                 {
                    if (!abonnésPurgeables.Contains(a))
                        abonnésPurgeables.Add(a);
                }
            }
        }

        private void listeAbonnésPurgeables()
        {
            listeAbonnésInactifs.Items.Clear();
            abonnésAPurger();
            if (abonnésPurgeables != null)
            {
                foreach (ABONNÉS a in abonnésPurgeables)
                {
                    listeAbonnésInactifs.Items.Add(a.NOM_ABONNÉ.ToString() + " " + a.PRÉNOM_ABONNÉ.ToString() + " " + a.CODE_ABONNÉ.ToString());
                }
            }
        }

        private void purgerAbonné(int codeAbonné)
        {
            abonnésAPurger();
            foreach (ABONNÉS a in abonnésPurgeables)
            {
                if (a.CODE_ABONNÉ == codeAbonné)
                {
                    var query = from l in musiqueSQL.ABONNÉS where l.CODE_ABONNÉ == a.CODE_ABONNÉ select l;
                    ABONNÉS x = query.First();
                    musiqueSQL.ABONNÉS.Remove(x);
                }
            }
        }
    }
}
