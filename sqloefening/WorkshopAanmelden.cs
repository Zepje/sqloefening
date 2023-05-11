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
using System.Text.RegularExpressions;
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
            bool control = controle();

            if (control == true)
            {
                string query = "INSERT INTO inschrijvingen (idPlanning, idStudent) VALUES (@idPlanning, @idStudent)";

                conn.Open();

                using (var command = new MySqlCommand(query, conn))
                {
                    // Add the parameters to the query

                    command.Parameters.AddWithValue("@idPlanning", zoekiddatagrid(5));



                    command.Parameters.AddWithValue("@idStudent", IDoutofname(LeerlingKiesMenu.Text));

                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine(rowsAffected + " row(s) inserted.");
                }

                conn.Close();
            }
        }

        int zoekiddatagrid(int collumplace)
        {
            int i = 0;
            string idvalue = string.Empty;
            foreach (DataGridViewCell cell in PlanningDataGrid.SelectedCells)
            {
                object value = cell.Value;
                if (i == collumplace)
                {
                    idvalue = value.ToString();
                }
                i++;
            }
            return int.Parse(idvalue);
        }

        bool controle()
        {
            int idplan = zoekiddatagrid(5);
            int MAX = zoekiddatagrid(4);
            int count = 0;
            string query = $"SELECT COUNT(*) FROM inschrijvingen WHERE idPlanning = '{idplan}';";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    count = reader.GetInt16(0);
                    Console.WriteLine($"max {count}");
                }

            }
            conn.Close();

            if (count < MAX)
                return true;
            else
                return false;
        }
        int IDoutofname(string input)
        {
            string idNumber = string.Empty;
            Regex regex = new Regex(@"\((\d+)\)");
            Match match = regex.Match(input);
            if (match.Success)
            {
                idNumber = match.Groups[1].Value;
                Console.WriteLine($"The ID number is {idNumber}");
            }

            return int.Parse(idNumber);
        }
        void FillComboBox()
        {

            string query = "select idStudent,Naam,Voornaam from student;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    string Naam = reader.GetString(1);
                    string Voornaam = reader.GetString(2);
                    LeerlingKiesMenu.Items.Add($"{Naam} {Voornaam} ({ID.ToString()})");
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
            PlanningDataGrid.Columns.Add("id", "id");

            PlanningDataGrid.AllowUserToAddRows = false;
            PlanningDataGrid.AllowUserToDeleteRows = false;
            PlanningDataGrid.ReadOnly = true;
            PlanningDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            PlanningDataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            PlanningDataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            PlanningDataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        void fulldatagrid()
        {
            List<List<string>> SearchID = SearchbyID();
            int i = 0;
            string query = "select GekozenMoment,maxCapaciteit,idPlanning from planning;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                { 

                    int Max = reader.GetInt32(1);
                    DateTime moment = reader.GetDateTime(0);
                    int id = reader.GetInt32(2);

                    PlanningDataGrid.Rows.Add(SearchID[i][2], SearchID[i][1], SearchID[i][0], moment,Max,id);
                    i++;
                }
            }
            conn.Close();
        }

        List<List<string>> SearchbyID()
        {
            List<List<int>> ids = new List<List<int>>();
            List<List<string>> Idnamefoundlist = new List<List<string>>();
            string query = "SELECT idLokaal,idCursus,idDocent FROM planning";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    List<int> id = new List<int>();
                    int i = reader.GetInt32(0);
                    id.Add(i);
                    i = reader.GetInt32(1);
                    id.Add(i);
                    i = reader.GetInt32(2);
                    id.Add(i);
                    ids.Add(id);

                }
            }
            conn.Close();
            for (int i = 0; i < ids.Count; i++)
            {
                ids[i][1] = ids[i][0];
                List<string> Idnamefound = new List<string>();
                Idnamefound.Add(zoekstringSQL(ids[i][0], "lokaal"));
                Idnamefound.Add(ZoekCursusById(ids[i][1]));
                Idnamefound.Add(zoekstringSQL(ids[i][2], "docent"));
                Idnamefoundlist.Add(Idnamefound);
            }
            return Idnamefoundlist;

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
                    gevonden = $"{reader.GetString(0)} {reader.GetString(1)}";
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
                    gevonden = reader.GetString(0);
                }
            }
            conn.Close();

            return gevonden;
        }

    }


}
