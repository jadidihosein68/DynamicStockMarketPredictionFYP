using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToTwitter;
using System.IO;
using System.Threading;
namespace WindowsFormsApplication1
{
    public partial class TwitterManagement : Form
    {
        private const string accessToken = "1262316374-4xVwPrTd7QVrlG85sI7s1kYIR70fJxdHIBWVh7R" ;
        private  const string accessTokenSecret = "zoUEWaiL2d3covAyNxoLxN2SflhCIpurAqUHChbUdaocc"; //"Access token secret goes here .. (Please generate your own)";
        private const string consumerKey = "jARWSMjoR9IqwZHUFWvi9E4fl";//"Api key goes here .. (Please generate your own)";
        // Api secret goes here .. (Please generate your own)
        private const string consumerSecret = "7TuZodFcdOPYQhHF3HqjcdJjB6y3B4a4wxngXctgTPkkOvBAIn";//"Api secret goes here .. (Please generate your own)";
        Connections ss;
        // The twitter account name goes here

        List<Tweet_Owner_List_Frame> myt = new List<Tweet_Owner_List_Frame>();

        void Loadlistview()
        {
            myt.Clear();
            ss.loadTweet_Owner_List_Frame(@"select Screen_Name, MIN (TweetID) , MAX(TweetID) , max(dates),COUNT(Tweets) from TweetsDB group by Screen_Name", myt);
            int count = 0; 
            for (int i = 0; i < myt.Count; i++)
            {
                ListViewItem lvl = new ListViewItem(myt[i].getScreen_Name());
                lvl.SubItems.Add(myt[i].getBigest_Tweet_ID().ToString());
                lvl.SubItems.Add(myt[i].getSmallest_Tweet_ID().ToString());
                lvl.SubItems.Add(myt[i].getLast_Update().ToShortDateString());
                lvl.SubItems.Add(myt[i].getNumber_Of_Tweets().ToString());
                listView1.Items.Add(lvl);
                count += myt[i].getNumber_Of_Tweets();
 
            }
            label1.Text = "Total number of user = " + listView1.Items.Count.ToString();
            label2.Text = "Total number of Tweets = " + count; //+ mamal.ToString() ;

        } 
        public TwitterManagement()
        {
            ss = new Connections();
            
            InitializeComponent();
            User.MouseEnter += new EventHandler(User_MouseEnter);
            Menu.MouseEnter += new EventHandler(Menue_MouseEnter);
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            //IDradioButton.Enabled=false;
            Loadlistview();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;


        }

        void Menue_MouseEnter(object sender, EventArgs e)
        {
            Status.Text = "Back to Main menu page";
        }

        void User_MouseEnter(object sender, EventArgs e)
        {
            Status.Text = "Extract a specific user Tweets";
        }

        private void User_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Screen name is blank");
                return;
            
            }


            for (int i = 0; i < listView1.Items.Count; i++)
            {


                if (textBox1.Text.ToString() == listView1.Items[i].SubItems[0].Text.ToString())
                {
                    MessageBox.Show("The " + textBox1.Text.ToString() + " Tweets exist in row " + (i + 1) + " please press update button ");
                    return;
                }
            }



            ////////////////////////// should be removed 
            /*
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please choose your table name");
                return;
            }
            */
            /*
            if (!ss.TableIsExist(textBox2.Text + "_TweetTable"))
            {
                ss.createTable("create table  " +
                textBox2.Text + "_TweetTable ( " +
                "Screen_Name varchar(30), " +
                "TweetID bigint primary key , " +
                "dates Date , " +
                "Tweets varchar (200) " +
                ");");

            }
            else
            {
                MessageBox.Show("Sorry the table name is already in use, please choose an other name");
                return;
            }
            */
            ///////////////////////////////////////////////
            Thread t = new Thread(new ThreadStart(Loading));
            t.Start();
            try
            {

                string twitterAccountToDisplay = textBox1.Text;

                var authorizer = new SingleUserAuthorizer
                {
                    CredentialStore = new InMemoryCredentialStore
                    {
                        ConsumerKey = consumerKey,
                        ConsumerSecret = consumerSecret,
                        OAuthToken = accessToken,
                        OAuthTokenSecret = accessTokenSecret
                    }
                };
                var twitterContext = new TwitterContext(authorizer);
                var statusTweets = from tweet in twitterContext.Status
                                   where
                                   tweet.Type == StatusType.User &&
                                   tweet.ScreenName == twitterAccountToDisplay &&
                                   tweet.IncludeContributorDetails == true &&
                                   tweet.Count == 200 &&
                                   tweet.IncludeEntities == true
                                   //&& tweet.MaxID == 295989270949281792
                                   select tweet;
                ulong temp = 0;
                int i = 0;
                List<Tweet_Frame> mystorage = new List<Tweet_Frame>();
                foreach (var statusTweet in statusTweets)
                {
                    i++;
                    DateTime dt = Convert.ToDateTime(statusTweet.CreatedAt);
                    mystorage.Add(new Tweet_Frame(statusTweet.StatusID, dt , statusTweet.Text.ToString(),statusTweet.ScreenName.ToString()));
                    if (i == 200)
                    {
                        temp = statusTweet.StatusID;
                    }
                }
                            while (i != 0 )
                            {
                                //MessageBox.Show(i.ToString());
                                                //var twitterContext2 = new TwitterContext(authorizer);
                                                var statusTweets2 = from tweet in twitterContext.Status
                                                   where
                                                           tweet.Type == StatusType.User &&
                                                           tweet.ScreenName == twitterAccountToDisplay &&
                                                           tweet.IncludeContributorDetails == true &&
                                                           tweet.Count == 200 &&
                                                           tweet.IncludeEntities == true
                                                            && tweet.MaxID == temp -1
                                                   select tweet;
                                                 i = 0;
                                                 foreach (var statusTweet in statusTweets2)
                                                 {
                                                     i++;
                                                     DateTime dt = Convert.ToDateTime(statusTweet.CreatedAt);
                                                     mystorage.Add(new Tweet_Frame(statusTweet.StatusID, dt, statusTweet.Text.ToString(), statusTweet.ScreenName.ToString()));
                                                  
                                                 }
                                                 temp = mystorage[mystorage.Count - 1].getTweetID();
                            }
                            
               // MessageBox.Show("a total number of " + mystorage.Count.ToString() + " Tweets are downloaded ");
                label3.Text = "Screen Name = " + textBox1.Text.ToString();           
                label4.Text = "Total Tweets = " + mystorage.Count.ToString();
              /*  
                string karim = "";
                foreach (Tweet_Frame elemet in mystorage) // Loop through List with foreach
                {
                    karim += "Date = " + elemet.getDate().ToShortDateString()  + " ID = " + elemet.getTweetID().ToString() + " Tweet = " + elemet.getTweets().ToString() + " Screen name = "+  elemet.getScreenName() ;
                }
                System.IO.File.WriteAllText(@"O:\Subjects\Trimester 9\Fyp part 2\Tweet export file\WriteLines.txt", karim);
                */

                ss.insertToTwitterTable(mystorage, "TweetsDB");
                label5.Text = "Data are inserted Successfully";
                /*
                ss.insert("insert into Tweet_Owner_List values ('" 
                    
                    + textBox2.Text + "_TweetTable','"
                    + mystorage[0].getScreenName() 
                    + "'," + mystorage[0].getTweetID().ToString()
                    + " , " + mystorage[mystorage.Count - 1].getTweetID().ToString() + ", '" + DateTime.Now.ToString("M/d/yyyy")+"' );");
                */
                /*
                ListViewItem item1 = new ListViewItem (textBox2.Text + "_TweetTable");
                item1.SubItems.Add(textBox1.Text);
                item1.SubItems.Add(mystorage[mystorage.Count - 1].getTweetID().ToString());
                item1.SubItems.Add(mystorage[0].getTweetID().ToString());
                item1.SubItems.Add(DateTime.Now.ToString("M/d/yyyy"));
                listView1.Items.Add(item1);
                */
            
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    listView1.Items.Remove(eachItem);
                }
                Loadlistview();
                t.Abort();
            }
            catch (Exception exx)
            {
                t.Abort();
                label5.Text = "Mission Aborted due to Error !";
                MessageBox.Show(exx.ToString());
            }
            //System.IO.File.WriteAllText(@"O:\Subjects\Trimester 9\Fyp part 2\Tweet export file\WriteLines.txt", mystorage);
           // TextWriter tw = new StreamWriter("myFile.txt");
           // foreach (MacroEvent mystorage in events)
           // {
            //    tw.WriteLine(item.ToString());
           // }
            //tw.Close();      
            
           
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Loading()
        {

            Application.Run(new Loading());
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (IDradioButton.Checked == true )
            { 
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
               

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
                else
                {
                    Status.Text = "Twitter ID can accept number only";
                }
        
            }
             */ 
        }

        private void IDradioButton_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void Update_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button is not finished the update function");
            if (this.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Twitter data set to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ulong templong = Convert.ToUInt64(this.listView1.SelectedItems[0].SubItems[3].Text.ToString());
//            ulong temp = 0;
                int i = 0;
                List<Tweet_Frame> mystorage = new List<Tweet_Frame>();
                string twitterAccountToDisplay = textBox1.Text;
                var authorizer = new SingleUserAuthorizer
                {
                    CredentialStore = new InMemoryCredentialStore
                    {
                        ConsumerKey = consumerKey,
                        ConsumerSecret = consumerSecret,
                        OAuthToken = accessToken,
                        OAuthTokenSecret = accessTokenSecret
                    }
                };
                var twitterContext = new TwitterContext(authorizer);

            while (i != 0)
            {
                //MessageBox.Show(i.ToString());
                //var twitterContext2 = new TwitterContext(authorizer);
                var statusTweets2 = from tweet in twitterContext.Status
                                    where
                                            tweet.Type == StatusType.User &&
                                            tweet.ScreenName == twitterAccountToDisplay &&
                                            tweet.IncludeContributorDetails == true &&
                                            tweet.Count == 200 &&
                                            tweet.IncludeEntities == true
                                             && tweet.SinceID == templong + 1
                                    select tweet;
                i = 0;
                foreach (var statusTweet in statusTweets2)
                {
                    i++;
                    DateTime dt = Convert.ToDateTime(statusTweet.CreatedAt);
                    mystorage.Add(new Tweet_Frame(statusTweet.StatusID, dt, statusTweet.Text.ToString(), statusTweet.ScreenName.ToString()));

                }
                templong = mystorage[mystorage.Count - 1].getTweetID();
            }
            MessageBox.Show("a total number of " + mystorage.Count + " Tweets were updated ");

        }


      
    }
}
