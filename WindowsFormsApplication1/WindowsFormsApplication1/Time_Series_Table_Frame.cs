using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * this class use to load database elements inside program to draw charts and do data mining
 * 
 * 
 * 
 */ 


namespace WindowsFormsApplication1
{
    class Time_Series_Table_Frame
    {
        private DateTime Date;
        private decimal? Open_ ;
        private decimal? High;
        private decimal? Low;
        private decimal? Close_;
        private decimal? Volume;
        private decimal? Adj_Close;
        private decimal? _12_Days_Ema;
        private decimal? _26_Days_Ema;
        private decimal? MACD_12Minus26_days;
        private decimal? _Signal;
        private decimal? _histogram;
        private decimal? Change;
        private decimal? gain;
        private decimal? Loss;
        private decimal? Avg_Gain;
        private decimal? Avg_Loss;
        private decimal? RS;
        private decimal? _14_days_RSI;
        private decimal? highest_high_14;
        private decimal? Lowest_low_14;
        private decimal? _14_day_StochasticOscillator;
        private decimal? _3_days_Ema;
        private decimal? _5_days_Ema;
        private decimal? _8_days_Ema;
        private decimal? _10_days_Ema;
        private decimal? _15_days_Ema;
        private decimal? _30_days_Ema;
        private decimal? _35_days_Ema;
        private decimal? _40_days_Ema;
        private decimal? _45_days_Ema;
        private decimal? _50_days_Ema;
        private decimal? _60_days_Ema;

        public Time_Series_Table_Frame(
           DateTime Date,
          decimal Open_ ,
          decimal High,
          decimal Low,
          decimal Close_,
          decimal Volume,
          decimal Adj_Close,
          decimal _12_Days_Ema,
          decimal _26_Days_Ema ,
          decimal MACD_12Minus26_days,
          decimal _Signal,
          decimal _histogram,
          decimal Change,
          decimal gain,
          decimal Loss,
          decimal Avg_Gain,
          decimal Avg_Loss,
          decimal RS,
          decimal _14_days_RSI,
          decimal highest_high_14,
          decimal Lowest_low_14,
          decimal _14_day_StochasticOscillator,
          decimal  _3_days_Ema,
          decimal _5_days_Ema,
          decimal _8_days_Ema,
          decimal _10_days_Ema,
          decimal _15_days_Ema,
          decimal _30_days_Ema,
          decimal _35_days_Ema,
          decimal _40_days_Ema,
          decimal _45_days_Ema,
          decimal  _50_days_Ema,
          decimal _60_days_Ema
            ) 
        
        {

            this.Date = Date;
            this.Open_ = Open_;
            this.High = High;
            this.Low = Low;
            this.Close_ = Close_;
            this.Volume = Volume;
            this.Adj_Close = Adj_Close;
            this._12_Days_Ema = _12_Days_Ema;
            this._26_Days_Ema = _26_Days_Ema;
            this.MACD_12Minus26_days = MACD_12Minus26_days;
            this._Signal = _Signal;
            this._histogram = _histogram;
            this.Change = Change;
            this.gain = gain;
            this.Loss = Loss;
            this.Avg_Gain = Avg_Gain;
            this.Avg_Loss=Avg_Loss;
            this.RS=RS;
            this._14_days_RSI = _14_days_RSI;
            this.highest_high_14=highest_high_14;
            this.Lowest_low_14=Lowest_low_14;
            this._14_day_StochasticOscillator=_14_day_StochasticOscillator;
            this._3_days_Ema=_3_days_Ema;
            this._5_days_Ema=_5_days_Ema;
            this._8_days_Ema=_8_days_Ema;
            this._10_days_Ema=_10_days_Ema;
            this._15_days_Ema = _15_days_Ema;
            this._30_days_Ema=_30_days_Ema;
            this._35_days_Ema=_35_days_Ema;
            this._40_days_Ema=_40_days_Ema;
            this._45_days_Ema=_45_days_Ema;
            this._50_days_Ema=_50_days_Ema;
            this._60_days_Ema=_60_days_Ema;
        
        
        
        }

         public DateTime getDate() { return Date; }
         public decimal? getOpen() { return Open_; }
         public decimal? getHigh() { return High; }
         public decimal? getLow() { return Low; }
         public decimal? getClose() { return Close_; }
         public decimal? getVolume() { return Volume; }
         public decimal? getAdj_Close() { return Adj_Close; }
         public decimal? get_12_Days_Ema() { return _12_Days_Ema; }
         public decimal? get_26_Days_Ema() { return _26_Days_Ema; }
         public decimal? getMACD_12Minus26_days() { return MACD_12Minus26_days; }
         public decimal? get_Signal() { return _Signal; }
         public decimal? get_histogram() { return _histogram; }
         public decimal? getChange() { return Change; }
         public decimal? getgain() { return gain; }
         public decimal? getLoss() { return Loss; }
         public decimal? getAvg_Gain() { return Avg_Gain; }
         public decimal? getAvg_Loss() { return Avg_Loss; }
         public decimal? getRS() { return RS; }
         public decimal? get_14_days_RSI() { return _14_days_RSI; }
         public decimal? gethighest_high_14() { return highest_high_14; }
         public decimal? getLowest_low_14() { return Lowest_low_14; }
         public decimal? get_14_day_StochasticOscillator() { return _14_day_StochasticOscillator; }
         public decimal? get_3_days_Ema() { return _3_days_Ema; }
         public decimal? get_5_days_Ema() { return _5_days_Ema; }
         public decimal? get_8_days_Ema() { return _8_days_Ema; }
         public decimal? get_10_days_Ema() { return _10_days_Ema; }
         public decimal? get_15_days_Ema() { return _15_days_Ema; }
         public decimal? get_30_days_Ema() { return _30_days_Ema; }
         public decimal? get_35_days_Ema() { return _35_days_Ema; }
         public decimal? get_40_days_Ema() { return _40_days_Ema; }
         public decimal? get_45_days_Ema() { return _45_days_Ema; }
         public decimal? get_50_days_Ema() { return _50_days_Ema; }
         public decimal? get_60_days_Ema() { return _60_days_Ema; }


    }
}
