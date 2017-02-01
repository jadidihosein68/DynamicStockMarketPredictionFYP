using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class GMMATEMP : TimeSeries 
    {
        public GMMATEMP(DateTime startdate, DateTime enddate, string stocktable,string analayse)
            : base(startdate, enddate, stocktable, analayse)
        {
            createTempTable();
            insertRows();
            Calculation();
        }

        //" + getAnalyseTableName() + "_GMMA
        public override void createTempTable()
        {

            string query = "create table " + getAnalyseTableName() + "_GMMA(" + 
            "ID              int , "+
            "Close_	        Money , " +              
            "_3_Days_EMA     decimal (10,4), "+
            "_5_Days_EMA	    decimal (10,4), "+
            "_8_Days_EMA     decimal (10,4), "+
            "_10_Days_EMA    decimal (10,4), "+
            "_12_Days_EMA    decimal (10,4), "+
            "_15_Days_EMA    decimal (10,4), "+
            "_30_days_EMA    decimal (10,4), "+
            "_35_Days_EMA    decimal (10,4), "+
            "_40_Days_EMA    decimal (10,4), "+
            "_45_Days_EMA    decimal (10,4), "+
            "_50_Days_EMA    decimal (10,4), "+
            "_60_days_EMA    decimal (10,4) " +
            "Primary key (ID));";

            con.createTable(query);         
         }
        protected override void Calculation()
        {
        /*
         * finding initial average 
         */
            string query =
           " update " + getAnalyseTableName() + "_GMMA set _3_Days_EMA = (select AVG (Close_) from " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID <= 3  ) where ID = 3; " +
            " update " + getAnalyseTableName() + "_GMMA set _5_Days_EMA = (select AVG (Close_) from " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID <= 5  ) where ID = 5;" +
            " update " + getAnalyseTableName() + "_GMMA set _8_Days_EMA = (select AVG (Close_) from " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID <= 8  ) where ID = 8;" +
            " update " + getAnalyseTableName() + "_GMMA set _10_Days_EMA = (select AVG (Close_) from " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID <= 10  ) where ID = 10;" +
            " update " + getAnalyseTableName() + "_GMMA set _12_Days_EMA = (select AVG (Close_) from " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID <= 12  ) where ID = 12;" +
            " update " + getAnalyseTableName() + "_GMMA set _15_Days_EMA = (select AVG (Close_) from " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID <= 15  ) where ID = 15;" +
            " update " + getAnalyseTableName() + "_GMMA set _30_Days_EMA = (select AVG (Close_) from " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID <= 30  ) where ID = 30;" +
            " update " + getAnalyseTableName() + "_GMMA set _35_Days_EMA = (select AVG (Close_) from " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID <= 35  ) where ID = 35;" +
            " update " + getAnalyseTableName() + "_GMMA set _40_Days_EMA = (select AVG (Close_) from " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID <= 40  ) where ID = 40;" +

            " update " + getAnalyseTableName() + "_GMMA set _45_Days_EMA = (select AVG (Close_) from " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID <= 45  ) where ID = 45;" +
            " update " + getAnalyseTableName() + "_GMMA set _50_Days_EMA = (select AVG (Close_) from " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID <= 50  ) where ID = 50;" +
            " update " + getAnalyseTableName() + "_GMMA set _60_Days_EMA = (select AVG (Close_) from " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID <= 60  ) where ID = 60;";

            con.update(query);

            /*
            con.openConnection();
            for (int i = 4; i <= 67; i++)
            {
                string query2 = "Update TEMPGMMA set _3_Days_EMA = "+
             " (SELECT  (select Close_ from TEMPMACD where TEMPGMMA.ID = TEMPMACD.ID ) " +
             " *(2.0/(3+1.0)) " +
             " +( select _3_Days_EMA from TEMPGMMA where ID = " + (i - 1).ToString() + " )*(1.0-(2.0/(3+1.0))) FROM TEMPGMMA where ID = " + (i).ToString() + " ) " +
             " where ID = "+i.ToString()+" ; ";
                con.executeNonquery(query2);
            }

            con.closeConnection();
            */

            
            string _5_Days_EMAcal = 
            "Declare @ID int ,@_5_Days_EMA decimal (10,4) " +
            "declare My_cursor cursor For " +
            "select " + getAnalyseTableName() + "_GMMA.ID , " + getAnalyseTableName() + "_GMMA._5_Days_EMA " +
            "from " + getAnalyseTableName() + "_GMMA ," + getAnalyseTableName() + "_View " +
            "where " + getAnalyseTableName() + "_GMMA.ID > 5 and " + getAnalyseTableName() + "_GMMA.ID= " + getAnalyseTableName() + "_View.ID " +
            "open My_cursor " +
            "Fetch Next From My_cursor INTO @ID,@_5_Days_EMA " +
            "while @@FETCH_STATUS = 0 " +
            "begin " +
            "update " + getAnalyseTableName() + "_GMMA set _5_Days_EMA = Close_*(2.0/(5.0+1.0)) + " +
            "((select _5_Days_EMA from  (select ID,_5_Days_EMA from " + getAnalyseTableName() + "_GMMA )as sq where sq.ID = " + getAnalyseTableName() + "_GMMA.ID -1  )) * (1-(2/(5.0+1.0))) " +
            "where " + getAnalyseTableName() + "_GMMA.ID > 5 " +
            "Fetch Next From My_cursor INTO @ID,@_5_Days_EMA " +
            "end  " +
            "close My_cursor " +
            "Deallocate My_cursor ";
            con.update(_5_Days_EMAcal);

            /*
             * calculating 3 days EMA 
             */ 

            string _3_Days_EMAcal = 
            "Declare @ID int ,@_3_Days_EMA decimal (10,4) " +
            "declare My_cursor cursor For " +
            "select " + getAnalyseTableName() + "_GMMA.ID , " + getAnalyseTableName() + "_GMMA._3_Days_EMA  " +
            "from " + getAnalyseTableName() + "_GMMA ," + getAnalyseTableName() + "_View " +
            "where " + getAnalyseTableName() + "_GMMA.ID > 3 and " + getAnalyseTableName() + "_GMMA.ID= " + getAnalyseTableName() + "_View.ID " +
            "open My_cursor " +
            "Fetch Next From My_cursor INTO @ID,@_3_Days_EMA " +
            "while @@FETCH_STATUS = 0  " +
            "begin  " +
            "update " + getAnalyseTableName() + "_GMMA set _3_Days_EMA = Close_*(2.0/(3.0+1.0)) + " +
            "((select _3_Days_EMA from  (select ID,_3_Days_EMA from " + getAnalyseTableName() + "_GMMA )as sq where sq.ID = " + getAnalyseTableName() + "_GMMA.ID -1  )) * (1-(2.0/(3.0+1.0))) " +
            "where " + getAnalyseTableName() + "_GMMA.ID > 3 " +
            "Fetch Next From My_cursor INTO @ID,@_3_Days_EMA " +
            "end  " +
            "close My_cursor " +
            "Deallocate My_cursor ";

            con.update(_3_Days_EMAcal);

            /*
             * calculating 8 day EMA 
             */
            string _8_Days_EMAcal =
            "Declare @ID int ,@_8_Days_EMA decimal (10,4) " +
            "declare My_cursor cursor For  " +
            "select " + getAnalyseTableName() + "_GMMA.ID , " + getAnalyseTableName() + "_GMMA._8_Days_EMA  " +
            "from " + getAnalyseTableName() + "_GMMA ," + getAnalyseTableName() + "_View " +
            "where " + getAnalyseTableName() + "_GMMA.ID > 8 and " + getAnalyseTableName() + "_GMMA.ID= " + getAnalyseTableName() + "_View.ID  " +
            "open My_cursor " +
            "Fetch Next From My_cursor INTO @ID,@_8_Days_EMA " +
            "while @@FETCH_STATUS = 0  " +
            "begin  " +
            "update " + getAnalyseTableName() + "_GMMA set _8_Days_EMA = Close_*(2.0/(8.0+1.0)) +  " +
            "((select _8_Days_EMA from  (select ID,_8_Days_EMA from " + getAnalyseTableName() + "_GMMA )as sq where sq.ID = " + getAnalyseTableName() + "_GMMA.ID -1  )) * (1-(2.0/(8.0+1.0))) " +
            "where " + getAnalyseTableName() + "_GMMA.ID > 8 " +
            "Fetch Next From My_cursor INTO @ID,@_8_Days_EMA " +
            "end " +
            "close My_cursor " +
            "Deallocate My_cursor ";
            con.update(_8_Days_EMAcal);

            string _10_Days_EMAcal =           
            "Declare @ID int ,@_10_Days_EMA decimal (10,4) "+
            "declare My_cursor cursor For "+
            "select " + getAnalyseTableName() + "_GMMA.ID , " + getAnalyseTableName() + "_GMMA._10_Days_EMA  " +
            "from " + getAnalyseTableName() + "_GMMA ," + getAnalyseTableName() + "_View " +
            "where " + getAnalyseTableName() + "_GMMA.ID > 10 and " + getAnalyseTableName() + "_GMMA.ID= " + getAnalyseTableName() + "_View.ID  " +
            "open My_cursor "+
            "Fetch Next From My_cursor INTO @ID,@_10_Days_EMA "+
            "while @@FETCH_STATUS = 0  "+
            "begin  "+
            "update " + getAnalyseTableName() + "_GMMA set _10_Days_EMA = Close_*(2.0/(10.0+1.0)) +  " +
            "((select _10_Days_EMA from  (select ID,_10_Days_EMA from " + getAnalyseTableName() + "_GMMA )as sq where sq.ID = " + getAnalyseTableName() + "_GMMA.ID -1  )) * (1-(2.0/(10.0+1.0))) " +
            "where " + getAnalyseTableName() + "_GMMA.ID > 10 " +
            "Fetch Next From My_cursor INTO @ID,@_10_Days_EMA "+
            "end  "+
            "close My_cursor "+
            "Deallocate My_cursor ";
            con.update(_10_Days_EMAcal);
            /*
             * calculate 12 days MACD
             */
            string _12_Days_EMAcal =
            "Declare @ID int ,@_12_Days_EMA decimal (10,4) " +
            "declare My_cursor cursor For "+
            "select " + getAnalyseTableName() + "_GMMA.ID , " + getAnalyseTableName() + "_GMMA._12_Days_EMA  " +
            "from " + getAnalyseTableName() + "_GMMA ," + getAnalyseTableName() + "_View " +
            "where " + getAnalyseTableName() + "_GMMA.ID > 12 and " + getAnalyseTableName() + "_GMMA.ID= " + getAnalyseTableName() + "_View.ID  " +
            "open My_cursor "+
            "Fetch Next From My_cursor INTO @ID,@_12_Days_EMA "+
            "while @@FETCH_STATUS = 0  "+
            "begin  "+
            "update " + getAnalyseTableName() + "_GMMA set _12_Days_EMA = Close_*(2.0/(12.0+1.0)) +  " +
            "((select _12_Days_EMA from  (select ID,_12_Days_EMA from " + getAnalyseTableName() + "_GMMA )as sq where sq.ID = " + getAnalyseTableName() + "_GMMA.ID -1  )) * (1-(2.0/(12.0+1.0))) " +
            "where " + getAnalyseTableName() + "_GMMA.ID > 12 " +
            "Fetch Next From My_cursor INTO @ID,@_12_Days_EMA "+
            "end  "+
            "close My_cursor "+
            "Deallocate My_cursor" ;
            con.update(_12_Days_EMAcal);


            string _15_Days =
"                Declare @ID int ,@_15_Days_EMA decimal (10,4) " +
"declare My_cursor cursor For " +
"select " + getAnalyseTableName() + "_GMMA.ID , " + getAnalyseTableName() + "_GMMA._15_Days_EMA  " +
"from " + getAnalyseTableName() + "_GMMA ," + getAnalyseTableName() + "_View " +
"where " + getAnalyseTableName() + "_GMMA.ID > 15 and " + getAnalyseTableName() + "_GMMA.ID= " + getAnalyseTableName() + "_View.ID  " +
"open My_cursor " +
"Fetch Next From My_cursor INTO @ID,@_15_Days_EMA " +
"while @@FETCH_STATUS = 0  " +
"begin  " +
"update " + getAnalyseTableName() + "_GMMA set _15_Days_EMA = Close_*(2.0/(15.0+1.0)) +  " +
"((select _15_Days_EMA from  (select ID,_15_Days_EMA from " + getAnalyseTableName() + "_GMMA )as sq where sq.ID = " + getAnalyseTableName() + "_GMMA.ID -1  )) * (1-(2.0/(15.0+1.0))) " +
"where " + getAnalyseTableName() + "_GMMA.ID > 15 " +
"Fetch Next From My_cursor INTO @ID,@_15_Days_EMA " +
"end  " +
"close My_cursor " +
"Deallocate My_cursor		 ";

            con.update(_15_Days);
            //16.44 with out  30-60 days cal  old style
            //17.71 with 40-60 days cal old style
            //14.66 new style 
            //12.22 last version :) 

            movingaverage.MAEfficent("" + getAnalyseTableName() + "_GMMA", 30);
            movingaverage.MAEfficent("" + getAnalyseTableName() + "_GMMA", 35);
            movingaverage.MAEfficent("" + getAnalyseTableName() + "_GMMA", 40);
            movingaverage.MAEfficent("" + getAnalyseTableName() + "_GMMA", 45);
            movingaverage.MAEfficent("" + getAnalyseTableName() + "_GMMA", 50);
            movingaverage.MAEfficent("" + getAnalyseTableName() + "_GMMA", 60);

        }

        public override void insertRows()
        {
            string query = "insert into " + getAnalyseTableName() + "_GMMA (ID , Close_ ) " +
                            "select ID , Close_ from " +
                            "" + getAnalyseTableName() + "_View ";  
            con.insert(query);
        }

    }
}
