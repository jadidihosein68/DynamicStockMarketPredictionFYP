using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Table_Stock_Info
    {
        string Symbol_;
        String name;
        DateTime MyNullableDate;

        Boolean Status;

       // public Table_Stock_Info() { }


        public Table_Stock_Info(String name)
        {
            this.name = name ;
            Status = false;
        }
     
        public Table_Stock_Info(String name, DateTime last_Update , Boolean Status)
        {
            this.name = name;
            MyNullableDate = last_Update;
            this.Status = Status;
        }


        public Table_Stock_Info(string symbol, string name, Boolean Status, DateTime last_Update)
        {
            Symbol_ = symbol;
            this.name = name;
            MyNullableDate = last_Update;
            this.Status = Status;
        }
        
        

        public String getName()    { return name;}
        public Boolean getStatus()  { return Status;}
        public DateTime getDate() { return MyNullableDate; }
        public string getSymbol() { return Symbol_; }

    }
}
