using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class TimeSeries
    {

        private DateTime startdate_;
        private DateTime enddate_;
        private string stocktable_;
        private string AnalyseTableName_;
        protected MOVINGAVERAGE movingaverage = new MOVINGAVERAGE();
        protected Connections con = new Connections();
        public TimeSeries(DateTime startdate, DateTime enddate, string stocktable)
        {
            startdate_ = Convert.ToDateTime(movingaverage.dateIndexBackward(startdate, 60, stocktable));
            enddate_ = enddate;
            stocktable_ = stocktable;
        }

        public TimeSeries(DateTime startdate, DateTime enddate, string Historicalstocktable , string AnalyseTableName )
        {
            startdate_ = Convert.ToDateTime(movingaverage.dateIndexBackward(startdate, 60, Historicalstocktable));
            enddate_ = enddate;
            stocktable_ = Historicalstocktable;
            AnalyseTableName_ = AnalyseTableName; 
        }

        public TimeSeries(string AnalyseTableName)
        {

            AnalyseTableName_ = AnalyseTableName;

        }

        public DateTime getStartDate() { return startdate_; }
        public DateTime getEndDate() { return enddate_; }
        public string getStockTable() { return stocktable_; }
        public string getAnalyseTableName() { return AnalyseTableName_; }
        /*
         * a function that create its own type temporarly table 
         * notice MACD should be created first then only other tables can made 
         */ 
        public virtual void createTempTable() { }
        /*
         * a function that perform all the calculation
         * 
         */ 
        protected virtual void Calculation() {}
        /*
         * a function that input the initial data for calculation :)
         */
        public virtual void insertRows() { }

        public TimeSeries() { }

        public virtual void dropTable()  {

            con.dropTable("drop View "+AnalyseTableName_+"_View");
            con.dropTable("drop table "+AnalyseTableName_+"_RSI");
            con.dropTable("drop table "+AnalyseTableName_+"_STO");
            con.dropTable("drop table "+AnalyseTableName_+"_MACD");
            con.dropTable("drop table " + AnalyseTableName_ + "_GMMA");
            con.dropTable("drop view " + AnalyseTableName_ + "_AllView");
            con.dropTable("delete analyse_lists where Stock_Table_name = '" + AnalyseTableName_ + "'");
        }
    }
}
