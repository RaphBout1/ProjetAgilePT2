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
        private readonly static string logAdmin = "admin";
        private HashSet<ALBUMS> albumsUS8 = new HashSet<ALBUMS>();
        private bool purgeModeOn = true;
        Connexion fenetrePrecedente;
        int page;
        List<ALBUMS> listeaffiche;
        public Admin(Connexion fenetrePrecedente)
        {
            InitializeComponent();
            listerAbonnés();
            listerAllées();
            albumsUS8 = albumPasEmpruntesDepuis1An();
            this.fenetrePrecedente = fenetrePrecedente;
            page = 0;
            listeaffiche = new List<ALBUMS>();
            purgebutton.Enabled = false;
            purgebutton.Visible = false;
            enRetardButton.Visible = false;
            purgerModeButton.Visible = false;
            buttonChangerMdp.Visible = false;
            precButton.Visible = false;
            suivantButton.Visible = false;
        }
        public Admin()
        {
            InitializeComponent();
            listerAbonnés();
            listerAllées();
            albumsUS8 = albumPasEmpruntesDepuis1An();
            page = 0;
            listeaffiche = new List<ALBUMS>();
            purgebutton.Enabled = false;
            purgebutton.Visible = false;
            enRetardButton.Visible = false;
            purgerModeButton.Visible = false;
            buttonChangerMdp.Visible = false;
            precButton.Visible = false;
            suivantButton.Visible = false;
        }
        /// <summary>
        /// Renvoie une liste d'abonnée ayant un emprunt non rendu en retard de 10 jours sur la date de rendue attendue.
        /// </summary>
        /// <returns>La Liste en question.</returns>
        public List<ABONNÉS> enRetard()
        {

            List<ABONNÉS> enretard10 = new List<ABONNÉS>();
            var listemprunt = from l in musiqueSQL.EMPRUNTER select l;
            foreach (EMPRUNTER e in listemprunt)
            {
                if (e.enRetard())
                {
                    enretard10.Add(e.ABONNÉS);
                }
            }

            return enretard10;
        }

        private List<EMPRUNTER> LivreEmprunteProlongé()
        {
            List<EMPRUNTER> prolongeList = new List<EMPRUNTER>();
            var lesLivresEmpruntes =
                   from m in musiqueSQL.EMPRUNTER
                   select m;

            foreach (EMPRUNTER m in lesLivresEmpruntes)
            {
                if (!(m.DATE_EMPRUNT.AddDays(m.ALBUMS.GENRES.DÉLAI).CompareTo(m.DATE_RETOUR_ATTENDUE) >= 0) && m.DATE_RETOUR == null)
                {
                    prolongeList.Add(m);
                }
            }
            return prolongeList;
        }

        private void remplirDataProlonge()
        {
            dataGridViewGlobale.DataSource = LivreEmprunteProlongé();
        }
        /// <summary>
        /// Méthode permettant renvoyant une liste d'album
        /// Cette dernière contient les 10 albums les plus empruntés de la base
        /// </summary>
        /// <returns> une List<ALBUMS> ne contenant que les 10 albums les plus vues</returns>
        public List<ALBUMS> DixPlusVue()
        {
            DateTime ilYAUnAn = DateTime.UtcNow.AddYears(-1);
            return (from e in musiqueSQL.EMPRUNTER
                    where e.DATE_EMPRUNT.CompareTo(ilYAUnAn) >= 0
                    group e by e.CODE_ALBUM into newGroup
                    orderby newGroup.Count() descending
                    select (from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == newGroup.Key select a).FirstOrDefault()).Take(10).ToList();
        }

        /// <summary>
        /// Permet d'effectuer un décalage droite dans une List<ALBUMS>
        /// en indiquant l'objet à placer après décalage et son index
        /// </summary>
        /// <param name="la"> la liste devant subir le décalage</param>
        /// <param name="a"> l'album a placé dans la liste</param>
        /// <param name="index"> l'index où doit être placé le nouveaux albums</param>
        /// <paramref name="finDecalage"> l'index où délimitant la fin du tableau voulu
        private static void DecaleDroiteAlbum(List<ALBUMS> la, ALBUMS a, int index, int finDecalage)
        {
            for (int compteurInverse = finDecalage; compteurInverse > index; compteurInverse--)
            {
                if (compteurInverse == finDecalage)
                {
                    la.Add(la[compteurInverse - 1]);
                }
                else
                {
                    la[compteurInverse] = la[compteurInverse - 1];
                }

            }
            la[index] = a;
            la.Remove(la[finDecalage]);
        }

        /// <summary>
        /// liste dans une listBox les abonnés purgeables
        /// </summary>
        private List<ABONNÉS> abonnésAPurger()
        {
            List<ABONNÉS> aPurgerListe = new List<ABONNÉS>();
            DateTime dateactuelle = DateTime.UtcNow.AddYears(-1);
            var dates = from e in musiqueSQL.EMPRUNTER group e by e.CODE_ABONNÉ into newGroup select new { newGroup.Key, derniereDate = newGroup.Max(d => d.DATE_EMPRUNT) };
            foreach (var kv in dates)
            {
                if (DateTime.UtcNow.AddYears(-1).CompareTo(kv.derniereDate) > 0)
                {
                    ABONNÉS aPurger = (from ab in musiqueSQL.ABONNÉS where ab.CODE_ABONNÉ == kv.Key select ab).First();
                    aPurgerListe.Add(aPurger);
                }
            }
            return aPurgerListe;
        }

        private void remplirDataAPurger()
        {
            dataGridViewGlobale.DataSource = abonnésAPurger();
            dataGridViewGlobale.Columns["CODE_PAYS"].Visible = false;
            dataGridViewGlobale.Columns["CODE_ABONNÉ"].Visible = false;
            dataGridViewGlobale.Columns["PASSWORD_ABONNÉ"].Visible = false;
        }

        /// <summary>
        /// Purge de la base de donnée l'abonné correspondant à ce code abonné ainsi que tous ses emprunts
        /// </summary>
        /// <param name="codeAbonné"></param> le CODE_ABONNE dans la base de l'abonné à purger
        public void purgerAbonné(int codeAbonné)
        {
            ABONNÉS aPurger = (from l in musiqueSQL.ABONNÉS where l.CODE_ABONNÉ == codeAbonné select l).First();
            if (aPurger != null)
            {
                (from e in musiqueSQL.EMPRUNTER where e.CODE_ABONNÉ == aPurger.CODE_ABONNÉ select e).ToList().ForEach(e => musiqueSQL.EMPRUNTER.Remove(e));
                musiqueSQL.ABONNÉS.Remove(aPurger);
                musiqueSQL.SaveChanges();
            }
            else
            {
                throw new databaseException("Cet abonné n'existe pas dans la base.");
            }

        }

        private void purgebutton_Click(object sender, EventArgs e)
        {
            try
            {
                ABONNÉS a = dataGridViewGlobale.SelectedRows[0].DataBoundItem as ABONNÉS;
                Console.WriteLine(a);
                purgerAbonné(a.CODE_ABONNÉ);
                purgebutton.Enabled = false;
                remplirDataAPurger();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + Environment.NewLine + "Annulation.");
            }
        }

        /**
         * retourne l'ensemble des albums dont la dernière date d'emprunt remonte à plus d'un an (ou n'a jamais été emprunté)
         */
        public HashSet<ALBUMS> albumPasEmpruntesDepuis1An()
        {
            HashSet<ALBUMS> albumPasEmprunter1An = new HashSet<ALBUMS>();
            var albumsJamaisEmpruntés = (from a in musiqueSQL.ALBUMS select a).ToList().Except(from e in musiqueSQL.EMPRUNTER select e.ALBUMS).ToList();
            albumsJamaisEmpruntés.ForEach(a => albumPasEmprunter1An.Add(a));
            DateTime dateactuelle = DateTime.UtcNow.AddYears(-1);
            var dates = from e in musiqueSQL.EMPRUNTER group e by e.CODE_ALBUM into newGroup select new { newGroup.Key, derniereDate = newGroup.Max(d => d.DATE_EMPRUNT) };
            foreach (var kv in dates)
            {
                if (DateTime.UtcNow.AddYears(-1).CompareTo(kv.derniereDate) > 0)
                {
                    albumPasEmprunter1An.Add((from a in musiqueSQL.ALBUMS where a.CODE_ALBUM == kv.Key select a).First());
                }
            }
            return albumPasEmprunter1An;
        }

        /// <summary>
        /// liste les abonnés
        /// </summary>
        /// <returns></returns>
        private List<ABONNÉS> listerAbonnés()
        {
            List<ABONNÉS> abo = new List<ABONNÉS>();
            var abonnés = from a in musiqueSQL.ABONNÉS orderby a.NOM_ABONNÉ select a;
            foreach (ABONNÉS a in abonnés)
            {
                abo.Add(a);
            }
            return abo;
        }

        private void remplirDataViewAbo()
        {
            dataGridViewGlobale.DataSource = listerAbonnés();
        }

        private void changerMdp()
        {
            ABONNÉS a = dataGridViewGlobale.SelectedRows[0].DataBoundItem as ABONNÉS;
            ChangerMdp changementMdp = new ChangerMdp((from abo in musiqueSQL.ABONNÉS where abo.LOGIN_ABONNÉ == logAdmin select abo).First());
            if (changementMdp.ShowDialog() == DialogResult.OK)
            {
                a.PASSWORD_ABONNÉ = changementMdp.nouveauMdp;
                musiqueSQL.SaveChanges();
            }
        }

        /// <summary>
        /// Vide et remplit la listeboxglobale avec les 10 albums les plus populaires
        /// </summary>
        private void remplir10pluspopulaires()
        {
            dataGridViewGlobale.DataSource = DixPlusVue();
            dataGridViewGlobale.Columns["CODE_ALBUM"].Visible = false;
            dataGridViewGlobale.Columns["CODE_EDITEUR"].Visible = false;
            dataGridViewGlobale.Columns["CODE_GENRE"].Visible = false;
            for (int i = 0; i < dataGridViewGlobale.RowCount; i++)
            {
                dataGridViewGlobale.Rows[i].Height = 100;
            }
            for (int i = 0; i < dataGridViewGlobale.ColumnCount; i++)
            {
                dataGridViewGlobale.Columns[i].Width = 100;
            }
            dataGridViewGlobale.RowHeadersWidth = 5;
            dataGridViewGlobale.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Refresh();
        }

        /// <summary>
        /// Insère dans une liste l'ensemble des allées disponibles
        /// </summary>
        private void listerAllées()
        {
            comboAllée.Items.Clear();
            var allees = from a in musiqueSQL.ALBUMS group a by a.ALLÉE_ALBUM into intAllees orderby intAllees.Key select intAllees.Key;
            foreach (string s in allees)
            {
                comboAllée.Items.Add(s.Trim());
            }
        }

        /// <summary>
        /// Rend visible ou invisible (toggle) l'ensemble des éléments liés à l'allée et au casier des disques.
        /// </summary>
        public void toggleCasiers(bool afficher)
        {
            comboAllée.Visible = afficher;
            comboCasier.Visible = afficher;
            allee.Visible = afficher;
            caiser.Visible = afficher;
            buttonCasier.Visible = afficher;

        }

        private void Pluspopulairebutton_Click(object sender, EventArgs e)
        {
            remplir10pluspopulaires();
            purgeModeOn = false;
            Refresh();
            purgebutton.Visible = false;
            purgebutton.Visible = false;
            enRetardButton.Visible = false;
            purgerModeButton.Visible = false;
            buttonChangerMdp.Visible = false;
            precButton.Visible = false;
            suivantButton.Visible = false;
            toggleCasiers(false);
        }

        private void moinsPopulaireButton_Click(object sender, EventArgs e)
        {
            page = 0;
            changerPage();
            purgeModeOn = false;
            Refresh();
            purgebutton.Visible = false;
            purgebutton.Visible = false;
            enRetardButton.Visible = false;
            purgerModeButton.Visible = false;
            buttonChangerMdp.Visible = false;
            precButton.Visible = true;
            suivantButton.Visible = true;
            toggleCasiers(false);
        }

        private void purgerModeButton_Click(object sender, EventArgs e)
        {
            remplirDataAPurger();
            purgeModeOn = true;
            Refresh();
            purgebutton.Visible = true;

        }

        private void enRetardButton_Click(object sender, EventArgs e)
        {
            dataGridViewGlobale.DataSource = enRetard();
            dataGridViewGlobale.Columns["CODE_PAYS"].Visible = false;
            dataGridViewGlobale.Columns["CODE_ABONNÉ"].Visible = false;
            dataGridViewGlobale.Columns["PASSWORD_ABONNÉ"].Visible = false;
            purgeModeOn = false;
            purgebutton.Visible = false;
            toggleCasiers(false);
            Refresh();
        }

        private void prolongesButton_Click(object sender, EventArgs e)
        {
            remplirDataProlonge();
            purgeModeOn = false;
            purgebutton.Visible = false;
            precButton.Visible = false;
            suivantButton.Visible = false;
            toggleCasiers(false);
            Refresh();
        }

        private void listeAbonnés_Click(object sender, EventArgs e)
        {
            remplirDataViewAbo();
            dataGridViewGlobale.Columns["CODE_PAYS"].Visible = false;
            dataGridViewGlobale.Columns["CODE_ABONNÉ"].Visible = false;
            dataGridViewGlobale.Columns["PASSWORD_ABONNÉ"].Visible = false;
            enRetardButton.Visible = true;
            purgerModeButton.Visible = true;
            buttonChangerMdp.Visible = true;
            precButton.Visible = false;
            suivantButton.Visible = false;
            toggleCasiers(false);
        }

        private void buttonChangerMdp_Click(object sender, EventArgs e)
        {
            changerMdp();
        }

       

        private void buttonAllée_Click(object sender, EventArgs e)
        {
            precButton.Visible = false;
            suivantButton.Visible = false;
            listerAllées();
            toggleCasiers(true);
        }

        private void buttonCasier_Click(object sender, EventArgs e)
        {
            try
            {
                declencherChargerAlbumsManquantsCasier();
            }
            catch (InformationsInvalidesException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Liste les albums manquants d'un casier pour les afficher à l'écran
        /// </summary>
        /// <param name="allée">L'allée du casier</param>
        /// <param name="casier">Le numéro du casier</param>
        private void chargerAlbumsManquantsCasier(string allée, int casier)
        {
            dataGridViewGlobale.DataSource = (from a in musiqueSQL.ALBUMS
                                             join emp in musiqueSQL.EMPRUNTER on a.CODE_ALBUM equals emp.CODE_ALBUM
                                             where a.ALLÉE_ALBUM == allée.ToString() && a.CASIER_ALBUM == casier && emp.DATE_RETOUR == null
                                             select a).ToList();
            dataGridViewGlobale.DataSource = listeaffiche;
            dataGridViewGlobale.Columns["CODE_ALBUM"].Visible = false;
            dataGridViewGlobale.Columns["CODE_EDITEUR"].Visible = false;
            dataGridViewGlobale.Columns["CODE_GENRE"].Visible = false;
            for (int i = 0; i < dataGridViewGlobale.RowCount; i++)
            {
                dataGridViewGlobale.Rows[i].Height = 100;
            }
            for (int i = 0; i < dataGridViewGlobale.ColumnCount; i++)
            {
                dataGridViewGlobale.Columns[i].Width = 100;
            }
            dataGridViewGlobale.RowHeadersWidth = 5;
            dataGridViewGlobale.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Appelle la fonction chargerAlbumsManquantsCasier en passant les informations des ListBox correspondantes en paramètre
        /// </summary>
        private void declencherChargerAlbumsManquantsCasier()
        {
            var allée = comboAllée.Text;
            var casier = comboCasier.Text;
            if (!String.IsNullOrEmpty(allée) && !String.IsNullOrEmpty(casier))
            {
                chargerAlbumsManquantsCasier(allée.ToString(), Convert.ToInt32(casier));
            }
            else
            {
                throw new InformationsInvalidesException("Le champ allée ou le champ casier ne présente pas de sélection valide.");
            }
        }

        private void dataGridViewGlobale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (purgeModeOn)
            {
                purgebutton.Visible = true;
            }
        }

        private void quitter_Click(object sender, EventArgs e)
        {
            fenetrePrecedente.Visible = true;
            this.Close();
        }

        private void comboAllée_TextChanged(object sender, EventArgs e)
        {
            var allée = comboAllée.Text;
            if (!String.IsNullOrEmpty(allée))
            {
                comboCasier.Text = null;
                comboCasier.Items.Clear();
                var casiers = from a in musiqueSQL.ALBUMS where a.ALLÉE_ALBUM == allée.ToString() group a by a.CASIER_ALBUM into casier select casier.Key;
                foreach (int i in casiers)
                {
                    comboCasier.Items.Add(i);
                }
            }
        }

        private void suivantButton_Click(object sender, EventArgs e)
        {
            page++;
            Console.WriteLine(page);
            changerPage();
            precButton.Visible = true;
        }

        private void precButton_Click(object sender, EventArgs e)
        {
            page--;
            changerPage();
            suivantButton.Visible = true;
        }

        private void changerPage()
        {
            var listetotale = albumPasEmpruntesDepuis1An().ToList();
            int nmb = 6;
            listeaffiche.Clear();
            for(int i = page * nmb; i < page * nmb + nmb; i++)
            {
                if (listetotale.Count > i)
                {
                    listeaffiche.Add(listetotale[i]);
                }
            }
            if (page == 0)
            {
                precButton.Visible = false;
            }
            if (listeaffiche.Count < nmb)
            {
                suivantButton.Visible = false;
            }
            dataGridViewGlobale.DataSource = listeaffiche;
            dataGridViewGlobale.Columns["CODE_ALBUM"].Visible = false;
            dataGridViewGlobale.Columns["CODE_EDITEUR"].Visible = false;
            dataGridViewGlobale.Columns["CODE_GENRE"].Visible = false;
            for (int i = 0; i < dataGridViewGlobale.RowCount; i++)
            {
                dataGridViewGlobale.Rows[i].Height = 100;
            }
            for (int i = 0; i < dataGridViewGlobale.ColumnCount; i++)
            {
                dataGridViewGlobale.Columns[i].Width = 100;
            }
            dataGridViewGlobale.RowHeadersWidth = 5;
            dataGridViewGlobale.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Refresh();
        }
    }
}
