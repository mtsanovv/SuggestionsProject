using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WinFormsTestApp
{
    public class Users
    {
        static string connectionString = "SERVER=localhost;DATABASE=wpf_test_app;UID=root";
        MySqlConnection connection;
        private BindingList<string> _data;
        public Users(BindingList<string> users)
        {
            connection = new MySqlConnection(connectionString);
            _data = users;
        }
        public BindingList<string> GetData()
        {
            string connectionString = "SERVER=localhost;DATABASE=wpf_test_app;UID=root";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users", connection);

            connection.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                string newEntry = "Username: " + dataReader.GetString(2) + " Email: " + dataReader.GetString(1) + " Cat ID: " + dataReader.GetInt32(4);
                _data.Add(newEntry);
            }

            connection.Close();

            return _data;
        }

        public BindingList<string> SearchByUsername(string username)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE username LIKE @searchPhrase", connection);
            string searchPhrase = "%" + username + "%";
            cmd.Parameters.AddWithValue("searchPhrase", searchPhrase);

            connection.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                string newEntry = "Username: " + dataReader.GetString(2) + " Email: " + dataReader.GetString(1) + " Cat ID: " + dataReader.GetInt32(4);
                _data.Add(newEntry);
            }

            connection.Close();

            return _data;
        }

        public BindingList<string> SearchByEmail(string email)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE email LIKE @searchPhrase", connection);
            string searchPhrase = "%" + email + "%";
            cmd.Parameters.AddWithValue("searchPhrase", searchPhrase);

            connection.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                string newEntry = "Username: " + dataReader.GetString(2) + " Email: " + dataReader.GetString(1) + " Cat ID: " + dataReader.GetInt32(4);
                _data.Add(newEntry);
            }

            connection.Close();

            return _data;
        }
    }
}
