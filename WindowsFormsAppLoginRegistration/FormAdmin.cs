using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppLoginRegistration
{
    public partial class FormAdmin : Form
    {
        private FormLogin Fl;
        public FormAdmin()
        {
            InitializeComponent();
        }
        public FormAdmin(string name, FormLogin fl):this()
        {
            this.lblAdmin.Text += name.ToUpper();
            this.Fl = fl;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Fl.Show();

        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Fl.Show();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormAddUser(this).Show();
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormRemoveUser(this).Show();
        }
    }
}
