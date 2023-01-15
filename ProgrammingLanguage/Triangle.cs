using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    /// <summary>
    /// Triangle class execute drawing triangles on canvas
    /// </summary>
    class Triangle
    {
        Canvas canvas;
        int p1, p2, p3, p4;

        public Triangle(Canvas canvas, int p1, int p2, int p3, int p4)
        {
            this.canvas = canvas;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
        }

        /// <summary>
        /// Execute command to draw a traingle
        /// </summary>
        public void Execute()
        {
            canvas.Triangle(p1, p2, p3, p4);
        }
    }
}
