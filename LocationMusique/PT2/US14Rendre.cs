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
    /// <summary>
    /// Une classe Form qui gère le fait de rendre un emprunt.
    /// </summary>
    public partial class US14Rendre : Form
    {
        ABONNÉS abo;
        MusiquePT2_DEntities musiqueSQL = new MusiquePT2_DEntities();
        public US14Rendre(ABONNÉS abo)
        {
            InitializeComponent();
            this.abo = abo;
            remplirEmpruntsBox();
        }
        /// <summary>
        /// Méthode qui remplit la ListBox de ce form avec tous les emprunts de l'abonné.
        /// </summary>
        private void remplirEmpruntsBox()
        {
            var empruntactuels = from l in musiqueSQL.ABONNÉS where l.CODE_ABONNÉ == abo.CODE_ABONNÉ select l.EMPRUNTER;
            foreach (EMPRUNTER i in empruntactuels.First()) 
            {
                if(i.DATE_RETOUR == null)
                {
                    listBoxEmpruntEnCours.Items.Add(i);
                }
                
            }
            Refresh();
        }
        /// <summary>
        /// Un appui sur le bouton rend l'emprunt sélectionné dans la ListBox.
        /// La date fixée est la date actuelle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rendreButton_Click(object sender, EventArgs e)
        {
            EMPRUNTER m = (EMPRUNTER) listBoxEmpruntEnCours.SelectedItem;
            rendreEmprunt(m);
            listBoxEmpruntEnCours.Items.Remove(m);
            Refresh();
        }
        /// <summary>
        /// Méthode qui rend un emprunt
        /// </summary>
        /// <param name="m">L'emprunt en question</param>
        public void rendreEmprunt(EMPRUNTER m)
        {
            var bonEmprunt = from l in musiqueSQL.EMPRUNTER where l.CODE_ABONNÉ == m.CODE_ABONNÉ && l.CODE_ALBUM == m.CODE_ALBUM select l;
            bonEmprunt.First().DATE_RETOUR = DateTime.UtcNow;
            musiqueSQL.SaveChanges();
        }
    }
}
