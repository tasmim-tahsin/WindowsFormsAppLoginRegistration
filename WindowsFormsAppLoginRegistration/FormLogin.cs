using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Reflection;

namespace WindowsFormsAppLoginRegistration
{
    public partial class FormLogin : Form
    {
        private DataAccess Da { get; set; }
        public FormLogin()
        {
            InitializeComponent();
            this.Da = new DataAccess();

        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            /*SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-A7UFOMU\SQLEXPRESS;Initial Catalog=LoginDatabase;Persist Security Info=True;User ID=sa;Password=tahsin1122");
            sqlcon.Open();
            string query = "select * from UserInformation where UserName = '"+this.txtUsername.Text+"' and Password = '"+this.txtPassword.Text+"';" ;
            SqlCommand sqlCommand = new SqlCommand(query,sqlcon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            */
            try
            {
                var sql = "select * from UserInformation where UserName = '" + this.txtUsername.Text + "' and Password = '" + this.txtPassword.Text + "';";
                var ds = this.Da.ExecuteQuery(sql);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    if (ds.Tables[0].Rows[0][2].ToString() == "admin")
                    {
                        this.Hide();
                        new FormAdmin(this.txtUsername.Text, this).Show();



                    }
                    else if (ds.Tables[0].Rows[0][2].ToString() == "seller")
                    {
                        this.Hide();
                        new Seller(this.txtUsername.Text, this).Show();

                    }
                }
                else
                {
                    MessageBox.Show("Invalid User");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            



            /*int index = 0;
            bool info = false;
            while (index<ds.Tables[0].Rows.Count)
            {
                
                if (this.txtUsername.Text == ds.Tables[0].Rows[index][0].ToString() && this.txtPassword.Text == ds.Tables[0].Rows[index][1].ToString())
                {
                    info = true;
                    //MessageBox.Show("valid User");

                    if (ds.Tables[0].Rows[index][2].ToString() == "admin")
                    {
                        this.Hide();
                        new FormAdmin(this.txtUsername.Text,this).Show();
                        break;
                        
                        
                    }
                    else if(ds.Tables[0].Rows[index][2].ToString() == "seller")
                    {
                        this.Hide();
                        new Seller(this.txtUsername.Text,this).Show();
                        break;
                        
                    }
                        
                    
                }
                
                index++;
            }
            if (!info)
            {
                MessageBox.Show("Invalid User");
            }
            */

            
            

            //sqlcon.Close();

        }

        private void chkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkBoxShowPassword.Checked)
            {
                this.txtPassword.UseSystemPasswordChar = false;
            }
            else 
            {
                this.txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

        }
    }
}
