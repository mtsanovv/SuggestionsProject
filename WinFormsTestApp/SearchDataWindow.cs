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
        public TextBox lastFocusedTextBox;
        public SearchDataWindow()
        {
            InitializeComponent();
            VM = new SearchDataVM();
            bindControls();
        }

        private void bindControls()
        {
            bindTextBoxesWithPropertiesAndEvents();

            usersListBox.DataSource = VM.UsersList;
            catsListBox.DataSource = VM.CatsList;

            searchNameBtn.Click += VM.SearchByCatName;
            searchBreedBtn.Click += VM.SearchByBreed;
            searchUserBtn.Click += VM.SearchByUsername;
            searchEmailBtn.Click += VM.SearchByEmail;

            suggestionsListBox.DataSource = VM.Suggestions;
            suggestionsListBox.DataBindings.Add("SelectedValue", VM, "SelectedSuggestion", true, DataSourceUpdateMode.OnPropertyChanged);
            suggestionsListBox.KeyDown += SuggestionsListBoxKeyDown;
            suggestionsListBox.DoubleClick += SuggestionsListBoxDoubleClick;
        }

        private void bindTextBoxesWithPropertiesAndEvents()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.DataBindings.Add("Text", VM, control.Name, true, DataSourceUpdateMode.OnPropertyChanged);
                    control.KeyDown += TextBoxKeyDown;
                    control.GotFocus += TextBoxFocused;
                }
            }
        }

        private void SuggestionsListBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VM.SelectedSuggestionChanged(lastFocusedTextBox);
            }
        }

        private void SuggestionsListBoxDoubleClick(object sender, EventArgs e)
        {
            VM.SelectedSuggestionChanged(lastFocusedTextBox);
        }

        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && suggestionsListBox.Items.Count > 0)
            {
                lastFocusedTextBox = sender as TextBox;
                suggestionsListBox.Focus();
                // the SelectedIndex has to change in order to allow key events on the suggestions list box
                int savedSuggestionsListBoxSelectedIndex = suggestionsListBox.SelectedIndex;
                suggestionsListBox.SelectedIndex = -1;
                suggestionsListBox.SelectedIndex = savedSuggestionsListBoxSelectedIndex;
            }
        }

        private void TextBoxFocused(object sender, EventArgs e)
        {
            lastFocusedTextBox = sender as TextBox;
        }
    }
}
