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

        public void Execute(Dictionary<string, string> userGivenVariables)
        {
            
            if (condition.Contains(CONSTANTS.EQUALSIF))
            {
                String splitter = "==";
                string[] splitted = condition.Split(new[] { splitter }, StringSplitOptions.None)
                       .Select(value => value.Trim())
                       .ToArray();
                string variable = splitted[0];
                int conditionValue2 = Int32.Parse(splitted[1]);
                int conditionValue1 = 0;

                if (userGivenVariables.ContainsKey(variable))
                {
                    conditionValue1 = Int32.Parse(userGivenVariables[variable]);
                }

                if(conditionValue1 == conditionValue2)
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
                int conditionValue2 = Int32.Parse(splitted[1]);
                int conditionValue1 = 0;

                if (userGivenVariables.ContainsKey(variable))
                {
                    conditionValue1 = Int32.Parse(userGivenVariables[variable]);
                }

                if (conditionValue1 < conditionValue2)
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
                int conditionValue2 = Int32.Parse(splitted[1]);
                int conditionValue1 = 0;

                if (userGivenVariables.ContainsKey(variable))
                {
                    conditionValue1 = Int32.Parse(userGivenVariables[variable]);
                }

                if (conditionValue1 > conditionValue2)
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
