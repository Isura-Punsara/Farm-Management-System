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
using System.Xml.Serialization;

namespace Farm
{
    public partial class vetbredrep : Form
    {
        public vetbredrep()
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

        private void heal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vethealrep vethealrep = new vethealrep();
            vethealrep.Show();
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

        private void sv_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(bid.Text) ||
                 string.IsNullOrWhiteSpace(quan.Text) ||
                 string.IsNullOrWhiteSpace(rate.Text))
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }

            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "INSERT INTO BreedingData (BatchID, SuccessRate, Date, Quantity) " +
                             "VALUES (@bid, @rate, @date, @quan)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@bid", bid.Text);
                    cmd.Parameters.AddWithValue("@rate", rate.Text);
                    cmd.Parameters.AddWithValue("@date", datepick.Value);
                    cmd.Parameters.AddWithValue("@quan", quan.Text);

                    // Execute query
                    con.Open();
                    cmd.ExecuteNonQuery();
                    

                    MessageBox.Show("Breeding data saved successfully!");
                }
            }
        }

        private void clr_Click(object sender, EventArgs e)
        {

            bid.Clear();
            rate.Clear();
            quan.Clear();
        }

       

        private void vetbredrep_Load(object sender, EventArgs e)
        {
            LoadGeneratedReports();
        }

        private void gen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(bid.Text) ||
      string.IsNullOrWhiteSpace(rate.Text) ||
      string.IsNullOrWhiteSpace(quan.Text))
            {
                MessageBox.Show("Please fill out all fields before generating the report.");
                return;
            }

            // Fetch the data from BreedingData table
            DataTable breedingData = GetBreedingDataByBatchID(bid.Text);

            if (breedingData.Rows.Count == 0)
            {
                MessageBox.Show("No data found for the provided Batch ID.");
                return;
            }

            // Create RDLC report
            LocalReport report = new LocalReport();
            report.ReportPath = Path.Combine(Application.StartupPath, @"C:\Users\CSN\source\repos\Farm\Breeding Report.rdlc");
            report.DataSources.Add(new ReportDataSource("BreedingData", breedingData));

            // Render the report as PDF
            byte[] pdfBytes = report.Render("PDF");

            // Save report metadata into BreedingReport table
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "INSERT INTO BreedingReport (BatchID, SuccessRate, Date, Quantity, GeneratedDate) " +
                             "VALUES (@bid, @rate, @date, @quan, @gdate)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@bid", bid.Text);
                    cmd.Parameters.AddWithValue("@rate", rate.Text);
                    cmd.Parameters.AddWithValue("@date", datepick.Value);
                    cmd.Parameters.AddWithValue("@quan", quan.Text);
                    cmd.Parameters.AddWithValue("@gdate", DateTime.Now);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Report generated successfully!");

                    LoadGeneratedReports();
                }
            }
        }
        private DataTable GetBreedingDataByBatchID(string batchID)
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "SELECT * FROM BreedingData WHERE BatchID = @BatchID";
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
                string sql = "SELECT BatchID, SuccessRate, Date, Quantity, GeneratedDate  FROM BreedingReport";
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
                    breedreportview reportviewform = new breedreportview();
                    reportviewform.reportview.LocalReport.ReportPath = Path.Combine(Application.StartupPath, @"C:\Users\CSN\source\repos\Farm\Breeding Report.rdlc");
                    reportviewform.reportview.LocalReport.DataSources.Clear();
                    reportviewform.reportview.LocalReport.DataSources.Add(new ReportDataSource("BreedingData", reportData));

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
                string sql = "SELECT * FROM BreedingReport WHERE BatchID = @BatchID";
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
    }
    
}
