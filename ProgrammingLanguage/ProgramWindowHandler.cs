using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguage
{
    class ProgramWindowHandler
    {
        Canvas canvas;
        Parser parser;
        int maxLimit = 100;
        int count = 0;
        public ProgramWindowHandler(Parser parser)
        {
            //this.canvas = canvas;
            this.parser = parser;
        }

        public void SeperateLines(String[] text)
        {
            //string[] text = richText.Lines;
            String[] splitText = new String[maxLimit];

            var variables = defineVariables(text);
            String[] newData = generatingCommands(text, variables);
            string[] modifiedAfterIF = ifHandler(newData, variables);

            for (int i = 0; i < modifiedAfterIF.Length; i++)
            {
                splitText[i] = modifiedAfterIF[i].ToString().Trim().ToLower();
                parser.ParseCommand(splitText[i], true);
            }
            
        }

        public Dictionary<string, string> defineVariables(String[] text)
        {
            String[] store = new String[maxLimit];
            String[] variables = new string[maxLimit];
            var map = new Dictionary<string, string>();



            foreach (String line in text)
            {
                if (line.Contains("="))
                {
                    variables = line.Split('=');
                    variables[0] = variables[0].Trim();
                    variables[1] = variables[1].Trim();

                    if (map.ContainsKey(variables[0]))
                    {
                        map.Add(variables[1], variables[1]);
                    }
                    else
                    {
                        map.Add(variables[0], variables[1]);
                    }
                }
            }
            return map;

        }

        public String[] generatingCommands(String[] text, Dictionary<string, string> data)
        {
            
            for(int i=0; i < text.Length; i++)
            {
                String[] commandAndValue = text[i].ToLower().Split(' ');

                if(commandAndValue.Length > 0 && commandAndValue[0].Equals("circle"))
                {
                    if (data.ContainsKey(commandAndValue[1]))
                    {
                        String s = data[commandAndValue[1]];
                        String command = "circle " + s;
                        text[i] = command;
                    }
                }
                else if(commandAndValue.Length >0 && commandAndValue[0].Equals("rect"))
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
                    string command = "rect " + v1 +"," + v2;
                    text[i] = command;
                }
            }

            return text;
        }

        public string[] ifHandler(String[] text, Dictionary<string, string> data)
        {
            string[] modifiedData = null;

            foreach (String line in text)
            {
                String condition;
                if (line.Contains("if"))
                {
                    String splitter = "if";
                    string[] splitted = line.Split(new[] { splitter }, StringSplitOptions.None)
                           .Select(value => value.Trim())
                           .ToArray();
                    condition = splitted[1];

                    String[] methodBody = ifMethodBody(text);
                    modifiedData = text.Except(methodBody).ToArray();
                    ifFunction operationIF = new ifFunction(condition, methodBody, parser);
                    operationIF.Execute(data);
                    break;
                }
                else
                {
                    modifiedData = text;
                }

            }
            return modifiedData;
        }

        public String[] ifMethodBody(String[] text)
        {
            int start = -1;
            int end = -1;
            String[] body = new string[text.Length];
            for(int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("if"))
                {
                    start = i;
                }

                if (text[i].Contains("end"))
                {
                    end = i;
                }
            }

            if (start >= 0 && end >= 0)
            {
                body = new string[end - start + 1];
                for (int j = 0; j < body.Length; j++)
                {
                    body[j] = text[start + j];
                }
            }
            return body;
        }




    }
}
