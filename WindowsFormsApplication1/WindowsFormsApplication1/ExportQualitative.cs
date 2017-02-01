using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class ExportQualitative : Form
    {
        Connections ss;
        List<Tweet_Owner_List_Frame> myt = new List<Tweet_Owner_List_Frame>();
        void Loadlistview()
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            myt.Clear();
            ss.loadTweet_Owner_List_Frame(@"select Screen_Name, MIN (TweetID) , MAX(TweetID) , max(dates),COUNT(Tweets) from TweetsDB group by Screen_Name", myt);

            for (int i = 0; i < myt.Count; i++)
            {
                ListViewItem lvl = new ListViewItem(myt[i].getScreen_Name());
               // lvl.SubItems.Add(myt[i].getBigest_Tweet_ID().ToString());
               // lvl.SubItems.Add(myt[i].getSmallest_Tweet_ID().ToString());
                lvl.SubItems.Add(myt[i].getLast_Update().ToShortDateString());
                lvl.SubItems.Add(myt[i].getNumber_Of_Tweets().ToString());
                listView1.Items.Add(lvl);
            }
        }
        public ExportQualitative()
        {
            InitializeComponent();
            ss = new Connections();
            Loadlistview();

        }
        public void Loading() {
            Application.Run(new Loading());
        
        }
        private void button2_Click(object sender, EventArgs e)
        {

            Thread t = new Thread(new ThreadStart(Loading));
            
            if (ss.TableIsExist("TweetsDB_Temp_for_Weka"))
                ss.dropTable("drop table TweetsDB_Temp_for_Weka");

            //MessageBox.Show(ss.TableIsExist("TweetsDB_Temp_for_Weka").ToString());
            

          
            
            List<Tweet_Frame> temps = new List<Tweet_Frame>();
            if (this.listView1.SelectedItems.Count == 0 & checkBox1.Checked == false)
            {
                MessageBox.Show("Please select a Table to export ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            t.Start();

            if (checkBox1.Checked)
            {
                if (checkBox2.Checked == false )
                    ss.loadTweet_Frame(textBox1.Text.ToString(), temps);
                else {
                    //MessageBox.Show("creating temp table");
                    ss.update("select *  into TweetsDB_Temp_for_Weka from(" + textBox1.Text.ToString() + ") as mt");
                    //MessageBox.Show("Removing enter");
                    ss.update("update TweetsDB_Temp_for_Weka set Tweets = REPLACE(REPLACE(Tweets, CHAR(13), ''), CHAR(10), '')");
                    ss.update("update TweetsDB_Temp_for_Weka set Tweets = "
                    +"REPLACE(REPLACE(Tweets, '\"', ''), '\"', '')");
                   
                    //MessageBox.Show("Loading data ");
                    ss.loadTweet_Frame("select * from TweetsDB_Temp_for_Weka", temps);
                    ss.dropTable("drop table TweetsDB_Temp_for_Weka");
                    //MessageBox.Show("data is clean now :)");
                }
            
            }
            else 
            {
                if (checkBox2.Checked == false)
                    ss.loadTweet_Frame("select * from TweetsDB where Screen_Name='" + this.listView1.SelectedItems[0].SubItems[0].Text.ToString() + "'", temps);
                else
                {
                    ss.update("select *  into TweetsDB_Temp_for_Weka from TweetsDB where Screen_Name='" + this.listView1.SelectedItems[0].SubItems[0].Text.ToString() + "'");
                    ss.update("update TweetsDB_Temp_for_Weka set Tweets = REPLACE(REPLACE(Tweets, CHAR(13), ''), CHAR(10), '')");
                    ss.update("update TweetsDB_Temp_for_Weka set Tweets = "
                    + "REPLACE(REPLACE(Tweets, '\"', ''), '\"', '')");
                    
                    ss.loadTweet_Frame("select * from TweetsDB_Temp_for_Weka", temps);
                    ss.dropTable("drop table TweetsDB_Temp_for_Weka");
                }
            
            }

            if (checkBox3.Checked)
            {
                
                for (int i = 0; i < temps.Count; i++)
                    while (temps[i].getTweets().IndexOf("http:") != -1)
                    {
                        
                        // while 
                        int temp = temps[i].getTweets().IndexOf("http:");
                        //MessageBox.Show(mylist[1].Contains(':').ToString()); // -1 for not founding 
                        int temp2 = temps[i].getTweets().IndexOf(' ', temp + 1);
                        if (temp2 == -1)
                            temp2 = temps[i].getTweets().Length;

                        temps[i].setTweets(temps[i].getTweets().Remove(temp, temp2 - temp));
                    }
            }

            if (checkBox2.Checked)
            {

                for (int i = 0; i < temps.Count; i++)
                    //Console.Write(tweets[i].Tweets + "\n");
                    if (temps[i].getTweets()[0] != '\"')
                        temps[i].setTweets("\"" + temps[i].getTweets() + "\"");
            }


            t.Abort();
            MessageBox.Show("a Total number of "+temps.Count.ToString()+" Rows are selected");
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            Export exp = new Export();


            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.ValidateNames = true;
            saveFileDialog1.DereferenceLinks = false;
            saveFileDialog1.Filter = "Excel |*.xlsx|CSV|*.csv";
            //saveFileDialog1.Filter = "CSV|*.csv";
            saveFileDialog1.Title = "Export Tweet"; 
            saveFileDialog1.ShowDialog();
            Thread t2 = new Thread(new ThreadStart(Loading));
            t2.Start();
            if (saveFileDialog1.FileName != "")
            {
               // System.IO.FileStream fs =
                //(System.IO.FileStream)saveFileDialog1.OpenFile();

                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        //label1.Text = saveFileDialog1.FileName.ToString();
                        exp.ExportTweetDB(temps, saveFileDialog1.FileName.ToString());
                        break;
                    case 2:

                        //MessageBox.Show(saveFileDialog1.FileName.ToString());
                        try
                        {
                            StringBuilder builder = new StringBuilder();
                            string headers = "Screen Name,Tweet ID,Dates,Tweets";
                            builder.Append(headers).Append("\n");
                            for (int i = 0; i < temps.Count; i++)
                            {
                                builder.Append(temps[i].TweetFrames_ToString()).Append("\n");
                            }
                            
                            using (StreamWriter writer =
                            //new StreamWriter("Final.csv"))
                            new StreamWriter(saveFileDialog1.FileName.ToString()))
                            {
                                writer.Write(builder);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        break;
                }
               // fs.Close();
            }
            MessageBox.Show("Export done sucessfully !");
            
            t2.Abort();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Get file name.
            string name = saveFileDialog1.FileName;
            // Write to the file name selected.
            // ... You can write the text from a TextBox instead of a string literal.

            MessageBox.Show("karim benzama");
            File.WriteAllText(name, "test");

        }

        
        
        
        

    }
}
