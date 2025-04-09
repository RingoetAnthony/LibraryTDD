using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTDD.Models.Exceptions
{
    public class ISBNDuplicateException : Exception
    {
        public ISBNDuplicateException():base("ISBN EXISTS")
        {
                
        }
    }
}
