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
    public partial class vetvac : Form
    {
        public vetvac()
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
        private void loaddata()
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "SELECT * FROM VacTable";

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

        private void vetvac_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void clr_Click(object sender, EventArgs e)
        {
            bid.Clear();
            vid.Clear();
            note.Clear();
        }

        private void sche_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(bid.Text) || string.IsNullOrWhiteSpace(vid.Text) || string.IsNullOrWhiteSpace(note.Text))
            {
                MessageBox.Show("Fill Out All The Fields!");
                return;
            }

            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();

                string sql = "INSERT INTO VacTable (BatchID, VacID, Date, Description) VALUES (@bid, @vid, @date, @note)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@bid", this.bid.Text);
                cmd.Parameters.AddWithValue("@vid", this.vid.Text);
                cmd.Parameters.AddWithValue("@date", this.datepick.Value.Date);
                cmd.Parameters.AddWithValue("@note", note.Text);

                int ret = cmd.ExecuteNonQuery();
                MessageBox.Show(ret > 0 ? "Record Created Successfully!" : "Failed to Create the Record!");
                loaddata();

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

        private void ani_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vetanihealcs vethealch = new vetanihealcs();
            vethealch.Show();
            this.Hide();
        }

        private void treat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vettreat vettreat = new vettreat();
            vettreat.Show();
            this.Hide();
        }
    }
}
