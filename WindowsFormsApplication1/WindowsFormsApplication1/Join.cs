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
    public partial class Join : Form
    {
        public Join()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string[]> Quantitative = new List<string[]>(); // 8 commas
            List<string[]> CountedTweets = new List<string[]>(); // 4 commas
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV|*.csv";
            openFileDialog1.Title = "Select a Quantitative CSV File to Append (MACD, RSI, KD, GMMA)";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName.ToString();
                using (StreamReader sr = new StreamReader(path))
                {

                    while (sr.Peek() >= 0)
                    {
                        string myline = sr.ReadLine();

                        string[] words = myline.Split(',');
                        Quantitative.Add(words);

                    }
                }


            }


            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "CSV|*.csv";
            openFileDialog2.Title = "Select a Qualitative CSV File to append (Tweet Terms)";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog2.FileName.ToString();
                using (StreamReader sr = new StreamReader(path))
                {

                    while (sr.Peek() >= 0)
                    {
                        string myline = sr.ReadLine();

                        string[] words = myline.Split(',');
                        CountedTweets.Add(words);

                    }
                }


            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.ValidateNames = true;
            saveFileDialog1.DereferenceLinks = false;
            saveFileDialog1.Filter = "CSV|*.csv";
            saveFileDialog1.Title = "Export Appended File";
            saveFileDialog1.ShowDialog();
            //Thread t2 = new Thread(new ThreadStart(Loading));
            //t2.Start();
            if (saveFileDialog1.FileName != "")
            {


                StringBuilder builder = new StringBuilder();
                string headers = "Date,Close price,MACD,KD,RSI,Guppy 3 days, Guppy 60 days, Tweet Term1, Tweet Term2, Tweet Term3, Label";
                builder.Append(headers).Append("\n");

                MessageBox.Show("Quantitative.Count = " + Quantitative.Count.ToString() + " CountedTweets.Count = " + CountedTweets.Count.ToString());
                for (int i = 1; i < Quantitative.Count; i++)
                {
                    for (int j = 1; j < CountedTweets.Count; j++)
                    {
                        if (Quantitative[i][0] == CountedTweets[j][0])
                        {

                            builder.Append(Quantitative[i][0]).Append("," + Quantitative[i][1]).Append("," + Quantitative[i][2]).
                            Append("," + Quantitative[i][3]).Append("," + Quantitative[i][4]).
                            Append("," + Quantitative[i][5]).Append("," + Quantitative[i][6]).
                            Append("," + CountedTweets[j][1]).
                            Append("," + CountedTweets[j][2]).Append("," + CountedTweets[j][3]).Append("\n");
                            //.Append(Quantitative[i][7]);
                            // MessageBox.Show("i = " + i + " j == " + j);
                            break;
                        }
                        else if (j == CountedTweets.Count - 1)
                        {
                            builder.Append( Quantitative[i][0]).Append("," + Quantitative[i][1]).Append("," + Quantitative[i][2]).
                                Append("," + Quantitative[i][3]).Append("," + Quantitative[i][4]).
                                Append("," + Quantitative[i][5]).Append("," + Quantitative[i][6]).Append("," + "NULL").
                                Append("," + "NULL").
                                Append("," + "NULL").Append("\n");
                                //.Append(Quantitative[i][7]);

                            // green earth
                            // brown line
                            

                        }

                    }
                }



                using (StreamWriter writer =
                    //new StreamWriter("Final.csv"))
                                    new StreamWriter(saveFileDialog1.FileName.ToString()))
                {
                    writer.Write(builder);
                }

            }
        }
    }
}
