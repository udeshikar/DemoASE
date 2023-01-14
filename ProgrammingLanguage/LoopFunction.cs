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

        public void Execute(Dictionary<string, string> data)
        {
            if (condition.Contains(CONSTANTS.LESSTHAN))
            {
                string[] splitted = condition.Split('<');
                string variable = splitted[0]; // count
                int values = Int32.Parse(splitted[1]); //5
                int value1 = 0;

                if (data.ContainsKey(variable))
                {
                    value1 = Int32.Parse(data[variable]); //count = 1
                }

                for(int i=value1; i < values; i++)
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
                            string[] abc;
                            if (calculation.Contains(CONSTANTS.ADD)) //check for plus
                            {
                                abc = calculation.Split('+');
                                string a = abc[0]; //r
                                int b = Int32.Parse(abc[1]); //10
                                if (data.ContainsKey(strings[0].Trim())) //check for r value in variable
                                {
                                    int c = Int32.Parse(data[strings[0].Trim()]); //r=20
                                    int x = b + c;
                                    data[strings[0].Trim()] = x.ToString();
                                }
                            }
                        }
                        else
                        {
                            String newLine1 = generatingCommands(line, data);
                            parser.ParseCommand(newLine1, true);
                        }
                    }
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
