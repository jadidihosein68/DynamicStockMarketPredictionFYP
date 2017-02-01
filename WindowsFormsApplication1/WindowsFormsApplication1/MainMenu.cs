using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
namespace WindowsFormsApplication1
{
    public partial class MainMenu : Form
    {
        
        public MainMenu()
        {

            Thread t = new Thread(new ThreadStart(Loading));
            t.Start();
            InitializeComponent();

            dataGhateringToolStripMenuItem.MouseHover += new EventHandler(dataGhateringToolStripMenuItem_MouseHover);
            dataAnalysisToolStripMenuItem.MouseHover += new EventHandler(dataAnalysisToolStripMenuItem_MouseHover);
            exitToolStripMenuItem.MouseHover += new EventHandler(exitToolStripMenuItem_MouseHover);

            t.Abort();

        }


        public void Loading() {

            Application.Run(new Loading());
        }

        private void button2_Click(object sender, EventArgs e)
        {
         //   Analyse Ana = new Analyse();
           // Ana.Show();
        }
        void dataGhateringToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Manage Set of Data";
            label1.Refresh();
        }

        void dataAnalysisToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

            label1.Text = "Perform Data Analyse";
            label1.Refresh();
        }

        void exitToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

            label1.Text = "Exit salamander";
            label1.Refresh();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            if (AppSettingUserDef.TextisExist())
            {
                if (!AppSettingUserDef.isValidCSText()) 
                {
                    UpdateConnection updateconnection = new UpdateConnection();
                    updateconnection.Show();
                }

            }
            else
            {
                
                AppSettingUserDef.createCSText();
                UpdateConnection updateconnection = new UpdateConnection();
                updateconnection.Show();
            }
            InitMyProgram initmp = new InitMyProgram();
            try
            {
                List<Analyse_Lists_Frame> AnalyseTable = new List<Analyse_Lists_Frame>();  // For database select pupose
                Connections ss = new Connections();
                ss.loadAnalyseTableInfo("select * from analyse_lists", AnalyseTable);

                for (int i = 0; i < AnalyseTable.Count; i++)
                {
                    ListViewItem lvl = new ListViewItem(AnalyseTable[i].getStock_Table_Name());
                    lvl.SubItems.Add(AnalyseTable[i].getStock_Symbol());
                    lvl.SubItems.Add(AnalyseTable[i].getStarting_Date_().ToShortDateString());
                    lvl.SubItems.Add(AnalyseTable[i].getLast_Date_().ToShortDateString());
                    listView3.Items.Add(lvl);
                }

            }
            catch (Exception )
            {
                MessageBox.Show("Ridi");
            }


            //TopMost = true;
            //FormBorderStyle = FormBorderStyle.None;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGhateringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FYP proj = new FYP();
            proj.Show();
            
        }
        private void dataAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analyse Ana = new Analyse();
            Ana.Show();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About Ab = new About();
            Ab.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(AppSettingUserDef.getConnectionString());
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateConnection UC = new UpdateConnection();
            UC.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AppSettingUserDef.connectionString.ToString(),"Connection String");
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            decimal? maximump = 0;
            decimal? minimump = 0;
            if (this.listView3.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a stock from analysis data table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listView1.Items.Clear();
            listView2.Items.Clear();

            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chart4.Series)
            {
                series.Points.Clear();
            }
            foreach (var series in chart5.Series)
            {
                series.Points.Clear();
            }

            foreach (var series in chart6.Series)
            {
                series.Points.Clear();
            }

            foreach (var series in chart7.Series)
            {
                series.Points.Clear();
            }

            foreach (var series in chart8.Series)
            {
                series.Points.Clear();
            }
            chart6.Series.Clear();
            chart7.Series.Clear();

            List<Time_Series_Table_Frame> MYLIST = new List<Time_Series_Table_Frame>();
            Connections con = new Connections();
            
            //con.loadTime_Serries_Table_Frame(@"select * from YLTVIEW where _60_days_Ema IS not NULL order by Date_", MYLIST);
            try
            {
                
                con.loadTime_Serries_Table_Frame("select * from " + this.listView3.SelectedItems[0].SubItems[0].Text.ToString() + "_allview where _60_days_Ema IS not NULL order by Date_", MYLIST);
            }catch (Exception)
            {
                MessageBox.Show("Please make sure the table is update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            minimump = MYLIST[0].getClose();
            // list view update 
            for (int i = 0; i < MYLIST.Count; i++)
            {

                if (MYLIST[i].getClose() > maximump)
                    maximump = MYLIST[i].getClose();
                else if (MYLIST[i].getClose() < minimump)
                    minimump= MYLIST[i].getClose();

                ListViewItem lvl = new ListViewItem(MYLIST[i].getDate().ToShortDateString());
                lvl.SubItems.Add(MYLIST[i].getOpen().ToString());
                lvl.SubItems.Add(MYLIST[i].getHigh().ToString());
                lvl.SubItems.Add(MYLIST[i].getLow().ToString());
                lvl.SubItems.Add(MYLIST[i].getClose().ToString());
                lvl.SubItems.Add(MYLIST[i].getVolume().ToString());
                lvl.SubItems.Add(MYLIST[i].getAdj_Close().ToString());
                lvl.SubItems.Add(MYLIST[i].get_12_Days_Ema().ToString());
                lvl.SubItems.Add(MYLIST[i].get_26_Days_Ema().ToString());

                lvl.SubItems.Add(MYLIST[i].getMACD_12Minus26_days().ToString());
                lvl.SubItems.Add(MYLIST[i].get_Signal().ToString());
                lvl.SubItems.Add(MYLIST[i].get_histogram().ToString());
                lvl.SubItems.Add(MYLIST[i].getChange().ToString());
                lvl.SubItems.Add(MYLIST[i].getgain().ToString());
                lvl.SubItems.Add(MYLIST[i].getLoss().ToString());
                lvl.SubItems.Add(MYLIST[i].getAvg_Gain().ToString());
                lvl.SubItems.Add(MYLIST[i].getAvg_Loss().ToString());

                lvl.SubItems.Add(MYLIST[i].getRS().ToString());
                lvl.SubItems.Add(MYLIST[i].get_14_days_RSI().ToString());
                lvl.SubItems.Add(MYLIST[i].gethighest_high_14().ToString());
                lvl.SubItems.Add(MYLIST[i].getLowest_low_14().ToString());
                lvl.SubItems.Add(MYLIST[i].get_14_day_StochasticOscillator().ToString());
                lvl.SubItems.Add(MYLIST[i].get_3_days_Ema().ToString());
                lvl.SubItems.Add(MYLIST[i].get_5_days_Ema().ToString());
                lvl.SubItems.Add(MYLIST[i].get_8_days_Ema().ToString());

                lvl.SubItems.Add(MYLIST[i].get_10_days_Ema().ToString());
                lvl.SubItems.Add(MYLIST[i].get_15_days_Ema().ToString());
                lvl.SubItems.Add(MYLIST[i].get_30_days_Ema().ToString());
                lvl.SubItems.Add(MYLIST[i].get_35_days_Ema().ToString());
                lvl.SubItems.Add(MYLIST[i].get_40_days_Ema().ToString());
                lvl.SubItems.Add(MYLIST[i].get_45_days_Ema().ToString());
                lvl.SubItems.Add(MYLIST[i].get_50_days_Ema().ToString());
                lvl.SubItems.Add(MYLIST[i].get_60_days_Ema().ToString());
                listView1.Items.Add(lvl);
                ////////////////////////////////////    list view 2 update 
                ListViewItem lvl2 = new ListViewItem(MYLIST[i].getDate().ToString());
                lvl2.SubItems.Add(MYLIST[i].getMACD_12Minus26_days().ToString());
                lvl2.SubItems.Add(MYLIST[i].get_Signal().ToString());

                lvl2.SubItems.Add(MYLIST[i].get_14_day_StochasticOscillator().ToString());
                lvl2.SubItems.Add(MYLIST[i].get_14_days_RSI().ToString());

                listView2.Items.Add(lvl2);

                ///////////////////////////////////     charts update 

                this.chart1.Series["MACD"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].getMACD_12Minus26_days());
                this.chart1.Series["SIGNAL"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_Signal());
                this.chart1.Series["Histogram"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_histogram());
                this.chart2.Series["Stocastic"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_14_day_StochasticOscillator());
                this.chart3.Series["RSI"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_14_days_RSI());

                this.chart4.Series["Short 3 day"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_3_days_Ema());
                this.chart4.Series["Short 5 day"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_5_days_Ema());
                this.chart4.Series["Short 8 day"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_8_days_Ema());
                this.chart4.Series["Short 10 day"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_10_days_Ema());
                this.chart4.Series["Short 12 day"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_12_Days_Ema());
                this.chart4.Series["Short 15 day"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_15_days_Ema());
                this.chart4.Series["Long 30 days"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_30_days_Ema());
                this.chart4.Series["Long 35 days"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_35_days_Ema());
                this.chart4.Series["Long 40 days"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_40_days_Ema());
                this.chart4.Series["Long 45 days"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_45_days_Ema());
                this.chart4.Series["Long 50 days"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_50_days_Ema());
                this.chart4.Series["Long 60 days"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].get_60_days_Ema());
                // it contains Date, High, Low, Open, Close
                this.chart5.Series["ClosePrice"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].getClose());
                this.chart5.Series["Price"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].getHigh(), MYLIST[i].getLow(), MYLIST[i].getOpen(), MYLIST[i].getClose());
                this.chart4.Series["Price"].Points.AddXY(MYLIST[i].getDate().ToShortDateString(), MYLIST[i].getHigh(), MYLIST[i].getLow(), MYLIST[i].getOpen(), MYLIST[i].getClose());
            }



            this.chart5.Series[0]["PriceUpColor"] = "Green";
            this.chart5.Series[0]["PriceDownColor"] = "Red";
            this.chart4.Series["Price"]["PriceUpColor"] = "Green";
            this.chart4.Series["Price"]["PriceDownColor"] = "Red";
            this.chart5.Series["Price"].Enabled = false;
            this.chart5.Series["ClosePrice"].Enabled = true;
  
            /*
            foreach (var series in chart5.Series)
            {
                this.chart6.Series.Add(series);
                this.chart8.Series.Add(series);
                this.chart7.Series.Add(series);
                
            }
            */
 
            foreach (var series in chart5.Series)
                chart6.Series.Add(series);

           foreach (var series in chart5.Series)
                chart7.Series.Add(series);

            //foreach (var series in chart5.Series)
                //chart8.Series.Add(series);

          // MessageBox.Show(this.chart5.ChartAreas[0].AxisY.Maximum.ToString());
          // MessageBox.Show(chart5.Series["Price"].Points.FindMaxByValue().ToString());
           //MessageBox.Show(chart1.Series["Price"].AxisX.Maximum.ToString());

           chart5.ChartAreas[0].AxisY.Maximum = (double)maximump;
           chart5.ChartAreas[0].AxisY.Minimum = (double)minimump;
           chart6.ChartAreas[0].AxisY.Maximum = (double)maximump;
           chart6.ChartAreas[0].AxisY.Minimum = (double)minimump;
           chart7.ChartAreas[0].AxisY.Maximum = (double)maximump;
           chart7.ChartAreas[0].AxisY.Minimum = (double)minimump;




            //MessageBox.Show(chart5.Series["Price"].Points.FindMaxByValue().ToString());
          // chart5.ChartAreas[0].RecalculateAxesScale();
           //MessageBox.Show(maximump.ToString());
           //MessageBox.Show(this.chart5.ChartAreas[0].AxisY.Maximum.ToString());

            // update normalize table : 

           try
           {
               List<Normalized_Frame_Work> mylist = new List<Normalized_Frame_Work>();
               List<GMMA_Frame> mytable = new List<GMMA_Frame>();
               string name = this.listView3.SelectedItems[0].SubItems[0].Text.ToString();
               string query =
                    "DECLARE @closemax money , " +
                    "@closeMin money ,  " +
                    "@RSIMax decimal(14,4) , " +
                    "@RSIMin decimal(14,4) ,  " +
                    "@KDMax decimal(14,4) ,  " +
                    "@KDMin decimal(14,4) ,  " +
                    "@MACDMax decimal(14,4) ,  " +
                    "@MACDMin decimal(14,4) ,  " +
                    "@_3_days_EmaMax decimal(14,4) ,  " +
                    "@_3_days_EmaMin decimal(14,4) ,  " +
                    "@_60_days_EmaMax decimal(14,4) , " +
                    "@_60_days_EmaMin decimal(14,4)  " +
                    "SET @closemax = (select MAX(Close_)from " + name + "_AllView where _60_days_Ema is not null)  " +
                    "SET @closeMin = (select min(Close_) from " + name + "_AllView where _60_days_Ema is not null) " +
                    "SET @RSIMax = (select max(_14_days_RSI) from " + name + "_AllView where _60_days_Ema is not null) " +
                    "SET @RSIMin = (select min(_14_days_RSI) from " + name + "_AllView where _60_days_Ema is not null) " +
                    "SET @KDMax = (select max(_14_day_StochasticOscillator) from " + name + "_AllView where _60_days_Ema is not null) " +
                    "SET @KDMin = (select min(_14_day_StochasticOscillator) from " + name + "_AllView where _60_days_Ema is not null) " +
                    "SET @MACDMax = (select max(MACD_12Minus26_days) from " + name + "_AllView where _60_days_Ema is not null) " +
                    "SET @MACDMin = (select min(MACD_12Minus26_days) from " + name + "_AllView where _60_days_Ema is not null) " +
                    "SET @_60_days_EmaMax = (select MAX(_60_days_Ema)from " + name + "_AllView where _60_days_Ema is not null) " +
                    "SET @_60_days_EmaMin = (select min(_60_days_Ema)from " + name + "_AllView where _60_days_Ema is not null) " +
                    "SET @_3_days_EmaMax = (select MAX(_3_days_Ema)from " + name + "_AllView where _60_days_Ema is not null) " +
                    "SET @_3_days_EmaMin = (select min(_3_days_Ema)from " + name + "_AllView where _60_days_Ema is not null) " +
                    "SELECT  " +
                    "Date_ , " +
                    "((Close_ - @closeMin)/(@closemax-@closeMin)) as Close_Normal,   " +
                    "((MACD_12Minus26_days - @MACDMin)/(@MACDMax-@MACDMin)) as MACD_Normal, " +
                    "((_14_day_StochasticOscillator - @KDMin)/(@KDMax-@KDMin))as KD_Normal, " +
                    "((_14_days_RSI - @RSIMin)/(@RSIMax-@RSIMin)) as RSI_Normal , " +
                    "((_3_days_Ema - @_3_days_EmaMin)/(@_3_days_EmaMax-@_3_days_EmaMin)) as _3_days_Ema_Normal , " +
                    "((_60_days_Ema - @_60_days_EmaMin)/(@_60_days_EmaMax-@_60_days_EmaMin)) as _60_days_Ema_Normal " +
                    "from " + name + "_AllView  " +
                    "where _60_days_Ema is not null ";
                    con.loadNormlized(query, mylist);

                    query =
                       "DECLARE " +
                       "@_3_days_EmaMax decimal(14,4) ,  " +
                       "@_3_days_EmaMin decimal(14,4) ,  " +
                       "@_5_days_EmaMax decimal(14,4) ,  " +
                       "@_5_days_EmaMin decimal(14,4) ,  " +
                       "@_8_days_EmaMax decimal(14,4) ,  " +
                       "@_8_days_EmaMin decimal(14,4) ,  " +
                       "@_10_days_EmaMax decimal(14,4) ,  " +
                       "@_10_days_EmaMin decimal(14,4) ,  " +
                       "@_12_days_EmaMax decimal(14,4) ,  " +
                       "@_12_days_EmaMin decimal(14,4) ,  " +
                       "@_15_days_EmaMax decimal(14,4) ,  " +
                       "@_15_days_EmaMin decimal(14,4) ,  " +
                       "@_30_days_EmaMax decimal(14,4) ,  " +
                       "@_30_days_EmaMin decimal(14,4) ,  " +
                       "@_35_days_EmaMax decimal(14,4) ,  " +
                       "@_35_days_EmaMin decimal(14,4) ,  " +
                       "@_40_days_EmaMax decimal(14,4) ,  " +
                       "@_40_days_EmaMin decimal(14,4) ,  " +
                       "@_45_days_EmaMax decimal(14,4) ,  " +
                       "@_45_days_EmaMin decimal(14,4) ,  " +
                       "@_50_days_EmaMax decimal(14,4) ,  " +
                       "@_50_days_EmaMin decimal(14,4) ,  " +
                       "@_60_days_EmaMax decimal(14,4) ,  " +
                       "@_60_days_EmaMin decimal(14,4)   " +
                       "SET @_3_days_EmaMax = (select MAX(_3_days_Ema)from " + name + "_AllView where _60_days_Ema is not null) " +
                       "SET @_5_days_EmaMax = (select MAX(_5_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_8_days_EmaMax = (select MAX(_8_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_12_days_EmaMax = (select MAX(_12_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_15_days_EmaMax = (select MAX(_15_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_10_days_EmaMax = (select MAX(_10_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_30_days_EmaMax = (select MAX(_30_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_35_days_EmaMax = (select MAX(_35_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_40_days_EmaMax = (select MAX(_40_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_45_days_EmaMax = (select MAX(_45_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_50_days_EmaMax = (select MAX(_50_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_60_days_EmaMax = (select MAX(_60_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_3_days_EmaMin = (select min(_3_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_5_days_EmaMin = (select min(_5_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_8_days_EmaMin = (select min(_8_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_10_days_EmaMin = (select min(_10_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_12_days_EmaMin = (select min(_12_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_15_days_EmaMin = (select min(_15_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_30_days_EmaMin = (select min(_30_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_35_days_EmaMin = (select min(_35_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_40_days_EmaMin = (select min(_40_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_45_days_EmaMin = (select min(_45_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_50_days_EmaMin = (select min(_50_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SET @_60_days_EmaMin = (select min(_60_days_Ema)from " + name + "_AllView where _60_days_Ema is not null)  " +
                       "SELECT DATE_, " +
                       "((_3_days_Ema - @_3_days_EmaMin)/(@_3_days_EmaMax-@_3_days_EmaMin)) as _3_days_Ema_Normal ,  " +
                       "((_5_days_Ema - @_5_days_EmaMin)/(@_5_days_EmaMax-@_5_days_EmaMin)) as _5_days_Ema_Normal , " +
                       "((_8_days_Ema - @_8_days_EmaMin)/(@_8_days_EmaMax-@_8_days_EmaMin)) as _8_days_Ema_Normal , " +
                       "((_10_days_Ema - @_10_days_EmaMin)/(@_10_days_EmaMax-@_10_days_EmaMin)) as _10_days_Ema_Normal , " +
                       "((_12_days_Ema - @_12_days_EmaMin)/(@_12_days_EmaMax-@_12_days_EmaMin)) as _12_days_Ema_Normal , " +
                       "((_15_days_Ema - @_15_days_EmaMin)/(@_15_days_EmaMax-@_15_days_EmaMin)) as _15_days_Ema_Normal , " +
                       "((_30_days_Ema - @_30_days_EmaMin)/(@_30_days_EmaMax-@_30_days_EmaMin)) as _30_days_Ema_Normal , " +
                       "((_35_days_Ema - @_35_days_EmaMin)/(@_35_days_EmaMax-@_35_days_EmaMin)) as _35_days_Ema_Normal , " +
                       "((_40_days_Ema - @_40_days_EmaMin)/(@_40_days_EmaMax-@_40_days_EmaMin)) as _40_days_Ema_Normal , " +
                       "((_45_days_Ema - @_45_days_EmaMin)/(@_45_days_EmaMax-@_45_days_EmaMin)) as _45_days_Ema_Normal , " +
                       "((_50_days_Ema - @_50_days_EmaMin)/(@_50_days_EmaMax-@_50_days_EmaMin)) as _50_days_Ema_Normal , " +
                       "((_60_days_Ema - @_60_days_EmaMin)/(@_60_days_EmaMax-@_60_days_EmaMin)) as _60_days_Ema_Normal  " +
                       "from " + name + "_AllView " +
                       "where _60_days_Ema is not null";

                    con.loadGMMA(query, mytable);
              
                    for (int i = 0; i < mylist.Count; i++)
                    {
                        this.chart8.Series["Price"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mylist[i].getClose());
                        this.chart8.Series["MACD"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mylist[i].getMACD());
                        this.chart8.Series["RSI"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mylist[i].getRSI());
                        this.chart8.Series["Stochastic"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mylist[i].getKD());
                        this.chart8.Series["GMMA_3_day"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mytable[i].get_3_days_Ema());
                        this.chart8.Series["GMMA_5_day"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mytable[i].get_5_days_Ema());
                        this.chart8.Series["GMMA_8_day"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mytable[i].get_8_days_Ema());
                        this.chart8.Series["GMMA_10_day"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mytable[i].get_10_days_Ema());
                        this.chart8.Series["GMMA_12_day"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mytable[i].get_12_days_Ema());
                        this.chart8.Series["GMMA_15_day"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mytable[i].get_15_days_Ema());
                        this.chart8.Series["GMMA_30_day"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mytable[i].get_30_days_Ema());
                        this.chart8.Series["GMMA_35_day"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mytable[i].get_35_days_Ema());
                        this.chart8.Series["GMMA_40_day"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mytable[i].get_40_days_Ema());
                        this.chart8.Series["GMMA_45_day"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mytable[i].get_45_days_Ema());
                        this.chart8.Series["GMMA_50_day"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mytable[i].get_50_days_Ema());
                        this.chart8.Series["GMMA_60_day"].Points.AddXY(mylist[i].getDate().ToShortDateString(), mytable[i].get_60_days_Ema());

                    }

           }
           catch (Exception ex) {
               MessageBox.Show("Normalize table is not updated please check dataset");
           }

            //

           chart8.ChartAreas[0].AxisY.Maximum = 1;





        }

        private void UpdateViewMACD_Click(object sender, EventArgs e)
        {
           // if (Convert.ToInt32(ThicknessBox.Text) < 0)
//MessageBox.Show("Tickness can not be negative");

            double nn;
            if (MACDYAxisMax.Text != "" && MACDYAxisMin.Text != "")
                if (double.TryParse(MACDYAxisMax.Text, out nn) && double.TryParse(MACDYAxisMin.Text, out nn))
            if (Convert.ToDouble(MACDYAxisMax.Text) <= Convert.ToDouble(MACDYAxisMin.Text))
            {
                MessageBox.Show("Maximum value should be bigger than minimum value");
                return;
            } 



            double n;
            if (double.TryParse(comboBox1.Text, out n))
                //chart5.ChartAreas[0].AxisX.Interval = Double.NaN;
                chart1.ChartAreas[0].AxisX.Interval = Convert.ToDouble(comboBox1.Text);
            else
                MessageBox.Show("Please double check X-Axis interval for price table");

            if (double.TryParse(ThicknessBox.Text, out n))
            {
                
                chart1.Series["MACD"].BorderWidth = Convert.ToInt32(ThicknessBox.Text);
                chart1.Series["SIGNAL"].BorderWidth = Convert.ToInt32(ThicknessBox.Text);
            }
            else
                MessageBox.Show("Please double check price thickness ");

            if (MACDYAxisInterval.Text != "")
                if (double.TryParse(MACDYAxisInterval.Text, out n))
                    chart1.ChartAreas[0].AxisY.Interval = Convert.ToDouble(MACDYAxisInterval.Text);
                else
                    MessageBox.Show("Please input an integer number and try again");

            if (MACDYAxisMax.Text != "")
                if (double.TryParse(MACDYAxisMax.Text, out n))
                    chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(MACDYAxisMax.Text);
                else
                    MessageBox.Show("Please input an integer number and try again");



            if (MACDYAxisMin.Text != "")
                if (double.TryParse(MACDYAxisMin.Text, out n))
                    chart1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(MACDYAxisMin.Text);
                else
                    MessageBox.Show("Please input an integer number and try again");
        }


        private void UpdateViewSTOC_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(comboStochasticInterval.Text, out n))
                chart2.ChartAreas[0].AxisX.Interval = Convert.ToDouble(comboStochasticInterval.Text);
            else
                MessageBox.Show("Please input an integer number and try again");
        }

        private void UpdateViewRSI_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(comboRSIInterval.Text, out n))
                chart3.ChartAreas[0].AxisX.Interval = Convert.ToDouble(comboRSIInterval.Text);
            else
                MessageBox.Show("Please input an integer number and try again");
        }

        private void UpdateViewGUPPY_Click(object sender, EventArgs e)
        {
            double nn;
            if (GUPPYYAxisMaxPrice.Text != "" && GUPPYYAxisMinPrice.Text != "")
                if (double.TryParse(GUPPYYAxisMaxPrice.Text, out nn) && double.TryParse(GUPPYYAxisMinPrice.Text, out nn))
            if (Convert.ToDouble(GUPPYYAxisMaxPrice.Text) <= Convert.ToDouble(GUPPYYAxisMinPrice.Text))
            {
                MessageBox.Show("Maximum value should be bigger than minimum value");
                return;
            } 

            if (checkBox1.Checked)
            {

                //chart4.Series["Price"].IsVisibleInLegend = true;
                chart4.Series["Price"].Enabled = true;

                switch (comboBox3.Text.ToString())
            {
                case "Line":
                    this.chart4.Series[12].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    break ;
                case "Stock":
                    this.chart4.Series[12].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Stock;
                    break ;
                case "Candlestick":
                    this.chart4.Series[12].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
                    break ;
            }

            }
            else {

                chart4.Series["Price"].Enabled = false;
            }  
            double n;
            if (double.TryParse(comboGUPPYInterval.Text, out n))
                chart4.ChartAreas[0].AxisX.Interval = Convert.ToDouble(comboGUPPYInterval.Text);
            else
                MessageBox.Show("Please input an integer number and try again");


            if (double.TryParse(GUPPYThicknessPriceBox.Text, out n))
            {
                chart4.Series["Price"].BorderWidth = Convert.ToInt32(GUPPYThicknessPriceBox.Text);
                //chart4.Series["ClosePrice"].BorderWidth = Convert.ToInt32(ThicknessPriceBox.Text);
            }
            else
                MessageBox.Show("Please double check price thickness ");

            if (GUPPYYAxisIntervalPrice.Text != "")
                if (double.TryParse(GUPPYYAxisIntervalPrice.Text, out n))
                    chart4.ChartAreas[0].AxisY.Interval = Convert.ToDouble(GUPPYYAxisIntervalPrice.Text);
                else
                    MessageBox.Show("Please input an integer number and try again");

            if (GUPPYYAxisMaxPrice.Text != "")
                if (double.TryParse(GUPPYYAxisMaxPrice.Text, out n))
                    chart4.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(GUPPYYAxisMaxPrice.Text);
                else
                    MessageBox.Show("Please input an integer number and try again");


            if (GUPPYYAxisMinPrice.Text != "")
                if (double.TryParse(GUPPYYAxisMinPrice.Text, out n))
                    chart4.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(GUPPYYAxisMinPrice.Text);
                else
                    MessageBox.Show("Please input an integer number and try again");
        
        
        
        
        
        
        
        
        
        }


        private void DefaultViewMACD_Click(object sender, EventArgs e)
        {

            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Minimum = Double.NaN;
            chart1.ChartAreas[0].AxisY.Maximum = Double.NaN;
            chart1.Series["SIGNAL"].BorderWidth = 2;
            chart1.Series["MACD"].BorderWidth = 2;
            chart1.ChartAreas[0].AxisY.Interval = Double.NaN;



        }

        private void UpdateViewMACDPrice_Click_1(object sender, EventArgs e)
        {

            double nn;
            if (MACDYAxisMaxPrice.Text != "" && MACDYAxisMinPrice.Text!="")
                if (double.TryParse(MACDYAxisMaxPrice.Text, out nn) && double.TryParse(MACDYAxisMinPrice.Text, out nn))
                    if (Convert.ToDouble(MACDYAxisMaxPrice.Text) <= Convert.ToDouble(MACDYAxisMinPrice.Text))
                    {
                        MessageBox.Show("Maximum value should be bigger than minimum value");
                        return;
                    } 
                //else
                   // MessageBox.Show("Please input an integer number and try again");
            
            


            switch (ChaertTypeMACDPrice.Text.ToString())
            {
                case "Line":
                    this.chart5.Series["Price"].Enabled = false;
                    this.chart5.Series["ClosePrice"].Enabled = true;
                    this.chart5.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    break ;
                case "Stock":
                    this.chart5.Series["Price"].Enabled = true;
                    this.chart5.Series["ClosePrice"].Enabled = false;
                    this.chart5.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Stock;
                    break ;

                case "Candlestick":
                    this.chart5.Series["Price"].Enabled = true;
                    this.chart5.Series["ClosePrice"].Enabled = false;
                    this.chart5.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
                    break;
                    /*
                case "BoxPlot":
                    chart5.Series["Price"].Enabled = true;
                    chart5.Series["ClosePrice"].Enabled = false;
                    chart5.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
                    break;
                     */ 
            }
            
            
            double n;
            if (double.TryParse(comboBox2.Text, out n))
                //chart5.ChartAreas[0].AxisX.Interval = Double.NaN;
                chart5.ChartAreas[0].AxisX.Interval = Convert.ToDouble(comboBox2.Text);
            else
                MessageBox.Show("Please double check X-Axis interval for price table");

            if (double.TryParse(ThicknessPriceBox.Text, out n))
            {
                chart5.Series["Price"].BorderWidth = Convert.ToInt32(ThicknessPriceBox.Text);
                chart5.Series["ClosePrice"].BorderWidth = Convert.ToInt32(ThicknessPriceBox.Text);
            }
            else
                MessageBox.Show("Please double check price thickness ");

            if (MACDYAxisIntervalPrice.Text != "")
                if (double.TryParse(MACDYAxisIntervalPrice.Text, out n))
                    chart5.ChartAreas[0].AxisY.Interval = Convert.ToDouble(MACDYAxisIntervalPrice.Text);
                else
                    MessageBox.Show("Please input an integer number and try again");

            if (MACDYAxisMaxPrice.Text != "")
                if (double.TryParse(MACDYAxisMaxPrice.Text, out n))
                    chart5.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(MACDYAxisMaxPrice.Text);
                else
                    MessageBox.Show("Please input an integer number and try again");



            if (MACDYAxisMinPrice.Text != "")
                if (double.TryParse(MACDYAxisMinPrice.Text, out n))
                    chart5.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(MACDYAxisMinPrice.Text);
                else
                    MessageBox.Show("Please input an integer number and try again");
        


        }

        private void DefaultViewMACDPrice_Click_1(object sender, EventArgs e)
        {
            chart5.ChartAreas[0].AxisX.Interval = 1;
            chart5.ChartAreas[0].AxisY.Minimum = Double.NaN;
            chart5.ChartAreas[0].AxisY.Maximum = Double.NaN;
            chart5.Series["Price"].BorderWidth = 2;
            chart5.ChartAreas[0].AxisY.Interval = Double.NaN;
        }

     

        private void userTweetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TwitterManagement Twitter = new TwitterManagement();
            Twitter.Show();
        }

        private void qualitativeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportQualitative ExportQual = new ExportQualitative();
            ExportQual.Show();
        }

        private void matchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Matching MyMatching = new Matching();
            MyMatching.Show();
        }

        private void quantitativeDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExportQuantitative ExportQuat = new ExportQuantitative();
            ExportQuat.Show();
        }

        private void counterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Counter mycounter = new Counter();
            mycounter.Show();
        }

        private void chart2_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            chart2.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            chart2.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);
            
            double pY = chart2.ChartAreas[0].CursorY.Position;
            //double px = chart2.ChartAreas[0].CursorY.Position;
            label29.Text = pY.ToString();

        }

        private void chart3_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            chart3.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            chart3.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);

            double pY = chart3.ChartAreas[0].CursorY.Position;
            //double px = chart2.ChartAreas[0].CursorY.Position;
            label31.Text = pY.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            GUPPYThicknessPriceBox.Enabled = !GUPPYThicknessPriceBox.Enabled;
            comboBox3.Enabled = !comboBox3.Enabled;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            double nn;
            if (NormalYAxisMaxPrice.Text != "" && NormalYAxisMinPrice.Text != "")
                if (double.TryParse(NormalYAxisMaxPrice.Text, out nn) && double.TryParse(NormalYAxisMinPrice.Text, out nn))
               if (Convert.ToDouble(NormalYAxisMaxPrice.Text)<=Convert.ToDouble(NormalYAxisMinPrice.Text))
               { 
                   MessageBox.Show("Maximum value should be bigger than minimum value");
                   return;
               } 
            //domainUpDown1.MinimumSize = domainUpDown1.Value + 1;
            //chart4.Series["Price"].Enabled = true;
            this.chart8.Series["Price"].Enabled = checkBox2.Checked;
            this.chart8.Series["MACD"].Enabled =checkBox3.Checked;
            this.chart8.Series["RSI"].Enabled =checkBox4.Checked;
            this.chart8.Series["Stochastic"].Enabled =checkBox5.Checked;
            this.chart8.Series["GMMA_3_day"].Enabled =checkBox6.Checked;
            this.chart8.Series["GMMA_5_day"].Enabled =checkBox7.Checked;
            this.chart8.Series["GMMA_8_day"].Enabled =checkBox8.Checked;
            this.chart8.Series["GMMA_10_day"].Enabled =checkBox9.Checked;
            this.chart8.Series["GMMA_12_day"].Enabled =checkBox10.Checked;
            this.chart8.Series["GMMA_15_day"].Enabled =checkBox11.Checked;
            this.chart8.Series["GMMA_30_day"].Enabled =checkBox12.Checked;
            this.chart8.Series["GMMA_35_day"].Enabled =checkBox13.Checked;
            this.chart8.Series["GMMA_40_day"].Enabled =checkBox14.Checked;
            this.chart8.Series["GMMA_45_day"].Enabled =checkBox15.Checked;
            this.chart8.Series["GMMA_50_day"].Enabled =checkBox16.Checked;
            this.chart8.Series["GMMA_60_day"].Enabled =checkBox17.Checked;


            double n;
            if (double.TryParse(comboNormalInterval.Text, out n))
                chart8.ChartAreas[0].AxisX.Interval = Convert.ToDouble(comboNormalInterval.Text);
            else
                MessageBox.Show("Please input an integer number and try again");



            if (double.TryParse(numericUpDown1.Text, out n))
            {
                int thickness = Convert.ToInt32(numericUpDown1.Text);
                this.chart8.Series["Price"].BorderWidth = thickness;
                this.chart8.Series["MACD"].BorderWidth = thickness;
                this.chart8.Series["RSI"].BorderWidth = thickness;
                this.chart8.Series["Stochastic"].BorderWidth = thickness;
                this.chart8.Series["GMMA_3_day"].BorderWidth = thickness;
                this.chart8.Series["GMMA_5_day"].BorderWidth = thickness;
                this.chart8.Series["GMMA_8_day"].BorderWidth = thickness;
                this.chart8.Series["GMMA_10_day"].BorderWidth = thickness;
                this.chart8.Series["GMMA_12_day"].BorderWidth = thickness;
                this.chart8.Series["GMMA_15_day"].BorderWidth = thickness;
                this.chart8.Series["GMMA_30_day"].BorderWidth = thickness;
                this.chart8.Series["GMMA_35_day"].BorderWidth = thickness;
                this.chart8.Series["GMMA_40_day"].BorderWidth = thickness;
                this.chart8.Series["GMMA_45_day"].BorderWidth = thickness;
                this.chart8.Series["GMMA_50_day"].BorderWidth = thickness;
                this.chart8.Series["GMMA_60_day"].BorderWidth = thickness;

                //chart4.Series["ClosePrice"].BorderWidth = Convert.ToInt32(ThicknessPriceBox.Text);
            }
            else
                MessageBox.Show("Please double check price thickness ");

            if (NormalizeYaxisintervalPrice.Text != "")
                if (double.TryParse(NormalizeYaxisintervalPrice.Text, out n))
                    chart8.ChartAreas[0].AxisY.Interval = Convert.ToDouble(NormalizeYaxisintervalPrice.Text);
                else
                    MessageBox.Show("Please input an integer number and try again");

            if (NormalYAxisMaxPrice.Text != "")
                if (double.TryParse(NormalYAxisMaxPrice.Text, out n))
                    chart8.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(NormalYAxisMaxPrice.Text);
                else
                {
                    MessageBox.Show("Please input an integer number and try again");
                return ;
                }

            if (NormalYAxisMinPrice.Text != "")
                if (double.TryParse(NormalYAxisMinPrice.Text, out n))
                    chart8.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(NormalYAxisMinPrice.Text);
                else
                {
                    MessageBox.Show("Please input an integer number and try again");
                return ;
                }

            switch (comboBox4.Text.ToString())
            {

                case "SeaGreen":

                    this.chart8.Palette = ChartColorPalette.SeaGreen;
                break;
                case "Excel" :
                this.chart8.Palette = ChartColorPalette.Excel;
                break;
                case "Berry":
                this.chart8.Palette = ChartColorPalette.Berry;
                break;
                case "Bright":
                this.chart8.Palette = ChartColorPalette.Bright;
                break;
                case "BrightPastel":
                this.chart8.Palette = ChartColorPalette.BrightPastel;
                break;
                case "Chocolate":
                this.chart8.Palette = ChartColorPalette.Chocolate;
                break;
                case "EarthTones":
                this.chart8.Palette = ChartColorPalette.EarthTones;
                break;
                case "Fire":
                this.chart8.Palette = ChartColorPalette.Fire;
                break;
                case "Grayscale":
                this.chart8.Palette = ChartColorPalette.Grayscale;
                break;
                case "Light":
                this.chart8.Palette = ChartColorPalette.Light;
                break;
                case "Pastel":
                this.chart8.Palette = ChartColorPalette.Pastel;
                break;







            }

        }

        private void chart8_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            chart8.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            chart8.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);


            double pY = chart8.ChartAreas[0].CursorY.Position;
            double px = chart8.ChartAreas[0].CursorY.Position;
            label28.Text = pY.ToString();
        }

        private void appendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Join joinTable = new Join();
            joinTable.Show();




        }

       
        



    }
}
