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
    public partial class fmmonatt : Form
    {
        public fmmonatt()
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

        private void Loaddata(String date, string employeeID)
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            string sql;
            if (!string.IsNullOrEmpty(employeeID))
            {
                sql = "SELECT * FROM AttTable WHERE Date = @date AND EmpID = @eid";
            }
            else
            {
                sql = "SELECT * FROM AttTable WHERE Date = @date";
            }
            SqlConnection con = new SqlConnection(cs);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@date", date);

                if (!string.IsNullOrEmpty(employeeID))
                {
                    da.SelectCommand.Parameters.AddWithValue("@eid", employeeID);
                }

                DataTable dt = new DataTable();
                da.Fill(dt);

                adgv.DataSource = dt;
                adgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occured: {ex.Message}");
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            string date = datepick.Value.ToString();
            string employeeID = eid.Text.Trim();

            if(string.IsNullOrEmpty(employeeID) )
            {
                MessageBox.Show("Please Enter a Employee ID!");
            }

            Loaddata(date, employeeID);
        }

        private void fmmonatt_Load(object sender, EventArgs e)
        {
            string date= datepick.Value.ToString();
            Loaddata(date, null);
        }
    }
}
