using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farm
{
    public partial class fmsuprep : Form
    {
        public fmsuprep()
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
            sid.Clear();
            name.Clear();
            note.Clear();
        }

        private void sv_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sid.Text) ||
                string.IsNullOrWhiteSpace(name.Text) ||
                string.IsNullOrWhiteSpace(note.Text))
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }

            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "INSERT INTO SupplierData (SupplierID, Name, Date, Description) " +
                             "VALUES (@bid, @rate, @date, @quan)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@bid", sid.Text);
                    cmd.Parameters.AddWithValue("@rate", name.Text);
                    cmd.Parameters.AddWithValue("@date", datepick.Value);
                    cmd.Parameters.AddWithValue("@quan", note.Text);

                    // Execute query
                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Supplier data saved successfully!");
                }
            }
        }

        private void gen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sid.Text) ||
      string.IsNullOrWhiteSpace(name.Text) ||
      string.IsNullOrWhiteSpace(note.Text))
            {
                MessageBox.Show("Please fill out all fields before generating the report.");
                return;
            }

  
            DataTable supplierData = GetSupplierDataBySupID(sid.Text);

            if (supplierData.Rows.Count == 0)
            {
                MessageBox.Show("No data found for the provided Supplier ID.");
                return;
            }

            LocalReport report = new LocalReport();
            report.ReportPath = Path.Combine(Application.StartupPath, @"C:\Users\bimsa\Desktop\app\Farm\SupplierReport.rdlc");
            report.DataSources.Add(new ReportDataSource("SupplierData", supplierData));

            byte[] pdfBytes = report.Render("PDF");

           
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "INSERT INTO SupplierReport (SupplierID, Name, Date, Description, GeneratedDate) " +
                             "VALUES (@bid, @rate, @date, @quan, @gdate)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@bid", sid.Text);
                    cmd.Parameters.AddWithValue("@rate", name.Text);
                    cmd.Parameters.AddWithValue("@date", datepick.Value);
                    cmd.Parameters.AddWithValue("@quan", note.Text);
                    cmd.Parameters.AddWithValue("@gdate", DateTime.Now);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Report generated successfully!");

                    LoadGeneratedReports();
                }
            }
        }
        private DataTable GetSupplierDataBySupID(string SupplierID)
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "SELECT * FROM SupplierData WHERE SupplierID = @supID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@supID", SupplierID);
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
                string sql = "SELECT SupplierID, Name, Description, Date, GeneratedDate  FROM SupplierReport";
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

        private void fmsuprep_Load(object sender, EventArgs e)
        {
            LoadGeneratedReports();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                string SupplierID = dgv.Rows[e.RowIndex].Cells["SupplierID"].Value.ToString();


                DataTable reportData = GetReportDataBySupID(SupplierID);

                if (reportData.Rows.Count > 0)
                {
                    SupRepView reportviewform = new SupRepView();
                    reportviewform.reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, @"C:\Users\bimsa\Desktop\app\Farm\SupplierReport.rdlc");
                    reportviewform.reportViewer1.LocalReport.DataSources.Clear();
                    reportviewform.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("SupplierData", reportData));

                    reportviewform.reportViewer1.RefreshReport();

                    reportviewform.reportViewer1.ZoomMode = ZoomMode.PageWidth;

                    reportviewform.Show();

                }
                else
                {
                    MessageBox.Show("No report found for the selected Batch ID.");
                }
            }
        }
        private DataTable GetReportDataBySupID(string SupplierID)
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "SELECT * FROM SupplierReport WHERE SupplierID = @BatchID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@BatchID", SupplierID);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        private void feed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmfedcun fmfedcun = new fmfedcun();
            fmfedcun.Show();
            this.Hide();
        }

        private void bred_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmbredrep fmbredrep = new fmbredrep();
            fmbredrep.Show();
            this.Hide();
        }
    }
}
