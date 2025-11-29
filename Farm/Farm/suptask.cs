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
    public partial class suptask : Form
    {
        public suptask()
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

        private void clr_Click(object sender, EventArgs e)
        {
            tid.Clear();
            eid.Clear();
            note.Clear();
        }

        private void sv_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tid.Text) || string.IsNullOrWhiteSpace(eid.Text) || string.IsNullOrWhiteSpace(note.Text))
            {
                MessageBox.Show("Fill Out All The Fields!");
                return;
            }

            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();

                string sql = "INSERT INTO TaskTable (TaskID, EmployeeID, Date, Status, Note) VALUES (@tid, @eid, @date, @stat, @note)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@tid", this.tid.Text);
                cmd.Parameters.AddWithValue("@eid", this.eid.Text);
                cmd.Parameters.AddWithValue("@stat", this.stat.Text);
                cmd.Parameters.AddWithValue("@date", this.datepick.Value.Date);
                cmd.Parameters.AddWithValue("@note", note.Text);

                int ret = cmd.ExecuteNonQuery();
                MessageBox.Show(ret > 0 ? "Task Created Successfully!" : "Failed to Create the Task!");
               
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

        private void crt_Click(object sender, EventArgs e)
        {

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

        private void vt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            supupdtask supupdtask = new supupdtask();   
            supupdtask.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            supatten supatten = new supatten();
            supatten.Show();
            this.Hide();
        }
    }
}
