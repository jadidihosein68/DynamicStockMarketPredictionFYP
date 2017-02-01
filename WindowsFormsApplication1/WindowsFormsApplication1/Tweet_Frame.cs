using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Tweet_Frame
    {
        private ulong TweetID;
        private string Screen_Name;
        private DateTime Date;
        private string Tweets;

        public ulong getTweetID()
        {
            return TweetID ;
        }
        public DateTime getDate()
        {
            return Date;
        }
        public string getTweets()
        {
            return Tweets;
        }

        public void setTweets(string temp)
        {

            Tweets = temp;
        }


        public string getScreenName()
        {

            return Screen_Name;

        }
        /*
        public Tweet_Frame(ulong TweetID_, DateTime Date_, string Tweets_)
        {
            this.TweetID = TweetID_;
            this.Date = Date_;
            this.Tweets = Tweets_;

        }*/
        public Tweet_Frame(ulong TweetID_, DateTime Date_, string Tweets_, string Screen_Name_)
        {
            this.TweetID = TweetID_;
            this.Date = Date_;
            this.Tweets = Tweets_;
            this.Screen_Name =Screen_Name_;
        }

        public string TweetFrames_ToString() {
            return Screen_Name + "," + TweetID + "," + Date.ToString("yyyy-MM-dd") + "," + Tweets;
        }
     



    }
}
