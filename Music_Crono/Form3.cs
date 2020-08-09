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
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();

            


        }
        
        public void loadweb()
        {
            Form1 frm1 = new Form1();
            
            webBrowser1.Navigate("www.youtube.com");
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
        }
        public void timertick(int a, int b, int c)
        {
            timer.Text = a + " : " + b + " : " + c;
        }
        
    }
}
