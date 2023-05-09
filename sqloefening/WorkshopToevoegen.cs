using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
