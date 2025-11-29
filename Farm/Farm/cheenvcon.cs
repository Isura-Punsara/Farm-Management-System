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
    public partial class cheenvcon : Form
    {
        public cheenvcon()
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

        private void viewenvlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheenvrec cheenvrec = new cheenvrec();
            cheenvrec.Show();
            this.Hide();
        }

        private void replink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chereps cheenvrep = new chereps();
            cheenvrep.Show();
            this.Hide();
        }

        private void envlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheenvcon cheenvcon = new cheenvcon();
            cheenvcon.Show();
            this.Hide();
        }

        private void medilink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chemedupd chemedupd = new chemedupd();
            chemedupd.Show();
            this.Hide();
        }

        private void eqlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheeqad cheeqad = new cheeqad();
            cheeqad.Show();
            this.Hide();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sid.Text) || string.IsNullOrWhiteSpace(datepick.Text) || string.IsNullOrWhiteSpace(temp.Text) || string.IsNullOrWhiteSpace(hum.Text) ||
                string.IsNullOrWhiteSpace(lqual.Text) || string.IsNullOrWhiteSpace(wqual.Text) || string.IsNullOrWhiteSpace(aqual.Text))
            {
                MessageBox.Show("Fill Out All The Fields!!!");
                return;
            }
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "INSERT INTO EnvTable (SectorID, Date, Temperature, Humidity, LightQuality, WaterQuality, AirQuality) VALUES (@sid, @date, @temp, @hum, @l, @w, @a)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@sid", this.sid.Text);
                cmd.Parameters.AddWithValue("@date", this.datepick.Value);
                cmd.Parameters.AddWithValue("@temp", this.temp.Text);
                cmd.Parameters.AddWithValue("@hum", this.hum.Text);
                cmd.Parameters.AddWithValue("@l", this.lqual.Text);
                cmd.Parameters.AddWithValue("@w", this.wqual.Text);
                cmd.Parameters.AddWithValue("@a", this.aqual.Text);

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
            sid.Text = "";
            datepick.Text = "";
            temp.Text = "";
            hum.Text = "";
            lqual.Text = "";
            wqual.Text = "";
            aqual.Text = "";


            sid.Focus();
        }
    }
}
