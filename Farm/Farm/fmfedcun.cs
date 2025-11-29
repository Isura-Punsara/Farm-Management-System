using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farm
{
    public partial class fmfedcun : Form
    {
        public fmfedcun()
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

        private void clr_Click(object sender, EventArgs e)
        {
            bid.Clear();
            sid.Clear();
            quan.Clear();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(bid.Text) ||
                string.IsNullOrWhiteSpace(quan.Text) ||
                string.IsNullOrWhiteSpace(sid.Text) || 
                ftype.SelectedItem == null)
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }

            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "INSERT INTO FeedingData (BatchID, SectorID, Date, Type, Quantity) " +
                             "VALUES (@bid, @sid, @date, @type, @quan)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@bid", bid.Text);
                    cmd.Parameters.AddWithValue("@sid", sid.Text);
                    cmd.Parameters.AddWithValue("@date", datepick.Value);
                    cmd.Parameters.AddWithValue("@type",ftype.SelectedItem);
                    cmd.Parameters.AddWithValue("@quan", quan.Text);

                    // Execute query
                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Feeding data saved successfully!");
                }
            }
        }

        private void gen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(bid.Text) ||
       string.IsNullOrWhiteSpace(sid.Text) ||
       string.IsNullOrWhiteSpace(quan.Text))
            {
                MessageBox.Show("Please fill out all fields before generating the report.");
                return;
            }

            // Fetch the data from BreedingData table
            DataTable FeedingData = GetFeedingDataByBatchID(bid.Text);

            if (FeedingData.Rows.Count == 0)
            {
                MessageBox.Show("No data found for the provided Batch ID.");
                return;
            }

            // Create RDLC report
            LocalReport report = new LocalReport();
            report.ReportPath = Path.Combine(Application.StartupPath, @"C:\Users\bimsa\Desktop\app\Farm\FeedingReport.rdlc");
            report.DataSources.Add(new ReportDataSource("FeedingData", FeedingData));

            // Render the report as PDF
            byte[] pdfBytes = report.Render("PDF");

            // Save report metadata into BreedingReport table
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "INSERT INTO FeedingReport (BatchID, SectorID, Date, Type, Quantity, GeneratedDate) " +
                             "VALUES (@bid, @sid, @date, @type, @quan, @gdate)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@bid", bid.Text);
                    cmd.Parameters.AddWithValue("@sid", sid.Text);
                    cmd.Parameters.AddWithValue("@date", datepick.Value);
                    cmd.Parameters.AddWithValue("@type",ftype.SelectedItem);
                    cmd.Parameters.AddWithValue("@quan", quan.Text);
                    cmd.Parameters.AddWithValue("@gdate", DateTime.Now);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Report generated successfully!");

                    LoadGeneratedReports();
                }
            }
        }
        private DataTable GetFeedingDataByBatchID(string batchID)
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "SELECT * FROM FeedingData WHERE BatchID = @BatchID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@BatchID", batchID);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        private void LoadGeneratedReports()
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "SELECT BatchID, SectorID, Date, Type, Quantity, GeneratedDate  FROM FeedingReport";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            dgv.DataSource = dt;
        }

        private void fmfedcun_Load(object sender, EventArgs e)
        {
            LoadGeneratedReports();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the BatchID of the selected row
                string batchID = dgv.Rows[e.RowIndex].Cells["BatchID"].Value.ToString();

                // Fetch the report data from the database for the selected BatchID
                DataTable reportData = GetReportDataByBatchID(batchID);

                if (reportData.Rows.Count > 0)
                {
                    feedreportview reportviewform = new feedreportview();
                    reportviewform.reportview.LocalReport.ReportPath = Path.Combine(Application.StartupPath, @"C:\Users\bimsa\Desktop\app\Farm\FeedingReport.rdlc");
                    reportviewform.reportview.LocalReport.DataSources.Clear();
                    reportviewform.reportview.LocalReport.DataSources.Add(new ReportDataSource("FeedingData", reportData));

                    reportviewform.reportview.RefreshReport();

                    reportviewform.reportview.ZoomMode = ZoomMode.PageWidth;

                    reportviewform.Show();

                }
                else
                {
                    MessageBox.Show("No report found for the selected Batch ID.");
                }
            }
        }
        private DataTable GetReportDataByBatchID(string batchID)
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "SELECT * FROM FeedingReport WHERE BatchID = @BatchID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@BatchID", batchID);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        private void bred_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmbredrep fmbredrep = new fmbredrep();
            fmbredrep.Show();
            this.Hide();
        }

        private void supp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmsuprep fmsuprep = new fmsuprep();
            fmsuprep.Show();
            this.Hide();
        }
    }
}
