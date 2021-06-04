using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{
    public partial class Admin : Form
    {
        private ABONNÉS utilisateurCourant;
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        private void LivreEmprunteProlongé()
        {
            if (utilisateurCourant != null)
            {
                var lesLivresEmpruntes =
                    from m in musiqueSQL.LocationMusique.EMPRUNTER
                    select m;

                foreach (EMPRUNTER m in lesLivresEmpruntes)
                {

                    if (m.estEmprunté)
                    {
                        ListBox.Items.Add(m);
                    }

                }
            }
        }
    }
}
