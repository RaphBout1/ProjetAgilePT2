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
        Dictionary<GENRES,int> listeGenreEmprunte = new Dictionary<GENRES,int>();
        List<ALBUMS> listeAlbumsRecommande = new List<ALBUMS>();

        #region Recommandation
        private void Recommandation()
        {
            listeGenreEmprunte.Clear();
            ListerGenreEmprunte();
            ListageRecommandeAlbum();
        }
        #region Calcule Recommandation
        private void ListerGenreEmprunte()
        {
            foreach(EMPRUNTER e in utilisateur.EMPRUNTER)
            {
                if (listeGenreEmprunte.ContainsKey(e.ALBUMS.GENRES))
                {
                    listeGenreEmprunte[e.ALBUMS.GENRES] += 1;
                }
                else
                {
                    listeGenreEmprunte.Add(e.ALBUMS.GENRES, 1);
                }
            }
        }

        private void ListageRecommandeAlbum()
        {
            Dictionary<int, ALBUMS> listeAlbum = new Dictionary<int, ALBUMS>();
            foreach (KeyValuePair<GENRES,int> gi in listeGenreEmprunte)
            {
                foreach(ALBUMS a in gi.Key.ALBUMS)
                {
                    listeAlbum.Add(a.EMPRUNTER.Count + (1000 * gi.Value), a);
                }
            }
            foreach(KeyValuePair<int,ALBUMS> ia in listeAlbum.OrderBy(importance => importance.Key))
            {
                listeAlbumsRecommande.Add(ia.Value);
            }
        }
        #endregion
    #endregion
    }
}
