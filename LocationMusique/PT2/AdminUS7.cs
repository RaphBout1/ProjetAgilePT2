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
        HashSet<ALBUMS> lesPlusEmprunté=new HashSet<ALBUMS>();

        public void DixPlusVue()
        {
            lesPlusEmprunté.Clear();
            var lesAlbums = from a in musiqueSQL.ALBUMS select a;
            foreach(ALBUMS a in lesAlbums)
            {
                if (lesPlusEmprunté.Count()<=10)
                {
                    lesPlusEmprunté.Add(a);
                }
                else
                {
                    foreach(ALBUMS pe in lesPlusEmprunté)
                    {
                        if(a.EMPRUNTER.Count > pe.EMPRUNTER.Count)
                        {
                            lesPlusEmprunté.Remove(pe);
                            lesPlusEmprunté.Add(a);
                        }
                    }
                }
            }
        }


    }
}
