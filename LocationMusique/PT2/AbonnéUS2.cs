using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{
    public partial class ABONNÉS
    {
        private void ActualiseListeEmprunté()
        {
            foreach(EMPRUNTER e in this.EMPRUNTER)
            {
                ALBUMS a = e.ALBUMS;
                //listBoxConsultEmprunt.Items.Add(a.TITRE_ALBUM+"       "+a.GENRES.LIBELLÉ_GENRE);
            }
        }
    }
}
