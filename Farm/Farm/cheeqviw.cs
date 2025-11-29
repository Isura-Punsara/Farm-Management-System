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
    public partial class cheeqviw : Form
    {
        public cheeqviw()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void equp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheequp cheequp = new cheequp();
            cheequp.Show();
            this.Hide();
        }

        private void eqadd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheeqad cheeqad = new cheeqad();
            cheeqad.Show();
            this.Hide();
        }

        private void rep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chereps cheenvrep = new chereps();
            cheenvrep.Show();
            this.Hide();
        }

        private void env_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheenvcon cheenvcon = new cheenvcon();
            cheenvcon.Show();
            this.Hide();
        }

        private void med_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chemedupd chemedupd = new chemedupd();
            chemedupd.Show();
            this.Hide();
        }

        private void eq_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheeqad cheeqad = new cheeqad();
            cheeqad.Show();
            this.Hide();
        }

        private void loaddata()
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "SELECT * FROM EqInventory";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                eqdgv.DataSource = dt;

                eqdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void cheeqviw_Load(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
