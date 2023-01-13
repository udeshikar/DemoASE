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

            for (int i = 0; i < text.Length; i++)
            {
                splitText[i] = text[i].ToString().Trim().ToLower();
                //parser.ParseCommand(splitText[i], true);
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
            }

            return text;
        }
        
        
        

        
    }
}
