using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class MACDTEMP : TimeSeries
    {
        public MACDTEMP(DateTime startdate, DateTime enddate, string stocktable, string analayse)
            : base(startdate, enddate, stocktable, analayse)
        {
            try
            {
                /*
                 * find 60 days earlier 
                 */
                createTempTable();
                insertRows();
                Calculation();
            }
            catch (Exception ex)
            { 
            
            }
        }

        public MACDTEMP() {}
        /*
         * a function that create its own type temporarly table 
         * notice MACD should be created first 
         * 
         * 
         */ 

        public override void createTempTable()  
        {

            string query = "create table " + getAnalyseTableName() + "_MACD(" +
                            "ID int ,   " +            
                            " Date_			date, " +
                            " Close_			Money,  " +
                            " _12_Days_EMA	decimal(14,4),  " +
                            " _26_Days_EMA	decimal(14,4), " +
                            " MACD_12Minus26_days decimal(14,4), " +
                            " _Signal			decimal(14,4), " +
                            " _histogram		decimal(14,4)," +
                            " MACD_Transform decimal(14,4), " +
                            " Signal_Transform decimal(14,4), " +
                            " primary key (ID) )";
            con.createTable(query);
        }

        public override void insertRows()
        {

            string query = "INSERT INTO "+getAnalyseTableName()+"_MACD (ID,Date_,Close_)"
                        + " SELECT ID , Date_,Close_ "
                        + " FROM " + getAnalyseTableName() + "_view"; 
        //+ "11/27/2013
            con.insert(query);
        }

        public void perform()
        {
            string query = "INSERT INTO " + getAnalyseTableName() + "_MACD (Date_,Open_,High,Low,Close_,Volume,Adj_Close) "
                    + " SELECT Date_,Open_,High,Low,Close_,Volume,Adj_Close "
                    + " FROM " + getStockTable() + "  where  " + getStockTable() + ".Date_ > 11/27/2013 ";
            con.insert(query);

        }

        protected override void Calculation()
        {

            try
            {
                /*
                 * inserting all elements
                 */ 
                //Fortestonly testt = new Fortestonly();
                //testt.Show();
             //   insertRows();
                // data set is ready :)
                // calculating averages
                decimal _12days_avg = movingaverage.getAverage(getStartDate(), 12, "Close_" ,getStockTable());
                decimal _26days_avg = movingaverage.getAverage(getStartDate(), 26, "Close_", getStockTable());
                // finding date 
                DateTime thedate = Convert.ToDateTime(movingaverage.dateIndexForward(getStartDate(), 12, "" + getAnalyseTableName() + "_MACD"));
                DateTime thedate2 = Convert.ToDateTime(movingaverage.dateIndexForward(getStartDate(), 26, "" + getAnalyseTableName() + "_MACD"));
                // update 12 days average    
                string query2 = "UPDATE " + getAnalyseTableName() + "_MACD SET _12_Days_EMA = " + _12days_avg + " where Date_ = '" + thedate.ToShortDateString() + "'";
                // update 26 days average
                string query3 = "UPDATE " + getAnalyseTableName() + "_MACD SET _26_Days_EMA = " + _26days_avg + " where Date_ = '" + thedate2.ToShortDateString() + "'";
                // execute dates 
                con.update(query2);
                con.update(query3);

                string limit = con.selectSingle("select count(Date_) from " + getStockTable() + " where Date_ >= '" + getStartDate().ToShortDateString() + "' and Date_ <= '" + getEndDate().ToShortDateString() + "'");
                //testt.label1.Text = limit;
                /*
                 * calculating moving average for 12 and 26 days up to 34 days only 
                 */

                int limitint = int.Parse(limit);

                movingaverage.MAEfficent("" + getAnalyseTableName() + "_MACD", 12);
                movingaverage.MAEfficent("" + getAnalyseTableName() + "_MACD", 26);

                /*
                 *Providing basis for MACD 12 - 26 
                 */
                string query4 = "UPDATE " + getAnalyseTableName() + "_MACD SET MACD_12Minus26_days = (_12_Days_EMA - _26_Days_EMA) where ID >= 26 ";
                con.update(query4);

                string query5 = con.selectSingle("select  avg(sq.MACD_12Minus26_days) as AvgTotalMAC " 
                                                +"FROM" +
                                                "(SELECT TOP 9 *FROM " + getAnalyseTableName() + "_MACD where ID >= 26 order by ID ) AS sq");

                string query6 = "update " + getAnalyseTableName() + "_MACD set _Signal = " + query5 + "where ID = 34";
                con.update(query6);

                for (int i = 35; i <= limitint; i++)
                    movingaverage.movingAvgForNthDay(i, 9, "" + getAnalyseTableName() + "_MACD", "_Signal", "MACD_12Minus26_days");

                string query7 = "update " + getAnalyseTableName() + "_MACD set _histogram = (MACD_12Minus26_days - _Signal )  where ID >= 34";
                con.update(query7);


                string query8 = " UPDATE " + getAnalyseTableName() + "_MACD " +
                    " SET MACD_transform = MACD_12Minus26_days - (select top 1 MACD_12Minus26_days" +
                    " from " + getAnalyseTableName() + "_MACD m2" +
                    " where m2.id < " + getAnalyseTableName() + "_MACD.id" +
                    " order by id desc" +
                   " ) ";
                con.update(query8);

                string query9 = " UPDATE " + getAnalyseTableName() + "_MACD  " +
                    " SET Signal_transform = _Signal - (select top 1 _Signal "+
                    " from " + getAnalyseTableName() + "_MACD m2 " +
                    " where m2.id < " + getAnalyseTableName() + "_MACD.id " +
                    " order by id desc " +
                   " ) ";

                con.update(query9);




            
            }
            catch (Exception ex) { 
            
            }
        }

        public override void dropTable()
        {
            con.dropTable("drop table " + getAnalyseTableName() + "_MACD");
        }

    }
}
