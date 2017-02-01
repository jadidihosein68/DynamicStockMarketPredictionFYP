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
namespace WindowsFormsApplication1
{
    public partial class ExportQuantitative : Form
    {
        Connections ss;
        public ExportQuantitative()
        {
            InitializeComponent();
            try
            {
                List<Analyse_Lists_Frame> AnalyseTable = new List<Analyse_Lists_Frame>();  // For database select pupose
                ss = new Connections();
                ss.loadAnalyseTableInfo("select * from analyse_lists", AnalyseTable);

                for (int i = 0; i < AnalyseTable.Count; i++)
                {
                    ListViewItem lvl = new ListViewItem(AnalyseTable[i].getStock_Table_Name());
                    lvl.SubItems.Add(AnalyseTable[i].getStock_Symbol());
                    lvl.SubItems.Add(AnalyseTable[i].getStarting_Date_().ToShortDateString());
                    lvl.SubItems.Add(AnalyseTable[i].getLast_Date_().ToShortDateString());
                    listView1.Items.Add(lvl);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ridi");
            }
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Export_Click(object sender, EventArgs e)
        {


            if (this.listView1.SelectedItems.Count == 0 )
            {
                MessageBox.Show("Please select a Table to export ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (NormalSeriesChekbox.Checked)
            {
                List<Normalized_Frame_Work> mylist = new List<Normalized_Frame_Work>();
               /*
                * select normalized tabel
                */ 
                string name = this.listView1.SelectedItems[0].SubItems[0].Text.ToString();

                string query =
                "DECLARE @closemax money , "+
                "@closeMin money ,  "+
                "@RSIMax decimal(14,4) , "+ 
                "@RSIMin decimal(14,4) ,  "+
                "@KDMax decimal(14,4) ,  "+
                "@KDMin decimal(14,4) ,  "+
                "@MACDMax decimal(14,4) ,  "+
                "@MACDMin decimal(14,4) ,  "+
                "@_3_days_EmaMax decimal(14,4) ,  "+
                "@_3_days_EmaMin decimal(14,4) ,  "+
                "@_60_days_EmaMax decimal(14,4) , "+ 
                "@_60_days_EmaMin decimal(14,4)  "+
                "SET @closemax = (select MAX(Close_)from " + name + "_AllView where _60_days_Ema is not null)  " +
                "SET @closeMin = (select min(Close_) from " + name +"_AllView where _60_days_Ema is not null) " +
                "SET @RSIMax = (select max(_14_days_RSI) from " +name + "_AllView where _60_days_Ema is not null) " +
                "SET @RSIMin = (select min(_14_days_RSI) from " + name +"_AllView where _60_days_Ema is not null) " +
                "SET @KDMax = (select max(_14_day_StochasticOscillator) from " + name +"_AllView where _60_days_Ema is not null) " +
                "SET @KDMin = (select min(_14_day_StochasticOscillator) from " + name +"_AllView where _60_days_Ema is not null) " +
                "SET @MACDMax = (select max(MACD_12Minus26_days) from " + name + "_AllView where _60_days_Ema is not null) " +
                "SET @MACDMin = (select min(MACD_12Minus26_days) from " + name + "_AllView where _60_days_Ema is not null) " +
                "SET @_60_days_EmaMax = (select MAX(_60_days_Ema)from " + name + "_AllView where _60_days_Ema is not null) " +
                "SET @_60_days_EmaMin = (select min(_60_days_Ema)from " + name + "_AllView where _60_days_Ema is not null) " +
                "SET @_3_days_EmaMax = (select MAX(_3_days_Ema)from " + name + "_AllView where _60_days_Ema is not null) " +
                "SET @_3_days_EmaMin = (select min(_3_days_Ema)from " + name + "_AllView where _60_days_Ema is not null) " +
                "SELECT  "+
                "Date_ , "+
                "((Close_ - @closeMin)/(@closemax-@closeMin)) as Close_Normal,   "+
                "((MACD_12Minus26_days - @MACDMin)/(@MACDMax-@MACDMin)) as MACD_Normal, "+
                "((_14_day_StochasticOscillator - @KDMin)/(@KDMax-@KDMin))as KD_Normal, "+
                "((_14_days_RSI - @RSIMin)/(@RSIMax-@RSIMin)) as RSI_Normal , "+
                "((_3_days_Ema - @_3_days_EmaMin)/(@_3_days_EmaMax-@_3_days_EmaMin)) as _3_days_Ema_Normal , " +
                "((_60_days_Ema - @_60_days_EmaMin)/(@_60_days_EmaMax-@_60_days_EmaMin)) as _60_days_Ema_Normal "  +
                "from " + name +"_AllView  " +
                "where _60_days_Ema is not null ";
            

                ss.loadNormlized(query, mylist);




                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                Export exp = new Export();


                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog1.ValidateNames = true;
                saveFileDialog1.DereferenceLinks = false;
                saveFileDialog1.Filter = "Excel |*.xlsx|CSV|*.csv";
                //saveFileDialog1.Filter = "Excel |*.xlsx|CSV|*.csv";
                saveFileDialog1.Title = "Export Quantitative";
                saveFileDialog1.ShowDialog();
                //Thread t2 = new Thread(new ThreadStart(Loading));
                //t2.Start();
                if (saveFileDialog1.FileName != "")
                {
                    // System.IO.FileStream fs =
                    //(System.IO.FileStream)saveFileDialog1.OpenFile();

                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            MessageBox.Show("Please Export .CSV file");
                            //exp.ExportTweetDB(mylist, saveFileDialog1.FileName.ToString());
                            break;
                        case 2:

                            //MessageBox.Show(saveFileDialog1.FileName.ToString());
                            try
                            {
                                StringBuilder builder = new StringBuilder();
                                string headers = "Date,Close price,MACD,KD,RSI,Guppy 3 days, Guppy 60 days, Label";
                                builder.Append(headers).Append("\n");
                                for (int i = 0; i < mylist.Count; i++)
                                {
                                    builder.Append(mylist[i].getDate().ToShortDateString()).
                                        Append("," + mylist[i].getClose())
                                        .Append("," + mylist[i].getMACD())
                                        .Append("," + mylist[i].getKD())
                                        .Append("," + mylist[i].getRSI())
                                        .Append("," + mylist[i].getLowGMA())
                                        .Append("," + mylist[i].gethighGMA())
                                        .Append("\n");
                                }

                                using (StreamWriter writer =
                                    //new StreamWriter("Final.csv"))
                                new StreamWriter(saveFileDialog1.FileName.ToString()))
                                {
                                    writer.Write(builder);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            break;
                    }
                    // fs.Close();
                }
                MessageBox.Show("Export done sucessfully !");
                }
            else
            {
                    
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Table to export ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name = this.listView1.SelectedItems[0].SubItems[0].Text.ToString();
            string query ;
            if (checkBox2.Checked)
            {
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
            }
            else
            { 
                    query =
                   " DECLARE "+
                   " @Temps decimal(14,4) "+
                   " set @Temps = 0.00000000 "+
                   " select Date_,(_3_days_Ema + @Temps),(_5_days_Ema+@Temps),(_8_days_Ema+@Temps),(_10_days_Ema+@Temps),(_12_days_Ema+@Temps),(_15_days_Ema+@Temps), "+
                   " (_30_days_Ema+@Temps),(_35_days_Ema+@Temps),(_40_days_Ema+@Temps),(_45_days_Ema+@Temps),(_50_days_Ema+@Temps),(_60_days_Ema + @Temps) "+
                   " from " + name + "_AllView  " +
                   " where _60_days_Ema is not null";

            }

            List<GMMA_Frame> mytable = new List<GMMA_Frame>();

            //MessageBox.Show(query.ToString());
            ss.loadGMMA(query,mytable);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();



             saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.ValidateNames = true;
            saveFileDialog1.DereferenceLinks = false;
            saveFileDialog1.Filter = "CSV|*.csv";
            saveFileDialog1.Title = "Export GMMA";
            saveFileDialog1.ShowDialog();
            //Thread t2 = new Thread(new ThreadStart(Loading));
            //t2.Start();
            if (saveFileDialog1.FileName != "")
            {
                // System.IO.FileStream fs =
                //(System.IO.FileStream)saveFileDialog1.OpenFile();

                switch (saveFileDialog1.FilterIndex)
                {
                        
                    case 1:

                        //MessageBox.Show(saveFileDialog1.FileName.ToString());
                        try
                        {
                            StringBuilder builder = new StringBuilder();
                            string headers = "Date,3 Days,5 Days,8 Days,10 Days,12 Days,15 Days,30 Days,35 Days,40 Days,45 Days,50 Days,60 Days";
                            builder.Append(headers).Append("\n");
                            for (int i = 0; i < mytable.Count; i++)
                            {
                                builder.Append(mytable[i].getdate().ToShortDateString()).
                                    Append("," + mytable[i].get_3_days_Ema())
                                    .Append("," + mytable[i].get_5_days_Ema())
                                    .Append("," + mytable[i].get_8_days_Ema())
                                    .Append("," + mytable[i].get_10_days_Ema())
                                    .Append("," + mytable[i].get_12_days_Ema())
                                    .Append("," + mytable[i].get_15_days_Ema())
                                    .Append("," + mytable[i].get_30_days_Ema())
                                    .Append("," + mytable[i].get_35_days_Ema())
                                    .Append("," + mytable[i].get_40_days_Ema())
                                    .Append("," + mytable[i].get_45_days_Ema())
                                    .Append("," + mytable[i].get_50_days_Ema())
                                    .Append("," + mytable[i].get_60_days_Ema())
                                    .Append("\n");
                            }

                            using (StreamWriter writer =
                                //new StreamWriter("Final.csv"))
                            new StreamWriter(saveFileDialog1.FileName.ToString()))
                            {
                                writer.Write(builder);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        break;
                }
                // fs.Close();
            }
            MessageBox.Show("Export done sucessfully !");
            
        




        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
