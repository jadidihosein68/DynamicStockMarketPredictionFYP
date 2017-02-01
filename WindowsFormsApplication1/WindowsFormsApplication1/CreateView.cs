using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class CreateView : TimeSeries
    {

        public CreateView(DateTime startdate, DateTime enddate, string Historicalstocktable, string analayse)
            : base(startdate, enddate, Historicalstocktable, analayse)
        {
            createTempTable();
        //    insertRows();
            //Calculation();
        }



        public override void createTempTable()
        {


            /*
            string query ="create table STOCTEMP"+
            "(ID int ,"+
            "highest_high_14 money,"+
            "lowest_Low_14 money, "+
            "_14_day_StochasticOscillator money )";
            */
            string query = "create table " + getAnalyseTableName() + "_STO" +
            "(ID int ," +
            "highest_high_14 decimal(14,4)," +
            "lowest_Low_14 decimal(14,4), " +
            "_14_day_StochasticOscillator decimal(14,4) )";


            //DataSetName = getAnalyseTableName();

            //HPT =getStockTable

            string CreateViewQuery = "create view " + getAnalyseTableName().ToString() + "_View as " +
    " select rank() OVER (ORDER BY " + getStockTable().ToString() + ".Date_, " + getStockTable().ToString() + ".Open_, " + getStockTable() + ".High," + getStockTable() + ".Low,Close_,Volume, Adj_Close) as ID, " + getStockTable() + ".Date_, " + getStockTable() + ".Open_," + getStockTable() + ".High," + getStockTable() + ".Low,Close_,Volume, Adj_Close " +
    " from " + getStockTable() + " where " + getStockTable() + ".Date_>='" + getStartDate().ToShortDateString() + "' and Date_ <= '" + getEndDate().ToShortDateString() + "' ";
            con.createView(CreateViewQuery);
        }



        protected override void Calculation()
        {

        }

        public override void insertRows()
        {

        }



    
    }

}
