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
    public partial class Viewusers : Form
    {
        public Viewusers()
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

        private void addusr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }

        private void upusr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateusers updateusers = new updateusers();
            updateusers.Show();
            this.Hide();
        }

        private void rep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            finreport finreport = new finreport();
            finreport.Show();
            this.Hide();
        }

        private void findata_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            finadata finadata = new finadata();
            finadata.Show();
            this.Hide();
        }

        private void costs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void hisdata_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hisdata hisdata = new hisdata();    
            hisdata.Show();
            this.Hide();
        }

        private void uc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }
        private void LoadData()
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "SELECT * FROM UserTable";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                userview.DataSource = dt;

                userview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void Viewusers_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
