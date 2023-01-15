using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    /// <summary>
    /// Flashing thread class execute the thread to flash colors on shapes
    /// </summary>
    class FlashingThreads
    {
        Thread newThread;
        Boolean flag = false;
        Color color1;
        Color color2;
        Canvas canvas;

        /// <summary>
        /// Constructor initializes the given colors and the thread 
        /// </summary>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        /// <param name="canvas"></param>
        public FlashingThreads(Color color1, Color color2, Canvas canvas)
        {
            this.color1 = color1;
            this.color2 = color2;
            this.canvas = canvas;
            newThread = new Thread(ThreadMethod);   
            newThread.Start();
        }

        /// <summary>
        /// Thread method to fill two colors continuosly for a given shape
        /// </summary>
        public void ThreadMethod()
        {
            while (true)
            {
                if (flag == false)
                {
                    canvas.flashColors(color1);
                    flag = true;
                }
                else
                {
                    canvas.flashColors(color2);
                    flag = false;
                }
                Thread.Sleep(500);
            }
        }
    }
}
