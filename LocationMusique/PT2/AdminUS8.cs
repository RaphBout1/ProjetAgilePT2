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
        HashSet<ALBUMS> albumPasEmprunter1 = new HashSet<ALBUMS>();
        private  void albumPasEmprunter()
        {
            var emprunt = from e in musiqueSQL.EMPRUNTER select e;
            foreach(EMPRUNTER e in emprunt)
            {
                if(e.DATE_EMPRUNT.CompareTo(DateTime.UtcNow.AddYears(-1)) <= 0)
                {
                    if (!albumPasEmprunter1.Contains(e.ALBUMS))
                    {
                        albumPasEmprunter1.Add(e.ALBUMS);
                    }
                }
            }
        }

        private  void listeAlbumPasEmprunte()
        {
            albumPasEmprunter();
            if (albumPasEmprunter1 != null)
            {
                string s = "";
                for (int i = 0; i < albumPasEmprunter1.Count; i++)
                {
                    s = s + albumPasEmprunter1.ElementAt(i).ToString() + "   ";
                }
                MessageBox.Show(s);
            }
        }
    }
}
