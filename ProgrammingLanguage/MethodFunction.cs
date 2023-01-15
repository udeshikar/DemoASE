using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    class MethodFunction
    {
        //String[] variables;
        public string[] body = null;
        Parser parser;

        public MethodFunction(string[] body, Parser parser)
        {
            //this.variables = variables;
            this.body = body;
            this.parser = parser;
        }

        public void Execute(Dictionary<string, string> userGivenVariables)
        {
            foreach (String line in body)
            {
                if (line.Contains("method") || line.Contains("end"))
                {
                    continue;
                }
                else
                {
                    String newLine1 = generatingCommands(line, userGivenVariables);
                    parser.ParseCommand(newLine1, true);
                } 
            }
        }

        public String generatingCommands(String commandLine, Dictionary<string, string> userGivenVariables)
        {
            String[] commandAndValue = commandLine.ToLower().Split(' ');

            if (commandAndValue.Length > 0 && commandAndValue[0].Equals("circle"))
            {
                if (userGivenVariables.ContainsKey(commandAndValue[1]))
                {
                    String s = userGivenVariables[commandAndValue[1]];
                    String command = "circle " + s;
                    commandLine = command;
                }
            }
            else if (commandAndValue.Length > 0 && commandAndValue[0].Equals("rect"))
            {
                string[] values = commandAndValue[1].Split(',');
                string v1 = values[0];
                string v2 = values[1];

                if (userGivenVariables.ContainsKey(v1))
                {
                    v1 = userGivenVariables[values[0]];
                }

                if (userGivenVariables.ContainsKey(v2))
                {
                    v2 = userGivenVariables[v2];
                }
                string command = "rect " + v1 + "," + v2;
                commandLine = command;
            }


            return commandLine;
        }
    }
}
