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
    public partial class empreport : Form
    {
        public empreport()
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

        private void replink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            finreport finreport = new finreport();
            finreport.Show();
            this.Hide();
        }

        private void finlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            finadata finadata = new finadata();
            finadata.Show();
            this.Hide();
        }

        private void costs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fcosts fcosts = new fcosts();
            fcosts.Show();
            this.Hide();
        }

        private void hdlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hisdata hisdata = new hisdata();
            hisdata.Show();
            this.Hide();
        }

        private void uclink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }

        private void frep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            finreport finreport = new finreport();
            finreport.Show();
            this.Hide();
        }

        private void srep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            supreport supreport = new supreport();
            supreport.Show();
            this.Hide();
        }

        private void crep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cusreport cusreport = new cusreport();
            cusreport.Show();
            this.Hide();
        }

        private void loadbtn_Click(object sender, EventArgs e)
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            if (frdate.Value > todate.Value)
            {
                MessageBox.Show("Start Date Can't be Later than End Date!!!");
                return;
            }

            try
            {
                con.Open();

                string sql = "SELECT ReportID, Name, Date FROM EmpRepCEO WHERE Date BETWEEN @frdate AND @todate ORDER BY Date";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@frdate", frdate.Value.Date);
                cmd.Parameters.AddWithValue("@todate", todate.Value.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                edgv.DataSource = dt;

                edgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Reports Found From the Selected Date Range!!!");
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
        private void loaddata()
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "SELECT ReportID, Name, Date FROM EmpRepCEO";
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                edgv.DataSource = dt;
                edgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void empreport_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void edgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
