using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    /// <summary>
    /// MethodFunction class execute commands that are inside of a method body
    /// </summary>
    class MethodFunction
    {
        public string[] body = null;
        Parser parser;
        String perameter = null;
        String parameterValues = null;

        /// <summary>
        /// Constructor initializes values for bethod body
        /// </summary>
        /// <param name="body"></param>
        /// <param name="parser"></param>
        public MethodFunction(string[] body, Parser parser, string perameter, string parameterValues)
        {
            this.body = body;
            this.parser = parser;
            this.perameter = perameter;
            this.parameterValues = parameterValues;
        }

        /// <summary>
        /// Execute methods provided by the user if the method is called
        /// </summary>
        /// <param name="userGivenVariables">Variables given by the user</param>
        public void Execute(Dictionary<string, string> userGivenVariables)
        {
            if(perameter == null)
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
            else
            {
                if(perameter.Contains(","))
                {
                    //have more than one parameter
                    String[] parameterVariables = perameter.Split(',');
                    String[] parameterVariableValues = parameterValues.Split(',');

                    for(int j=0; j<body.Length; j++)
                    {
                        if (body[j].Contains("method") || body[j].Contains("end"))
                        {
                            continue;
                        }
                        else
                        {
                            for(int i = 0; i < parameterVariables.Length; i++)
                            {
                                if (body[j].Contains(parameterVariables[i]))
                                {
                                    if (body[j].Contains("="))
                                    {
                                        string[] splits = body[j].Split('=');
                                        if (splits[1] == parameterVariables[i])
                                        {
                                            splits[1] = parameterVariableValues[i];
                                            body[j] = splits[0] + "=" + splits[1];
                                        }
                                            
                                    }
                                    else
                                    {
                                        string[] splits = body[j].Split(' ');
                                        if (splits[0] == "circle")
                                        {
                                            if (splits[1] == parameterVariables[i])
                                            {
                                                splits[1] = parameterVariableValues[i];
                                                body[j] = splits[0] + " " + splits[1];
                                            }
                                        }
                                        else if (splits[0] == "rect")
                                        {
                                            String[] arr4 = splits[1].Split(',');
                                            if (arr4[0] == parameterVariables[i])
                                            {
                                                arr4[0] = parameterVariableValues[i];
                                            }
                                            else if (arr4[1] == parameterVariables[i])
                                            {
                                                arr4[1] = parameterVariableValues[i];
                                            }
                                            body[j] = splits[0] + " " + arr4[0] +"," + arr4[1];
                                        }
                                    }

                                }
                            }
                            String newLine1 = generatingCommands(body[j], userGivenVariables);
                            parser.ParseCommand(newLine1, true);
                        }
                    }
                }
                else
                {
                    for(int i=0; i<body.Length; i++)
                    {
                        if (body[i].Contains("method") || body[i].Contains("end"))
                        {
                            continue;
                        }
                        else
                        {
                            if (body[i].Contains(perameter))
                            {
                                if (body[i].Contains("="))
                                {
                                    string[] splits = body[i].Split('=');
                                    if (splits[1] == perameter)
                                    {
                                        splits[1] = parameterValues;
                                        body[i] = splits[0] + "=" + splits[1];
                                    }

                                }
                                else
                                {
                                    string[] splits = body[i].Split(' ');
                                    if (splits[1] == perameter)
                                    {
                                        splits[1] = parameterValues;
                                        body[i] = splits[0] + " " + splits[1];
                                    }
                                }
                            }
                            String newLine1 = generatingCommands(body[i], userGivenVariables);
                            parser.ParseCommand(newLine1, true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Assign variable values to commands if exists
        /// </summary>
        /// <param name="commandLine">Command with a variable value</param>
        /// <param name="userGivenVariables">Variables given by the user</param>
        /// <returns>proper string command without variables</returns>
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
