using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{
    public partial class EMPRUNTER
    {
        public bool enRetard()
        {
            bool test = false;
            if(DATE_RETOUR > DATE_RETOUR_ATTENDUE.AddDays(10))
            {
                test = true;
            }
            return test;
        }
        
    }
}
