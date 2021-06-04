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
        private void ActualiseListeEmprunté()
        {
            if (utilisateur != null)
            {
                foreach (EMPRUNTER e in utilisateur.EMPRUNTER)
                {
                    ALBUMS a = e.ALBUMS;
                    listBoxConsultEmprunt.Items.Add(a.TITRE_ALBUM + "   " + a.GENRES.LIBELLÉ_GENRE);
                }
            }
        }
    }
}
