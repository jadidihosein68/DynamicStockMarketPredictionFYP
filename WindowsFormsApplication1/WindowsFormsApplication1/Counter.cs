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
    public partial class Counter : Form
    {
        public Counter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int date_column = Int32.Parse(textBox2.Text.ToString());// remmeber its start from 0 
            List<string[]> nested = new List<string[]>();

            List<int[]> counts = new List<int[]>(); // the list to count occurance 
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV|*.csv";
            openFileDialog1.Title = "Select a CSV File to count";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName.ToString();
                using (StreamReader sr = new StreamReader(path))
                {
                    
                    while (sr.Peek() >= 0)
                    {
                        string myline = sr.ReadLine();

                        string[] words = myline.Split(',');
                        nested.Add(words);

                    }
                }

                //MessageBox.Show(nested[0].Length.ToString());
                List<string> current_day = new List<string>();
                current_day.Add(nested[1][date_column]);
                current_day.Add(nested[1][date_column]);
                int[] temp = new int[nested[0].Length];
                /*
                foreach( int i in temp){
                    i = 0;
                }
                */

                //MessageBox.Show(current_day);

                counts.Add(temp);
                counts.Add(temp);
                int day = 1 ; 

                

               for (int i = 1 ; i < nested.Count ; i++ ) // first row is header 
               {

                   

                   if (nested[i][date_column]==current_day[day])
                   {
                       for (int j = date_column + 1; j < nested[i].Length; j++) // each element in row 
                       {
                          // int x = Int32.Parse(TextBoxD1.Text);
                           counts[day][j] += Int32.Parse(nested[i][j]);
                       }

                   }
                       
                   else 
                   {
                       current_day.Add(nested[i][date_column]);
                       day ++;
                       counts.Add(new int[nested[0].Length]);
                       for (int j = date_column+1; j < nested[i].Length; j++) // each element in row 
                       {
                           // int x = Int32.Parse(TextBoxD1.Text);
                           counts[day][j] += Int32.Parse(nested[i][j]);
                       }
                   }                
               }


               int marvel = 0;
               for (int i = 1; i < 6; i++)
               {
                   textBox1.Text += current_day[i] + " -> ";
                   for (int j = date_column+1; j < nested[0].Length; j++)
                   {
                       marvel++;
                       textBox1.Text += counts[i][j].ToString() + " , ";
                   }
                   textBox1.Text += "\r\n";
               
               }

               List<string> final = new List<string>();
                for (int j = 1; j < counts.Count; j++)
              {
                  int max1 =0, max2=0 , max3=0;
                  int index1 = 0,index2 = 0,index3 = 0; 
                    
                    for (int i = 1 ; i < counts[j].Length ; i++)
                    //foreach (int i in counts[j])
                  {
                      if (counts[j][i] > max1)
                      {
                          max3 = max2;
                          index3 = index2;
                          max2 = max1;
                          index2 = index1;
                          max1 = counts[j][i];
                          index1 = i;
                      }
                      else if (counts[j][i] > max2)
                      {
                          max2 = counts[j][i];
                          index2 = i;
                      }
                      else if (counts[j][i] > max3)
                      {
                          max3 = counts[j][i];
                          index3 = i;
                      }

                  }

                    final.Add(current_day[j] + "," + nested[0][index1] + "," + nested[0][index2] + "," + nested[0][index3]);
                    //MessageBox.Show("day = " + current_day[j] + "max1 = " + max1 + " which is " + nested[0][index1] + ", Max2 = " + max2 + " which is " + nested[0][index2] + " Max3 = " + max3 + " which is " + nested[0][index3]);
              }

               //////////////////saveing proccess 

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog1.ValidateNames = true;
                saveFileDialog1.DereferenceLinks = false;
                saveFileDialog1.Filter = "CSV|*.csv";
                saveFileDialog1.Title = "Export word frequency";
                saveFileDialog1.ShowDialog();
                string headers = "Date,Term 1,Term 2,Term 3";
                StringBuilder builder = new StringBuilder();
                builder.Append(headers).Append("\n");
                for (int i = 0; i < final.Count; i++)
                {
                    builder.Append(final[i]).Append("\n");
                }

                using (StreamWriter writer =
                    //new StreamWriter("Final.csv"))
                           new StreamWriter(saveFileDialog1.FileName.ToString()))
                {
                    writer.Write(builder);
                }

                /*
               int maxValue = counts[1].Max();
               MessageBox.Show(counts[1].ToList().IndexOf(maxValue).ToString() + " the word = "+ nested[0][counts[1].ToList().IndexOf(maxValue)].ToString());
              */
                 // int maxIndex = anArray.ToList().IndexOf(maxValue);

                /*
               MessageBox.Show("nested.Count = " + nested.Count.ToString()
                   + " counts.Coun = " + counts.Count.ToString() + " nested[0].Length = " + nested[0].Length.ToString() + " counts[0][0] = " + counts[0][0].ToString());
                */
                
                //nested is work correctly 
                //
                /*
               for (int i = 0; i < 5; i++)
               {

                   for (int j = 0; j < counts[i].Length; j++)
                       textBox1.Text += counts[i][j].ToString() + " , ";
                   textBox1.Text += "\r\n";
               }
                */
            }
            //MessageBox.Show(nested.Count.ToString());
            //MessageBox.Show(nested[10].Length.ToString()); // number of row 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
