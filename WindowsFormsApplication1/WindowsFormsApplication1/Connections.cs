using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    /*
     *This class provide fucntions for database DDL commands 
     *The System.Data.SqlClient library is used to connect to the database 
     *before using make sure your connections_string is correct  
     */

    class Connections
    {
        private SqlConnection conn;
        public Connections(){
            //string connection_string = "Data Source=HOSEIN-PC;Initial Catalog=FYP1;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            string connection_string = AppSettingUserDef.connectionString;
             conn = new SqlConnection(connection_string);
        }

        public bool TableIsExist(string Table_name)
        {
            SqlCommand comm = new SqlCommand(@"SELECT Count(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + Table_name + "'", conn);
            conn.Close();
            conn.Open();
            object result = comm.ExecuteScalar();
            conn.Close();
            return result.ToString().Equals("1");
        }
        /*
         * create a table to store historical data 
         */
        public bool CreateHistoricalTable(string TableName)
        {

            try
            {
                SqlCommand comm = new SqlCommand(@"create table " + TableName
                    + " (Date_ date ,Open_ money,High money ,Low money ,Close_ money ,Volume money ,Adj_Close money,primary key (Date_))"
                    , conn);
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("invalid Name");
                return false;
            }
        }


        public void insertToTwitterTable(List<Tweet_Frame> Tweets ,String name)
        {
            try
            {
                foreach (Tweet_Frame Tweet in Tweets )
                {
                    SqlCommand cmd = new SqlCommand(
                                  "INSERT INTO " + name + " VALUES(@Screen_Name,@TweetID,@Date,@Tweets);"
                                  , conn);
                    cmd.Parameters.Add("@Screen_Name", SqlDbType.VarChar);
                    cmd.Parameters["@Screen_Name"].Value = Tweet.getScreenName();
                    cmd.Parameters.Add("@TweetID", SqlDbType.BigInt);
                    cmd.Parameters["@TweetID"].Value = Tweet.getTweetID();
                    cmd.Parameters.Add("@Date", SqlDbType.Date);
                    cmd.Parameters["@Date"].Value = Tweet.getDate().ToShortDateString();
                    cmd.Parameters.Add("@Tweets", SqlDbType.VarChar);
                    cmd.Parameters["@Tweets"].Value = Tweet.getTweets();
                    conn.Open();
                    Int32 rowsAffected = cmd.ExecuteNonQuery();
                    //   Console.WriteLine("RowsAffected: {0}", rowsAffected);
                    conn.Close();
                }
            }catch
                (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.ToString());
            }
        }




 
        /*
         * the function below create a table 
         * input : 
         * DDL = data definition query  
         * Out put :
         * True if create successfully 
         * False if unable to create 
         */


        public bool createTable(string query)
        {
            try
            {
                SqlCommand comm = new SqlCommand(query, conn);
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("invalid command = " + query.ToString());
                return false;
            }
        }

        public bool createView(string query)

        {
            try
            {
                SqlCommand comm = new SqlCommand(query, conn);
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("invalid command = " + query.ToString());
                return false;
            }




        
        }





        public bool dropTable(string query)
        {
            try
            {
                SqlCommand comm = new SqlCommand(query, conn);
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("invalid command = " + query.ToString());
                conn.Close();
                return false;
            }
        }


        /*
         * the set of cuntions made for moving average purpose only 
         */ 
        public void openConnection()
        {
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("invalid connection string !");
            }
       }

        public void closeConnection()
        {

            conn.Close();
        }
        public void executeNonquery(string query)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }




        /*
         *Function below indicate wheather server is connected to the program or not . 
         *return true if connected, return false if not connected 
         */
        
        /*
        private bool IsOpen(){
            try
            {
                conn.Open();
                return true; 
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool IsClose()
        {
            try{
                conn.Close();
                return true;
            }
            catch (SqlException ex){
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        
        */
        /*
        public void insert(string table, string name, bool state)
        {
            string query = "indert into " + table + "values ('" + name + "' , " + state + ");";
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        
         */ 
         /*
         * insert into table inside database 
         */

        public bool insert(string query){
            bool ans = true;    
            try
                {
                    conn.Close();
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    ans = false;
                    MessageBox.Show(ex.Message.ToString());
                    conn.Close();
                }
            finally
                {
                   
                    conn.Close();
                }
            return ans;    
        }

        /*
         * the function below attepmt to insert new row if the row exist already it will update it 
         */ 
        public void insertOrUpdate(string insert,string update){ 



        }


        public void update(string query)
        {
            try
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                conn.Close();
            }
            finally
            {
                conn.Close();
            }
        }
        /*
         * the function below load database element inside Table 
         * input : 
         * query : a select query
         * List table a data structure in which can use for many tables 
         * 
         */ 

        public void loadRunTimeStockInfo(string query, List <Table_Stock_Info> Table) {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read()) // read all the elements inside db ! 
                {
                    Table.Add(new Table_Stock_Info(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(),reader.GetBoolean(2), reader.GetDateTime(3) ));
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally{

                                conn.Close();
                                //MessageBox.Show(Table.size); 
            }
        }

        /*
         * the function below load database element to a Table 
         * inputs : 
         * query : a select query
         * Table : a historical_Table_Frame list to load historical table data 
         * Note this function can use for analyse_lists to
         * 
         */
        public void loadHistoricalStockInfo(string query, List<Historical_Table_Frame> Table)
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read()) // read all the elements inside db ! 
                {
                    Table.Add(new Historical_Table_Frame(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(),reader.GetDateTime(2)));
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

                conn.Close();
                //MessageBox.Show(Table.size); 
            }
        }


        public void loadNormlized(string query, List<Normalized_Frame_Work> Table)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand(query, conn);

            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read()) // read all the elements inside db ! 
            {
                Table.Add(new Normalized_Frame_Work(reader.GetDateTime(0), reader.GetDecimal(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetDecimal(4), reader.GetDecimal(5), reader.GetDecimal(6)));
            }
            reader.Close();
            
            conn.Close();
        }

        public void loadGMMA(string query, List<GMMA_Frame> Table)
        {


            conn.Open();
            SqlCommand comm = new SqlCommand(query, conn);

            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read()) // read all the elements inside db ! 
            {
                Table.Add(new GMMA_Frame(reader.GetDateTime(0), reader.GetDecimal(1), reader.GetDecimal(2), reader.GetDecimal(3)
                    , reader.GetDecimal(4), reader.GetDecimal(5), reader.GetDecimal(6), reader.GetDecimal(7), reader.GetDecimal(8)
                    , reader.GetDecimal(9), reader.GetDecimal(10), reader.GetDecimal(11), reader.GetDecimal(12)));
            }
            reader.Close();

            conn.Close();
        }



        public void loadAnalyseTableInfo(string query, List<Analyse_Lists_Frame> Table)
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read()) // read all the elements inside db ! 
                {
                    Table.Add(new Analyse_Lists_Frame(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetDateTime(2),reader.GetDateTime(3)));                
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

                conn.Close();
                //MessageBox.Show(Table.size); 
            }
        }



        /*
         * The function below return a single value from the select statement 
         */

        
        public void loadTweet_Owner_List_Frame(string query, List<Tweet_Owner_List_Frame> table)
        {

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read()) // read all the elements inside db ! 
                {
                    
                    try
                    {
                        table.Add(new Tweet_Owner_List_Frame( reader.GetString(0), (ulong)reader.GetInt64(1), (ulong)reader.GetInt64(2), reader.GetDateTime(3),reader.GetInt32(4)));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        reader.Close();
                    }
                      
                
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

                conn.Close();
                //MessageBox.Show(Table.size); 
            }

        }




        public void loadTweet_Frame(string query, List<Tweet_Frame> table)
        {

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read()) // read all the elements inside db ! 
                {

                    try
                    {
                        table.Add(new Tweet_Frame((ulong)reader.GetInt64(1), reader.GetDateTime(2), reader.GetString(3), reader.GetString(0)));
                    }
                       // Tweet_Frame(ulong TweetID_, DateTime Date_, string Tweets_, string Screen_Name_)
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        reader.Close();
                    }


                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

                conn.Close();
                //MessageBox.Show(Table.size); 
            }

        }









        public void loadTime_Serries_Table_Frame(string query, List<Time_Series_Table_Frame> Table)
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read()) // read all the elements inside db ! 
                {

                    try
                    {
                        Table.Add(new Time_Series_Table_Frame(reader.GetDateTime(0), reader.GetDecimal(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetDecimal(4)
                        , reader.GetDecimal(5), reader.GetDecimal(6), reader.GetDecimal(7), reader.GetDecimal(8), reader.GetDecimal(9), reader.GetDecimal(10), reader.GetDecimal(11)
                        , reader.GetDecimal(12), reader.GetDecimal(13), reader.GetDecimal(14), reader.GetDecimal(15), reader.GetDecimal(16), reader.GetDecimal(17), reader.GetDecimal(18)
                        , reader.GetDecimal(19), reader.GetDecimal(20), reader.GetDecimal(21), reader.GetDecimal(22), reader.GetDecimal(23), reader.GetDecimal(24), reader.GetDecimal(25)
                    , reader.GetDecimal(26), reader.GetDecimal(27), reader.GetDecimal(28), reader.GetDecimal(29), reader.GetDecimal(30), reader.GetDecimal(31), reader.GetDecimal(32)));

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
               /*   
                    DateTime mydate = new DateTime (2011,11,11);
                    Table.Add(new Time_Series_Table_Frame(reader.GetDateTime(0), reader.GetDecimal(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetDecimal(4)               
                        , 11, 11, 11, 11, 11, 11, 11
               , 11, 11, 11, 11, 11, 11, 11
               , 11, 11, 11,11,11,11,11
           , 11, 11, 11,11, 11, 11, 11));
               
                    */



                   }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

                conn.Close();
                //MessageBox.Show(Table.size); 
            }
        }





        public string selectSingle(String query)
        {
 
            try
            {
                SqlCommand comm = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                List<string> str0 = new List<string>();
        //        List<string> str1 = new List<string>();
          //      List<string> str2 = new List<string>();


                while (reader.Read()) // read all the elements inside db ! 
                {
                    str0.Add(reader.GetValue(0).ToString());
            //        str1.Add(reader.GetValue(1).ToString());
                }
                reader.Close();
                return str0[0];
              //  MessageBox.Show(str0[4].ToString() + str1[4].ToString());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                return "Data were not found";
            }
            finally
            {
                conn.Close();
            }
        }


        /*
        public void select()
        {




        */
            /*
            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create the SelectCommand.

            SqlCommand command = new SqlCommand("SELECT * FROM Customers " +
                "WHERE Country = @Country AND City = @City", conn);

            // Add the parameters for the SelectCommand.
            command.Parameters.Add("@Country", SqlDbType.NVarChar, 15);
            command.Parameters.Add("@City", SqlDbType.NVarChar, 15);
            adapter.SelectCommand = command;

            */



            /*
            conn.Open();
           // SqlConnection connection = new SqlConnection(myConnectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT count(*) FROM student;";

            int result = ((int)cmd.ExecuteScalar());
            conn.Close();

            MessageBox.Show(result.ToString()); 
            DataRow[] 

            */

        /*
            try
            {

                SqlCommand comm = new SqlCommand("SELECT * from student;", conn);
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                List<string> str0 = new List<string>();
                List<string> str1 = new List<string>();
                List<string> str2 = new List<string>();

              
                while (reader.Read()) // read all the elements inside db ! 
                {
                    str0.Add(reader.GetValue(0).ToString());
                    str1.Add(reader.GetValue(1).ToString());
                }
                
                
                reader.Close();

                MessageBox.Show(str0[4].ToString() + str1[4].ToString());

            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.ToString());

            }
            finally
            {
                conn.Close();

            }

 

        }

        */


        }



        
        




        

    }

