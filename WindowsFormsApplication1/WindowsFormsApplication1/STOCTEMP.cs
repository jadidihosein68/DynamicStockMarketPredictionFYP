using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{

    class STOCTEMP : TimeSeries
    {
        
        //private DateTime startdate_;
        //private DateTime enddate_;
        //private string stocktable_;
        //protected MOVINGAVERAGE movingaverage = new MOVINGAVERAGE();
      //  protected Connections con = new Connections();
        public STOCTEMP(DateTime startdate, DateTime enddate, string Historicalstocktable , string analayse)
            : base(startdate, enddate, Historicalstocktable, analayse)
        {
            createTempTable();
            insertRows();
            Calculation();
        }


        public override void createTempTable()
        {

            string query = "create table " + getAnalyseTableName() + "_STO" +
            "(ID int ," +
            "highest_high_14 decimal(14,4)," +
            "lowest_Low_14 decimal(14,4), " +
            "_14_day_StochasticOscillator decimal(14,4), "+
            "Sto_Transform decimal(14,4)" +
            ")";
            
            con.createTable(query);
         }

       

        protected override void Calculation()
        {
         /*
         * calculate Highest High (14)
         */
            string query = "update " + getAnalyseTableName() + "_STO set " +
                        "highest_high_14 = " +
                        "(select MAX(High) from  " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_STO.ID >= " + getAnalyseTableName() + "_View.ID AND " + getAnalyseTableName() + "_STO.ID < " + getAnalyseTableName() + "_View.ID +14 )" +
                        "where ID >= 14 ";
        con.update(query);

        /*
         * calculate Lowest Low (14)
         */
        string query2 = "update " + getAnalyseTableName() + "_STO set " +
                                "lowest_low_14 = " +
                                "(select MIN(LOW) from  " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_STO.ID >= " + getAnalyseTableName() + "_View.ID AND " + getAnalyseTableName() + "_STO.ID < " + getAnalyseTableName() + "_View.ID +14 )" +
                                "where ID >= 14 ";
        con.update(query2);
        /*
         * calculate 14-day Stochastic Oscillator 
         */
        string query3 = "update " + getAnalyseTableName() + "_STO set "
                        + @"_14_day_StochasticOscillator = (((select close_ from " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_STO.ID= " + getAnalyseTableName() + "_View.ID)-lowest_Low_14)/" +
                        "(HiGHEST_HIGH_14-lowest_Low_14)*100.0)" +
                        "where ID >=  14" ;
        con.update(query3);

        string query4 = " UPDATE " + getAnalyseTableName() + "_STO " +
                " SET Sto_transform = _14_day_StochasticOscillator - (select top 1 _14_day_StochasticOscillator " +
                " from " + getAnalyseTableName() + "_STO m2 " +
                " where m2.id < " + getAnalyseTableName() + "_STO.id " +
                " order by id desc " +
                " )";
        con.update(query4);
        }

        public override void insertRows()
        {

            string query = "insert into " + getAnalyseTableName() + "_STO (ID) " +
                            "select ID from " +
                            "" + getAnalyseTableName() + "_View ";
            
            con.insert(query);

        }


        


    }
}
