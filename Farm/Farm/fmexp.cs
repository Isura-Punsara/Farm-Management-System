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
    public partial class fmexp : Form
    {
        public fmexp()
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

        private void inc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fminc fminc = new fminc();
            fminc.Show();
            this.Hide();
        }

        private void prof_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmprof fmprof = new fmprof();
            fmprof.Show();
            this.Hide();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void insertExpenses()
        {
            if (string.IsNullOrWhiteSpace(fcost.Text) || string.IsNullOrWhiteSpace(vcost.Text) || string.IsNullOrWhiteSpace(other.Text) || datepick.Value == null)
            {
                MessageBox.Show("Fill Out All the Fields!!!");
                return;
            }

            int fixedc = Convert.ToInt32(fcost.Text);
            int Vari = Convert.ToInt32(vcost.Text);
            int otherc = Convert.ToInt32(other.Text);
            DateTime expensedate = datepick.Value.Date;

            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "INSERT INTO ExpTable (FixedCosts, VariableCosts, Other, Date) VALUES (@fc, @vc, @oc, @date)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@fc", fixedc);
                cmd.Parameters.AddWithValue("@vc", Vari );
                cmd.Parameters.AddWithValue("@oc",otherc );
                cmd.Parameters.AddWithValue("@date", expensedate);

                int rowsaff = cmd.ExecuteNonQuery();
                if (rowsaff > 0)
                {
                    MessageBox.Show("Record inserted Successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to inser Record!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void calandsave()
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();

                string totsql = "SELECT SUM(FixedCosts + VariableCosts + Other) FROM ExpTable WHERE CAST (Date AS DATE) = @date";
                SqlCommand cmd = new SqlCommand(totsql, con);

                cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);

                object result = cmd.ExecuteScalar();

                decimal expenses = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                string insertsql = "INSERT INTO TransTable (Exp, Date) VALUES (@totalExpenses, @date)";

                SqlCommand cmdinsert = new SqlCommand(insertsql, con);
                cmdinsert.Parameters.AddWithValue("@totalExpenses", expenses);
                cmdinsert.Parameters.AddWithValue("@date", DateTime.Now.Date);

                int affected = cmdinsert.ExecuteNonQuery();

                if(affected > 0)
                {
                    MessageBox.Show("Saved SuccessFully!");
                }
                else
                {
                    MessageBox.Show("Failed to Save Data!");
                }

            } 
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error" + ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unexpected Error" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void cal_Click(object sender, EventArgs e)
        {
            insertExpenses();
            loaddata();
            calandsave();
        }

        private void loaddata()
        {
            string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                string sql = "SELECT * FROM ExpTable";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                expdgv.DataSource = dt;

                expdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void fmexp_Load(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
