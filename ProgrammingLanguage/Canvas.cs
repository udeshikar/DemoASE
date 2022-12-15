using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguage
{
    /// <summary>
    /// Canvas class holds information that is displayed on the form in response to simple programming language commands 
    /// </summary>

    class Canvas
    {
        //instance data for pen and x,y positions and  graphics context
        Graphics g, cursorG;
        int XCanvasSize = 493; 
        int YCanvasSize = 425;
        Pen pen;
        int xPos, yPos;
        int toX = 0;
        int toY = 0;
        public bool draw = true;
        int currentX, currentY;
        
        /// <summary>
        /// Constructor initialize canvas to black pen at 0,0
        /// </summary>
        /// <param name="g"> Graphics context of place to draw on</param>
        public Canvas(Graphics g)
        {
            this.g = g;
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
        }

        /// <summary>
        /// Draw a line from current Pen position (xPos, yPos)
        /// </summary>
        /// <param name="toX">X position to draw to</param>
        /// <param name="toY">Y position to draw to</param>
        public void DrawTo(int toX, int toY)
        {
            if (toX < 0 || toX > XCanvasSize || toY < 0 || toY > YCanvasSize)
            {
                //throw new ApplicationException("Invalid Screen Position");
                ErrorMessage("Invalid Screen Position");
                return;
            }
                
            g.DrawLine(pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos= toY;
           // updateCursor();
        }

        /// <summary>
        /// Move the current position of the cursor
        /// </summary>
        /// <param name="x">new x value</param>
        /// <param name="y">new y value</param>
        public void MoveTo(int x, int y)
        {
            if (x < 0 || x > XCanvasSize || y < 0 || y > YCanvasSize)
            {
                //throw new ApplicationException("Invalid Screen Position");
                ErrorMessage("Invalid Screen Position");
                return;
            }

            xPos = x;
            yPos = y;
        }

        /// <summary>
        /// Draw a circle of radius around the position
        /// </summary>
        /// <param name="radius">radius of circle</param>
        public void Circle(int radius)
        {
            if (radius < 0)
            {
                //throw new ApplicationException("\ninvalid size for radius");
                ErrorMessage("invalid size for radius");
                return;
            }
               
            g.DrawEllipse(pen, xPos-radius, yPos-radius, radius * 2, radius * 2);
        }

        /// <summary>
        /// Draw a rectangle from current pen position
        /// </summary>
        /// <param name="width">Width of the rectangle to be drawn</param>
        public void Rect(int width, int height)
        {
            if (width < 0 || height < 0)
            {
                //throw new ApplicationException("\ninvalid rectangle size");
                ErrorMessage("invalid rectangle size");
                return;
            }
                
            g.DrawRectangle(pen, xPos-(width/2), yPos-(width/2), width, height);
        }

        /// <summary>
        /// Draw a triangle from current pen position
        /// </summary>
        /// <param name="p1">x value of second point of rectangle</param>
        /// <param name="p2">y value of second point of rectangle</param>
        /// <param name="p3">x value of third point of rectangle</param>
        /// <param name="p4">y value of third point of rectangle</param>
        public void Triangle(int p1, int p2, int p3, int p4)
        {
            if(p1 < 0 || p2 < 0 || p3 < 0 || p4 < 0)
            {
                MessageBox.Show("invalid traingle size");
                return;
            }

            currentX = xPos;
            currentY = yPos;

            this.DrawTo(p1, p2);
            this.DrawTo(p3, p4);
            this.DrawTo(currentX, currentY);
        }

        public void Clear()
        {
            this.g.Clear(Color.Transparent);
        }

        /// <summary>
        /// Set the cursor back to the initial position
        /// </summary>
        public void Reset()
        {
            this.xPos = 0; 
            this.yPos = 0;
        }

        /// <summary>
        /// Set a given color for pen
        /// </summary>
        /// <param name="color"></param>
        public void PenColor(String color)
        {
            if(color == "red")
            {
                this.pen = new Pen(Color.Red, 1);
            }
            else if(color == "blue")
            {
                this.pen = new Pen(Color.Blue, 1);
            }
            else if(color == "green")
            {
                this.pen = new Pen(Color.Green, 1);
            }
            else if(color == "black")
            {
                this.pen = new Pen(Color.Black, 1);
            }
            else
            {
                ErrorMessage("Value is not accepted for given colors");
                return;
            }
        }

        public void ErrorMessage(String msg)
        {
            Font font = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.DarkRed);
            g.DrawString(msg, font, brush, xPos, yPos);
        }
    }
}
