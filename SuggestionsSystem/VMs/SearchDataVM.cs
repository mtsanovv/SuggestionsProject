using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using SuggestionsSystem.Models;
using SuggestionsSystem.Interfaces;

namespace SuggestionsSystem.VMs
{
    public class SearchDataVM : DependencyObject, INotifyPropertyChanged, ISearchDataVM
    {
        private Cats _cats;
        private Users _users;

        private IList<string> _catsList;
        public IList<string> CatsList
        {
            get
            {
                return _catsList;
            }
            set
            {
                _catsList = value;
                PropChanged("CatsList");
            }
        }

        private IList<string> _usersList;
        public IList<string> UsersList
        {
            get
            {
                return _usersList;
            }
            set
            {
                _usersList = value;
                PropChanged("UsersList");
            }
        }

        private IList<string> _suggestions;
        public IList<string> Suggestions
        {
            get
            {
                return _suggestions;
            }
            set
            {
                _suggestions = value;
                PropChanged("Suggestions");
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
        private bool _suggestionsIsFocused;
        public bool SuggestionsIsFocused
        {
            get
            {
                return _suggestionsIsFocused;
            }
            set
            {
                _suggestionsIsFocused = value;
                PropChanged("SuggestionsIsFocused");
            }
        }

        private string _catNameTextBox;
        public string CatNameTextBox
        {
            get
            {
                return _catNameTextBox;
            }
            set
            {
                _catNameTextBox = value;
                TriggerSuggestions("CatName");
            }
        }

        private bool _catNameIsFocused;
        public bool CatNameIsFocused
        {
            get
            {
                return _catNameIsFocused;
            }
            set
            {
                _catNameIsFocused = value;
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
                TriggerSuggestions("CatBreed");
            }
        }
        private bool _catBreedIsFocused;
        public bool CatBreedIsFocused
        {
            get
            {
                return _catBreedIsFocused;
            }
            set
            {
                _catBreedIsFocused = value;
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
                TriggerSuggestions("Username");
            }
        }
        private bool _usernameIsFocused;
        public bool UsernameIsFocused
        {
            get
            {
                return _usernameIsFocused;
            }
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
                TriggerSuggestions("Email");
            }
        }
        private bool _emailIsFocused;
        public bool EmailIsFocused
        {
            get
            {
                return _emailIsFocused;
            }
            set
            {
                _emailIsFocused = value;
                PropChanged("EmailIsFocused");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand SearchCatByName { get; set; }
        public RelayCommand SearchCatByBreed { get; set; }
        public RelayCommand SearchUserByUsername { get; set; }
        public RelayCommand SearchUserByEmail { get; set; }
        public RelayCommand FocusSuggestionsBoxCommand { get; set; }
        public RelayCommand SelectSuggestionCommand { get; set; }

        private string _lastFocusedTextBoxName;
        public string LastFocusedTextBoxName
        {
            get
            {
                return _lastFocusedTextBoxName;
            }
            set
            {
                _lastFocusedTextBoxName = value;
            }
        }
        private readonly Action _winFormsAfterSelectedSuggestionChanged;
        public SearchDataVM()
        {
            _catsList = new ObservableCollection<string>();
            _usersList = new ObservableCollection<string>();
            _suggestions = new ObservableCollection<string>();
            _cats = new Cats();
            _users = new Users();
            SearchCatByName = new RelayCommand(SearchByCatName);
            SearchCatByBreed = new RelayCommand(SearchByBreed);
            SearchUserByUsername = new RelayCommand(SearchByUsername);
            SearchUserByEmail = new RelayCommand(SearchByEmail);
            FocusSuggestionsBoxCommand = new RelayCommand(FocusSuggestionsBox);
            SelectSuggestionCommand = new RelayCommand(SelectSuggestion);
        }

        public SearchDataVM(Action selectedSuggestionChanged)
        {
            _catsList = new BindingList<string>();
            _usersList = new BindingList<string>();
            _suggestions = new BindingList<string>();
            // CatsList and UsersList need to be used when instantiating Cats and Users so that the results can be fed in those
            // WinForms list binding works by binding to the address a variable points to instead of the contents it holds
            _cats = new Cats(CatsList);
            _users = new Users(UsersList);
            _winFormsAfterSelectedSuggestionChanged = selectedSuggestionChanged;
        }

        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void SearchByCatName()
        {
            CatsList.Clear();
            CatsList = _cats.SearchByCatName(CatNameTextBox);
            TriggerSuggestions("CatName", true);
        }
        public void SearchByBreed()
        {
            CatsList.Clear();
            CatsList = _cats.SearchByBreed(CatBreedTextBox);
            TriggerSuggestions("CatBreed", true);
        }
        public void SearchByUsername()
        {
            UsersList.Clear();
            UsersList = _users.SearchByUsername(UsernameTextBox);
            TriggerSuggestions("Username", true);
        }
        public void SearchByEmail()
        {
            UsersList.Clear();
            UsersList = _users.SearchByEmail(EmailTextBox);
            TriggerSuggestions("Email", true);
        }
        public void FocusSuggestionsBox()
        {
            FocusHelper.SetFocus(this, "SuggestionsIsFocused");
        }
        public void SelectSuggestion()
        {
            SearchSuggestions.Select(this, SelectedSuggestion);
        }

        public void TriggerSuggestions(string paramID, bool shouldTrySavingSuggestion = false)
        {
            string focusedParam = paramID + "IsFocused";
            string textBoxParam = paramID + "TextBox";
            IList<string> relatedList = GetListRelatedToParamID(paramID);
            string fileRelatedToParamID = GetFileRelatedToParamID(paramID);
            if (fileRelatedToParamID == null)
            {
                return;
            }
            SearchSuggestions.SwitchContext(this, fileRelatedToParamID, textBoxParam, focusedParam, relatedList, Suggestions);
            if (shouldTrySavingSuggestion)
            {
                SearchSuggestions.TrySaveSuggestion(this);
                return;
            }
            SearchSuggestions.Suggest(this);
            PropChanged(textBoxParam);
        }

        public IList<string> GetListRelatedToParamID(string paramID)
        {
            if (paramID.IndexOf("cat", StringComparison.OrdinalIgnoreCase) > -1)
            {
                // paramID contains the string cat so it's definitely related to CatsList
                return CatsList;
            }
            return UsersList;
        }

        public string GetFileRelatedToParamID(string paramID)
        {
            switch (paramID)
            {
                case "CatName":
                    return "cat_names.txt";
                case "CatBreed":
                    return "cat_breeds.txt";
                case "Username":
                    return "usernames.txt";
                case "Email":
                    return "emails.txt";
            }
            return null;
        }

        //winforms-only methods below
        public void SelectedSuggestionChanged()
        {
            if (SelectedSuggestion != null)
            {
                SearchSuggestions.Select(this, SelectedSuggestion);
                _winFormsAfterSelectedSuggestionChanged();
            }
        }
    }
}
