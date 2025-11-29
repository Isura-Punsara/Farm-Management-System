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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor =Color.FromArgb(128, 211, 211, 211);
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

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {
            panel6.BackColor = Color.Transparent;
        }

        private void usersigntb_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(uidtb.Text) || string.IsNullOrWhiteSpace(nametb.Text) || string.IsNullOrWhiteSpace(addtb.Text) || urcb.SelectedItem == null
                || string.IsNullOrWhiteSpace(pwtb.Text))
            {
                MessageBox.Show("Fill Out All The Fields!");
                return;
            }

            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();

                string sql = "INSERT INTO UserTable (UserID, Name, Phone, Address, Password, Role) VALUES (@uid, @name, @phone, @add, @pw, @role)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@uid", this.uidtb.Text);
                cmd.Parameters.AddWithValue("@name", this.nametb.Text);
                cmd.Parameters.AddWithValue("@phone", this.phonetb.Text);
                cmd.Parameters.AddWithValue("@add", this.addtb.Text);
                cmd.Parameters.AddWithValue("@pw", this.pwtb.Text);
                cmd.Parameters.AddWithValue("@role", this.urcb.SelectedItem);

                int ret = cmd.ExecuteNonQuery();
                MessageBox.Show(ret > 0 ? "User Added Successfully!" : "Failed To Add User!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error"+ ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error Occured"+ ex.Message);
            }
            finally
            {
                con.Close();
            }


        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            uidtb.Text = "";
            nametb.Text = "";
            phonetb.Text = "";
            addtb.Text = "";
            pwtb.Text = "";
            urcb.SelectedItem = -1;

            uidtb.Focus();
        }

        private void CEOusrviw_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Viewusers viewusers = new Viewusers();
            viewusers.Show();
            this.Hide();
        }

        private void ceoupusr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateusers updateusers = new updateusers();
            updateusers.Show();
            this.Hide();
        }

        private void rep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            finreport finreport = new finreport();
            finreport.Show();
            this.Hide();
        }

        private void findat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            finadata finadata = new finadata();
            finadata.Show();
            this.Hide();
        }

        private void moncos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void hisdat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hisdata hisdata = new hisdata();
            hisdata.Show();
            this.Hide();
        }

        private void uc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }
    }
}
