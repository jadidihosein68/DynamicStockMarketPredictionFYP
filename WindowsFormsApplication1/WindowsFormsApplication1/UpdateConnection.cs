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
    public partial class UpdateConnection : Form
    {
        AppSettingUserDef appsettingUserdef = new AppSettingUserDef();
        public UpdateConnection()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!appsettingUserdef.isValidCS(CS.Text.ToString()))
                {   //MessageBox.Show("invalid connection pleas try again");
                    MessageBox.Show("invalid connection ! please try again");
                }
                else
                {
                    //
                    AppSettingUserDef.connectionString = CS.Text.ToString();
                    appsettingUserdef.updateText();
                    this.Close();
                }
        }

        private void UpdateConnection_Load(object sender, EventArgs e)
        {
            MessageBox.Show("dear user to use the program properly u need to update your connection string ");
        }

        /*
         * Exit button
         */ 
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
