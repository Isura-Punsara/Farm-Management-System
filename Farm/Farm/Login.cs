using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(128, 211, 211, 211);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.Transparent;
        }
        private void showDirector()
        {
            dirfinrep dirfinrep = new dirfinrep();
            dirfinrep.Show();
            this.Hide();
        }
        private void showCEO()
        {
            finadata finadata = new finadata();
            finadata.Show();
            this.Hide();
        }    
        private void showFarmManager()
        {
            fmmonatt fmmonatt = new fmmonatt();
            fmmonatt.Show();
            this.Hide();
        }
        private void showVet()
        {
            vetvetvis vetvetvis = new vetvetvis();
            vetvetvis.Show();
            this.Hide();
        }
        private void showchem()
        {
            cheenvrec cheenvrec = new cheenvrec();
            cheenvrec.Show();
            this.Hide();
        }
        private void showsuper()
        {
            suptask supatten = new suptask();
            supatten.Show();
            this.Hide();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            if (string.IsNullOrWhiteSpace(usertb.Text) || string.IsNullOrWhiteSpace(pwtb.Text))
            {
                MessageBox.Show("Fill Out All The Fields!!!");
                return;
            }

            try
            {
                con.Open();
                string sql = "SELECT Role FROM UserTable WHERE UserID = @uid AND Password = @pw";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@uid", this.usertb.Text);
                cmd.Parameters.AddWithValue("@pw", this.pwtb.Text);

                object ob = cmd.ExecuteScalar();

                if (ob != null)
                {
                    string role = ob.ToString();
                    MessageBox.Show($"Login Successful! Welcome, {role}!");

                    switch (role)
                    {
                        case "Director":
                            showDirector();
                            break;

                        case "CEO":
                            showCEO();
                            break;

                        case "Farm Manager":
                            showFarmManager();
                            break;

                        case "Veteranarian":
                            showVet();
                            break;

                        case "Chemist":
                            showchem();
                            break;

                        case "Supervisor":
                            showsuper();
                            break;

                        default:
                            MessageBox.Show("Role Not Recognized.");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid UserID or Password. Login Failed!!!");
                }

            }
            catch(SqlException ex)
            {
                MessageBox.Show("Database Error" +ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unexpected Error Ocurred"+ ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
