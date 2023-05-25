using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sqloefening
{
    public partial class WorkshopAanmelden : Form
    {
        string connectionString = "server=127.0.0.1;port=3307;database=mydb;user=root;password=usbw;";
        MySqlConnection conn = new MySqlConnection();
       

        public WorkshopAanmelden()
        {
            InitializeComponent();
            conn.ConnectionString = connectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        void FillComboBox()
        {
        conn.Open();

         LeerlingKiesMenu.Items.Add("Red");
           
        }
    }


}
