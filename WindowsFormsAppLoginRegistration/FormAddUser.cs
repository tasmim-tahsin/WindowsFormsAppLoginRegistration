using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppLoginRegistration
{
    public partial class FormAddUser : Form
    {
        private FormAdmin FormAdmin {  get; set; }
        public FormAddUser()
        {
            InitializeComponent();
        }
        public FormAddUser(FormAdmin formAdmin):this()
        {
            this.FormAdmin = formAdmin;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.FormAdmin.Show();
        }

        private void FormAddUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.FormAdmin.Show();
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtUsername.Clear();
            this.txtPassword.Clear();
            this.txtConfirmPassword.Clear();
            this.txtRole.Clear();
        }

        public bool IsExist()
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-A7UFOMU\SQLEXPRESS;Initial Catalog=LoginDatabase;Persist Security Info=True;User ID=sa;Password=tahsin1122");
            sqlcon.Open();
            string query = "select * from UserInformation where UserName = '" + this.txtUsername.Text + "';";
            SqlCommand sqlCommand = new SqlCommand(query, sqlcon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            if (ds.Tables[0].Rows.Count==1)
            {
                
                sqlcon.Close();
                return true;
            }
            else 
            { 
                sqlcon.Close();
                return false;
            }
        }

        public void AddUser()
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-A7UFOMU\SQLEXPRESS;Initial Catalog=LoginDatabase;Persist Security Info=True;User ID=sa;Password=tahsin1122");
                sqlcon.Open();
                string query = "insert into UserInformation values (@Username,@Password,@Role);";
                SqlCommand sqlCommand = new SqlCommand(query, sqlcon);
                sqlCommand.Parameters.AddWithValue("@UserName", this.txtUsername.Text);
                sqlCommand.Parameters.AddWithValue("@Password", this.txtPassword.Text);
                sqlCommand.Parameters.AddWithValue("@Role", this.txtRole.Text);
                sqlCommand.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch {
                Exception ex = new Exception();
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if(this.IsExist())
            {
                MessageBox.Show("User already exist");
            }
            else
            {
                if(this.txtUsername.Text =="" || this.txtPassword.Text  =="" || this.txtConfirmPassword.Text == "" || this.txtConfirmPassword.Text != this.txtPassword.Text ||this.txtRole.Text =="")
                {
                    MessageBox.Show("Please Fill all the values");
                }
                else
                {
                    this.AddUser();
                    MessageBox.Show("User added Successfully");
                    this.txtUsername.Clear();
                    this.txtPassword.Clear();
                    this.txtConfirmPassword.Clear();
                    this.txtRole.Clear();
                }
                
            }
        }
    }
}
