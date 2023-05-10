using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace sqloefening
{
    public partial class WorkshopToevoegen : Form
    {
        string conn = "server=127.0.0.1;port=3307;database=mydb;user=root;password=usbw;";
        public WorkshopToevoegen()
        {
            InitializeComponent();
            vulDocentDropdown();
            vulCursusDropdown();
            vulLokaalDropdown();
            uurPicker.Format = DateTimePickerFormat.Time;
        }

        private void toevoegenButton_Click(object sender, EventArgs e)
        {
            if(docentComboBox.SelectedIndex == -1 || lokaalComboBox.SelectedIndex == -1 || cursussenComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Niet alle velden zijn correct ingevuld!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (maxDeelnemersInput.Value < 1)
            {
                MessageBox.Show("Er moet minstens 1 deelnemer toegelaten zijn.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string docent = docentComboBox.Text;
            string cursus = cursussenComboBox.Text;
            string lokaal = lokaalComboBox.Text;

            int idDocent = verkrijgIdentificatieDocent(docent);
            int idCursus = verkrijgIdentificatieCursus(cursus);
            int idLokaal = verkrijgIdentificatieLokaal(lokaal);

            DateTime moment = verkrijgGekozenMoment();
            int maxCapaciteit = (int)maxDeelnemersInput.Value;

            vulDatabase(idDocent, idCursus, idLokaal, moment, maxCapaciteit);

        }

        private void vulDatabase(int idDocent, int idCursus, int idLokaal, DateTime moment, int maxCapaciteit)
        {
            string query = "INSERT INTO planning (idDocent, idCursus, idLokaal, GekozenMoment, maxCapaciteit) VALUES (@idDocent, @idCursus, @idLokaal, @GekozenMoment, @maxCapaciteit)";

            using (var connection = new MySqlConnection(conn))
            {
                connection.Open();

                using (var command = new MySqlCommand(query, connection))
                {
                    // Add the parameters to the query
                    command.Parameters.AddWithValue("@idDocent", idDocent);
                    command.Parameters.AddWithValue("@idCursus", idCursus);
                    command.Parameters.AddWithValue("@idLokaal", idLokaal);
                    command.Parameters.AddWithValue("@GekozenMoment", moment);
                    command.Parameters.AddWithValue("@maxCapaciteit", maxCapaciteit);

                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine(rowsAffected + " row(s) inserted.");
                }
            }
        }

        private DateTime verkrijgGekozenMoment()
        {
            DateTime selectedDate = datumPicker.Value.Date;
            TimeSpan selectedTime = uurPicker.Value.TimeOfDay;

            DateTime combinedDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day,
                selectedTime.Hours, selectedTime.Minutes, selectedTime.Seconds);

            return combinedDateTime;
        }

        private int verkrijgIdentificatieDocent(string docent)
        {
            string pattern = @"\[([a-zA-Z0-9]+)\]";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(docent);

            if (match.Success)
            {
                string docentnummer = match.Groups[1].Value;

                string query = "SELECT idDocent FROM docent WHERE Docentnummer = @Docentnummer";

                using (var connection = new MySqlConnection(conn))
                {
                    connection.Open();

                    using (var command = new MySqlCommand(query, connection))
                    {
                        // Add the parameter to the query
                        command.Parameters.AddWithValue("@Docentnummer", docentnummer);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idDocent = reader.GetInt32("idDocent");
                                
                                Console.WriteLine("idDocent: " + idDocent);

                                return idDocent;
                            }
                            else
                            {
                                Console.WriteLine("No matching docent found.");
                                return 0;
                            }
                        }
                    }
                }


            }
            else
            {
                Console.WriteLine("No ID found in the input string.");
                return 0;
            }


            
        }

        private int verkrijgIdentificatieCursus(string cursus)
        {
            string pattern = @"\[([a-zA-Z0-9]+)\]";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(cursus);

            if (match.Success)
            {
                string cursusnummer = match.Groups[1].Value;

                string query = "SELECT idCursus FROM cursussen WHERE identificatieNummer = @identificatieNummer";

                using (var connection = new MySqlConnection(conn))
                {
                    connection.Open();

                    using (var command = new MySqlCommand(query, connection))
                    {
                        // Add the parameter to the query
                        command.Parameters.AddWithValue("@identificatieNummer", cursusnummer);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idCursus = reader.GetInt32("idCursus");

                                Console.WriteLine("idCursus: " + idCursus);

                                return idCursus;
                            }
                            else
                            {
                                Console.WriteLine("No matching cursus found.");
                                return 0;
                            }
                        }
                    }
                }


            }
            else
            {
                Console.WriteLine("No ID found in the input string.");
                return 0;
            }



        }

        private int verkrijgIdentificatieLokaal(string lokaal)
        {
            string query = "SELECT idLokaal FROM lokaal WHERE Lokaalnummer = @Lokaalnummer";

            using (var connection = new MySqlConnection(conn))
            {
                connection.Open();

                using (var command = new MySqlCommand(query, connection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@Lokaalnummer", lokaal);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idLokaal = reader.GetInt32("idLokaal");

                            Console.WriteLine("idLokaal: " + idLokaal);

                            return idLokaal;
                        }
                        else
                        {
                            Console.WriteLine("No matching lokaal found.");
                            return 0;
                        }
                    }
                }
            }
        }

        private void vulDocentDropdown()
        {
            using var connection = new MySqlConnection(conn);
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT Titel, Naam, Voornaam, Docentnummer FROM docent;", connection);
            using (var reader = command.ExecuteReader()){
                while (reader.Read())
                {
                    string titel;
                    try
                    {
                        titel = reader.GetString(0) + " ";
                    }
                    catch
                    {
                        titel = "";
                    }
                    
                    string naam = reader.GetString(1);
                    string voornaam = reader.GetString(2);
                    string docentnummer = reader.GetString(3);
                    docentComboBox.Items.Add($"{titel}{naam} {voornaam} [{docentnummer}]");
                }

                connection.Close();
            }
            
        }

        private void vulCursusDropdown()
        {
            using var connection = new MySqlConnection(conn);
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT Naam, identificatieNummer FROM cursussen;", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string naam = reader.GetString(0);
                    string id = reader.GetString(1);
                    cursussenComboBox.Items.Add($"{naam} [{id}]");
                }

                connection.Close();
            }
        }

        private void vulLokaalDropdown()
        {
            using var connection = new MySqlConnection(conn);
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT Lokaalnummer FROM lokaal;", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string lokaal = reader.GetString(0);
                    lokaalComboBox.Items.Add(lokaal);
                }

                connection.Close();
            }
        }
    }
}
