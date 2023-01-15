using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    class FlashingThreads
    {
        Thread newThread;
        Boolean flag = false;
        Color color1;
        Color color2;
        Canvas canvas;

        public FlashingThreads(Color color1, Color color2, Canvas canvas)
        {
            this.color1 = color1;
            this.color2 = color2;
            this.canvas = canvas;
            newThread = new Thread(ThreadMethod);   
            newThread.Start();
        }

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
