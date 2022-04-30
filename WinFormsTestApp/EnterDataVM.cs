﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuggestionsSystem;
using TestApp;

namespace WinFormsTestApp
{
    public class EnterDataVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private EnterSuggestions _enterSuggestions;
        private static string[] propertiesToHide = { "Password", "CatID" };

        private User _currentUser;
        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                PropChanged("UsernameTextBox");
                PropChanged("PasswordTextBox");
                PropChanged("EmailTextBox");
                PropChanged("CatIDTextBox");
            }
        }

        private BindingList<string> _suggestions;
        public BindingList<string> Suggestions
        {
            get { return _suggestions; }
            set { _suggestions = value; PropChanged("Suggestions"); }
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
                _enterSuggestions.SwitchContext(this, CurrentUser, "Username", "UsernameIsFocused", Suggestions);
                _enterSuggestions.Suggest(CurrentUser, propertiesToHide);
                PropChanged("UsernameTextBox");
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
                _enterSuggestions.SwitchContext(this, CurrentUser, "Password", "PasswordIsFocused", Suggestions);
                _enterSuggestions.Suggest(CurrentUser, propertiesToHide);
                PropChanged("PasswordTextBox");
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
                _enterSuggestions.SwitchContext(this, CurrentUser, "Email", "EmailIsFocused", Suggestions);
                _enterSuggestions.Suggest(CurrentUser, propertiesToHide);
                PropChanged("EmailTextBox");
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
                int catId = 0;
                Int32.TryParse(value, out catId);
                CurrentUser.CatID = catId;
                _enterSuggestions.SwitchContext(this, CurrentUser, "CatID", "CatIDIsFocused", Suggestions);
                _enterSuggestions.Suggest(CurrentUser, propertiesToHide);
                PropChanged("CatIDTextBox");
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

        public void SelectedSuggestionChanged(Object sender, EventArgs e)
        {
            if (SelectedSuggestion != null)
            {
                _enterSuggestions.Select(this, CurrentUser, _selectedSuggestion);
                PropChanged("UsernameTextBox");
                PropChanged("PasswordTextBox");
                PropChanged("EmailTextBox");
                PropChanged("CatIDTextBox");
            }
        }
        public EnterDataVM()
        {
            _suggestions = new BindingList<string>();
            _enterSuggestions = new EnterSuggestions("users.txt");
            CurrentUser = new User();
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
        public void AddUser(object sender, EventArgs e)
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
    }
}
