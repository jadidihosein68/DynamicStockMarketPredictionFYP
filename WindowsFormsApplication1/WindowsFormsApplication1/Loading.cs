using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Loading : Form
    {
        DateTime Starttime = DateTime.Now;


     
        public Loading()
        {
            
            InitializeComponent();
            this.TopMost = true;
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            DateTime end = DateTime.Now;
            TimeSpan t = end - Starttime;
            string answer = answer = String.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
            
            Clock.Text = answer.ToString();
            Clock.Refresh();
        }
       
    }
}
