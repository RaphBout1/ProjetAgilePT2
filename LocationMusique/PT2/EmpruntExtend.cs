using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{
    public partial class EMPRUNTER
    {
        public override String ToString()
        {
            return ALBUMS.TITRE_ALBUM + " " + DATE_RETOUR_ATTENDUE.ToString();
        }
        public bool enRetard()
        {
            bool test = false;
            if (DATE_RETOUR == null && DateTime.UtcNow > DATE_RETOUR_ATTENDUE.AddDays(10))
            {
                test = true;
            }
            return test;
        }

        public override bool Equals(object obj)
        {
            return obj is EMPRUNTER eMPRUNTER &&
                   CODE_ABONNÉ == eMPRUNTER.CODE_ABONNÉ &&
                   CODE_ALBUM == eMPRUNTER.CODE_ALBUM;
        }
    }
}
