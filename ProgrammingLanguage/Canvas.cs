using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguage
{
    /// <summary>
    /// Canvas class holds information that is displayed on the form in response to simple programming language commands 
    /// </summary>

    class Canvas
    {
        //instance data for pen and x,y positions and  graphics context
        Graphics g, cursorG;
        int XCanvasSize, YCanvasSize;
        Pen pen;
        int xPos, yPos;

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

        public Canvas(Graphics g, Graphics cursorG) 
        {
            this.g=g;
            this.cursorG = cursorG;
            XCanvasSize = XSize;
            YCanvasSize = YSize;
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);

        }

        public void Clear()
        {
           // g.Clear(background_color);
        }


        /// <summary>
        /// Draw a line from current Pen position (xPos, yPos)
        /// </summary>
        /// <param name="toX">X position to draw to</param>
        /// <param name="toY">Y position to draw to</param>
        public void DrawLine(int toX, int toY)
        {
            g.DrawLine(pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos = toY;
        }

        public void DrawTo(int toX, int toY)
        {
            if (toX < 0 || toX > XCanvasSize || toY < 0 || toY > YCanvasSize)
                throw new ApplicationException("Invalid Screen Position");
            g.DrawLine(pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos= toY;
            updateCursor();
        }

        public void MoveTo(int x, int y)
        {
            if (toX < 0 || toX > XCanvasSize || toY < 0 || toY > YCanvasSize)
                throw new ApplicationException("Invalid Screen Position");
            g.DrawLine(pen, xPos, yPos, toX, toY);
            xPos = x;
            yPos = y;
            updateCursor();
        }

        /// <summary>
        /// Draw a rectangle from current pen position
        /// </summary>
        /// <param name="width">Width of the rectangle to be drawn</param>
        public void DrawSquare(int width)
        {
            g.DrawRectangle(pen, xPos, yPos, xPos + width, yPos + width);
        }

        /// <summary>
        /// Draw a circle of radius around the position
        /// </summary>
        /// <param name="radius">radius of circle</param>
        public void Circle(int radius)
        {
            if (radius < 0)
                throw new ApplicationException("\ninvalid size for radius");
                g.DrawEllipse(pen, xPos-radius, yPos-radius, radius * 2, radius * 2);
        }

        public void Rect(int width, int height)
        {
            if (width < 0 || height < 0)
                throw new ApplicationException("\ninvalid rectangle size");
            g.DrawRectangle(pen, xPos-(width/2), yPos-(width/2), width, height);
        }
    }
}
