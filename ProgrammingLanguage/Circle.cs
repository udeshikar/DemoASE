using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    class Circle 
    {
        Canvas canvas;
        int radius;
        String name;

        public Circle()
        {

        }

        /// <summary>
        /// draw a circle around the cursor
        /// </summary>
        /// <param name="Canvase">Canvase this command is affecting</param>
        /// <param name="radius">radius of the circle</param>
        public Circle(Canvas canvas, int radius) 
        {
            this.canvas = canvas;
            this.radius = radius;
        }

        public void Execute()
        {
            canvas.Circle(radius);
        }

    }
}
