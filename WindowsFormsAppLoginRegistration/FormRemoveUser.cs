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
    public partial class FormRemoveUser : Form
    {
        private FormAdmin FormAdmin { get; set; }
        private DataAccess Da { get; set; }
        public FormRemoveUser()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            this.PopulateGridView();
        }
        public FormRemoveUser(FormAdmin formAdmin) : this()
        {
            this.FormAdmin = formAdmin;
        }

        private void PopulateGridView()
        {
            string query = "select * from UserInformation";
            var ds = this.Da.ExecuteQuery(query);

            this.userGrid.DataSource = ds.Tables[0];
        }
        private void FormRemoveUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.FormAdmin.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.FormAdmin.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtUsername.Clear();
            
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

            if (ds.Tables[0].Rows.Count == 1)
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
        public void RemoveUser()
        {
            try
            {
                /*SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-A7UFOMU\SQLEXPRESS;Initial Catalog=LoginDatabase;Persist Security Info=True;User ID=sa;Password=tahsin1122");
                sqlcon.Open();
                string query = "delete from UserInformation where UserName=@UserName;";
                SqlCommand sqlCommand = new SqlCommand(query, sqlcon);
                sqlCommand.Parameters.AddWithValue("@UserName", username);
                sqlCommand.ExecuteNonQuery();
                sqlcon.Close();
                */
                var sql = "delete from UserInformation where UserName='"+this.txtUsername.Text+"';";
                this.Da.ExecuteQuery(sql);
            }
            catch
            {
                Exception ex = new Exception();
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if(this.IsExist())
            {
                this.RemoveUser();
                MessageBox.Show("User Removed");
                this.PopulateGridView();

            }
            else
                MessageBox.Show("No user found");

        }

        private void FormRemoveUser_Load(object sender, EventArgs e)
        {
            this.userGrid.AutoGenerateColumns=false;
        }
    }
}
