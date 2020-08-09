using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Media;
using System.Runtime.InteropServices;

namespace Music_Crono
{
    public partial class Form1 : Form
    {
        public int h, m, s;
        public Form1()
        {
            InitializeComponent();
            
        }

        public void mute()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMAND_VOLUME_MUTE);
        }

        public void up()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMAND_VOLUME_UP);
        }



        int hms;
        int mms;
        int sms;
        int timeremain;
        private const int APPCOMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMAND_VOLUME_UP = 0xA0000;
        private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        public int calculate()
        {
            h =0+ Convert.ToInt32(hour.Text);
            m =0+ Convert.ToInt32(min.Text);
            s =0+ Convert.ToInt32(sec.Text);
            hms = h * 60 * 60 * 1000;
            mms = m * 60 * 1000;
            sms = s * 1000;
            timeremain = hms + mms + sms;
            return timeremain;
        }
        public Form3 web = new Form3();
        private void button1_Click(object sender, EventArgs e)
        {
            
            web.Show();
            web.loadweb();

            if (calculate() == 0)
            {
                MessageBox.Show("Introdu timp");
            }
            else
            {

                up();
                starttime();
                running = true;
            }
            

        }

        Timer MyTimer = new Timer();

        private void sec_Leave(object sender, EventArgs e)
        {
            if (sec.Text =="")
            { sec.Text = "0"; }
        }

        private void min_Leave(object sender, EventArgs e)
        {
            if (min.Text == "")
            { min.Text = "0"; }
        }

        private void hour_Leave(object sender, EventArgs e)
        {
            if (hour.Text == "")
            { hour.Text = "0"; }
        }

       
        
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Form2 frm2 = new Form2();

            
            frm2.Show();
            
           // this.WindowState = FormWindowState.Minimized;
            
            

        }

        private void sec_Enter(object sender, EventArgs e)
        {
            sec.Text = "";
        }

        private void min_Enter(object sender, EventArgs e)
        {
            min.Text = "";
        }

        private void hour_Enter(object sender, EventArgs e)
        {
            hour.Text = "";
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            this.WindowState=FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mute();
        }

        public bool running;
        public void starttime ()
        {
            
            MyTimer.Interval = (1000); // 45 mins
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            hour.Enabled = false;
            min.Enabled = false;
            sec.Enabled = false;
            button1.Enabled = false;
            MyTimer.Start();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            s --;
            if (s < 0)
            {
                m--;
                s = 59;
            } else if ((m < 0)&&(s<0))
            {
                h--;
                m = 59;

            } else if ((h==0)&&(m==0)&&(s==0))
            {
                MyTimer.Stop();
                
                running = false ;
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMAND_VOLUME_MUTE);
                hour.Enabled = true;
                min.Enabled = true;
                sec.Enabled = true;
                button1.Enabled = true;
                
                web.Hide();
                MessageBox.Show("A expirat timpu'");
            }
            sec.Text = s.ToString();
            min.Text = m.ToString();
            hour.Text = h.ToString();
            web.timertick(h, m, s);
            // SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMAND_VOLUME_MUTE);

            
            

        }


    }
}
