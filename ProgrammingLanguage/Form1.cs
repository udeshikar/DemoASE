using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguage
{
    public partial class Form1 : Form
    {
        Bitmap OutputBitmap = new Bitmap(640, 480);
        Canvas MyCanvas;
        public Form1()
        {
            InitializeComponent();
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
        }

        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //read command line get rid of trailing spaces and convert to lower case
                //String Command = commandLine.Text.Trim().ToLower(); 
                //if(Command == ("line") == true)
                //{
                 //   MyCanvas.DrawLine(160, 120);
                  //  Console.WriteLine("Line");
                //}
                //else if(Command == ("square") == true)
               // {
                   // MyCanvas.DrawSquare(25);
                   // Console.WriteLine("Square");
               // }
                //commandLine.Text == "";
              //  Refresh();

                e.SuppressKeyPress = true;

                try
                {
                    
                }


            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // get graphics context of form
            g.DrawImageUnscaled(OutputBitmap, 0, 0);// put the off screen bitmap on the form
        }
    }
}
