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
    public partial class cusreport : Form
    {
        public cusreport()
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

        private void cusreport_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void replink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            finreport finreport = new finreport();
            finreport.Show();
            this.Hide();
        }

        private void fdlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void hislink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void erep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            empreport empreport = new empreport();
            empreport.Show();
            this.Hide();
        }

        private void srep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            supreport supreport = new supreport();
            supreport.Show();
            this.Hide();
        }

       
        

        private void cdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
