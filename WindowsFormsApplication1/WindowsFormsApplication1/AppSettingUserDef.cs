using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    class AppSettingUserDef
    {

        static string patch_;
        public static string connectionString ;//= "Data Source=HOSEIN-PC;Initial Catalog=FYP1;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        /*
         * check the existance of \Data\Init.txt
         * output :
         * True if exist false if not exist 
         */
       
        public static bool TextisExist () // should be static 
        {
            string patch = Directory.GetCurrentDirectory();
            string patch2 = Directory.GetParent(Directory.GetParent(patch).FullName).FullName;
            patch2 += @"\Data";
            patch_ = patch2;
            if (File.Exists(patch_ + @"\Init.txt"))
                return true;
            return false;
        }
       /*
        * check wheather the connection string is valid of not 
        */ 
      
       public static bool isValidCSText() // should be static
       {
           try
           {
               connectionString = System.IO.File.ReadAllText(patch_ + @"\Init.txt");
               SqlConnection conn = new SqlConnection(connectionString);
               conn.Open();
               conn.Close();
               return true;
           }
           catch (Exception e)
           {
               return false;
           }
       
       }
        /*
         * create the connection string text file 
         */ 
    public bool isValidCS (string ConnectionString){

        try
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            conn.Close();
            return true;
        }
        catch (Exception e)
        { 
            return false; 
        }

    }

        public static void createCSText () { // should be static 

            //string patch2 = 
            if (!Directory.Exists(patch_))
            {
                Directory.CreateDirectory(patch_);
            }
            StreamWriter sw = File.CreateText(patch_ + @"\Init.txt");
        }
        public void updateText()
        {

            File.WriteAllText(patch_ + @"\Init.txt", connectionString);

        }


    }
}
