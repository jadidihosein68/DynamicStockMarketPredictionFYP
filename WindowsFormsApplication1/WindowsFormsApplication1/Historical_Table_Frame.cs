using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Historical_Table_Frame
    {
                private string Symbol_ ;
                private string TableName_ ;
                private DateTime LastUpdate_;
                public string getSymbol() { return Symbol_; }
                public string getTableName(){return TableName_; }
                public DateTime getLastUpdate() { return LastUpdate_; }
         public Historical_Table_Frame(string Symbol ,string TableName ,DateTime LastUpdate)
         {
              Symbol_ = Symbol;
              TableName_ = TableName;
              LastUpdate_ = LastUpdate;
         }

          
   }
}
