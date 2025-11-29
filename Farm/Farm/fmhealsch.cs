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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Farm
{
    public partial class fmhealsch : Form
    {
        public fmhealsch()
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            panel7.BackColor = Color.Transparent;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            panel6.BackColor = Color.Transparent;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmaniprof fmaniprof = new fmaniprof();
            fmaniprof.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmhealsch fmhealsch = new fmhealsch();
            fmhealsch.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fminvrep fminvrep = new fminvrep();
            fminvrep.Show();
            this.Hide();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fminv fminv = new fminv();
            fminv.Show();
            this.Hide();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmtsk fmtsk = new fmtsk();
            fmtsk.Show();
            this.Hide();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fminc fminc = new fminc();
            fminc.Show();
            this.Hide();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmempprof fmempprof = new fmempprof();
            fmempprof.Show();
            this.Hide();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmmonatt fmmonatt = new fmmonatt();
            fmmonatt.Show();
            this.Hide();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmsupprof fmsupprof = new fmsupprof();
            fmsupprof.Show();
            this.Hide();
        }

        private void schdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = schdgv.Rows[e.RowIndex];

                sid.Text = row.Cells["SchduleID"].Value.ToString();
                aid.Text = row.Cells["AnimalID"].Value.ToString();
                bid.Text = row.Cells["BatchID"].Value.ToString();
                type.Text = row.Cells["Type"].Value.ToString();

            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            sid.Clear();
            aid.Clear(); 
            bid.Clear(); 
            type.Clear();
        }

        private void schedule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sid.Text) || string.IsNullOrWhiteSpace(aid.Text) || string.IsNullOrWhiteSpace(bid.Text) || string.IsNullOrWhiteSpace(type.Text))
            {
                MessageBox.Show("Fill Out All The Fields!");
                return;
            }

            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();

                string sql = "INSERT INTO HealSchedule (SchduleID, AnimalID, BatchID, Type) VALUES (@sid, @aid, @bid, @type)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@sid", this.sid.Text);
                cmd.Parameters.AddWithValue("@aid", this.aid.Text);
                cmd.Parameters.AddWithValue("@bid", this.bid.Text);
                cmd.Parameters.AddWithValue("@type", this.type.Text);

                int ret = cmd.ExecuteNonQuery();
                MessageBox.Show(ret > 0 ? "Schedule Created Successfully!" : "Failed to Create the Schedule!");
                LoadData();
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

        private void LoadData()
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "SELECT * FROM HealSchedule";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                schdgv.DataSource = dt;

                schdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sid.Text) || string.IsNullOrWhiteSpace(aid.Text) || string.IsNullOrWhiteSpace(bid.Text) || string.IsNullOrWhiteSpace(type.Text))
            {
                MessageBox.Show("Please fill out all fields before updating.");
                return;
            }

            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "UPDATE HealSchedule SET AnimalID = @aid, BatchID = @bid WHERE SchduleID = @sid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@aid", aid.Text);
                cmd.Parameters.AddWithValue("@bid", bid.Text);
                cmd.Parameters.AddWithValue("@sid",sid.Text);


                int ret = cmd.ExecuteNonQuery();
                MessageBox.Show(ret > 0 ? "Record updated successfully!" : "No record found to update.");
                LoadData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sid.Text) || string.IsNullOrWhiteSpace(aid.Text) || string.IsNullOrWhiteSpace(bid.Text) || string.IsNullOrWhiteSpace(type.Text))
            {
                MessageBox.Show("Enter Both Animal and Batch IDs to delete.");
                return;
            }

            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "DELETE FROM HealSchedule WHERE SchduleID = @sid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@sid", sid.Text);

                int ret = cmd.ExecuteNonQuery();
                MessageBox.Show(ret > 0 ? "Record Deleted Successfully!" : "No record found to delete.");
                LoadData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void fmhealsch_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void feed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmfedsch fmfedsch = new fmfedsch();
            fmfedsch.Show();
            this.Hide();
        }
    }
}
