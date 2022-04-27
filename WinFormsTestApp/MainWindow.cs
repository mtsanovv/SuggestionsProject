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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void enterDataBtn_Click(object sender, EventArgs e)
        {
            EnterDataWindow enterDataWindow = new EnterDataWindow();
            enterDataWindow.Show();
        }

        private void searchDataBtn_Click(object sender, EventArgs e)
        {
            SearchDataWindow searchDataWindow = new SearchDataWindow();
            searchDataWindow.Show();
        }
    }
}
