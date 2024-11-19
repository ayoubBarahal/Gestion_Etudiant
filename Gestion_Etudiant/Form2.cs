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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gestion_Etudiant
{



    public partial class Form2 : Form
    {

        private MySqlConnection connection;


        public Form2()
        {
            InitializeComponent();
            Connection conn = new Connection();
            connection = conn.connectionDB();
        }



        public void AddStudent()
        {
            int code = int.Parse(textBox1.Text);
            String nom = textBox2.Text;
            String prenom = textBox3.Text;
            String filiere = textBox4.Text;

            String sqli = "insert into etudiant values(@code,@nom,@prenom,@filiere) ";
            MySqlCommand command = new MySqlCommand(sqli, connection);

            command.Parameters.AddWithValue("@code", code);
            command.Parameters.AddWithValue("@nom", nom);
            command.Parameters.AddWithValue("@prenom", prenom);
            command.Parameters.AddWithValue("@filiere", filiere);

            try
            {
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("L'étudiant est ajouté avec succès.");
                }
                else
                    MessageBox.Show("Failed to ADD Student ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateStudent()
        {
            int code = int.Parse(textBox1.Text);
            String nom = textBox2.Text;
            String prenom = textBox3.Text;
            String filiere = textBox4.Text;

            String sql = "update  etudiant set  nom=@nom , prenom=@prenom , filiere=@filiere where code=@code ";
            MySqlCommand command = new MySqlCommand(sql, connection);


            command.Parameters.AddWithValue("code", code);
            command.Parameters.AddWithValue("nom", nom);
            command.Parameters.AddWithValue("prenom", prenom);
            command.Parameters.AddWithValue("filiere", filiere);

            try
            {
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("L'étudiant est  modifié avec succès.");
                }
                else
                    MessageBox.Show("Failed to modify Student ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }


        public void DeleteStudent()
        {
            int code = int.Parse(textBox1.Text);

            String sql = "delete from etudiant where code=@code ";
            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("code", code);
            try
            {
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("L'étudiant est  supprimé avec succès.");
                }
                else
                    MessageBox.Show("Failed to delete Student ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void findStudent()
        {
            int code = int.Parse(textBox1.Text);

            String sql = "select * from etudiant where code=@code ";
            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("code", code);



            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    String nom = reader.GetString("nom");
                    String prenom = reader.GetString("prenom");
                    String filiere = reader.GetString("filiere");

                    textBox1.Text = code.ToString();
                    textBox2.Text = nom;
                    textBox3.Text = prenom;
                    textBox4.Text = filiere;
                }
                else
                {
                    Console.WriteLine("Aucun étudiant trouvé  .");
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void firstStudent()
        {
            int first = 1;
            String sql = "select * from etudiant where code=@code";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("code", first);

            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    int code = reader.GetInt32("code");
                    String nom = reader.GetString("nom");
                    String prenom = reader.GetString("prenom");
                    String filiere = reader.GetString("filiere");

                    textBox1.Text = code.ToString();
                    textBox2.Text = nom;
                    textBox3.Text = prenom;
                    textBox4.Text = filiere;
                }
                else
                {
                    Console.WriteLine("Etudiant n'existe pas");
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur MySQL : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur générale : " + ex.Message);
            }
        }

        public void lastStudent()
        {
            String lastsql = "SELECT code FROM etudiant ORDER BY code DESC LIMIT 1";
            MySqlCommand command1 = new MySqlCommand(lastsql, connection);

            MySqlDataReader reader1 = null;
            try
            {
                reader1 = command1.ExecuteReader();

                if (reader1.HasRows)
                {
                    reader1.Read();

                    int last = reader1.GetInt32("code");

                    reader1.Close();

                    String sql = "SELECT * FROM etudiant WHERE code=@code";
                    MySqlCommand command2 = new MySqlCommand(sql, connection);
                    command2.Parameters.AddWithValue("code", last);

                    MySqlDataReader reader2 = null;
                    try
                    {
                        reader2 = command2.ExecuteReader();

                        if (reader2.HasRows)
                        {
                            reader2.Read();

                            int code = reader2.GetInt32("code");
                            String nom = reader2.GetString("nom");
                            String prenom = reader2.GetString("prenom");
                            String filiere = reader2.GetString("filiere");

                            textBox1.Text = code.ToString();
                            textBox2.Text = nom;
                            textBox3.Text = prenom;
                            textBox4.Text = filiere;
                        }
                        else
                        {
                            Console.WriteLine("Etudiant n'existe pas");
                        }

                        reader2.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Erreur MySQL : " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erreur générale : " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Aucun étudiant trouvé dans la base.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur MySQL : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur générale : " + ex.Message);
            }
            finally
            {
                if (reader1 != null && !reader1.IsClosed)
                {
                    reader1.Close();
                }
            }
        }

        public void nextStudent()
        {
            int code = int.Parse(textBox1.Text);
            String sql = "select * from etudiant where code=@code ";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("code", code + 1);
            MySqlDataReader reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    reader.Read();


                    int nextcode = reader.GetInt32("code");
                    String nom = reader.GetString("nom");
                    String prenom = reader.GetString("prenom");
                    String filiere = reader.GetString("filiere");

                    textBox1.Text = nextcode.ToString();
                    textBox2.Text = nom;
                    textBox3.Text = prenom;
                    textBox4.Text = filiere;
                }
                else
                {
                    MessageBox.Show("C'est le dernier étudiant, pas de suivant. ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reader.Close();
            }

        }

        public void previousStudent()
        {
            int code = int.Parse(textBox1.Text);
            String sql = "select * from etudiant where code=@code ";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("code", code - 1);
            MySqlDataReader reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    reader.Read();


                    int nextcode = reader.GetInt32("code");
                    String nom = reader.GetString("nom");
                    String prenom = reader.GetString("prenom");
                    String filiere = reader.GetString("filiere");

                    textBox1.Text = nextcode.ToString();
                    textBox2.Text = nom;
                    textBox3.Text = prenom;
                    textBox4.Text = filiere;
                }
                else
                {
                    MessageBox.Show("C'est le premier étudiant, il n'y en a pas de précédent ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reader.Close();
            }

        }




        private void vider()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddStudent();
            vider();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateStudent();
            vider();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeleteStudent();
            vider();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            findStudent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            firstStudent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            lastStudent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            nextStudent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            previousStudent();
        }
    }
}
