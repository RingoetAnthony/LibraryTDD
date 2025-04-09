using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTDD.Models.Exceptions
{
    public class NegativeCopiesException : Exception
    {
        public NegativeCopiesException() : base("Le nombre de copies ne peut pas être négatif")
        { 
                    
        }
    }
}
