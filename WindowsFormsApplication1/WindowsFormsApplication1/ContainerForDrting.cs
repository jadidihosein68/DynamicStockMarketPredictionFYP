using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ContainerForDrting
    {

        DateTime Date; 
        string name;
        decimal? MACD;
        decimal? Signal;
        decimal? Stocastic;
        decimal? RSI;


        ContainerForDrting(
        DateTime Date, 
        string name,
        decimal? MACD,
        decimal? Signal,
        decimal? Stocastic,
        decimal? RSI
            ) {

                this.Date= Date;
                this.name= name;
                this.MACD=MACD;
                this.Signal = Signal;
                this.Stocastic = Stocastic;
                this.RSI=RSI;
              }      

        DateTime getDate () {return Date ;}
         string getname () {return name ;}
        decimal? getMACD() {return MACD;}
        decimal? getSignal() {return Signal;}
        decimal? getStocastic() {return Stocastic;}
        decimal? getRSI() { return RSI; }

    }
}
