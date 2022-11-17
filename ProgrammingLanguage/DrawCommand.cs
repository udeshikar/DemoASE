using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    public abstract class DrawCommand : Command
    {
        protected Canvas canvas;

        public DrawCommand()
        {

        }

        /// <summary>
        /// Immediate execution of moving cursor to x,y
        /// </summary>
        /// <param name="canvas"></param>
        public DrawCommand(Canvas canvas)
        {
            this.canvas = canvas;
        }

        /// <summary>
        /// Parse the parameters to the derived class and set them up
        /// </summary>
        /// <param name="ParameterList"></param>
        public abstract void ParseParameters(int[] ParameterList);

        public void Set(Canvas canvas, StoredProgram program, String Name)
        {
            base.Set(Program, Name, "");
            this.canvas = canvas;
        }

        public Canvas Canvas()
        {
            return canvas;
        }
    }
}
