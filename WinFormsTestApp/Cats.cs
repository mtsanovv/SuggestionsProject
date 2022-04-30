using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WinFormsTestApp
{
    public class Cats
    {
        private BindingList<string> _data;
        public Cats(BindingList<string> cats)
        {
            _data = cats;
        }
        public BindingList<string> GetData()
        {
            string connectionString = "SERVER=localhost;DATABASE=wpf_test_app;UID=root";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cats", connection);

            connection.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                string newEntry = "Name: " + dataReader.GetString(1) + "; Breed: " + dataReader.GetString(2);
                _data.Add(newEntry);
            }

            connection.Close();

            return _data;
        }
        public BindingList<string> SearchByCatName(string catName)
        {
            string connectionString = "SERVER=localhost;DATABASE=wpf_test_app;UID=root";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cats WHERE name LIKE @searchPhrase", connection);
            string searchPhrase = "%" + catName + "%";
            cmd.Parameters.AddWithValue("searchPhrase", searchPhrase);

            connection.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                string newEntry = "Name: " + dataReader.GetString(1) + "; Breed: " + dataReader.GetString(2);
                _data.Add(newEntry);
            }

            connection.Close();

            return _data;
        }
        public BindingList<string> SearchByBreed(string breed)
        {
            string connectionString = "SERVER=localhost;DATABASE=wpf_test_app;UID=root";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cats WHERE breed LIKE @searchPhrase", connection);
            string searchPhrase = "%" + breed + "%";
            cmd.Parameters.AddWithValue("searchPhrase", searchPhrase);

            connection.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                string newEntry = "Name: " + dataReader.GetString(1) + "; Breed: " + dataReader.GetString(2);
                _data.Add(newEntry);
            }

            connection.Close();

            return _data;
        }
    }
}
