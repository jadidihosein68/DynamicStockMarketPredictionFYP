using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Analyse_lists
    {

        string Symbol_;
        String name_;
        DateTime MyNullableStartDate_;
        DateTime MyNullableEndDate_;

        Analyse_lists(string Symbol, String name, DateTime MyNullableStartDate, DateTime MyNullableEndDate)
        {
            Symbol_ = Symbol;
            name_ = name;
            MyNullableEndDate_ = MyNullableEndDate;
            MyNullableStartDate_ = MyNullableStartDate;
        }


        string getSymbol() { return Symbol_; }
        String getname() { return name_; }
        DateTime getMyNullableStartDate() { return MyNullableStartDate_; }
        DateTime getMyNullableEndDate() { return MyNullableEndDate_; }


    
    }
}
