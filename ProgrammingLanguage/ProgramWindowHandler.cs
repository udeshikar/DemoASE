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
        bool valid;
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
                parser.ParseCommand(splitText[i], true);
            }
            

        }
    }
}
