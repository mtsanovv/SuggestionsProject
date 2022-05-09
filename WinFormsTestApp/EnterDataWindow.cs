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
    public partial class EnterDataWindow : Form
    {
        private EnterDataVM VM;

        public EnterDataWindow()
        {
            InitializeComponent();
            VM = new EnterDataVM(AfterSelectedSuggestionChanged);
            BindControls();
        }
        private void BindControls()
        {
            BindTextBoxesWithPropertiesAndEvents();

            addButton.Click += AddUserButtonClicked;

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

        private void BindTextBoxesWithPropertiesAndEvents()
        {
            foreach(Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.DataBindings.Add("Text", VM, control.Name, true, DataSourceUpdateMode.OnPropertyChanged);
                    control.KeyDown += TextBoxFocusOrKeyDown;
                    control.GotFocus += TextBoxFocusOrKeyDown;
                }
            }
        }

        private void AddUserButtonClicked(object sender, EventArgs e)
        {
            VM.AddUser();
        }

        private void SuggestionListBoxSelectedItemChanged(object sender, EventArgs e)
        {
            KeyEventArgs ke = e as KeyEventArgs;
            if(ke == null)
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
            if(ke == null)
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
