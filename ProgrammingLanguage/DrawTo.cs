using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    /// <summary>
    /// DrawTo class execute the drawing function on form
    /// </summary>
    class DrawTo 
    {
        protected int xPos, yPos;
        Canvas canvas;

        public DrawTo()
        {

        }

        /// <summary>
        /// Constructor initializes the x and y positions of the curser on given canvas
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        public DrawTo(Canvas canvas, int xPos, int yPos) 
        {
            this.canvas = canvas;
            this.xPos = xPos;
            this.yPos = yPos;
        }

        /// <summary>
        /// Execute the command to draw a line
        /// </summary>
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
