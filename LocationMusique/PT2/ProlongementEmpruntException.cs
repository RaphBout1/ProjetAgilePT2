using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{
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
