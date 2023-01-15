using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    class LoopFunction
    {
        public string[] body = null;
        public string[] splitCondition = new string[2];
        public string condition;
        Parser parser;
        ProgramWindowHandler programWindowHandler;

        public LoopFunction(string condition, string[] body, Parser parser)
        {
            this.condition = condition;
            this.body = body;
            this.parser = parser;
        }

        /// <summary>
        /// Executing Loop functions provided by user
        /// </summary>
        /// <param name="userGivenVariables">Variables given by the user</param>
        public void Execute(Dictionary<string, string> userGivenVariables)
        {
            if (condition.Contains(CONSTANTS.LESSTHAN))
            {
                string[] splitted = condition.Split('<');
                string variable = splitted[0]; // count
                int conditionValue2 = Int32.Parse(splitted[1]); //5
                int conditionValue1 = 0;

                if (userGivenVariables.ContainsKey(variable))
                {
                    conditionValue1 = Int32.Parse(userGivenVariables[variable]); //count = 1
                }

                for(int i=conditionValue1; i < conditionValue2; i++)
                {
                    foreach(String line in body)
                    {
                        if (line.Contains("while") || line.Contains("endloop"))
                        {
                            continue;
                        }
                        else if (line.Contains("="))
                        {
                            string[] strings = line.Split('=');
                            string calculation = strings[1]; // r+10
                            string[] variablesToCalculate;
                            if (calculation.Contains(CONSTANTS.ADD)) //check for plus
                            {
                                variablesToCalculate = calculation.Split('+');
                                string value1 = variablesToCalculate[0]; //r
                                int value2 = Int32.Parse(variablesToCalculate[1]); //10
                                if (userGivenVariables.ContainsKey(strings[0].Trim())) //check for r value in variable
                                {
                                    int c = Int32.Parse(userGivenVariables[strings[0].Trim()]); //r=20
                                    int x = value2 + c;
                                    userGivenVariables[strings[0].Trim()] = x.ToString();
                                }
                            }
                        }
                        else
                        {
                            String newLine1 = generatingCommands(line, userGivenVariables);
                            parser.ParseCommand(newLine1, true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generating commands by assigning variable values to commands
        /// </summary>
        /// <param name="commandLine">Command with a variable value</param>
        /// <param name="userGivenVariables">Variables given by the user</param>
        /// <returns></returns>
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
