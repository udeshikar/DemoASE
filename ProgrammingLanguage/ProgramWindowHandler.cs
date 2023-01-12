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
            

            for(int i = 0; i < text.Length; i++)
            {
                splitText[i] = text[i].ToString().Trim().ToLower();
                //parser.ParseCommand(splitText[i], true);
            }
            defineVariables(splitText);
        }

        public void defineVariables(String[] text)
        {
            String[] store = new String[maxLimit];
            String[] variables = new string[maxLimit];
            

            foreach (String line in text)
            {
                //splitText[i] = text[i].ToString().Trim().ToLower();
                //store variables
                if (line.Contains("="))
                {
                    variables = line.Split('=');
                    store[count] = variables[0];
                    store[count + 1] = variables[1];
                    count++;
                }

                if (line.Contains("if") || line.Contains("while"))
                {
                    break;
                }
            }
        }
    }
}
