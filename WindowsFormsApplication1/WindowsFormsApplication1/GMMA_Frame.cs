using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class GMMA_Frame
    {
        private DateTime date;
        private decimal _3_days_Ema;
        private decimal _5_days_Ema;
        private decimal _8_days_Ema;
        private decimal _10_days_Ema;
        private decimal _12_days_Ema;
        private decimal _15_days_Ema;
        private decimal _30_days_Ema;
        private decimal _35_days_Ema;
        private decimal _40_days_Ema;
        private decimal _45_days_Ema;
        private decimal _50_days_Ema;
        private decimal _60_days_Ema;

        public DateTime getdate() { return date; }
        public decimal get_3_days_Ema() { return _3_days_Ema; }
        public decimal get_5_days_Ema() { return _5_days_Ema; }
        public decimal get_8_days_Ema() { return _8_days_Ema; }
        public decimal get_10_days_Ema() { return _10_days_Ema; }
        public decimal get_12_days_Ema() { return _12_days_Ema; }
        public decimal get_15_days_Ema() { return _15_days_Ema; }
        public decimal get_30_days_Ema() { return _30_days_Ema; }
        public decimal get_35_days_Ema() { return _35_days_Ema; }
        public decimal get_40_days_Ema() { return _40_days_Ema; }
        public decimal get_45_days_Ema() { return _45_days_Ema; }
        public decimal get_50_days_Ema() { return _50_days_Ema; }
        public decimal get_60_days_Ema() { return _60_days_Ema; }

        public GMMA_Frame(
            DateTime date_,
         decimal _3_days_Ema_,
         decimal _5_days_Ema_,
         decimal _8_days_Ema_,
         decimal _10_days_Ema_,
         decimal _12_days_Ema_,
         decimal _15_days_Ema_,
         decimal _30_days_Ema_,
         decimal _35_days_Ema_,
         decimal _40_days_Ema_,
         decimal _45_days_Ema_,
         decimal _50_days_Ema_,
         decimal _60_days_Ema_) {
             date = date_;
             _3_days_Ema = _3_days_Ema_;
             _5_days_Ema = _5_days_Ema_;
             _8_days_Ema = _8_days_Ema_;
             _10_days_Ema = _10_days_Ema_;
             _12_days_Ema = _12_days_Ema_;
             _15_days_Ema = _15_days_Ema_;
             _30_days_Ema = _30_days_Ema_;
             _35_days_Ema = _35_days_Ema_;
             _40_days_Ema = _40_days_Ema_;
             _45_days_Ema = _45_days_Ema_;
             _50_days_Ema = _50_days_Ema_;
             _60_days_Ema = _60_days_Ema_;
        }
    
    
    }
}
