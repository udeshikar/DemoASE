using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    
    public interface Commands
    {
        /// <summary>
        /// Execute the given command
        /// </summary>
        /// <returns>lines to jump +/- usually 1 to signify no jump</returns>

        bool Execute();
    }
}
