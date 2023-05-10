using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
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
            FillComboBox();
            makedatagrid();
            fulldatagrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        void FillComboBox()
        {

            string query = "select Studentnummer,Naam,Voornaam from student;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string ID = reader.GetString(0);
                    string Naam = reader.GetString(1);
                    string Voornaam = reader.GetString(2);
                    LeerlingKiesMenu.Items.Add($"{Naam} {Voornaam} ({ID})");
                }

                LeerlingKiesMenu.SelectedIndex = 0;
                LeerlingKiesMenu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }
            conn.Close();

        }

        void makedatagrid()
        { 
            PlanningDataGrid.Columns.Add("idDocent", "idDocent");
            PlanningDataGrid.Columns.Add("idCursus", "idCursus");
            PlanningDataGrid.Columns.Add("idLokaal", "idLokaal");
            PlanningDataGrid.Columns.Add("GekozenMoment", "GekozenMoment");
            PlanningDataGrid.Columns.Add("maxCapaciteit", "maxCapaciteit");

            PlanningDataGrid.AllowUserToAddRows = false;
            PlanningDataGrid.AllowUserToDeleteRows = false;
            PlanningDataGrid.ReadOnly = true;
            PlanningDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            PlanningDataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            PlanningDataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        void fulldatagrid()
        {
            List<string> SearchID = SearchbyID(); 
            string query = "from planning;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string docent = zoekstringSQL(reader.GetInt32(0),"docent",reader);
                    string cursus = ZoekCursusById(reader.GetInt32(1),reader);
                    string lokaal = zoekstringSQL(reader.GetInt32(2), "lookaal", reader);
                    int Max = reader.GetInt32(4);
                    DateTime moment = reader.GetDateTime(3);

                    PlanningDataGrid.Rows.Add(docent,cursus,lokaal,moment,Max);
                }
            }
            conn.Close();
        }

        List<string> SearchbyID()
        {
            List<int> ids = new List<int>();
            List<string> Idnamefound = new List<string>();
            string query = "SELECT idLokaal,idCursus,idDocent FROM planning";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ids[0] = reader.GetInt32(0);
                    ids[1] = reader.GetInt32(1);
                    ids[2] = reader.GetInt32(2);
                }
            }
            conn.Close();

            Idnamefound[0] = zoekstringSQL(ids[0], "lokaal");
            Idnamefound[1] = ZoekCursusById(ids[1]);
            Idnamefound[2] = zoekstringSQL(ids[2], "docent");

            return Idnamefound;

        }


        string zoekstringSQL(int ZoekID, string table)
        {

            string gevonden = string.Empty;

            string query = string.Empty;
            if (table == "docent")
                query = $"SELECT Naam, Voornaam FROM docent WHERE idDocent = {ZoekID}";

            if (table == "lokaal")
                query = $"SELECT Lokaalnummer, Campus FROM lokaal WHERE idLokaal = {ZoekID}";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                }
            }

            conn.Close();

            return gevonden;
        }

        string ZoekCursusById(int Zoekid)
        {

            string gevonden = string.Empty;

            string query = $"SELECT Naam FROM cursussen WHERE idCursus= {Zoekid}";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                }
            }
            conn.Close();

            return gevonden;
        }

    }


}
