using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class InitMyProgram
    {
        Connections conn = new Connections();
       

        public InitMyProgram()
        {
           // Loading load = new Loading();
           // load.label1.Text = ("Checking Histoorical_Stock_Table Existance (Historical Stock Data)");
           // load.label1.Refresh();
            //load.Show();
            check_Histoorical_Stock_Table();
            //load.label1.Text = ("Checking Stock_Name Existance (Real time Stock Data)");
            //load.label1.Refresh();
            check_Stock_Name();
            //load.label1.Text = ("Checking Analyse_lists Existance");
            //load.label1.Refresh();
            check_analyse_lists();

            /*
            load.label1.Text = ("Checking Tweet_Owner_List Existance");
            load.label1.Refresh();
            check_Tweet_Owner_List();
            */
           // load.label1.Text = ("Checking TweetsDB Existance");
            //load.label1.Refresh();
            Check_TweetsDB();

            //load.Close();


            
        }

        /*
         * the function below check wheather Histoorical_Stock_Table exist or not 
         * if exist function will return null
         * else function will create the table 
         */
        public void check_Histoorical_Stock_Table()
        {
            if (conn.TableIsExist("Histoorical_Stock_Table"))
                return;

                string query =
                " create table Histoorical_Stock_Table (" +
                "Stock_Symbol varchar (30)," +
                "Stock_Table varchar (30)," +
                "LastUpdate date," +
                "primary key (Stock_Symbol)" +
                ");";
                conn.createTable(query);
        }

        /*
         * the function below check wheather Stock_Name exist or not 
         * if exist function will return null
         * else function will create the table 
         */

        public void check_Stock_Name()
        {
            if (conn.TableIsExist("Stock_Name"))
                return;

            string query =
            "create table Stock_Name (" +
            "Symbol varchar (30) , " +
            "Table_Name varchar (30)," +
            "STATUS bit," +
            "LastUpdate  date " +
            ")";
                conn.createTable(query);
        }

        public void check_analyse_lists () {

            if (conn.TableIsExist("analyse_lists"))
                return;

            string query =   "create table analyse_lists"+
            "( Stock_Symbol varchar (30),"+
            "Stock_Table_name varchar (30),"+
            "Sratring_date date,"+
            "Last_date date,"+
            "primary key (Stock_Table_name)" +
            ")";
            conn.createTable(query);
        }

        public void check_Tweet_Owner_List()
        {

            if (conn.TableIsExist("Tweet_Owner_List"))
                return;

            string query = "create table Tweet_Owner_List (" +
                    "Table_Name varchar (60) primary key, " +
                    "Screen_Name varchar (40) , "+ 
                    "Bigest_Tweet_ID bigint, "+ 
                    "Smallest_Tweet_ID bigint, "+
                    "Last_Update date  "+
                    "); " ;
            conn.createTable(query);
        }
        public void Check_TweetsDB()
        {
            if (conn.TableIsExist("TweetsDB"))
                return;

            string query = "create table  " +
                "TweetsDB ( " +
                "Screen_Name varchar(30), " +
                "TweetID bigint , " +
                "dates Date , " +
                "Tweets varchar (200) " +
                ", primary key (TweetID,dates) );";
            conn.createTable(query);

        
        
        }



    }
}
