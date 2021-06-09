using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{
    /// <summary>
    /// Lancée lorsque le prolongement d'un emprunt ne peut pas être effectué
    /// </summary>
    public class ProlongementEmpruntException : Exception
    {
        string message;
        public ProlongementEmpruntException(string message) : base(message)
        {
            this.message = message;
        }

        public override string ToString()
        {
            return message;
        }
    }
}
