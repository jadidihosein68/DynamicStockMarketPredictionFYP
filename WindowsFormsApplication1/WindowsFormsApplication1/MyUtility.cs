using System;
using System.Collections.Generic;
using System.Linq;//
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; //



namespace WindowsFormsApplication1
{
    class MyUtility
    {

        
        public static decimal? getDecimal(string data)
        {
            decimal? a = 0;

            if (data == "N/A"|| data == "-")
                return 0;
            try
            {
                a = decimal.Parse(data);
            }
            catch (ArgumentNullException ex)
            {

                //(object)DBNull.Value;
                //a = 0 ; 
                return 0;
            }
            catch (FormatException ex)
            {
               // MessageBox.Show(" this is not valid  -> " + data);
                return 0;
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Over flow happened !");
                return 0;
            } 
            return a;
        }

        public static double? getDouble(string data)
        {
            if (data == "N/A" || data == "-")
                return 0;
            double? a = 0;
            try
            {
                    a = double.Parse(data);
            }
            catch (ArgumentNullException ex)
            {

                return a;
            }
            catch (FormatException ex){
                //MessageBox.Show(" this is not valid  -> " + data);
                return 0;
            }
            catch (OverflowException ex){
                MessageBox.Show("Over flow happened !");
                return 0;
            }
            return a;
        }
        
        public static bool validNoOfElements(String[] container , int size)
        {
            if (container.Length != size)
                return false;
            return true; 
        }
        public static DateTime? getDateTime(string date , string houre)
        {
            DateTime? Last_Trade_Date = null;
            if (!(date == string.Empty || houre == string.Empty))
            {
                DateTime Thedate = Convert.ToDateTime(date.Replace("\"", ""));
                date = houre.Replace("\"", "").Insert(houre.Length - 4, " ");
                DateTime dates = Convert.ToDateTime(houre);
                TimeSpan span = dates.TimeOfDay;
                // end of conversion 
                 Last_Trade_Date = Thedate + span;
            }
            return Last_Trade_Date;
        }

        public static DateTime? getDateOnly(string date) {

            DateTime? a = null;
            try
            {
                a = Convert.ToDateTime(date.Replace("\"", ""));
            }
            catch (ArgumentNullException ex)
            {
                return null;
            }
            catch (FormatException ex)
            {
                //MessageBox.Show(" this is not valid  -> " + data);
                return null;
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Over flow happened !");
                return null;
            }
            return a;
        
        }




        public static int? getInteger(string data)
        {
            int? a = 0;

            if (data == "N/A" || data == "-")
                return 0;
            try
            {
                a = int.Parse(data);
            }
            catch (ArgumentNullException ex)
            {

                //(object)DBNull.Value;
                //a = 0 ; 
                return 0;
            }
            catch (FormatException ex)
            {
                // MessageBox.Show(" this is not valid  -> " + data);
                return 0;
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Over flow happened !");
                return 0;
            }
            return a;
        }



        /*
         * checked wheather tha name of table is Valid or not 
        */

        public static bool isValidName(string Name) {
            string interval = "0123456789";
            for (int i = 0 ; i < interval.Length;i++ )
                if (Name[0].Equals(interval[i]))
                    return false ;
            if (Name.Contains(" "))
                return false;
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (regexItem.IsMatch(Name))
                return true;
            return false;
        }
    }
}
