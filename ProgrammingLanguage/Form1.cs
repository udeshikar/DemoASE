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
        public Form1()
        {
            InitializeComponent();
        }

        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Key Down");
            if(e.KeyCode == Keys.Enter)
            {
                Console.WriteLine("Enter Pressed");
            }
        }
    }
}
