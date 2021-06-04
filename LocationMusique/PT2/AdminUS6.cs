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
        private HashSet<ABONNÉS> abonnésPurgeables = new HashSet<ABONNÉS>();
        private void abonnésAPurger()
        {
            var abonnés = from e in musiqueSQL.EMPRUNTER
                          join alb in musiqueSQL.ALBUMS on e.CODE_ALBUM equals alb.CODE_ALBUM
                          join abo in musiqueSQL.ABONNÉS on e.CODE_ABONNÉ equals abo.CODE_ABONNÉ
                          where e.DATE_EMPRUNT.CompareTo(DateTime.UtcNow.AddYears(-1)) <= 0
                          select abo;
            foreach (ABONNÉS a in abonnés)
            {
                if (!abonnésPurgeables.Contains(a))
                    abonnésPurgeables.Add(a);
            }
        }

        private void listeAbonnésPurgeables()
        {
            abonnésAPurger();
            if (abonnésPurgeables != null)
            {
                string s = "";
                for (int i = 0; i < abonnésPurgeables.Count; i++)
                {
                    s = s + abonnésPurgeables.ElementAt(i) + "   ";
                }
                MessageBox.Show(s);
            }
        }

        private void purgerAbonné(int codeAbonné)
        {
            abonnésAPurger();
            foreach (ABONNÉS a in abonnésPurgeables)
            {
                if (a.CODE_ABONNÉ == codeAbonné)
                {
                    musiqueSQL.ABONNÉS.Remove(a);
                }
            }
        }
    }
}
