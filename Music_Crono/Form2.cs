using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music_Crono
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (pass.Text == "neta")
            {
                frm1.up();
                System.Environment.Exit(1);

            }
            else
            {
                this.Close();
            }

        }
        public Form1 frm1 = new Form1();
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
            
        }
    }
}
