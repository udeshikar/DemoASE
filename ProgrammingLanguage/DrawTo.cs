using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    class DrawTo : DrawCommand
    {
        protected int xPos, yPos;

        public DrawTo()
        {

        }

        public DrawTo(Canvas canvas, int xPos, int yPos) : base(canvas)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            Name = "DrawTo";
        }

        public void Set(Canvas canvas, String name, int x, int y)
        {
            base.Set(canvas, name);
            this.xPos = x;
            this.yPos = y;
        }

        public override void Execute()
        {
            try
            {
                canvas.DrawTo(xPos, yPos);
            }
            catch(ApplicationException e)
            {

            }
        }
    }
}
