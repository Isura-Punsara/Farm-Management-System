using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farm
{
    public partial class fmprof : Form
    {
        public fmprof()
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

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void exp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmexp fmexp = new fmexp();
            fmexp.Show();
            this.Hide();
        }

        private void inc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fminc fminc = new fminc();
            fminc.Show();
            this.Hide();
        }

        private void calprofit()
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();

                string incsql = "SELECT ISNULL(SUM(Inc), 0) FROM TransTable WHERE Date = @date";
                SqlCommand inccmd = new SqlCommand(incsql, con);
                inccmd.Parameters.AddWithValue("@date", datepick.Value.Date);
                object incresult = inccmd.ExecuteScalar();
                int totinc = incresult != DBNull.Value ? Convert.ToInt32(incresult) : 0;
                totinctb.Text = totinc.ToString();

                string expsql = "SELECT ISNULL(SUM(Exp), 0) FROM TransTable WHERE Date = @date";
                SqlCommand expcmd = new SqlCommand(expsql, con);
                expcmd.Parameters.AddWithValue("@date", datepick.Value.Date);
                object expresult = expcmd.ExecuteScalar();
                int totexp = expresult != DBNull.Value ? Convert.ToInt32(expresult) : 0;
                totexptb.Text = totexp.ToString();

                int profit = totinc - totexp;
                prof.Text = profit.ToString();

                string profsql = "INSERT INTO ProfTable (Profit, Date) VALUES (@prof, @date)";
                SqlCommand profitcmd = new SqlCommand(profsql, con);
                profitcmd.Parameters.AddWithValue("@prof", this.prof.Text);
                profitcmd.Parameters.AddWithValue("@date", datepick.Value.Date);

                profitcmd.ExecuteNonQuery();

                MessageBox.Show("Profit Calculated and Saved Successfully!");
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Database Error" + ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unexpected Error" + ex.Message);
            }
            finally
            {
                con.Close();
            }
            loadata();
        }

        private void loadata()
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();

                string sql = "SELECT * FROM ProfTable";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                profdgv.DataSource = dt;
                profdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error Loading Data:" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void cal_Click(object sender, EventArgs e)
        {
            calprofit();
        }

        private void fmprof_Load(object sender, EventArgs e)
        {
            loadata();
        }
    }
}
