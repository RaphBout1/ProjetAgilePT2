using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{
    /// <summary>
    /// Lancée quand une requête envers la base de donnée n'est pas valide ou n'aurait pas le comportement attendu
    /// </summary>
    class databaseException : Exception
    {
        string message;
        public databaseException(string message) : base(message)
        {
            this.message = message;
        }

        public override string ToString()
        {
            return message;
        }
    }
}
