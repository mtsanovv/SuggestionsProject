using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuggestionsSystem;

namespace WinFormsTestApp
{
    public class SearchDataVM
    {
        private Cats _cats;
        private Users _users;

        private BindingList<string> _catsList;
        public BindingList<string> CatsList
        {
            get { return _catsList; }
            set { _catsList = value; PropChanged("CatsList"); }
        }

        private BindingList<string> _usersList;
        public BindingList<string> UsersList
        {
            get { return _usersList; }
            set { _usersList = value; PropChanged("UsersList"); }
        }

        private BindingList<string> _suggestions;
        public BindingList<string> Suggestions
        {
            get { return _suggestions; }
            set { _suggestions = value; PropChanged("Suggestions"); }
        }

        private string _catNameTextBox;
        public string CatNameTextBox
        {
            get { return _catNameTextBox; }
            set
            {
                _catNameTextBox = value;
                SearchSuggestions.SwitchContext(this, "cat_names.txt", "CatNameTextBox", "CatNameIsFocused", CatsList, Suggestions);
                SearchSuggestions.Suggest(this);
                PropChanged("CatNameTextBox");
            }
        }
        private bool _catNameIsFocused;
        public bool CatNameIsFocused
        {
            get { return _catNameIsFocused; }
            set
            {
                _catNameIsFocused = value;
                if (_catNameIsFocused)
                {
                    SearchSuggestions.SwitchContext(this, "cat_names.txt", "CatNameTextBox", "CatNameIsFocused", CatsList, Suggestions);
                    SearchSuggestions.Suggest(this);
                }
                PropChanged("CatNameIsFocused");
            }
        }
        private string _catBreedTextBox;
        public string CatBreedTextBox
        {
            get
            {
                return _catBreedTextBox;
            }
            set
            {
                _catBreedTextBox = value;
                SearchSuggestions.SwitchContext(this, "cat_breeds.txt", "CatBreedTextBox", "CatBreedIsFocused", CatsList, Suggestions);
                SearchSuggestions.Suggest(this);
                PropChanged("CatBreedTextBox");
            }
        }
        private bool _catBreedIsFocused;
        public bool CatBreedIsFocused
        {
            get { return _catBreedIsFocused; }
            set
            {
                _catBreedIsFocused = value;
                if (CatBreedIsFocused)
                {
                    SearchSuggestions.SwitchContext(this, "cat_breeds.txt", "CatBreedTextBox", "CatBreedIsFocused", CatsList, Suggestions);
                    SearchSuggestions.Suggest(this);
                }
                PropChanged("CatBreedIsFocused");
            }
        }
        private string _usernameTextBox;
        public string UsernameTextBox
        {
            get
            {
                return _usernameTextBox;
            }
            set
            {
                _usernameTextBox = value;
                SearchSuggestions.SwitchContext(this, "usernames.txt", "UsernameTextBox", "UsernameIsFocused", UsersList, Suggestions);
                SearchSuggestions.Suggest(this);
                PropChanged("UsernameTextBox");
            }
        }
        private bool _usernameIsFocused;
        public bool UsernameIsFocused
        {
            get { return _usernameIsFocused; }
            set
            {
                _usernameIsFocused = value;
                PropChanged("UsernameIsFocused");
            }
        }
        private string _emailTextBox;
        public string EmailTextBox
        {
            get
            {
                return _emailTextBox;
            }
            set
            {
                _emailTextBox = value;
                SearchSuggestions.SwitchContext(this, "emails.txt", "EmailTextBox", "EmailIsFocused", UsersList, Suggestions);
                SearchSuggestions.Suggest(this);
                PropChanged("EmailTextBox");
            }
        }
        private bool _emailIsFocused;
        public bool EmailIsFocused
        {
            get { return _emailIsFocused; }
            set
            {
                _emailIsFocused = value;
                PropChanged("EmailIsFocused");
            }
        }

        private string _selectedSuggestion;
        public string SelectedSuggestion
        {
            get
            {
                return _selectedSuggestion;
            }
            set
            {
                _selectedSuggestion = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public SearchDataVM()
        {
            _catsList = new BindingList<string>();
            _usersList = new BindingList<string>();
            _suggestions = new BindingList<string>();
            _cats = new Cats(CatsList);
            _users = new Users(UsersList);
        }

        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void SearchByCatName(object sender, EventArgs e)
        {
            CatsList.Clear();
            _cats.SearchByCatName(CatNameTextBox);
            SearchSuggestions.SwitchContext(this, "cat_names.txt", "CatNameTextBox", "CatNameIsFocused", CatsList, Suggestions);
            SearchSuggestions.TrySaveSuggestion(this);
        }
        public void SearchByBreed(object sender, EventArgs e)
        {
            CatsList.Clear();
            _cats.SearchByBreed(CatBreedTextBox);
            SearchSuggestions.SwitchContext(this, "cat_breeds.txt", "CatBreedTextBox", "CatBreedIsFocused", CatsList, Suggestions);
            SearchSuggestions.TrySaveSuggestion(this);
        }
        public void SearchByUsername(object sender, EventArgs e)
        {
            UsersList.Clear();
            _users.SearchByUsername(UsernameTextBox);
            SearchSuggestions.SwitchContext(this, "usernames.txt", "UsernameTextBox", "UsernameIsFocused", UsersList, Suggestions);
            SearchSuggestions.TrySaveSuggestion(this);
        }
        public void SearchByEmail(object sender, EventArgs e)
        {
            UsersList.Clear();
            _users.SearchByEmail(EmailTextBox);
            SearchSuggestions.SwitchContext(this, "emails.txt", "EmailTextBox", "EmailIsFocused", UsersList, Suggestions);
            SearchSuggestions.TrySaveSuggestion(this);
        }

        public void SelectedSuggestionChanged(TextBox textBoxToFocus)
        {
            if (SelectedSuggestion != null)
            {
                SearchSuggestions.Select(this, SelectedSuggestion);
                textBoxToFocus.Focus();
                textBoxToFocus.Select(textBoxToFocus.Text.Length, 0);
            }
        }
    }
}
