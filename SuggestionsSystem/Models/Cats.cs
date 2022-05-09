using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuggestionsSystem.Models
{
    public class Cats
    {
        private IList<string> _data;
        public Cats(IList<string> list = null)
        {
            if(list != null)
            {
                _data = list;
                return;
            }
            _data = new ObservableCollection<string>();
        }
        public IList<string> GetData()
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
        public IList<string> SearchByCatName(string catName)
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
        public IList<string> SearchByBreed(string breed)
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
