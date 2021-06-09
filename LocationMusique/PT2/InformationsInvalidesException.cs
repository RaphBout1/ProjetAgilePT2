using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT2
{
    /// <summary>
    /// Lancée lorsque les informations passées dans un formulaire ne sont pas valides
    /// </summary>
    public class InformationsInvalidesException : Exception
    {
        string message;
        public InformationsInvalidesException(string message) : base(message)
        {
            this.message = message;
        }

        public override string ToString()
        {
            return message;
        }
    }
}