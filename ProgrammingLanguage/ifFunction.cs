using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    class IfFunction
    {
        public string[] body = null;
        public string[] splitCondition = new string[2];
        public string condition;
        Parser parser;

        public IfFunction(string condition, string[] body, Parser parser)
        {
            this.condition = condition;
            this.body = body;
            this.parser = parser;
        }

        public void Execute(Dictionary<string, string> data)
        {
            
            if (condition.Contains(CONSTANTS.EQUALSIF))
            {
                String splitter = "==";
                string[] splitted = condition.Split(new[] { splitter }, StringSplitOptions.None)
                       .Select(value => value.Trim())
                       .ToArray();
                string variable = splitted[0];
                int values = Int32.Parse(splitted[1]);
                int value1 = 0;

                if (data.ContainsKey(variable))
                {
                    value1 = Int32.Parse(data[variable]);
                }

                if(value1 == values)
                {
                    foreach(string line in body)
                    {
                        if(line.Contains("if") || line.Contains("end"))
                        {
                            continue;
                        }
                        else
                        {
                            parser.ParseCommand(line, true);
                        }
                    }
                }

            }
            else if (condition.Contains(CONSTANTS.LESSTHAN))
            {
                string[] splitted = condition.Split('<');
                string variable = splitted[0];
                int values = Int32.Parse(splitted[1]);
                int value1 = 0;

                if (data.ContainsKey(variable))
                {
                    value1 = Int32.Parse(data[variable]);
                }

                if (value1 < values)
                {
                    foreach (string line in body)
                    {
                        if (line.Contains("if") || line.Contains("end"))
                        {
                            continue;
                        }
                        else
                        {
                            parser.ParseCommand(line, true);
                        }
                    }
                }

            }
            else if (condition.Contains(CONSTANTS.GREATERTHAN))
            {
                string[] splitted = condition.Split('>');
                string variable = splitted[0];
                int values = Int32.Parse(splitted[1]);
                int value1 = 0;

                if (data.ContainsKey(variable))
                {
                    value1 = Int32.Parse(data[variable]);
                }

                if (value1 > values)
                {
                    foreach (string line in body)
                    {
                        if (line.Contains("if") || line.Contains("end"))
                        {
                            continue;
                        }
                        else
                        {
                            parser.ParseCommand(line, true);
                        }
                    }
                }
            }
        }
    }
}
