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
    public partial class vethealch : Form
    {
        public vethealch()
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

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                sid.Text = row.Cells["ScheduleID"].Value.ToString();
                bid.Text = row.Cells["BatchID"].Value.ToString();
                datepick.Text = row.Cells["Date"].Value.ToString();
                note.Text = row.Cells["Description"].Value.ToString();

            }
        }

        private void clr_Click(object sender, EventArgs e)
        {
            sid.Clear();
            bid.Clear();
            note.Clear();
        }
        private void LoadData()
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "SELECT * FROM CheckTable";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv.DataSource = dt;

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        private void sch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sid.Text) || string.IsNullOrWhiteSpace(bid.Text) || string.IsNullOrWhiteSpace(note.Text))
            {
                MessageBox.Show("Fill Out All The Fields!");
                return;
            }

            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();

                string sql = "INSERT INTO CheckTable (ScheduleID, BatchID, Date, Description) VALUES (@sid, @bid, @date, @note)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@sid", this.sid.Text);
                cmd.Parameters.AddWithValue("@bid", this.bid.Text);
                cmd.Parameters.AddWithValue("@date", this.datepick.Value);
                cmd.Parameters.AddWithValue("@note", this.note.Text);

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

        private void upd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(sid.Text) || string.IsNullOrWhiteSpace(bid.Text) || string.IsNullOrWhiteSpace(note.Text))
            {
                MessageBox.Show("Please fill out all fields before updating.");
                return;
            }

            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "UPDATE CheckTable SET Date = @date, BatchID = @bid WHERE ScheduleID = @sid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@date", datepick.Value);
                cmd.Parameters.AddWithValue("@bid", bid.Text);
                cmd.Parameters.AddWithValue("@sid", sid.Text);


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

        private void del_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sid.Text) || string.IsNullOrWhiteSpace(bid.Text) ||  string.IsNullOrWhiteSpace(note.Text))
            {
                MessageBox.Show("Enter Both Animal and Batch IDs to delete.");
                return;
            }

            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "DELETE FROM CheckTable WHERE ScheduleID = @sid";
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

        private void vethealch_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void vis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vetvetvis vetvetvis = new vetvetvis();
            vetvetvis.Show();
            this.Hide();
        }

        private void bred_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vetbredsch vetbredsch = new vetbredsch();
            vetbredsch.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vethealch vetanihealcs = new vethealch();
            vetanihealcs.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vethealrep vethealrep = new vethealrep();
            vethealrep.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vetvac vetvac = new vetvac();
            vetvac.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vetmedinv vetmedinv = new vetmedinv();
            vetmedinv.Show();
            this.Hide();
        }
    }
}
