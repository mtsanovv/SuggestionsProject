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
    public partial class EnterDataWindow : Form
    {
        private EnterDataVM VM;

        public EnterDataWindow()
        {
            InitializeComponent();
            VM = new EnterDataVM();
            bindControls();
        }
        private void bindControls()
        {
            emailTextBox.DataBindings.Add("Text", VM, "EmailTextBox", true, DataSourceUpdateMode.OnPropertyChanged);
            usernameTextBox.DataBindings.Add("Text", VM, "UsernameTextBox", true, DataSourceUpdateMode.OnPropertyChanged);
            passwordTextBox.DataBindings.Add("Text", VM, "PasswordTextBox", true, DataSourceUpdateMode.OnPropertyChanged);
            catIdTextBox.DataBindings.Add("Text", VM, "CatIDTextBox", true, DataSourceUpdateMode.OnPropertyChanged);

            addButton.Click += VM.AddUser;

            suggestionsListBox.DataSource = VM.Suggestions;
            suggestionsListBox.DataBindings.Add("SelectedValue", VM, "SelectedSuggestion", true, DataSourceUpdateMode.OnPropertyChanged);
            suggestionsListBox.SelectedIndexChanged += VM.SelectedSuggestionChanged;
        }
    }
}
