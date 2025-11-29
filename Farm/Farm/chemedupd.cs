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
    public partial class chemedupd : Form
    {
        public chemedupd()
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

        private void invup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chemedadd chemedadd = new chemedadd();
            chemedadd.Show();
            this.Hide();
        }

        private void view_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chemedinv chemedinv = new chemedinv();
            chemedinv.Show();
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

        private void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mid.Text) || string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(num.Text) || string.IsNullOrWhiteSpace(datepick.Text))
            {
                MessageBox.Show("Fill Out All The Fields!!!");
                return;
            }
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "INSERT INTO MedInventory (MedicationID, Name, Quantity, Date) VALUES (@mid, @name, @qun, @date)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@mid", this.mid.Text);
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

        private void clear_Click(object sender, EventArgs e)
        {
            mid.Text = "";
            name.Text = "";
            num.Text = "";
            datepick.Text = "";

            mid.Focus();
        }
    }
}
