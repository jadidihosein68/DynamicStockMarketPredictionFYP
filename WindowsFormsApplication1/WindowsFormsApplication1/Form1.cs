using System;


using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Net.NetworkInformation;

namespace WindowsFormsApplication1
{
    public partial class FYP : Form
    {

        List<Table_Stock_Info> myt = new List<Table_Stock_Info>();              // For database select pupose
        List<Historical_Table_Frame> HistoricalTable = new List<Historical_Table_Frame>();  // For database select pupose
        string StockNames = "";
        Connections ss;         // for connecting purpose 
        int Min = 15;
        int Sec = 0;
        bool done = false;
        public FYP()
        {
            InitializeComponent();
            /*
             * the Try below load the data ito the list 
             */
            this.TopMost = true;
            try{
                ss = new Connections();
                ss.loadRunTimeStockInfo("SELECT * FROM Stock_Name where STATUS != 0 ;", myt);
                ss.loadHistoricalStockInfo("SELECT * FROM Histoorical_Stock_Table", HistoricalTable);
                }
            catch (SqlException ex){
                MessageBox.Show(ex.ToString());
            }

           int counter = 0 ;
           /* the for loop below write daily data into the list view and create the download connection string 
            * 
            * 
            */
            for (int i = 0; i < myt.Count; i++){
                ListViewItem lvl = new ListViewItem(myt[i].getSymbol());
                lvl.SubItems.Add(myt[i].getName());
                lvl.SubItems.Add(myt[i].getStatus().ToString());
                lvl.SubItems.Add(myt[i].getDate().ToString());
                listView1.Items.Add(lvl);
                StockNames += myt[i].getSymbol();
                if (myt.Count - counter > 1)
                    StockNames += "+";
                counter++;
             }

            for (int i = 0; i < HistoricalTable.Count; i++)
            {
                ListViewItem lvl = new ListViewItem(HistoricalTable[i].getSymbol());
                lvl.SubItems.Add(HistoricalTable[i].getTableName());
                lvl.SubItems.Add(HistoricalTable[i].getLastUpdate().ToShortDateString());
                listView2.Items.Add(lvl);
            }

            




        }
        
        private void button1_Click(object sender, EventArgs e)
        {

         

        }


        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {


            if (this.listView1.SelectedItems.Count == 0)
                return;

            StockName.Text = this.listView1.SelectedItems[0].SubItems[0].Text;
            StockName.Refresh();
            
            
            
            
            
            // listView1.Columns.Add("Column4", 100); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            timer1.Start();
        }

        private void Exits_Click(object sender, EventArgs e)
        {
            
            //Application.Exit();
            this.Close();
        }

        /*
         * the function below download real-time data 
         * 
         * 
         */
        private void myfunction()
        {

            string downloadedString;
            // string downloadedString1;        
            System.Net.WebClient client;
            client = new System.Net.WebClient();
            //try { 

            StatusOfConnection.Text = "Downloading .CSV files";
            StatusOfConnection.Refresh();
            downloadedString = client.DownloadString("http://download.finance.yahoo.com/d/quotes.csv?s=" + StockNames + "&f=sl1d1t1c1hgvbap2b4e7jj1j5k2k5m2m5m8oqr7s7t7w1ya2b2dee8kij6lm3m6pp5rr5t8w4b3cc6e9j4k1k4mm4m7p6r1r6t6wx");//hgvbap2b4c8d2e7f6jg3g6j1");
            string unconfirmed = client.DownloadString("http://download.finance.yahoo.com/d/quotes.csv?s=" + StockNames + "&f=l2c8d2g3r2v1c3g4l3e1g1i5n4p1s1g5g6v7s6f0");         
            string DLSTring_Bid_Size = client.DownloadString("http://download.finance.yahoo.com/d/quotes.csv?s=" + StockNames + "&f=b6");
            
            string DLSTring_Market_Cap_Real_time = client.DownloadString("http://download.finance.yahoo.com/d/quotes.csv?s=" + StockNames + "&f=j3");
            
            string DLSTring_Ask_Size = client.DownloadString("http://download.finance.yahoo.com/d/quotes.csv?s=" + StockNames + "&f=a5");
            
            string DLSTring_Last_Trade_Size = client.DownloadString("http://download.finance.yahoo.com/d/quotes.csv?s=" + StockNames + "&f=k3");
            
            string DLSTring_Shares_Outstanding = client.DownloadString("http://download.finance.yahoo.com/d/quotes.csv?s=" + StockNames + "&f=j2"); // j2           

            //s6	Revenue	
            //f0	Trade Links Additional
            //j2	Shares Outstanding      //
      	
            //////////////////////////////////// Lable code 
            StatusOfConnection.Text = "Downloading .CSV files Performed Successfully";
            StatusOfConnection.Refresh();
            //////////////////////////////////// end of Lable code 
            //MessageBox.Show("download Performed Successfully");    
            //}catch (WebException ex){
            //  MessageBox.Show("ex.Tostring");
            //}
            string[] temp = downloadedString.Split(',');
            string [] UCtemp = unconfirmed.Split(',');
            // check container VALIDITY 
            //MessageBox.Show(temp.Length.ToString()); // 61 
            //MessageBox.Show(UCtemp.Length.ToString()); // 18 
            StatusOfConnection.Text = "Cheking .CSV validity";    
            StatusOfConnection.Refresh();
            if (!MyUtility.validNoOfElements(temp, 61))
            {
                MessageBox.Show("Error : .CSV file format is not match Confirmed data are incorrect\nContact administrator");
                StatusOfConnection.Text = ".CSV file format is not match\nContact administrator";
                StatusOfConnection.Refresh();
                return;
            }    
           if ( !MyUtility.validNoOfElements(UCtemp, 20))
            {
                MessageBox.Show("Error : .CSV file format is not match Unconfirmed data are incorrect\nContact administrator");
                StatusOfConnection.Text = ".CSV file format is not match\nContact administrator";
                StatusOfConnection.Refresh();    
                return;
            }
                //MessageBox.Show("Invalid");

            
            // Starting of declaring attribute -------------------------------- To purpose of development all the attributes are shifted to variable first  
            StatusOfConnection.Text = "Start Assigning value to variables";
            StatusOfConnection.Refresh();
            string Symbol = temp[0].Replace("\"", ""); // done
            decimal? Last_Trade_Price_only = MyUtility.getDecimal(temp[1]); // done
            for (int i = 0; i < temp.Length; i++)
                temp[i] = temp[i].Replace("\"", "");
            DateTime date = Convert.ToDateTime(temp[2].Replace("\"", ""));
            temp[3] = temp[3].Replace("\"", "").Insert(temp[3].Length - 4, " ");
            DateTime dates = Convert.ToDateTime(temp[3]);
            TimeSpan span = dates.TimeOfDay;
            // end of conversion 
            DateTime Last_Update_Time = DateTime.Now;       // primary key 
            //MessageBox.Show(temp.Length.ToString());
            DateTime Last_Trade_Date = date + span;             // done
            decimal? Change = MyUtility.getDecimal(temp[4]);    //done
            //MessageBox.Show(temp.Length.ToString());
                    decimal? Days_High = MyUtility.getDecimal(temp[5]);
                    decimal? Days_Low = MyUtility.getDecimal(temp[6]);
            double? Volume = MyUtility.getDouble(temp[7]);
            // MessageBox.Show(temp[8]);
           decimal? Bid = MyUtility.getDecimal(temp[8]);

           // decimal? Bid = 0;//= MyUtility.getDecimal(temp[8]);

            // MessageBox.Show(Bid.ToString());
            //if (decimal.TryParse(temp[8], out Bid))
            //  Bid = decimal.Parse(temp[8]);
            //MessageBox.Show(Bid.ToString());
            //Parse(temp[8]); //
            double? Ask = MyUtility.getDouble(temp[9]);
            string Change_in_percent = temp[10].Replace("\"", "");




            decimal? book_Value = MyUtility.getDecimal(temp[11]);
            //string After_houre_change = temp[12].Replace("\"", "") ;          // c8
            //DateTime? TradeDate = null ;                                                      // d2
            //if (temp[13] != "0" && temp[13] != "-" && temp[13] != "N/A")
            //   TradeDate = Convert.ToDateTime(temp[13].Replace("\"", ""));;    
            decimal? EPS_Estimate_Current_Year = MyUtility.getDecimal(temp[12]);
            decimal? _52_week_Low = MyUtility.getDecimal(temp[13]);


            //  MessageBox.Show(temp[13]);
            // MessageBox.Show(_52_week_Low.ToString());
            //string Annualized_Gain = temp[16].Replace("\"" , "");                             // g3
            //decimal? Holdings_Gain_Real_time = MyUtility.getDecimal(temp[17]);                // g6
            string Market_Capitalization = temp[14]; // since it is based on billion I consider it as string 
            // MessageBox.Show(Change_in_percent + " my new things ");
            decimal? Change_From_52_week_Low = MyUtility.getDecimal(temp[15]);
            string Change_Percent_Real_time = temp[16].Replace("\"", "");		//string
            double? Percent_Change_From_52_week_High = MyUtility.getDouble(temp[17]);
            //decimal? High_Limit=  MyUtility.getDecimal(temp[22]) ;                            //l2
            
            //////////////////////////////////////////////////// parametrized db Failed !
            /*un comment part bellow for parametrized DB
            SqlConnection conn;
            string connection_string = "Data Source=HOSEIN-PC\\SQLEXPRESS;Initial Catalog=FYP;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            conn = new SqlConnection(connection_string);

            try
           {
                
                SqlCommand cmd001 = new SqlCommand(
                "INSERT INTO " + "KLSE_Table_Parametrized " + " VALUES(@Symbol,@Last_Update_Date,@Last_Update_Time,@Last_Trade_Price_only,@Last_Trade_Date"
                + ",@Last_Trade_Time,@Change,@Days_High,@Days_Low,@Volume,@Bid"
                + ",@Ask,@Change_in_percent,@book_Value,@EPS_Estimate_Current_Year"//,@The_52_week_Low"
                //+ ",@Market_Capitalization"+",@Change_From_52_week_Low"//,@Change_Percent_Real_time,@Percent_Change_From_52_week_High"
                + ");"
                    , conn);
                
                cmd001.Parameters.Add("@Symbol", SqlDbType.VarChar);    //1
                cmd001.Parameters["@Symbol"].Value = Symbol;

                cmd001.Parameters.Add("@Last_Update_Date",SqlDbType.Date );//2
                cmd001.Parameters["@Last_Update_Date"].Value = Last_Update_Time.ToShortDateString();

                cmd001.Parameters.Add("@Last_Update_Time",SqlDbType.DateTime );// -- pk//3
                cmd001.Parameters["@Last_Update_Time"].Value = Last_Update_Time.ToLongTimeString();
                 
                cmd001.Parameters.Add("@Last_Trade_Price_only", SqlDbType.Money);//4
                cmd001.Parameters["@Last_Trade_Price_only"].Value = Last_Trade_Price_only;

                cmd001.Parameters.Add("@Last_Trade_Date", SqlDbType.Date);//5
                cmd001.Parameters["@Last_Trade_Date"].Value =Last_Trade_Date.ToShortDateString() ;

                cmd001.Parameters.Add("@Last_Trade_Time", SqlDbType.DateTime);//6
                cmd001.Parameters["@Last_Trade_Time"].Value =Last_Trade_Date.ToLongTimeString(); 

                cmd001.Parameters.Add("@Change", SqlDbType.Money);//7
                cmd001.Parameters["@Change"].Value =Change ;

                cmd001.Parameters.Add("@Days_High", SqlDbType.Money);//8
                cmd001.Parameters["@Days_High"].Value =Days_High ;
 
                cmd001.Parameters.Add("@Days_Low", SqlDbType.Money);//9
                cmd001.Parameters["@Days_Low"].Value =Days_Low ;

                cmd001.Parameters.Add("@Volume", SqlDbType.Float);//10
                cmd001.Parameters["@Volume"].Value = Volume;

                cmd001.Parameters.Add("@Bid",SqlDbType.Money );//11
                cmd001.Parameters["@Bid"].Value = Bid;
                
                cmd001.Parameters.Add("@Ask", SqlDbType.Float);//12
                cmd001.Parameters["@Ask"].Value = Ask;

                cmd001.Parameters.Add("@Change_in_percent", SqlDbType.VarChar);//13
                cmd001.Parameters["@Change_in_percent"].Value =Change_in_percent;
                
                cmd001.Parameters.Add("@book_Value",SqlDbType.Money );//14
                cmd001.Parameters["@book_Value"].Value =book_Value;
                    
                cmd001.Parameters.Add("@EPS_Estimate_Current_Year" ,SqlDbType.Money );//15
                cmd001.Parameters["@EPS_Estimate_Current_Year"].Value =EPS_Estimate_Current_Year;
            */ ///////////////// do not uncomment star bellow 
                /*
                decimal The_52_week_Low = _52_week_Low
                cmd001.Parameters.Add("@The_52_week_Low",SqlDbType.Money );//16
                cmd001.Parameters["The_52_week_Low"].Value =The_52_week_Low;
                cmd001.Parameters.Add("@Market_Capitalization", SqlDbType.VarChar); // 17
                cmd001.Parameters["@Market_Capitalization"].Value =Market_Capitalization;
                cmd001.Parameters.Add("@Change_From_52_week_Low", SqlDbType.Money );
                cmd001.Parameters["@Change_From_52_week_Low"].Value =Change_From_52_week_Low;
                cmd001.Parameters.Add("@Change_Percent_Real_time", SqlDbType.VarChar);
                cmd001.Parameters["@Change_Percent_Real_time"].Value =Change_Percent_Real_time;
                cmd001.Parameters.Add("@Percent_Change_From_52_week_High", SqlDbType.Float);
                cmd001.Parameters["@Percent_Change_From_52_week_High"].Value = Percent_Change_From_52_week_High;
                */

            /* un comment part bellow for parametrized DB
                try
                {
                    conn.Open();
                    Int32 rowsAffected = cmd001.ExecuteNonQuery();
                    //counters++;
                    //   Console.WriteLine("RowsAffected: {0}", rowsAffected);
                    conn.Close();

                }
                catch (Exception ex)
                {


                    MessageBox.Show(ex.ToString());
                    conn.Close();

                }
                //Int32 rowsAffected = cmd.ExecuteNonQuery();
                //MessageBox.Show("done!");   

            }
            catch (IndexOutOfRangeException) // Error 001
            {
                MessageBox.Show("Contact administrator Technical Error 001 / Form1 ");
               HistLabel.Text = "Contact Admin /Error 001";
                HistLabel.Refresh();
            }


    */
            ////////////////////////////////////////////////////

            
            string Days_Range_Real_time = temp[18].Replace("\"", "");		// string 
            double? Change_From_200_day_Moving_Average = MyUtility.getDouble(temp[19]);
            string Percent_Change_From_50_day_Moving_Average = temp[20].Replace("\"", "");
            decimal? open_ = MyUtility.getDecimal(temp[21]);
            string Ex_Dividend_Date = temp[22].Replace("\"", "");// percentage string
            //DateTime? PE_Ratio_Real_time = null;                                              //r2
            //if (temp[28] != "0" && temp[28] != "-" && temp[28] != "N/A")
            //  PE_Ratio_Real_time = Convert.ToDateTime(temp[28].Replace("\"", "")); ;
            decimal? PriceOverEPS_Estimate_Next_Year = MyUtility.getDecimal(temp[23]);
            decimal? Short_Ratio = MyUtility.getDecimal(temp[24]);
            string Ticker_Trend = temp[25];
            // string Holdings_Value = temp[32];                                                //v1
            string Days_Value_Change = temp[26];
            decimal? Dividend_Yield = MyUtility.getDecimal(temp[27]);


            double? Average_Daily_Volume = MyUtility.getDouble(temp[28]);
            decimal? Ask_Real_time = MyUtility.getDecimal(temp[29]);                        //b2	 Ask (Real-time)
            //		b6	Bid_Size	temporarly removed 	// consist of two parts                 //b6
            //double? Commission = MyUtility.getDouble(temp[37]);                             //c3    //double        //Unconfirmed
            double? Dividend_Over_Share = MyUtility.getDouble(temp[30]);	            //d     //double		//confirmed
            double? Earnings_Over_Share = MyUtility.getDouble(temp[31]);		            //e     //double		//confirmed
            decimal? EPS_Estimate_Next_Year = MyUtility.getDecimal(temp[32]);		        //e8    //decimal		//confirmed
            decimal? _52_week_High = MyUtility.getDecimal(temp[33]);				        //k     //decimal 		//confirmed 
            //decimal? Holdings_Gain  = MyUtility.getDecimal(temp[42]);			            //g4    //decimal 		//Unconfirmed

            //MessageBox.Show(temp[34]);

            string More_Info = temp[34];		                                	        //i     //string 		//confirmed    
            //		j3	Market Cao 				// Error Prone			//
            string Percent_Change_From_52_week_Low = temp[35];	                            //      j6//string percentage 		// confirmed
            //		k3	Last_Trade_Size			                        	//consist of two part 		
            string Last_Trade_With_Time = temp[36];				                    //l     //string			        // confirmed
            //double?	Low_Limit			=MyUtility.getDouble(temp[46]);		                //l3    //Double
            double? _50_day_Moving_Average = MyUtility.getDouble(temp[37]);			        //m3    //double
            string Percent_Change_From_200_day_Moving_Average = temp[38];	                //m6    //string 


            decimal? Previous_Close = MyUtility.getDecimal(temp[39]);			        //p     //decimal
            double? Price_Over_Sales = MyUtility.getDouble(temp[40]);		    	        //p5    //double 
            decimal? P_OverE_Ratio = MyUtility.getDecimal(temp[41]);				        //r     //decimal
            decimal? PEG_Ratio = MyUtility.getDecimal(temp[42]);			            //r5    //decimal 
            decimal? _1_yr_Target_Price = MyUtility.getDecimal(temp[43]);		        //t8    //decimal   // 



            //decimal? Holdings_Value_Real_Time =MyUtility.getDecimal(temp[54]);		        //v7    //decimal   // 
            string Days_Value_Change_Real_time = temp[44];	                                //w4	//string	//confirmed
            /*   
         * to test the string the number of column of exel file should be the same for all the stocks 
         * test string : http://download.finance.yahoo.com/d/quotes.csv?s=ORCL+MSFT+^OEX+AXS.L+LLD5.L+JAH+^MID+AXS.L+JAH+YHOO+GE+^KLSE+FB+ASIA&f=sl1d1t1c1hgvbap2b4e7jj1j5k2k5m2m5m8oqr7s7t7w1ya2b2dee8kij6lm3m6pp5rr5t8w4b3cc6e9j4k1k4mm4m7p6r1r6t6wx
             
         *  all the attribute should exist !
        */
            //                         Ask_Size				//a5	//Unconfirmed eliminated due to un expected errors
            decimal? Bid_Real_time = MyUtility.getDecimal(temp[45]);	                    	//b3	//decimal	//confirmed

            //MessageBox.Show(temp[57].ToString());
            string Change_and_Percent_Change = temp[46];			                        //c	//string	//confirmed
            string Change_Real_time = temp[47];                                    	//c6	//string	//confirmed
            //string Error_Indication		= temp[59] ;	                                    //e1	//string	//unconfirmed
            decimal? EPS_Estimate_Next_Quarter = MyUtility.getDecimal(temp[48]);	        //e9	//decimal	//confirmed
            //string Holdings_Gain_Percent	= temp[61] ;		                            //g1	//string	//unconfirmed 
            //   string Holdings_Gain_Percent_Real_time	= temp[61] ;	                        //g5	//string 	//unconfirmed
            //string Order_Book_Real_time= temp[63] ;		                                	//i5	//string	//unconfirmed

            string EBITDA = temp[49];				                                    	//j4	//string 	//confirmed  	//billion based 
            string Last_Trade_Real_time_With_Time = temp[50];	                        	//k1	//string 	//confirmed 
            decimal? Change_From_52_week_High = MyUtility.getDecimal(temp[51]);	            //k4	//decimal 	//confirmed 	
            string Days_Range = temp[52];				                                    //m	//string	//confirmed
            decimal? _200_day_Moving_Average = MyUtility.getDecimal(temp[53]);	            //m4	//decimal 	//confirmed 
            decimal? Change_From_50_day_Moving_Average = MyUtility.getDecimal(temp[54]);      //m7	//decimal	//confirmed

            //string Notes= temp[70] ;				                                       	//n4	//string	//unconfirmed
            //decimal? Price_Paid	=MyUtility.getDecimal(temp[71]);			                //p1	//decimal	//unconfirmed
            decimal? Price_Over_Book = MyUtility.getDecimal(temp[55]);	            	//p6	//decimal	//confirmed
            string Dividend_Pay_Date = temp[56];//56		                                //r1	//date		//confirmed
            decimal? Price_Over_EPS_Estimate_Current_Year = MyUtility.getDecimal(temp[57]);	//r6	//decimal 	//confirmed
            //decimal? SharesOwned=MyUtility.getDecimal(temp[75]);		                	//s1	//decimal	//unfconfirmed
            string Trade_Links = temp[58];                                        		//t6	//string [100]	//confirmed
            string _52_week_Range = temp[59];	                                    	//w	//string	//confirmed
            string Stock_Exchange = temp[60];                                	//x	//string 	//confirmed
           ///////////////////////////////      Special assignments !
            // valid example test :http://download.finance.yahoo.com/d/quotes.csv?s=^OEX+ORCL+MSFT+^OEX+AXS.L+LLD5.L+JAH+^MID+AXS.L+JAH+YHOO+GE+^KLSE+FB+ASIA&f=l2c8d2g3r2v1c3g4l3e1g1i5n4p1s1g5g6v7 


            string High_Limit = UCtemp[0].Replace("\"","");             				//l2    //Done
            string After_Hours_Change_Real_time = UCtemp[1].Replace("\"", "");  		//c8    //Done
            string Trade_Date = UCtemp[2].Replace("\"", "") ;			            	//d2    //Done
            string Annualized_Gain=UCtemp[3].Replace("\"","");			                //g3    //Done
            string P_Over_E_Ratio_Real_time = UCtemp[4].Replace("\"", "");		        //r2    //Done
            string Holding_Value = UCtemp[5].Replace("\"","");			            	//v1    //Done
            string Commission = UCtemp[6].Replace("\"","");		                		//c3    //Done
            string Holding_Gain = UCtemp[7].Replace("\"", "");			            	//g4    //Done
            string Low_Limit = UCtemp[8].Replace("\"", "");				                //l3    //Done
            string Error_Indication = UCtemp[9].Replace("\"", "");			            //e1    //Done
            string Holding_Gain_Percent = UCtemp[10].Replace("\"", "");			        //g1    //Done
            string Order_Book_Real_time = UCtemp[11].Replace("\"", "");			        //i5    //Done
            string Notes = UCtemp[12].Replace("\"", "");					            //n4    //Done
            string PricePaid = UCtemp[13].Replace("\"", "");				            //p1    //Done
            string Shares_Owned = UCtemp[14].Replace("\"", "");				            //s1    //Done
            string Holding_Gain_Percent_Real_Time = UCtemp[15].Replace("\"", "");		//g5    //Done
            string Holdings_Gain_Real_time = UCtemp[16].Replace("\"", "");		        //g6    //Done
            string Holdings_Value_Real_time = UCtemp[17].Replace("\"", "");		        //v7    //Done


            string Bid_Size = DLSTring_Bid_Size.Replace("\"", "");                      //      //Done
            string Market_Cap_Real_time = DLSTring_Market_Cap_Real_time.Replace("\"", "");
            string Ask_Size = DLSTring_Ask_Size.Replace("\"", "");
            string Last_Trade_Size = DLSTring_Last_Trade_Size.Replace("\"", "");
            string Shares_Outstanding = DLSTring_Shares_Outstanding;

            string  Revenue = UCtemp[18].Replace("\"", "");	;
            string Trade_Links_Additional = UCtemp[19].Replace("\"", ""); ;

                //s6	Revenue	
            //f0	Trade Links Additional


            string myquery0 = "insert into KLSE_Table_Extend values ("
                + "'" + High_Limit + "','" + After_Hours_Change_Real_time
                + "','" + Trade_Date + "','" + Annualized_Gain + "','" + P_Over_E_Ratio_Real_time
                + "','" + Holding_Value + "','" + Commission + "','" + Holding_Gain + "','" + Low_Limit + "','" + Error_Indication
                + "','" + Holding_Gain_Percent + "','" + Order_Book_Real_time + "','" + Notes + "','" + PricePaid
                + "','" + Shares_Owned + "','" + Holding_Gain_Percent_Real_Time + "','" + Holdings_Gain_Real_time + "','" + Holdings_Value_Real_time + "','" + Bid_Size
                + "','" + Market_Cap_Real_time + "','" + Ask_Size + "','" + Last_Trade_Size + "','" + Revenue + "','" + Trade_Links_Additional + "','" + Shares_Outstanding +"'" + ");";  
            
            ss.insert(myquery0);

            //
            //
            //
            //
            /////////////////////////////       end of special assignments 
            StatusOfConnection.Text = "End of assignment, inserting query starts to proccess";
            StatusOfConnection.Refresh();
            string myquery = "insert into KLSE_Table values ('" + Symbol + "','" + Last_Update_Time.ToShortDateString() + "','" + Last_Update_Time.ToLongTimeString() + "'," + Last_Trade_Price_only + ", '" + Last_Trade_Date.ToShortDateString() + "','" + Last_Trade_Date.ToLongTimeString() + "'," +
                                      Change + "," + Days_High + "," + Days_Low + "," + Volume + "," + Bid + "," + Ask + ",'" + Change_in_percent + " ' ," + book_Value
                                      + ", " + EPS_Estimate_Current_Year + ", " + _52_week_Low + ",'" + Market_Capitalization + "'," + Change_From_52_week_Low + ", '" + Change_Percent_Real_time + "',"
                                      + Percent_Change_From_52_week_High + ",'" + Days_Range_Real_time + "'," + Change_From_200_day_Moving_Average + ",'" + Percent_Change_From_50_day_Moving_Average + "'," + open_ + ",'" + Ex_Dividend_Date + "',"
                                      + PriceOverEPS_Estimate_Next_Year + "," + Short_Ratio + ",'" + Ticker_Trend + "','" + Days_Value_Change + "'," + Dividend_Yield 
                                      + "," + Average_Daily_Volume + "," + Ask_Real_time + "," + Dividend_Over_Share + "," + Earnings_Over_Share + "," + EPS_Estimate_Next_Year + "," + _52_week_High + ",'"
                                      + More_Info + "','" + Percent_Change_From_52_week_Low + "','" + Last_Trade_With_Time + "', " + _50_day_Moving_Average + ",'" + Percent_Change_From_200_day_Moving_Average + "',"
                                      + Previous_Close + "," + Price_Over_Sales + "," + P_OverE_Ratio + "," + PEG_Ratio + "," + _1_yr_Target_Price
                                      + ",'" + Days_Value_Change_Real_time + "'," + Bid_Real_time + ",'" + Change_and_Percent_Change + "','" + Change_Real_time + "'," + EPS_Estimate_Next_Quarter
                                      + ",'" + EBITDA + "','" + Last_Trade_Real_time_With_Time + "'," + Change_From_52_week_High + ",'" + Days_Range + "'," + _200_day_Moving_Average + "," + Change_From_50_day_Moving_Average
                                      + "," + Price_Over_Book + ",'" + Dividend_Pay_Date + "'," + Price_Over_EPS_Estimate_Current_Year + ",'" + Trade_Links + "','" + _52_week_Range + "','" + Stock_Exchange + "'" 
                                      + ")";
                    ss.insert(myquery);



                                     string myqueryfinal = "insert into TableFinal values ('" + Symbol + "','" + Last_Update_Time.ToShortDateString() + "','" + Last_Update_Time.ToLongTimeString() + "'," + Last_Trade_Price_only + ", '" + Last_Trade_Date.ToShortDateString() + "','" + Last_Trade_Date.ToLongTimeString() + "'," +
                                     Change + "," + Days_High + "," + Days_Low + "," + Volume + "," + Bid + "," + Ask + ",'" + Change_in_percent + " ' ," + book_Value
                                     + ", " + EPS_Estimate_Current_Year + ", " + _52_week_Low + ",'" + Market_Capitalization + "'," + Change_From_52_week_Low + ", '" + Change_Percent_Real_time + "',"
                                     + Percent_Change_From_52_week_High + ",'" + Days_Range_Real_time + "'," + Change_From_200_day_Moving_Average + ",'" + Percent_Change_From_50_day_Moving_Average + "'," + open_ + ",'" + Ex_Dividend_Date + "',"
                                     + PriceOverEPS_Estimate_Next_Year + "," + Short_Ratio + ",'" + Ticker_Trend + "','" + Days_Value_Change + "'," + Dividend_Yield +
                                     "," + Average_Daily_Volume + "," + Ask_Real_time + "," + Dividend_Over_Share + "," + Earnings_Over_Share + "," + EPS_Estimate_Next_Year + "," + _52_week_High + ",'"
                                     + More_Info + "','" + Percent_Change_From_52_week_Low + "','" + Last_Trade_With_Time + "', " + _50_day_Moving_Average + ",'" + Percent_Change_From_200_day_Moving_Average + "',"
                                     + Previous_Close + "," + Price_Over_Sales + "," + P_OverE_Ratio + "," + PEG_Ratio + "," + _1_yr_Target_Price
                                     + ",'" + Days_Value_Change_Real_time + "'," + Bid_Real_time + ",'" + Change_and_Percent_Change + "','" + Change_Real_time + "'," + EPS_Estimate_Next_Quarter
                                     + ",'" + EBITDA + "','" + Last_Trade_Real_time_With_Time + "'," + Change_From_52_week_High + ",'" + Days_Range + "'," + _200_day_Moving_Average + "," + Change_From_50_day_Moving_Average
                                     + "," + Price_Over_Book + ",'" + Dividend_Pay_Date + "'," + Price_Over_EPS_Estimate_Current_Year + ",'" + Trade_Links + "','" + _52_week_Range + "','" + Stock_Exchange + "',"
                                     + "'" + High_Limit + "','" + After_Hours_Change_Real_time
                                     + "','" + Trade_Date + "','" + Annualized_Gain + "','" + P_Over_E_Ratio_Real_time
                                     + "','" + Holding_Value + "','" + Commission + "','" + Holding_Gain + "','" + Low_Limit + "','" + Error_Indication
                                     + "','" + Holding_Gain_Percent + "','" + Order_Book_Real_time + "','" + Notes + "','" + PricePaid
                                     + "','" + Shares_Owned + "','" + Holding_Gain_Percent_Real_Time + "','" + Holdings_Gain_Real_time + "','" + Holdings_Value_Real_time + "','" + Bid_Size
                                     + "','" + Market_Cap_Real_time + "','" + Ask_Size + "','" + Last_Trade_Size + "','"
                                     + Revenue + "','" + Trade_Links_Additional + "','" + Shares_Outstanding +"'" + ");";                                     

                    ss.insert(myqueryfinal);

            StatusOfConnection.Text = "Waiting for next update ";
            //MessageBox.Show(Percent_Change_From_50_day_Moving_Average.ToString());
            //--------------------------------- Notice
            // The variables l3, g4, c3, r2,v1,c8,d2, g3, g6 and l2 removed because of uncertainity 
            //
        }

        private void Update_Click(object sender, EventArgs e)
        {
            Sec = 0;
            Min = 15;
            myfunction();
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            /*
            string connetionString = null;
            string sql = null;
            connetionString = "Data Source=HOSEIN-PC\\SQLEXPRESS;Initial Catalog=FYP;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                sql = "insert into Main values ([Firt Name], [Last Name]) values(@first,@last)";
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@first", "mamad");
                    cmd.Parameters.AddWithValue("@last", "ghase");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Row inserted !! ");
                }
            }

            */


        }
        /*
         * the function below check the internet connection and update realtime database 
         */ 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Sec % 15 == 0)
            {
                bool connection = NetworkInterface.GetIsNetworkAvailable();
                if (connection == true)
                {
                    ConnectionLable.Text = "Connected";

                }
                else
                {
                    ConnectionLable.Text = "Connection Lost";
                }
                ConnectionLable.Refresh();
            }

            if (Sec > 0)
            {
                Sec--;
            }
            else
            {

                if (Sec == 0 && Min == 0)
                {
                    done = true;
                    Sec = 59;
                    Min = 14;
                }
                else
                {
                    Min--;
                    Sec = 59;
                }
            }
            ClockTimer.Text = Min.ToString("00") + ":" + Sec.ToString("00");
            ClockTimer.Refresh();
            if (done)
            {
                done = false;
                myfunction();
            }
        }

        private void DLHistoricalDataB_Click(object sender, EventArgs e)
        {
            bool validname = false;
            bool ready = false;

            if (MyUtility.isValidName(StockTableName.Text))
                validname = true;
            else
            {
                MessageBox.Show("Stock Table name can not nither start with number nor include special charachter");
                StockNameTxtBox.Text = "Stock Name";
                StockTableName.Text = "Stock Table";
            }


            if (!ss.TableIsExist(StockTableName.Text) && validname)
            {
                DialogResult dialogResult = MessageBox.Show("Table \"" + StockTableName.Text + "\" does not exist  would you like to create it ?", "Table does not found", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (ss.CreateHistoricalTable(StockTableName.Text))
                    {
                        HistLabel.Text = "Table " + StockTableName.Text + " created successfully";

                        ListViewItem lvl = new ListViewItem(StockNameTxtBox.Text);
                        lvl.SubItems.Add(StockTableName.Text);
                        lvl.SubItems.Add(DateTime.Now.ToShortDateString());
                        listView2.Items.Add(lvl);
                        ss.insert("insert into Histoorical_Stock_Table values ('" + StockNameTxtBox.Text + "', '" + StockTableName.Text + "' ,'" + DateTime.Now.ToShortDateString() + "');");
                        ready = true;
                    }
                    else
                        HistLabel.Text = "Creating table terminated due, \n(Invalid Stock Table Name)";
                }
                else if (dialogResult == DialogResult.No)
                {
                    HistLabel.Text = "Action Terminated";
                }
            }
            else if (ss.TableIsExist(StockTableName.Text))
                ready = true;

            if (ready)
            {
                ///////////// sql initial command's 
                SqlConnection conn;
                string connection_string = "Data Source=HOSEIN-PC;Initial Catalog=FYP1;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
                conn = new SqlConnection(connection_string);
                ////////////////////////// end of sql commands, starting of webclient commands 
                try
                {
                    string downloadedStrings;
                    System.Net.WebClient client;
                    client = new System.Net.WebClient();
                    downloadedStrings = client.DownloadString("http://ichart.finance.yahoo.com/table.csv?s=" + StockNameTxtBox.Text);//hgvbap2b4c8d2e7f6jg3g6j1");
                    string[] temp = downloadedStrings.Split('\n');
                    ///////////////////////// end of webclient commands 

                    /*the temp.Length -1 should be put instead of temp.Length because we did 
                     * not count the first element .
                     */

                    HistLabel.Text = "Inserting";
                    HistLabel.Refresh();
                    int counters = 0;
                    bool Succed = true;

                    for (int i = 1; i < temp.Length - 1; i++)
                    {
                        try
                        {
                            string[] innerTemp = temp[i].Split(',');
                            DateTime mydate = Convert.ToDateTime(innerTemp[0]);
                            decimal? Open = MyUtility.getDecimal(innerTemp[1]);
                            decimal? High = MyUtility.getDecimal(innerTemp[2]);
                            decimal? Low = MyUtility.getDecimal(innerTemp[3]);
                            decimal? Close = MyUtility.getDecimal(innerTemp[4]);
                            decimal? Volume = MyUtility.getDecimal(innerTemp[5]);
                            decimal? Adj_Close = MyUtility.getDecimal(innerTemp[6]);

                            SqlCommand cmd = new SqlCommand(
                                "INSERT INTO " + StockTableName.Text + " VALUES(@Date_,@Open_,@High,@Low,@Close_,@Volume,@Adj_Close);"
                                , conn);
                            cmd.Parameters.Add("@Date_", SqlDbType.Date);
                            cmd.Parameters["@Date_"].Value = mydate.ToShortDateString();
                            cmd.Parameters.Add("@Open_", SqlDbType.Decimal);
                            cmd.Parameters["@Open_"].Value = Open;
                            cmd.Parameters.Add("@High", SqlDbType.Decimal);
                            cmd.Parameters["@High"].Value = High;
                            cmd.Parameters.Add("@Low", SqlDbType.Decimal);
                            cmd.Parameters["@Low"].Value = Low;
                            cmd.Parameters.Add("@Close_", SqlDbType.Decimal);
                            cmd.Parameters["@Close_"].Value = Close;
                            cmd.Parameters.Add("@Volume", SqlDbType.Decimal);
                            cmd.Parameters["@Volume"].Value = Volume;
                            cmd.Parameters.Add("@Adj_Close", SqlDbType.Decimal);
                            cmd.Parameters["@Adj_Close"].Value = Adj_Close;
                            try
                            {
                                conn.Open();
                                Int32 rowsAffected = cmd.ExecuteNonQuery();
                                counters++;
                                //   Console.WriteLine("RowsAffected: {0}", rowsAffected);
                                conn.Close();

                            }
                            catch (Exception ex)
                            {


                                //   Console.WriteLine(ex.Message);
                                //MessageBox.Show(ex.Data.ToString());
                                HistLabel.Text = counters + " Rows has been added";
                                HistLabel.Refresh();
                                // MessageBox.Show(ex.HResult.ToString());
                                MessageBox.Show(ex.ToString());
                                Succed = false;
                                conn.Close();
                                break;
                                //DisplaySqlErrors(ex);


                            }
                            //Int32 rowsAffected = cmd.ExecuteNonQuery();
                            //MessageBox.Show("done!");   





                        }
                        catch (IndexOutOfRangeException) // Error 001
                        {
                            MessageBox.Show("Contact administrator Technical Error 001 / Form1 ");
                            HistLabel.Text = "Contact Admin /Error 001";
                            HistLabel.Refresh();
                        }

                    }

                    if (Succed)
                        HistLabel.Text = "Inserting done successfully,\n" +counters+ " rows are added";
                }
                catch (System.Net.WebException)
                {
                    MessageBox.Show("Check Stock name symbol and try again (Stock Name)");
                    StockNameTxtBox.Text = "Stock Name" ;
                    StockTableName.Text = "Stock Table";
                }
                finally
                {

                    // update time ! 

                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView2.SelectedItems.Count == 0)
                return;

            StockNameTxtBox.Text = this.listView2.SelectedItems[0].SubItems[0].Text;
            StockTableName.Text = this.listView2.SelectedItems[0].SubItems[1].Text;
            
            StockNameTxtBox.Refresh();
            StockTableName.Refresh();
        }
    }
}
