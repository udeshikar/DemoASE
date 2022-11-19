using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    /// <summary>
    /// abstract class abstraction for commands to add to a program
    /// </summary>
    public abstract class Command : Commands
    {
        private String name = "";
       // private StoredProgram program;
        private String parameterlist; //original parameter list

        public Command()
        {

        }

        /// <summary>
        /// Execute the given command, If the command is a conditional it returns false
        /// </summary>
        /// <returns>false if a conditional command returned a negative value</returns>
        public abstract bool Execute(); //run this command, return whether the next command should be executed

       // public StoredProgram Program()


    }
}
