using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Analyse : Form
    {
        List<Table_Stock_Info> myt = new List<Table_Stock_Info>();              // For database select pupose
        List<Historical_Table_Frame> HistoricalTable = new List<Historical_Table_Frame>();  // For database select pupose
        List<Analyse_Lists_Frame> AnalyseTable = new List<Analyse_Lists_Frame>();  // For database select pupose
        Connections ss;
        //string StockNames = "";

        public Analyse()
        {
            InitializeComponent();
            button1.MouseHover += new EventHandler(button1_MouseHover);
            Createbutton.MouseHover += new EventHandler(Createbutton_MouseHover);
            button3.MouseHover += new EventHandler(button3_MouseHover);
            HistoTextBox.MouseHover += new EventHandler(HistoTextBox_MouseHover);
            dateStart.MouseHover += new EventHandler(dateStart_MouseHover);
            dateEnd.MouseHover += new EventHandler(dateEnd_MouseHover);
            DataSetName.MouseHover += new EventHandler(DataSetName_MouseHover);
            this.TopMost = true;
            button1.Enabled = false;
//------------------------ update Database for existing table 
            try
            {
                ss = new Connections();
                ss.loadRunTimeStockInfo("SELECT * FROM Stock_Name where STATUS != 0 ;", myt);
                ss.loadHistoricalStockInfo("SELECT * FROM Histoorical_Stock_Table", HistoricalTable);
                ss.loadAnalyseTableInfo("select * from analyse_lists", AnalyseTable);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            int counter = 0;
            for (int i = 0; i < HistoricalTable.Count; i++)
            {
                ListViewItem lvl = new ListViewItem(HistoricalTable[i].getSymbol());
                lvl.SubItems.Add(HistoricalTable[i].getTableName());
                lvl.SubItems.Add(HistoricalTable[i].getLastUpdate().ToShortDateString());
                listView1.Items.Add(lvl);
            }
            for (int i = 0; i < AnalyseTable.Count; i++)
            {
                ListViewItem lvl = new ListViewItem(AnalyseTable[i].getStock_Table_Name());
                lvl.SubItems.Add(AnalyseTable[i].getStock_Symbol());
                lvl.SubItems.Add(AnalyseTable[i].getStarting_Date_().ToShortDateString());
                lvl.SubItems.Add(AnalyseTable[i].getLast_Date_().ToShortDateString());
                listView2.Items.Add(lvl);
            }

            


        }
        //----------------------- update completed
        //-----------------------Mouse Hover events 
        void button1_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Update an existing series of data";
            label1.Refresh();
        }

        void Createbutton_MouseHover(object sender, EventArgs e)
        { 
            label1.Text = "Creating a new data set ";
            label1.Refresh();
        }
        
        void button3_MouseHover(object sender, EventArgs e)
        {

            label1.Text = "Back to main menu";
            label1.Refresh();
        }


        void HistoTextBox_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Please choose the reference historical table from the table ";
            label1.Refresh();
        }
        void dateStart_MouseHover(object sender, EventArgs e) 
        {
            label1.Text = "Please choose the starting day for analysis, make sure 60 record from the start date are exist ";
            label1.Refresh();
        }
        void dateEnd_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Please choose the ending date for analysis, make sure the date is already exist ";
            label1.Refresh();
        }

        void DataSetName_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Please type the name of your data set, name should be continuous and no special characters allowed ";
            label1.Refresh();
        }
// click events 
        private void button1_Click(object sender, EventArgs e)
        {
            // update button 
            label1.Text = "Update an existing series of data";
            label1.Refresh();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Analyse_Load(object sender, EventArgs e)
        {
           // FormBorderStyle = FormBorderStyle.None;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
                return;

            HistoTextBox.Text = this.listView1.SelectedItems[0].SubItems[1].Text; 
        }

        private void Createbutton_Click(object sender, EventArgs e)
        {

            
            try {
            if (!MyUtility.isValidName(DataSetName.Text)) 
                throw new Exception() ;


            if (this.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a stock from Historical data table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string insetrquery = "insert into analyse_lists values('" + this.listView1.SelectedItems[0].SubItems[0].Text.ToString() + "','" + DataSetName.Text.ToString() + "','" + dateStart.Value.ToShortDateString() + "','" + dateEnd.Value.ToShortDateString() + "')";
            //ss.insert(insetrquery);
            if (ss.insert(insetrquery))
            {
                ListViewItem lvl = new ListViewItem(DataSetName.Text.ToString());
                lvl.SubItems.Add(this.listView1.SelectedItems[0].SubItems[0].Text.ToString());
                lvl.SubItems.Add(dateStart.Value.ToShortDateString());
                lvl.SubItems.Add(dateEnd.Value.ToShortDateString());
                listView2.Items.Add(lvl);
            }

            //Loading Load = new Loading();
            //Load.label1.Text = "Calculating MACD ... ";
            //Load.Show();

            TimeSeries myview = new CreateView(this.dateStart.Value.Date, this.dateEnd.Value.Date, HistoTextBox.Text, DataSetName.Text);
            TimeSeries MAC = new MACDTEMP(this.dateStart.Value.Date, this.dateEnd.Value.Date, HistoTextBox.Text, DataSetName.Text);
            //Load.label1.Text = "Calculating Stocastic Occilator ... ";
            TimeSeries STO = new STOCTEMP(this.dateStart.Value.Date, this.dateEnd.Value.Date, HistoTextBox.Text, DataSetName.Text);    
           // Load.label1.Text = "Calculating RSI ... ";
            TimeSeries RSI = new RSITEMP(this.dateStart.Value.Date, this.dateEnd.Value.Date, HistoTextBox.Text, DataSetName.Text);
            //Load.label1.Text = "Calculating GMMA ... ";
            TimeSeries GMMA = new GMMATEMP(this.dateStart.Value.Date, this.dateEnd.Value.Date, HistoTextBox.Text, DataSetName.Text);
            string query =

                //view = "+DataSetName+"_View
                //MACDTEMP =  "+DataSetName+"_MACD
                //Sto = "+DataSetName+"_STO
                //RSI = "+DataSetName+"_RSI
                //GMMA = "+DataSetName+"_GMMA
                
                  //  YLTView = "+DataSetName+"_AllView

                    "create view " + DataSetName.Text + "_AllView as " +
                "select " + DataSetName.Text + "_View.Date_, " + DataSetName.Text + "_View.Open_, " + DataSetName.Text + "_View.High, " + DataSetName.Text + "_View.Low, " + DataSetName.Text + "_View.Close_, " + DataSetName.Text + "_View.Volume, " + DataSetName.Text + "_View.Adj_Close," +
                "" + DataSetName.Text + "_MACD._12_Days_Ema ," + DataSetName.Text + "_MACD._26_Days_Ema , " + DataSetName.Text + "_MACD.MACD_12Minus26_days, " + DataSetName.Text + "_MACD._Signal, " + DataSetName.Text + "_MACD._histogram, " +
                "" + DataSetName.Text + "_RSI.Change," + DataSetName.Text + "_RSI.gain," + DataSetName.Text + "_RSI.Loss, " + DataSetName.Text + "_RSI.Avg_Gain, " + DataSetName.Text + "_RSI.Avg_Loss," + DataSetName.Text + "_RSI.RS," + DataSetName.Text + "_RSI._14_days_RSI, " +
                "" + DataSetName.Text + "_STO.highest_high_14, " + DataSetName.Text + "_STO.Lowest_low_14, " + DataSetName.Text + "_STO._14_day_StochasticOscillator, " +
                "" + DataSetName.Text + "_GMMA._3_days_Ema," + DataSetName.Text + "_GMMA._5_days_Ema," + DataSetName.Text + "_GMMA._8_days_Ema," + DataSetName.Text + "_GMMA._10_days_Ema," + DataSetName.Text + "_GMMA._15_days_Ema," + DataSetName.Text + "_GMMA._30_days_Ema," + DataSetName.Text + "_GMMA._35_days_Ema, " +
                "" + DataSetName.Text + "_GMMA._40_days_Ema," + DataSetName.Text + "_GMMA._45_days_Ema," + DataSetName.Text + "_GMMA._50_days_Ema," + DataSetName.Text + "_GMMA._60_days_Ema " +
                 " from " + DataSetName.Text + "_View, " + DataSetName.Text + "_MACD , " + DataSetName.Text + "_RSI , " + DataSetName.Text + "_GMMA, " + DataSetName.Text + "_STO where " + DataSetName.Text + "_View.ID= " + DataSetName.Text + "_MACD.ID and " + DataSetName.Text + "_View.ID = " + DataSetName.Text + "_RSI.ID and " + DataSetName.Text + "_View.ID =" + DataSetName.Text + "_GMMA.ID and " + DataSetName.Text + "_View.ID = " + DataSetName.Text + "_STO.ID";
            ss.createView(query);
            //MAC.createTable();
            //MAC.dropMACD();
            //Load.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Table name");
            }
       }

        private void DropTable_Click(object sender, EventArgs e)
        {
            
            TimeSeries nes = new TimeSeries(this.listView2.SelectedItems[0].SubItems[0].Text.ToString());
            nes.dropTable();
            foreach (ListViewItem eachItem in listView2.SelectedItems)
            {
                listView2.Items.Remove(eachItem);
            }
        }

        private void AfterRuningTrigger_Click(object sender, EventArgs e)
        {
           
        }

    }
}