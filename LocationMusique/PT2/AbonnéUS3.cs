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
    public partial class Utilisateur : Form
    {
        private ABONNÉS utilisateur;
        public void ProlongerEmprunt(int codeAlbum)
        {
            foreach (EMPRUNTER e in utilisateur.EMPRUNTER)
            {
                ALBUMS a = e.ALBUMS;
                if (a.CODE_ALBUM == codeAlbum)
                {
                    if (!e.dejaRenouvelé && e.DATE_RETOUR == null)
                    {
                        e.dejaRenouvelé = true;
                        e.DATE_RETOUR_ATTENDUE = e.DATE_RETOUR_ATTENDUE.AddMonths(1);
                    }
                }
            }
            
        }

        public void ProlongerTousEmprunts()
        {

        }
    }
}
