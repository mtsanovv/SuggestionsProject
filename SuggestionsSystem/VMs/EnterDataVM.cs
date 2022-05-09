using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using SuggestionsSystem.Models;

namespace SuggestionsSystem.VMs
{
    public class EnterDataVM : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private EnterSuggestions _enterSuggestions;
        private static string[] propertiesToHide = { "Password", "CatID" };
        private User _currentUser;
        private readonly bool _isWinforms = false;
        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                triggerPropChangedForAllTextBoxes();
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
        public string UsernameTextBox
        {
            get
            {
                return CurrentUser.Username;
            }
            set
            {
                CurrentUser.Username = value;
                GetSuggestions("Username");
            }
        }
        public string PasswordTextBox
        {
            get
            {
                return CurrentUser.Password;
            }
            set
            {
                CurrentUser.Password = value;
                GetSuggestions("Password");
            }
        }
        public string EmailTextBox
        {
            get
            {
                return CurrentUser.Email;
            }
            set
            {
                CurrentUser.Email = value;
                GetSuggestions("Email");
            }
        }
        public string CatIDTextBox
        {
            get
            {
                return CurrentUser.CatID.ToString();
            }
            set
            {
                if(_isWinforms)
                {
                    CatIdTextBoxChangedWinForms(value);
                    return;
                }
                CatIdTextBoxChangedWpf(value);
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
        private bool _passwordIsFocused;
        public bool PasswordIsFocused
        {
            get { return _passwordIsFocused; }
            set
            {
                _passwordIsFocused = value;
                PropChanged("PasswordIsFocused");
            }
        }
        private bool _catIDIsFocused;
        public bool CatIDIsFocused
        {
            get { return _catIDIsFocused; }
            set
            {
                _catIDIsFocused = value;
                PropChanged("CatIDIsFocused");
            }
        }
        private bool _suggestionsIsFocused;
        public bool SuggestionsIsFocused
        {
            get { return _suggestionsIsFocused; }
            set
            {
                _suggestionsIsFocused = value;
                PropChanged("SuggestionsIsFocused");
            }
        }

        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand FocusSuggestionsBoxCommand { get; set; }
        public RelayCommand SelectSuggestionCommand { get; set; }

        // lastFocusedTextBox properties are winforms-only
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
        public EnterDataVM()
        {
            // wpf constructor should always be parameterless
            initializeCommonProperties();
            _suggestions = new ObservableCollection<string>();
            AddUserCommand = new RelayCommand(AddUser);
            FocusSuggestionsBoxCommand = new RelayCommand(FocusSuggestionsBox);
            SelectSuggestionCommand = new RelayCommand(SelectSuggestion);
        }

        public EnterDataVM(Action selectedSuggestionChanged)
        {
            // winforms constructor needs parameters
            _isWinforms = true;
            initializeCommonProperties();
            _suggestions = new BindingList<string>();
            _winFormsAfterSelectedSuggestionChanged = selectedSuggestionChanged;
        }

        private void initializeCommonProperties()
        {
            _enterSuggestions = new EnterSuggestions("users.txt");
            CurrentUser = new User();
            _enterSuggestions.SetSuggestionsProperty(Suggestions);
        }

        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public void AddUser()
        {
            if (IsValid(EmailTextBox))
            {
                CurrentUser = new User(UsernameTextBox, PasswordTextBox, EmailTextBox, Int32.Parse(CatIDTextBox));
                CurrentUser.addToDatabase();

            }
            else
            {
                MessageBox.Show("Invalid email address!");
            }
            _enterSuggestions.TrySaveSuggestion(CurrentUser, IsValid, "Email");
        }

        private void FocusSuggestionsBox()
        {
            FocusHelper.SetFocus(this, "SuggestionsIsFocused");
        }

        private void SelectSuggestion()
        {
            _enterSuggestions.Select(this, CurrentUser, _selectedSuggestion);
            triggerPropChangedForAllTextBoxes();
        }

        // winforms-only methods below
        public void SelectedSuggestionChanged()
        {
            if (SelectedSuggestion != null)
            {
                _enterSuggestions.Select(this, CurrentUser, SelectedSuggestion);
                triggerPropChangedForAllTextBoxes();
                _winFormsAfterSelectedSuggestionChanged();
            }
        }

        private void triggerPropChangedForAllTextBoxes()
        {
            PropChanged("UsernameTextBox");
            PropChanged("PasswordTextBox");
            PropChanged("EmailTextBox");
            PropChanged("CatIDTextBox");
        }

        private void GetSuggestions(string paramID)
        {
            string paramFocusedName = paramID + "IsFocused";
            string paramIDTextBox = paramID + "TextBox";
            _enterSuggestions.SwitchContext(this, CurrentUser, paramID, paramFocusedName, Suggestions);
            _enterSuggestions.Suggest(CurrentUser, propertiesToHide);
            PropChanged(paramIDTextBox);
        }

        private void CatIdTextBoxChangedWinForms(string value)
        {
            int catId = 0;
            Int32.TryParse(value, out catId);
            CurrentUser.CatID = catId;
            GetSuggestions("CatID");
        }

        private void CatIdTextBoxChangedWpf(string value)
        {
            CurrentUser.CatID = Int32.Parse(value);
            GetSuggestions("CatID");
        }
    }
}
