using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    class Parser
    {
        private const int MaxParams = 10;
        Canvas Canvas;

        public Parser(Canvas canvas)
        {
            this.Canvas = canvas;
            canvas.updateCursor();
        }

        public Command ParseCommand(String line, bool execute)
        {
            int x = 0, y = 0;
            line = line.Trim();
            if (line.Length == 0)
                throw new ApplicationException("\nCommand was blank ");
            String Command;

            String[] split = line.Split(' ');
            String[] Parameters = new string[MaxParams];
            int[] ParamList = new int[MaxParams];

            Command = split[0];

            if(split.Length > 1)
            {
                Parameters = split[1].Split(',');

                //convert parameters
                for(int i = 0; i < Parameters.Length; i++)
                {
                    try
                    {
                        ParamsInt[i] = Int32.Parse(Parameters[i]);
                    }
                    catch(FormatException e)
                    {
                        throw new ApplicationException("\n Not a numeric parameter ");
                    }
                }
            }

            if(Command.Equals("moveto") == "true")
            {
                if (Parameters.Length != 2)
                    throw new ApplicationException("\n Invalid number of parameters for moveTo");

                MoveTo c = (MoveTo)CommFactory.MakeCommand("moveto");
                c.Set(Canvas, "MoveTo", ParamsInt[0], ParamsInt[1]);
                if(execute) c.Execute();
                return c;
            }
            else if (Command.Equals("drawto") == "true")
            {
                if (Parameters.Length != 2)
                    throw new ApplicationException("\n Invalid number of parameters for drawTo");

                MoveTo c = (MoveTo)CommFactory.MakeCommand("drawto");
                c.Set(Canvas, "DrawTo", ParamsInt[0], ParamsInt[1]);
                if (execute) c.Execute();
                return c;
            }
            else if(Command.Equals("circle") == true)
            {
                if (Parameters.Length != 1)
                    throw new ApplicationException("\nInvalid number of parameters for circle");

                Circle c = (Circle)CommFactory.MakeCommand("circle");
                if(execute) c.Execute();
                return c;
            }
        }
    }
}
