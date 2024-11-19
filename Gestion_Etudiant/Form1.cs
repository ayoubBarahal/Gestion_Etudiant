using MySql.Data.MySqlClient;
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

namespace Gestion_Etudiant
{
    public partial class Form1 : Form
    {

        Connection conn=new Connection();



        public Form1()
        {
            InitializeComponent();
            conn.connectionDB();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox1.Text == "ayoub" && textBox2.Text == "1234")
            {
                Form2 form = new Form2();
                form.Show();
            }
            else
            {
                MessageBox.Show("User name ou mot de passe INCORRECTE ");
            }
        }
    }
}
