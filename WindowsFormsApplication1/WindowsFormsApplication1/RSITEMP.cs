using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class RSITEMP : TimeSeries
    {
        //private DateTime startdate_;
        //private DateTime enddate_;
        //private string stocktable_;
        //protected MOVINGAVERAGE movingaverage = new MOVINGAVERAGE();
        //protected Connections con = new Connections();
        public RSITEMP(DateTime startdate, DateTime enddate, string stocktable, string analayse)
            : base(startdate, enddate, stocktable, analayse)
        {
            createTempTable();
            insertRows();
            Calculation();
        }

        public override void createTempTable()
        {

            string query = " create table " + getAnalyseTableName() + "_RSI ( " +
            " ID int , " +
            "Change			decimal(14,4), " +
            "Gain			decimal(14,4) DEFAULT 0 , " +
            "Loss			decimal(14,4) DEFAULT 0 , " +
            "Avg_Gain		decimal(14,4), " +
            "Avg_Loss		decimal(14,4), " +
            "RS				decimal(14,4), " +
            "_14_days_RSI	decimal(14,4), " +
            "RSI_Transform	decimal(14,4), " +
            "primary key (ID) ) ";
            con.createTable(query);

        }

        
        protected override void Calculation()
        {
            /*
             * calculating change 
             */
            string query = "Update " + getAnalyseTableName() + "_RSI set Change = (select close_ From " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID = " + getAnalyseTableName() + "_RSI.ID) - (select close_ From " + getAnalyseTableName() + "_View where " + getAnalyseTableName() + "_View.ID = " + getAnalyseTableName() + "_RSI.ID-1) " +
            "where ID >=2";
            con.update(query);

            /*
             * calculating Gain
             */
            string query2 = "update " + getAnalyseTableName() + "_RSI " +
                            " set Gain = Change " +
                            "where Change > 0 and ID >=2 ";
            con.update(query2);
            /*
             * calculating Loss
             */
            string query3 = "update " + getAnalyseTableName() + "_RSI " +
                " set Loss = (Change * -1.0) " +
                "where Change < 0 and ID >=2 ";
            con.update(query3);
            /*
             * calculate AVG_Gain initial calculation for first row only 
             */
            string query4 = " update " + getAnalyseTableName() + "_RSI " +
                            "set Avg_Gain = (select AVG (Gain) from " + getAnalyseTableName() + "_RSI where ID <=15 and ID >= 2)" +
                            "where ID = 15 ;";
            con.update(query4);
           /*
           * calculate AVG_LOSS initial calculation for first row only 
           */
            string query5 = " update " + getAnalyseTableName() + "_RSI " +
                     "set Avg_LOSS = (select AVG (LOSS) from " + getAnalyseTableName() + "_RSI where ID <=15 and ID >= 2)" +
                     "where ID = 15 ;";
            con.update(query5);
            
            /*
             * calculating AVG_Gain and AVG_LOSS (the loop function) 
             */

            string limit = con.selectSingle("select count(ID) from " + getAnalyseTableName() + "_RSI");
            int limitint = int.Parse(limit);
            con.openConnection();
            for (int i = 16; i <= limitint; i++)
            {
                con.executeNonquery(
                   "Update " + getAnalyseTableName() + "_RSI " +
                   "set Avg_Gain = " +
                   "(SELECT  (((( select Avg_Gain from " + getAnalyseTableName() + "_RSI where ID = " + (i - 1).ToString() + " )*13.0) + Gain )/14.0) FROM " + getAnalyseTableName() + "_View where ID = " + i.ToString() + ") " +
                   "from " + getAnalyseTableName() + "_RSI where ID = " + i.ToString()
                   );
                con.executeNonquery(
                    "Update " + getAnalyseTableName() + "_RSI " +
                    "set Avg_LOSS = " +
                    "(SELECT  (((( select Avg_LOSS from " + getAnalyseTableName() + "_RSI where ID = " + (i - 1).ToString() + " )*13.0) + LOSS )/14.0) FROM " + getAnalyseTableName() + "_View where ID = " + i.ToString() + ") " +
                    "from " + getAnalyseTableName() + "_RSI where ID = " + i.ToString()
                    );
            }
            con.closeConnection();

            string query6 = " update " + getAnalyseTableName() + "_RSI " +
                     "set RS = Avg_Gain /Avg_LOSS " +
                     "where ID >= 15 ;";
            con.update(query6);

            string query65 = "update " + getAnalyseTableName() + "_RSI " +
                            "set _14_days_RSI = 100 where ID>=15";
                     con.update(query65);
            string query7 = "update " + getAnalyseTableName() + "_RSI " +
                            "set _14_days_RSI = 100 - (100 / (1+RS)) " +
                            "where Avg_LOSS != 100 and ID >= 15 ; ";
            con.update(query7);

            string query8 = "UPDATE " + getAnalyseTableName() + "_RSI" +
                            " SET RSI_transform = _14_days_RSI - (select top 1 _14_days_RSI" +
                            " from " + getAnalyseTableName() + "_RSI m2" +
                            " where m2.id < " + getAnalyseTableName() + "_RSI.id" +
                            " order by id desc" +
                            " )";
            con.update(query8);
            
        }

        public override void insertRows()
        {

            string query = "insert into " + getAnalyseTableName() + "_RSI (ID) " +
                            "select ID from " +
                            "" + getAnalyseTableName() + "_View ";
            con.insert(query);            
        }

    }
}
