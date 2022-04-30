using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTestApp
{
    public partial class SearchDataWindow : Form
    {
        private SearchDataVM VM;
        public SearchDataWindow()
        {
            InitializeComponent();
            VM = new SearchDataVM();
            bindControls();
        }

        private void bindControls()
        {
            nameTextBox.DataBindings.Add("Text", VM, "CatNameTextBox", true, DataSourceUpdateMode.OnPropertyChanged);
            breedTextBox.DataBindings.Add("Text", VM, "CatBreedTextBox", true, DataSourceUpdateMode.OnPropertyChanged);
            userTextBox.DataBindings.Add("Text", VM, "UsernameTextBox", true, DataSourceUpdateMode.OnPropertyChanged);
            emailTextBox.DataBindings.Add("Text", VM, "EmailTextBox", true, DataSourceUpdateMode.OnPropertyChanged);

            usersListBox.DataSource = VM.UsersList;
            catsListBox.DataSource = VM.CatsList;

            searchNameBtn.Click += VM.SearchByCatName;
            searchBreedBtn.Click += VM.SearchByBreed;
            searchUserBtn.Click += VM.SearchByUsername;
            searchEmailBtn.Click += VM.SearchByEmail;

            suggestionsListBox.DataSource = VM.Suggestions;
            suggestionsListBox.DataBindings.Add("SelectedValue", VM, "SelectedSuggestion", true, DataSourceUpdateMode.OnPropertyChanged);
            suggestionsListBox.SelectedIndexChanged += VM.SelectedSuggestionChanged;
        }
    }
}
