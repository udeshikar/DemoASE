using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    /// <summary>
    /// Circle class execute the drawing circle function on form
    /// </summary>
    class Circle 
    {
        Canvas canvas;
        int radius;

        public Circle()
        {

        }

        /// <summary>
        /// Constructor initializes the circle to a given radius value on given canvas
        /// </summary>
        /// <param name="canvas">Canvase this command is affecting</param>
        /// <param name="radius">radius of the circle</param>
        public Circle(Canvas canvas, int radius) 
        {
            this.canvas = canvas;
            this.radius = radius;
        }

        /// <summary>
        /// Executing the command to draw a circle
        /// </summary>
        public void Execute()
        {
            canvas.Circle(radius);
        }

    }
}
