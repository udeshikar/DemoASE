using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    class DrawTo 
    {
        protected int xPos, yPos;
        Canvas canvas;

        public DrawTo()
        {

        }

        public DrawTo(Canvas canvas, int xPos, int yPos) 
        {
            this.canvas = canvas;
            this.xPos = xPos;
            this.yPos = yPos;
            //Name = "DrawTo";
        }

        public void Execute()
        {
            canvas.DrawTo(xPos, yPos);
        }

        //public void Set(Canvas canvas, String name, int x, int y)
        //{
        //base.Set(canvas, name);
        //this.xPos = x;
        //this.yPos = y;
        //}

        //public override void Execute()
        //{
        //    try
        //    {
        //        canvas.DrawTo(xPos, yPos);
        //    }
        //    catch(ApplicationException e)
        //    {

        //    }
        //}

        
    }
}
