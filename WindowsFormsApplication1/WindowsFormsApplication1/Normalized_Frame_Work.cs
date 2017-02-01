using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Normalized_Frame_Work
    {
        private DateTime date_;
        private decimal? Close_;
        private decimal? MACD_;
        private decimal? KD_;
        private decimal? RSI_;
        private decimal? LowGMA_;
        private decimal? highGMA_;


        public decimal? getLowGMA() { return LowGMA_; }
        public decimal? gethighGMA() { return highGMA_; }
        public DateTime getDate() { return date_; }
        public decimal? getClose() { return Close_ ; }
        public decimal? getMACD() { return MACD_;}
        public decimal? getKD() { return KD_; }
        public decimal? getRSI() { return RSI_; }


        public Normalized_Frame_Work (DateTime date, decimal Close, decimal MACD, decimal KD, decimal RSI)
        {
            date_ = date;
            Close_ = Close;
            MACD_ = MACD;
            KD_ = KD;
            RSI_ = RSI;
        }

        public Normalized_Frame_Work(DateTime date, decimal Close, decimal MACD, decimal KD, decimal RSI, decimal LowGMA, decimal highGMA)
        {
            date_ = date;
            Close_ = Close;
            MACD_ = MACD;
            KD_ = KD;
            RSI_ = RSI;
            LowGMA_ = LowGMA;
            highGMA_ = highGMA;
        }







    }
}
