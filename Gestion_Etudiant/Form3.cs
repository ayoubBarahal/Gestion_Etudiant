using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Etudiant
{
    public partial class Form3 : Form
    {

        private MySqlConnection connection;


        public Form3()
        {
            InitializeComponent();
            Connection conn = new Connection();
            connection = conn.connectionDB();
        }


        public void Dataload()
        {
            String sql = "SELECT * FROM etudiant";
            if (connection != null)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    Console.WriteLine("Data loaded successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Failed to connect to the database.");
            }
        }

        private void Quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Dataload();
        }
    }
}
