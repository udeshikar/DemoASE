using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    class Rectangle
    {
        Canvas canvas;
        int width, height;

        public Rectangle(Canvas canvas, int width, int height)
        {
            this.canvas = canvas;
            this.width = width;
            this.height = height;
        }

        public void Execute()
        {
            canvas.Rect(width, height);
        }
    }
}
