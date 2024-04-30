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
    public partial class Seller : Form
    {
        private FormLogin Fl;
        public Seller()
        {
            InitializeComponent();
        }
        public Seller(string name, FormLogin fl): this()
        {
            this.lblSeller.Text += name;
            this.Fl = fl;

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Fl.Show();

        }

        private void Seller_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Fl.Show();
        }
    }
}
