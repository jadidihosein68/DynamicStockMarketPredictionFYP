using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Tweet_Owner_List_Frame
    {
        private int Number_Of_Tweets ;
        private string Screen_Name ; 
        private ulong Bigest_Tweet_ID ; 
        private ulong Smallest_Tweet_ID ;
        private DateTime Last_Update ;
        private DateTime smallest_Day ;

        public int getNumber_Of_Tweets() { return Number_Of_Tweets; }
        public string getScreen_Name() { return Screen_Name; }
        public ulong getBigest_Tweet_ID() { return Bigest_Tweet_ID; }
        public ulong getSmallest_Tweet_ID() { return Smallest_Tweet_ID; }
        public DateTime getLast_Update() { return Last_Update; }

        public DateTime getSmallest_Day(){return smallest_Day;}

        public Tweet_Owner_List_Frame( string Screen_Name_, ulong Bigest_Tweet_ID_, ulong Smallest_Tweet_ID_, DateTime Last_Update_,int Number_Of_Tweets_)
        {
            Number_Of_Tweets = Number_Of_Tweets_;
            Screen_Name = Screen_Name_ ;
            Bigest_Tweet_ID = Bigest_Tweet_ID_;
            Smallest_Tweet_ID = Smallest_Tweet_ID_;
            Last_Update = Last_Update_;
        }

    }
}
