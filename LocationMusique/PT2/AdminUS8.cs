using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace PT2
{

    public partial class Admin
    {

        /**
         * retourne l'ensemble des albums dont la dernière date d'emprunt remonte à plus d'un an
         */
        private HashSet<ALBUMS> albumPasEmpruntesDepuis1An()
        {
            HashSet<ALBUMS> albumPasEmprunter1An = new HashSet<ALBUMS>();
            Dictionary<int, List<EMPRUNTER>> emprunts = (Dictionary<int, List<EMPRUNTER>>)(from e in musiqueSQL.EMPRUNTER group e by e.CODE_ALBUM into newGroup select newGroup);
            Dictionary<int, DateTime> dates = new Dictionary<int, DateTime>();
            foreach (var kv in emprunts)
            {
                dates[kv.Key] = kv.Value.Max(d => d.DATE_EMPRUNT);
            }
            foreach (var kv in dates)
            {
                if (DateTime.UtcNow.AddYears(-1).CompareTo(kv.Value) < 0)
                {
                    albumPasEmprunter1An.Add((from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == kv.Key select a).First());
                }
            }
            return albumPasEmprunter1An;
        }
    }
}
