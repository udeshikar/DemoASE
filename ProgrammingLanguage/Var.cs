using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    class Var
    {
        public String varName;
        public int value;
        public String expression;

        public Var()
        {
            
        }

        public Var(string varName, int value, string expression)
        {
            this.varName = varName;
            this.value = value;
            this.expression = expression;
        }


    }
}
