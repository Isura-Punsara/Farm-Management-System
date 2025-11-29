using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farm
{
    public partial class cheeqad : Form
    {
        public cheeqad()
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

        private void equpd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheequp cheequp = new cheequp();
            cheequp.Show();
            this.Hide();
        }

        private void view_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheeqviw cheeqviw = new cheeqviw();
            cheeqviw.Show();
            this.Hide();
        }

        private void rep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chereps cheenvrep = new chereps();
            cheenvrep.Show();
            this.Hide();
        }

        private void env_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheenvcon cheenvcon = new cheenvcon();
            cheenvcon.Show();
            this.Hide();
        }

        private void med_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chemedupd chemedupd = new chemedupd();
            chemedupd.Show();
            this.Hide();
        }

        private void eq_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheeqad cheeqad = new cheeqad();
            cheeqad.Show();
            this.Hide();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(eid.Text) || string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(num.Text) || string.IsNullOrWhiteSpace(datepick.Text))
            {
                MessageBox.Show("Fill Out All The Fields!!!");
                return;
            }
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "INSERT INTO EqInventory (EquipmentID, Name, Quantity, Date) VALUES (@eid, @name, @qun, @date)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@eid", this.eid.Text);
                cmd.Parameters.AddWithValue("@name", this.name.Text);
                cmd.Parameters.AddWithValue("@qun", this.num.Value);
                cmd.Parameters.AddWithValue("@date", this.datepick.Value);

                int ret = cmd.ExecuteNonQuery();
                MessageBox.Show(ret > 0 ? "Data Added Successfully!" : "Failed To Add Data!");

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

        private void clearbtn_Click(object sender, EventArgs e)
        {
            eid.Text = "";
            name.Text = "";
            num.Text = "";
            datepick.Text = "";

            eid.Focus();
        }
    }
}
