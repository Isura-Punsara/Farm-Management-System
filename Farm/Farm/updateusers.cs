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

namespace Farm
{
    public partial class updateusers : Form
    {
        public updateusers()
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            panel4.BackColor = Color.FromArgb(128, 211, 211, 211);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            panel5.BackColor = Color.Transparent;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            panel6.BackColor = Color.Transparent;
        }

        private void viwusr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Viewusers viewusers = new Viewusers();
            viewusers.Show();
            this.Hide();
        }

        private void addusr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }

        private void rep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            finreport finreport = new finreport();
            finreport.Show();
            this.Hide();
        }

        private void findata_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            finadata finadata = new finadata();
            finadata.Show();
            this.Hide();
        }

        private void costs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void hisdata_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hisdata hisdata = new hisdata();    
            hisdata.Show();
            this.Hide();
        }

        private void uc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup uc = new Signup();
            uc.Show();
            this.Hide();
        }

        private void loadusr_Click(object sender, EventArgs e)
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            if (string.IsNullOrWhiteSpace(loaduidtb.Text))
            {
                MessageBox.Show("Enter Valid User ID!");
                return;
            }

            try
            {
                con.Open();
                string sql = "SELECT * FROM UserTable WHERE UserID = @uid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@uid", this.loaduidtb.Text);

                SqlDataReader readr = cmd.ExecuteReader();

                if (readr.Read())
                {
                    uidtb.Text = readr["UserID"].ToString();
                    nametb.Text = readr["Name"].ToString();
                    addtb.Text = readr["Address"].ToString();
                    pntb.Text = readr["Phone"].ToString();
                    urcb.Text = readr["Role"].ToString();
                    pwtb.Text = readr["Password"].ToString();

                }
                else
                {
                    MessageBox.Show("No User Found With Given ID!");
                }
                readr.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Database Error" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error Occured" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void upd_Click(object sender, EventArgs e)
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            if (string.IsNullOrWhiteSpace(this.uidtb.Text) || string.IsNullOrWhiteSpace(this.nametb.Text) || string.IsNullOrWhiteSpace(this.addtb.Text) ||
                string.IsNullOrWhiteSpace(this.pntb.Text) || urcb.SelectedItem == null || string.IsNullOrWhiteSpace(this.pwtb.Text))
            {
                MessageBox.Show("Fill Out All The Fields!!!");
                return;
            }
            try
            {
                con.Open();
                string sql = "UPDATE UserTable SET Name = @name, Address = @add, Phone = @pn, Role = @role, Password = @pw WHERE UserID = @uid";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@uid", this.uidtb.Text);
                cmd.Parameters.AddWithValue("@name", this.nametb.Text);
                cmd.Parameters.AddWithValue("@add", this.addtb.Text);
                cmd.Parameters.AddWithValue("@pn", this.pntb.Text);
                cmd.Parameters.AddWithValue("@role", this.urcb.Text);
                cmd.Parameters.AddWithValue("@pw", this.pwtb.Text);

                int affectedrows = cmd.ExecuteNonQuery();

                if (affectedrows > 0)
                {
                    MessageBox.Show("User Details Updated Successfull!!");
                }
                else
                {
                    MessageBox.Show("Failed To Update User Details!!");
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Database Error" +ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unexpected Error Occured" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void del_Click(object sender, EventArgs e)
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            if (string.IsNullOrWhiteSpace(this.loaduidtb.Text))
            {
                MessageBox.Show("Please Enter a !!!");
                return;
            }
            try
            {
                con.Open();
                string sql = "DELETE FROM UserTable WHERE UserID = @uid";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@uid", this.uidtb.Text);

                int affectedrows = cmd.ExecuteNonQuery();

                if (affectedrows > 0)
                {
                    MessageBox.Show("User Deleted Successfull!!");
                    Cleartb();
                }
                else
                {
                    MessageBox.Show("Failed To Delete User!!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error Occured" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void Cleartb()
        {
            uidtb.Text = "";
            nametb.Text = "";
            addtb.Text = "";
            pntb.Text = "";
            urcb.SelectedIndex = -1;
            pwtb.Text = "";
            uidtb.Focus();
        }

        private void updateusers_Load(object sender, EventArgs e)
        {

        }
    }
}
