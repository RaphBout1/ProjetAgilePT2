using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{
    public partial class ABONNÉS
    {
        public override bool Equals(object obj)
        {
            return obj is ABONNÉS aBONNÉS &&
                   CODE_ABONNÉ == aBONNÉS.CODE_ABONNÉ;
        }

        public override string ToString()
        {
            return NOM_ABONNÉ + " " + PRÉNOM_ABONNÉ;
        }
    }
}
