using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuggestionsSystem.VMs;

namespace WinFormsTestApp
{
    public partial class SearchDataWindow : Form
    {
        private SearchDataVM VM;
        public SearchDataWindow()
        {
            InitializeComponent();
            VM = new SearchDataVM(AfterSelectedSuggestionChanged);
            BindControls();
        }

        private void BindControls()
        {
            BindTextBoxesWithPropertiesAndEvents();

            usersListBox.DataSource = VM.UsersList;
            catsListBox.DataSource = VM.CatsList;

            searchNameBtn.Click += SearchButtonClicked;
            searchBreedBtn.Click += SearchButtonClicked;
            searchUserBtn.Click += SearchButtonClicked;
            searchEmailBtn.Click += SearchButtonClicked;

            suggestionsListBox.DataSource = VM.Suggestions;
            suggestionsListBox.DataBindings.Add("SelectedValue", VM, "SelectedSuggestion", true, DataSourceUpdateMode.OnPropertyChanged);
            suggestionsListBox.KeyDown += SuggestionListBoxSelectedItemChanged;
            suggestionsListBox.DoubleClick += SuggestionListBoxSelectedItemChanged;
        }

        public void AfterSelectedSuggestionChanged()
        {
            foreach (Control control in this.Controls)
            {
                TextBox textBoxControl = control as TextBox;
                if (textBoxControl != null && control.Name == VM.LastFocusedTextBoxName)
                {
                    textBoxControl.Focus();
                    textBoxControl.Select(control.Text.Length, 0);
                }
            }
        }

        private void SearchButtonClicked(object sender, EventArgs e)
        {
            Button senderBtn = sender as Button;
            if(senderBtn.Name.Equals(searchNameBtn.Name))
            {
                VM.SearchByCatName();
                return;
            }

            if(senderBtn.Name.Equals(searchBreedBtn.Name))
            {
                VM.SearchByBreed();
                return;
            }

            if(senderBtn.Name.Equals(searchUserBtn.Name))
            {
                VM.SearchByUsername();
                return;
            }

            if(senderBtn.Name.Equals(searchEmailBtn.Name))
            {
                VM.SearchByEmail();
                return;
            }
        }

        private void BindTextBoxesWithPropertiesAndEvents()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.DataBindings.Add("Text", VM, control.Name, true, DataSourceUpdateMode.OnPropertyChanged);
                    control.KeyDown += TextBoxFocusOrKeyDown;
                    control.GotFocus += TextBoxFocusOrKeyDown;
                }
            }
        }

        private void SuggestionListBoxSelectedItemChanged(object sender, EventArgs e)
        {
            KeyEventArgs ke = e as KeyEventArgs;
            if (ke == null)
            {
                // it's the doubleclick event
                VM.SelectedSuggestionChanged();
                return;
            }
            if (ke.KeyCode == Keys.Enter)
            {
                VM.SelectedSuggestionChanged();
            }
        }

        private void TextBoxFocusOrKeyDown(object sender, EventArgs e)
        {
            KeyEventArgs ke = e as KeyEventArgs;
            TextBox textBox = sender as TextBox;
            if (ke == null)
            {
                // it's the focus event
                VM.LastFocusedTextBoxName = textBox.Name;
                return;
            }

            if (ke.KeyCode == Keys.Down && suggestionsListBox.Items.Count > 0)
            {
                VM.LastFocusedTextBoxName = textBox.Name;
                suggestionsListBox.Focus();
                // the SelectedIndex has to change in order to allow key events on the suggestions list box
                int savedSuggestionsListBoxSelectedIndex = suggestionsListBox.SelectedIndex;
                suggestionsListBox.SelectedIndex = -1;
                suggestionsListBox.SelectedIndex = savedSuggestionsListBoxSelectedIndex;
            }
        }
    }
}
