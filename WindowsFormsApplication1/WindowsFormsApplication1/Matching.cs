using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace WindowsFormsApplication1
{
    public partial class Matching : Form
    {
        Connections ss = new Connections();
        //List<Tweet_Owner_List_Frame> myt = new List<Tweet_Owner_List_Frame>();
        List<Tweet_Frame> myt = new List<Tweet_Frame>();
        public Matching()
        {
            
            InitializeComponent();
            listView1.Cursor = Cursors.Default;
        }

        private void Execute_button_Click(object sender, EventArgs e)
        {
            
            //listView1.Clear();
            Thread t = new Thread(new ThreadStart(Loading));
            t.Start();

            ss.loadTweet_Frame(textBox1.Text.ToString(), myt);
            
            for (int i = 0; i < myt.Count; i++)
            {
                ListViewItem lvl = new ListViewItem(myt[i].getScreenName().ToString());
                lvl.SubItems.Add(myt[i].getTweets().ToString());
                lvl.SubItems.Add(myt[i].getDate().ToShortDateString());
               // lvl.SubItems.Add(myt[i].getLast_Update().ToShortDateString());
                //lvl.SubItems.Add(myt[i].getNumber_Of_Tweets().ToString());
                listView1.Items.Add(lvl);
            }

            t.Abort();

            label2.Text = myt.Count.ToString() +" Rows are selected ";
        }
        public void Loading()
        {

            Application.Run(new Loading());
        }
        private void Close_key_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
