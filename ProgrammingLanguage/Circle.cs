using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    class Circle : DrawCommand
    {
        int radius;

        public Circle()
        {

        }

        /// <summary>
        /// draw a circle around the cursor
        /// </summary>
        /// <param name="Canvase">Canvase this command is affecting</param>
        /// <param name="radius">radius of the circle</param>
        public Circle(Canvas canvas, int radius) : base(canvas)
        {
            Name = "Circle";
            this.radius = radius;
        }

        public override bool Execute()
        {
            this.ProcessParameters("=" + this.ParameterList, out int[] ParamsInt);
            this.ParseParameters(ParamsInt);
            this.radius = ParamsInt[0];
            canvas.Circle(radius);
            return true;
        }

        //public new void Set(Canvas canvas, StoredProgram program, String Parameters)
    }
}
