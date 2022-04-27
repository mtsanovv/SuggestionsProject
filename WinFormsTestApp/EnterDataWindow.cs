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
            usernameTextBox.DataBindings.Add("Text", VM, "UsernameTextBox", true, DataSourceUpdateMode.OnPropertyChanged);
            emailTextBox.DataBindings.Add("Text", VM, "EmailTextBox", true, DataSourceUpdateMode.OnPropertyChanged);
            passwordTextBox.DataBindings.Add("Text", VM, "PasswordTextBox", true, DataSourceUpdateMode.OnPropertyChanged);
            catIdTextBox.DataBindings.Add("Text", VM, "CatIDTextBox", true, DataSourceUpdateMode.OnPropertyChanged);
            suggestionsListBox.DataSource = VM.Suggestions;
        }
    }
}
