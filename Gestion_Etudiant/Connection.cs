using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant
{
    internal class Connection
    {

        String conn = "Server=localhost;Database=GestionEtudiant;User ID=MyUser;Password=1234";

        public  MySqlConnection connectionDB()
        {
            MySqlConnection connection = new MySqlConnection(conn);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
