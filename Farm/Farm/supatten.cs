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
    public partial class supatten : Form
    {
        public supatten()
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
            suptask fmtsk = new suptask();
            fmtsk.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            supfedrep supfedrep = new supfedrep();
            supfedrep.Show();
            this.Hide();
        }

        private void initializeDataFridView()
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";

            DataGridViewComboBoxColumn attendance = new DataGridViewComboBoxColumn();
            attendance.HeaderText = "Attendance";
            attendance.Name = "Attendance";
            attendance.Items.Add("Present");
            attendance.Items.Add("Absent");
            adgv.Columns.Add(attendance);

            string sql = "SELECT EmpID, Name FROM EmpTable";
            SqlDataAdapter da = new SqlDataAdapter(sql, cs);
            DataTable dt = new DataTable();
            da.Fill(dt);

            adgv.DataSource = dt;
            adgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void adgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if(adgv.IsCurrentCellDirty)
            {
                adgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void adgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == adgv.Columns["Attendance"].Index)
            {
                string employeeID = adgv.Rows[e.RowIndex].Cells["EmpID"].Value.ToString();
                string attendancestats = adgv.Rows[e.RowIndex].Cells["Attendance"].Value.ToString();

                InsertDatabase( employeeID,attendancestats);
            }
        }

        private void InsertDatabase(string employeeID, string attendancestats)
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);
            try
            {
                con.Open();

                DateTime date = DateTime.Today;

                string sql = @"INSERT INTO AttTable (EmpID, Attendance, Date) VALUES (@eid, @att, @date)";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@eid", employeeID);
                cmd.Parameters.AddWithValue("@att", attendancestats);
                cmd.Parameters.AddWithValue("@date", date);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occured: {ex.Message}");
            }
            
        }

        private void supatten_Load(object sender, EventArgs e)
        {
            initializeDataFridView();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            supatten supatten = new supatten();
            supatten.Show();
            this.Hide();
        }
    }
}
