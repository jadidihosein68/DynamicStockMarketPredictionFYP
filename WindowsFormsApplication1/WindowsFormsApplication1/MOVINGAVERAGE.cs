using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class MOVINGAVERAGE
    {
        Connections mycon = new Connections();
        /*
         * the function below return the Date of nth record before 
         * inputs : 
         * startingdate = the date that u want to find earlier dates 
         * numberofelement = how many record should be counted 
         * tablename = name of table 
         * output : 
         * a string that represent the date 
         * Remark : 
         * this function is avalable for all the table with Date_ attributes  
         */
        public string dateIndexBackward (DateTime startingdate, int numberofelement , string tablename) {
            string query = "SELECT  DATE_ " +
                            " FROM " + tablename + " where Date_ <= '" + startingdate.ToShortDateString() + "'" +
                            " ORDER BY DATE_ DESC " +
                            " OFFSET  " + (numberofelement-1).ToString() + " ROWS " +
                            " FETCH NEXT 1 ROWS ONLY  ";
            string Date = mycon.selectSingle(query);
            return Date;
        }
        /*
         * the function below return the Date of nth record after the record
         * input :
         * startingdate = the date that u want to find earlier dates 
         * numberofelement = how many record should be counted 
         * tablename = name of table 
         * output : 
         * a string that represent the date 
         * Remark : 
         * this function is avalable for all the table with Date_ attributes
         */
        public string dateIndexForward(DateTime startingdate, int numberofelement, string tablename)
        {
            string query = "SELECT  DATE_ " +
                            " FROM " + tablename + " where Date_ >= '" + startingdate.ToShortDateString() + "'" +
                            " ORDER BY DATE_ ASC " +
                            " OFFSET  " + (numberofelement - 1).ToString() + " ROWS " +
                            " FETCH NEXT 1 ROWS ONLY  ";
            string Date = mycon.selectSingle(query);
            return Date;
        }


        /*
         * the function below find average of nth close price   
         * inputs : 
         * startingdate = the starting date to calculate average 
         * numberofperiod = the number of record to calculate average 
         * tablename = name of table
         * out put : 
         * a decimal element that present the average of data 
         * Remark : 
         * this function is only avalable for historical tables 
         */
        public decimal getAverage(DateTime startingdate, int numberofperiod,string attributeforavg ,string tablename) {
            string getaverage = "select  avg(sq." + attributeforavg +") as AvgTotalClose " +
                                "FROM" +
                                "(SELECT TOP " + numberofperiod.ToString() + " *FROM " + tablename + " where Date_ >= " + "'" + startingdate.ToShortDateString().ToString() + "'" + " order by Date_ ASC ) AS sq";
            
            string average = mycon.selectSingle(getaverage);

            decimal d = decimal.Parse(average);
            return d;
        }
        /*
         * the function below calculate the Average formula but this function purposly only used for a limite row of data 
         * input : 
         * ID = ID of row start from 0 autogen for easier calculation  
         * numberofdate = number of Moving average days (12 or 26 days are some good example :) ) 
         * tablename = name of the target table to updating
         * attribute = the target attributr (the one that will updateing )
         * attributefunction = name of the attribute that calculating Moving average based on Close_ price can be an example for MACD
         */

        public void movingAvgForNthDay(int ID, decimal numberofdate, string tablename , string attribute, string attributefunction)
        {

            string query = "Update " + tablename + " set " + attribute + " = (SELECT  (" + attributefunction + "*(2.0/(" + numberofdate.ToString() + "+1.0))+( select " + attribute + " from " + tablename + " where ID = " + (ID - 1).ToString() + " )*(1.0-(2.0/(" + numberofdate.ToString() + "+1.0)))) as MACD FROM " + tablename + " where ID = " + ID.ToString() + ") where ID = " + ID.ToString();
            mycon.update(query);
        
        }

        /*
         * the function below update the moving average 
         * TargetTable = the table that u want to update the moving average for example GMMA
         * NOD = number of day 15 can be an example 
         * 
         */

        public void MAEfficent(string TargetTable ,int NOD  )
        { 
        
            string query =
            " Declare @ID int ,@Days_EMA decimal (10,4) " +
            " declare My_cursor cursor For " +
            " select " + TargetTable + ".ID , " + TargetTable + "._" + NOD.ToString() + "_Days_EMA " +
            " from "+ TargetTable + " " +
            " where "+TargetTable+".ID > "+NOD.ToString()+" " +
            " open My_cursor " +
            " Fetch Next From My_cursor INTO @ID,@Days_EMA" +
            " while @@FETCH_STATUS = 0 " +
            " begin " +
            " update "+TargetTable+" set _"+NOD.ToString()+"_Days_EMA = Close_*(2.0/("+NOD.ToString()+".0+1.0)) + " +
            " ((select _"+NOD.ToString()+"_Days_EMA from  (select ID,_"+NOD.ToString()+"_Days_EMA from "+TargetTable+" )as sq where sq.ID = "+TargetTable+".ID -1  )) * (1-(2.0/("+NOD.ToString()+".0+1.0)))" +
            " where "+TargetTable+".ID > "+NOD.ToString() +
            " Fetch Next From My_cursor INTO @ID,@Days_EMA" +
            " end " +
            " close My_cursor" +
            " Deallocate My_cursor		" ;

            mycon.update(query);
        }





        /*
         * 
         * 
         * 
         * 
         */
        public void maximumElement(int ID, string attributefunction)
        {


            string query = "select  Max(sq." + attributefunction + ") as MaxHigh FROM (SELECT TOP 14 *FROM TEMPMACD where ID >= 0 order by ID ) AS sq ;";



            //return 0;
        }


    }
}
