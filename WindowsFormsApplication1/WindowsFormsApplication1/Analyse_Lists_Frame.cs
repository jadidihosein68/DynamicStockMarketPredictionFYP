using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Analyse_Lists_Frame
    {

                private string Stock_Symbol_ ;
                private string Stock_Table_Name_ ;
                private DateTime Starting_Date_;
                private DateTime Last_Date_;
                public string getStock_Symbol() { return Stock_Symbol_; }
                public string getStock_Table_Name() { return Stock_Table_Name_; }
                public DateTime getStarting_Date_() { return Starting_Date_; }
                public DateTime getLast_Date_() { return Last_Date_; }
                public Analyse_Lists_Frame(string Symbol, string TableName,DateTime StartingDate, DateTime LastUpdate)
         {
             Stock_Symbol_ = Symbol;
              Stock_Table_Name_ = TableName;
              Starting_Date_ = StartingDate;
              Last_Date_ = LastUpdate;
         }
    }
}
