using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT2
{
    class InformationsInvalidesException : Exception
    {
        public InformationsInvalidesException(string message) : base(message)
        {
            MessageBox.Show("message");
        }
    }
}