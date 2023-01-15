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

        public void Execute(Dictionary<string, string> data)
        {
            foreach (String line in body)
            {
                if (line.Contains("method") || line.Contains("end"))
                {
                    continue;
                }
                else
                {
                    String newLine1 = generatingCommands(line, data);
                    parser.ParseCommand(newLine1, true);
                } 
            }
        }

        public String generatingCommands(String text, Dictionary<string, string> data)
        {
            String[] commandAndValue = text.ToLower().Split(' ');

            if (commandAndValue.Length > 0 && commandAndValue[0].Equals("circle"))
            {
                if (data.ContainsKey(commandAndValue[1]))
                {
                    String s = data[commandAndValue[1]];
                    String command = "circle " + s;
                    text = command;
                }
            }
            else if (commandAndValue.Length > 0 && commandAndValue[0].Equals("rect"))
            {
                string[] values = commandAndValue[1].Split(',');
                string v1 = values[0];
                string v2 = values[1];

                if (data.ContainsKey(v1))
                {
                    v1 = data[values[0]];
                }

                if (data.ContainsKey(v2))
                {
                    v2 = data[v2];
                }
                string command = "rect " + v1 + "," + v2;
                text = command;
            }


            return text;
        }
    }
}
