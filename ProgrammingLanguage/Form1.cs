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
        Canvas MyCanvas ;
        Parser parser;
        ProgramWindowHandler program;
        bool draw;

        public Form1()
        {
            InitializeComponent();
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            parser = new Parser(MyCanvas);
        }

        

        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //read command line get rid of trailing spaces and convert to lower case
                String Command = commandLine.Text.Trim().ToLower();

                parser.ParseCommand(Command, true);

                e.SuppressKeyPress = true;
                OutputWindow.Invalidate();
                commandLine.Text = "";
                //clear_OutputWindow();
               
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            this.draw = MyCanvas.draw;
            if (draw == true)
            {
                Graphics g = e.Graphics; // get graphics context of form
                g.DrawImageUnscaled(OutputBitmap, 0, 0);// put the off screen bitmap on the form
            }

            else if (draw == false)
            {
                e.Graphics.Clear(Color.White);
                this.draw = true;
                MyCanvas.draw = true;
                OutputWindow.Invalidate(); 
                
                
            }

            }

        private void Btn_Syntax_Click(object sender, EventArgs e)
        {
            string[] text = ProgramWindow.Lines;
            program = new ProgramWindowHandler(parser);
            program.SeperateLines(text);
        }

        private void Btn_Run_Click(object sender, EventArgs e)
        {
            string[] text = ProgramWindow.Lines;
            program = new ProgramWindowHandler(parser);
            program.SeperateLines(text);
            OutputWindow.Invalidate();
            //ProgramWindow.Clear();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            String path = "E:\\Lectures\\Assignment\\saved.txt";
            System.IO.File.WriteAllText(@path, ProgramWindow.Text.Replace("\n", Environment.NewLine));
        }

        private void Btn_Load_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
                if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ProgramWindow.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }
    }
}
