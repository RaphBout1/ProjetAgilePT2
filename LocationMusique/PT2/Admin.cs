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
        
        private HashSet<ABONNÉS> abonnésPurgeables = new HashSet<ABONNÉS>();
        HashSet<ALBUMS> lesPlusEmprunté = new HashSet<ALBUMS>();
        public Admin()
        {
            InitializeComponent();
            enRetard();
            LivreEmprunteProlongé();
            abonnésAPurger();

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
                    listBox1.Items.Add(e.ABONNÉS);
                    
                }
            }
            Refresh();
            return enretard10;
        }

        private void LivreEmprunteProlongé()
        {
             var lesLivresEmpruntes =
                    from m in musiqueSQL.EMPRUNTER
                    select m;

                foreach (EMPRUNTER m in lesLivresEmpruntes)
                {
                    if (!(m.DATE_EMPRUNT.AddMonths(1).AddDays(m.ALBUMS.GENRES.DÉLAI).CompareTo(m.DATE_RETOUR_ATTENDUE.AddMonths(1)) >= 0) && m.DATE_RETOUR == null) //à vérifier
                    {
                        listBox2.Items.Add(m);
                    }

                }
            
            Refresh();
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
            DateTime dateactuelle = DateTime.UtcNow.AddYears(-1);
            var abonnés = from e in musiqueSQL.EMPRUNTER
                          join alb in musiqueSQL.ALBUMS on e.CODE_ALBUM equals alb.CODE_ALBUM
                          join abo in musiqueSQL.ABONNÉS on e.CODE_ABONNÉ equals abo.CODE_ABONNÉ
                          where e.DATE_EMPRUNT.CompareTo(dateactuelle) <= 0
                          select abo;
            foreach (ABONNÉS a in abonnés)
                if (!abonnésPurgeables.Contains(a))
            {
                    abonnésPurgeables.Add(a);
                listBox3.Items.Add(a);
            }
            Refresh();
        }

       

        private void purgerAbonné(int codeAbonné)
        {
            abonnésAPurger();
            
                
                    var query = from l in musiqueSQL.ABONNÉS where l.CODE_ABONNÉ == codeAbonné select l;
                    ABONNÉS x = query.First();
                    musiqueSQL.ABONNÉS.Remove(x);
                    musiqueSQL.SaveChanges();
                
            
        }

        private void purgebutton_Click(object sender, EventArgs e)
        {
            ABONNÉS a = (ABONNÉS)listBox3.SelectedItem;
            purgerAbonné(a.CODE_ABONNÉ);
        }
    }
}
