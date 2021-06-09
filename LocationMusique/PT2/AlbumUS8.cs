using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{
    public partial class ALBUMS
    {
        public int nmbEmpruntEnUnAn;
        public override bool Equals(object obj)
        {
            return obj is ALBUMS aLBUMS &&
                   CODE_ALBUM == aLBUMS.CODE_ALBUM;
        }

        public override string ToString()
        {
            return this.TITRE_ALBUM;
        }

        /// <summary>
        /// Calcule le nombre d'emprunt effectué dans l'année courante 
        /// (ne comptabilise pas si l'emprunt est en cours ou non)
        /// </summary>
        public void EmpruntAnnee()
        {
            nmbEmpruntEnUnAn = 0;
            foreach(EMPRUNTER e in this.EMPRUNTER)
            {
                if(e.DATE_EMPRUNT >= DateTime.UtcNow.AddYears(-1))
                {
                    nmbEmpruntEnUnAn++;
                }
            }
        }

        public override int GetHashCode()
        {
            return 1186937416 + CODE_ALBUM.GetHashCode();
        }
    }
}
