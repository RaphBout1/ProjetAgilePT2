using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{
    public partial class ALBUMS
    {
        public override bool Equals(object obj)
        {
            return obj is ALBUMS aLBUMS &&
                   CODE_ALBUM == aLBUMS.CODE_ALBUM &&
                   TITRE_ALBUM == aLBUMS.TITRE_ALBUM;
        }

        public override string ToString()
        {
            return this.TITRE_ALBUM;
        }
    }
}
