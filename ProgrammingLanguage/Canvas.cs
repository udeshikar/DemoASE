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
        Graphics g;
        int XCanvasSize = 493; 
        int YCanvasSize = 425;
        Pen pen;
        int xPos, yPos;
        int radius, width, height;
        public bool draw = true;
        int currentX, currentY;
        Color color = Color.Black;
        String shape;
        
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
                ErrorMessage("Invalid Screen Position");
                return;
            }
                
            g.DrawLine(pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos= toY;
        }

        /// <summary>
        /// Move the current position of the cursor to the given point
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
        /// Draw a circle of radius around the current position for a given radius value
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
            this.shape = "circle";
            this.radius = radius;
        }

        /// <summary>
        /// Draw a rectangle from current pen position for a given width and height
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
            this.shape = "rect";
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Draw a triangle from current pen position for given coordinates
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

        /// <summary>
        /// Remove all the drawings from canvas and clear it
        /// </summary>
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
        /// <param name="givenColor">Given color for pen to draw</param>
        public void PenColor(String givenColor)
        {
            if(givenColor == "red")
            {
                this.pen = new Pen(Color.Red, 1);
                this.color = Color.Red;
            }
            else if(givenColor == "blue")
            {
                this.pen = new Pen(Color.Blue, 1);
                this.color = Color.Blue;
            }
            else if (givenColor == "yellow")
            {
                this.pen = new Pen(Color.Yellow, 1);
                this.color = Color.Yellow;
            }
            else if(givenColor == "green")
            {
                this.pen = new Pen(Color.Green, 1);
                this.color = Color.Green;
            }
            else if(givenColor == "black")
            {
                this.pen = new Pen(Color.Black, 1);
                this.color = Color.Black;
            }
            else if (givenColor == "white")
            {
                this.pen = new Pen(Color.White, 1);
                this.color = Color.White;
            }
            else
            {
                ErrorMessage("Value is not accepted for given colors");
                return;
            }
        }

        /// <summary>
        /// Fill the last drawn shape with the given color or remove filling
        /// </summary>
        /// <param name="fillCondition">Condition to decide whether to fill the shape or not</param>
        public void fillShape(String fillCondition)
        {
            if(fillCondition.Equals("on"))
            {
                if(this.shape == "circle")
                {
                    SolidBrush brush = new SolidBrush(this.color);
                    g.FillEllipse(brush, xPos - this.radius, yPos - this.radius, this.radius * 2, this.radius * 2);
                }
                else if(this.shape == "rect")
                {
                    SolidBrush brush = new SolidBrush(this.color);
                    g.FillRectangle(brush, xPos - (this.width / 2), yPos - (this.width / 2), this.width, this.height);
                }
            }
            else if (fillCondition.Equals("off"))
            {
                if (this.shape == "circle")
                {
                    SolidBrush brush = new SolidBrush(Color.Transparent);
                    g.FillEllipse(brush, xPos - this.radius, yPos - this.radius, this.radius * 2, this.radius * 2);
                }
                else if (this.shape == "rect")
                {
                    SolidBrush brush = new SolidBrush(Color.Transparent);
                    g.FillRectangle(brush, xPos - (this.width / 2), yPos - (this.width / 2), this.width, this.height);
                }
            }
        }

        /// <summary>
        /// Show error messages on the canvas
        /// </summary>
        /// <param name="msg">Message to be shown on the canvas</param>
        public void ErrorMessage(String msg)
        {
            Font font = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.DarkRed);
            g.DrawString(msg, font, brush, xPos, yPos);
        }

        /// <summary>
        /// Fill the color of a shape using given colors
        /// </summary>
        /// <param name="color">Given color to fill the shape</param>
        public void flashColors(Color color)
        {
            if (this.shape == "circle")
            {
                SolidBrush b = new SolidBrush(color);
                g.FillEllipse(b, xPos - this.radius, yPos - this.radius, this.radius * 2, this.radius * 2);
            }
            else if (this.shape == "rect")
            {
                SolidBrush b = new SolidBrush(color);
                g.FillRectangle(b, xPos - (this.width / 2), yPos - (this.width / 2), this.width, this.height);
            }
        }
    }
}
