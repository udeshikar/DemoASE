using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    /// <summary>
    /// Rectangle class execute drawing rectangles on canvas
    /// </summary>
    class Rectangle
    {
        Canvas canvas;
        int width, height;

        /// <summary>
        /// Initializes the constructor for given canvas, widdth and height values
        /// </summary>
        /// <param name="canvas">canvas to work with</param>
        /// <param name="width">width of the constructor to be drawn</param>
        /// <param name="height">height of the constructor to be drawn</param>
        public Rectangle(Canvas canvas, int width, int height)
        {
            this.canvas = canvas;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Execute the command to draw a rectangle
        /// </summary>
        public void Execute()
        {
            canvas.Rect(width, height);
        }
    }
}
