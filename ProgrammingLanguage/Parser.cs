﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    class Parser
    {
        private const int MaxParams = 10;
        Canvas Canvas;
        Circle circle;
        Rectangle rect;
        bool draw;
        DrawTo drawLine;

        public Parser()
        {
        }

        public Parser(Canvas canvas)
        {
            this.Canvas = canvas;
        }

        public void ParseCommand(string line, bool execute)
        {
            //int x = 0, y = 0;
            line = line.Trim();
            if (line.Length == 0)
                throw new ApplicationException("\nCommand was blank ");
            String Command;

            String[] split = line.Split(' ');
            String[] Parameters = new string[MaxParams];
            int[] ParamList = new int[MaxParams];

            Command = split[0];

            
            if (split.Length > 1 & Command.Equals("pen") == false)
            {
                Parameters = split[1].Split(',');

                //convert parameters
                for(int i = 0; i < Parameters.Length; i++)
                {
                    try
                    {
                        ParamList[i] = Int32.Parse(Parameters[i]);
                        Console.WriteLine(ParamList[i]);
                    }
                    catch(FormatException e)
                    {
                        throw new ApplicationException("\n Not a numeric parameter ");
                    }
                }
            }

            else if (Command.Equals("pen") == true)
            {
                Canvas.PenColor(split[1]);
            }



            if(Command.Equals("circle") == true)
            {
                if (Parameters.Length != 1)
                    throw new ApplicationException("\nInvalid number of parameters for circle");

                circle = new Circle(Canvas, ParamList[0]);
                circle.Execute();
                //Canvas.Circle(ParamList[0]);
            }

            else if (Command.Equals("rect") == true)
            {
                if (Parameters.Length != 2)
                    throw new ApplicationException("\nInvalid number of parameters for Rectangle");

                rect = new Rectangle(Canvas, ParamList[0], ParamList[1]);
                rect.Execute();
            }

            else if (Command.Equals("drawto") == true)
            {
                if (Parameters.Length != 2)
                    throw new ApplicationException("\nInvalid number of parameters for Line");

                drawLine = new DrawTo(Canvas, ParamList[0], ParamList[1]);
                drawLine.Execute();
            }

            else if(Command.Equals("moveto") == true)
            {
                Canvas.MoveTo(ParamList[0], ParamList[1]);
            }

            else if(Command.Equals("clear") == true)
            {
                Canvas.Clear();
            }

            else if(Command.Equals("reset") == true)
            {
                Canvas.Reset();
            }

        }
    }
}
