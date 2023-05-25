using MySqlConnector;

namespace sqloefening
{

    public partial class Form1 : Form
    {
        string conn = "server=127.0.0.1;port=3307;database=mydb;user=root;password=usbw;";
        public Form1()
        {
            InitializeComponent();
            setupDataGrid();
            fillDataGrid();
        }

        private void setupDataGrid()
        {
            inschrijvingenDataGridView.Columns.Add("Student", "Student");
            inschrijvingenDataGridView.Columns.Add("Docent", "Docent");
            inschrijvingenDataGridView.Columns.Add("Cursus", "Cursus");
            inschrijvingenDataGridView.Columns.Add("Lokaal", "Lokaal");
            inschrijvingenDataGridView.Columns.Add("Moment", "Moment");

            inschrijvingenDataGridView.AllowUserToAddRows = false;
            inschrijvingenDataGridView.AllowUserToDeleteRows = false;
            inschrijvingenDataGridView.ReadOnly = true;
            inschrijvingenDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn column in inschrijvingenDataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void fillDataGrid()
        {
            using(MySqlConnection connection = new MySqlConnection(conn))
            {
                connection.Open();

                string query = "SELECT idStudent, idPlanning FROM inschrijvingen";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int idStudent = reader.GetInt32("idStudent");
                            int idPlanning = reader.GetInt32("idPlanning");

                            string studentNaam = verkrijgStudentNaam(idStudent);
                            Console.WriteLine(studentNaam);

                            string docentNaam, cursusnaam, lokaal, moment;
                            (docentNaam, cursusnaam, lokaal, moment) = verkrijgPlanningInfo(idPlanning);
                            AddRowToDataGridView(studentNaam, docentNaam, cursusnaam, lokaal, moment);
                        }

                    }
                }
            }
        }

        private void AddRowToDataGridView(string student, string docent, string cursus, string lokaal, string moment)
        {

            DataGridViewRow row = new DataGridViewRow();

            DataGridViewCell studentCell = new DataGridViewTextBoxCell();
            studentCell.Value = student;
            row.Cells.Add(studentCell);

            DataGridViewCell docentCell = new DataGridViewTextBoxCell();
            docentCell.Value = docent;
            row.Cells.Add(docentCell);

            DataGridViewCell cursusCell = new DataGridViewTextBoxCell();
            cursusCell.Value = cursus;
            row.Cells.Add(cursusCell);

            DataGridViewCell lokaalCell = new DataGridViewTextBoxCell();
            lokaalCell.Value = lokaal;
            row.Cells.Add(lokaalCell);

            DataGridViewCell momentCell = new DataGridViewTextBoxCell();
            momentCell.Value = moment;
            row.Cells.Add(momentCell);

            inschrijvingenDataGridView.Rows.Add(row);
        }

        private (string, string, string, string) verkrijgPlanningInfo(int id) //docentnaam, cursusnaamm, lokaal, tijdstip
        {
            int idDocent, idCursus, idLokaal;
            DateTime GekozenMoment;

            (idDocent, idCursus, idLokaal, GekozenMoment) = verkrijgPlanningData(id);

            string docentNaam = verkrijgDocentNaam(idDocent);
            string cursusnaam = verkrijgCursusNaam(idCursus);
            string lokaal = verkrijgLokaal(idLokaal);
            string moment = GekozenMoment.ToString("dd/MM/yyyy HH:mm:ss");

            return (docentNaam, cursusnaam, lokaal, moment);



        }

        private (int, int, int, DateTime) verkrijgPlanningData(int id)
        {
            string query = "SELECT idDocent, idCursus, idLokaal, GekozenMoment FROM planning WHERE idPlanning = @idPlanning";

            int idDocent=0, idCursus=0, idLokaal = 0;
            DateTime GekozenMoment = DateTime.Now;
            using (var connection = new MySqlConnection(conn))
            {
                connection.Open();

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idPlanning", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idDocent = reader.GetInt32("idDocent");
                            idCursus = reader.GetInt32("idCursus");
                            idLokaal = reader.GetInt32("idLokaal");
                            GekozenMoment = (DateTime)reader.GetMySqlDateTime("GekozenMoment");
                        }

                    }
                }
            }


            return (idDocent, idCursus, idLokaal, GekozenMoment);
        }

        private string verkrijgDocentNaam(int id)
        {
            string query = "SELECT Naam, Voornaam, Titel FROM docent WHERE idDocent = @idDocent";

            using (var connection = new MySqlConnection(conn))
            {
                connection.Open();

                using (var command = new MySqlCommand(query, connection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@idDocent", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string Naam = reader.GetString("Naam");
                            string Voornaam = reader.GetString("Voornaam");
                            string Titel;
                            try
                            {
                                Titel = reader.GetString("Titel") + " ";
                            }
                            catch
                            {
                                Titel = "";
                            }
                            return $"{Titel}{Naam} {Voornaam}";
                        }

                    }
                }
            }

            return "";
        }

        private string verkrijgStudentNaam(int id)
        {
            string query = "SELECT Naam, Voornaam FROM student WHERE idStudent = @idStudent";

            using (var connection = new MySqlConnection(conn))
            {
                connection.Open();

                using (var command = new MySqlCommand(query, connection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@idStudent", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string Naam = reader.GetString("Naam");
                            string Voornaam = reader.GetString("Voornaam");

                            return $"{Naam} {Voornaam}";
                        }
                        
                    }
                }
            }

            return "";
        }

        private string verkrijgCursusNaam(int id)
        {
            string query = "SELECT Naam FROM cursussen WHERE idCursus = @idCursus";

            using (var connection = new MySqlConnection(conn))
            {
                connection.Open();

                using (var command = new MySqlCommand(query, connection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@idCursus", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string Naam = reader.GetString("Naam");

                            return Naam;
                        }

                    }
                }
            }

            return "";
        }

        private string verkrijgLokaal(int id)
        {
            string query = "SELECT Lokaalnummer FROM lokaal WHERE idLokaal = @idLokaal";

            using (var connection = new MySqlConnection(conn))
            {
                connection.Open();

                using (var command = new MySqlCommand(query, connection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@idLokaal", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string Lokaalnummer = reader.GetString("Lokaalnummer");

                            return Lokaalnummer;
                        }

                    }
                }
            }

            return "";
        }

        private void workshopToevoegenButton_Click(object sender, EventArgs e)
        {
            WorkshopToevoegen workshopToevoegen = new WorkshopToevoegen();
            workshopToevoegen.Show();
        }

        private void workshopAanmeldenButton_Click(object sender, EventArgs e)
        {
            WorkshopAanmelden workshopAanmelden = new WorkshopAanmelden();
            workshopAanmelden.Show();
        }

        

    }
}