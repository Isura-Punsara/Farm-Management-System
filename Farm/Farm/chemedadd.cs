using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farm
{
    public partial class chemedadd : Form
    {
        public chemedadd()
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

        private void fetchdata()
        {
            string medicationID = mid.Text.Trim();
            if (!string.IsNullOrEmpty(medicationID))
            {
                string connectionString = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sql = "SELECT Quantity FROM MedInventory WHERE MedicationID = @MedicationID";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@MedicationID", medicationID);

                    try
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            num.Value = Convert.ToDecimal(reader["Quantity"]);
                        }
                        else
                        {
                            MessageBox.Show("Medication not found!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter Medication ID.");
            }
        }

        private void UpdateQuantity()
        {
            string medicationID = mid.Text.Trim();
            int enteredQuantity = (int)num.Value;
            string operation = rbget.Checked ? "Get" : "Store";

            if (!string.IsNullOrEmpty(medicationID) && enteredQuantity > 0)
            {
                string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string updateQuery = operation == "Get" ?
                        "UPDATE MedInventory SET Quantity = Quantity - @Quantity WHERE MedicationID = @MedicationID AND Quantity >= @Quantity" :
                        "UPDATE MedInventory SET Quantity = Quantity + @Quantity WHERE MedicationID = @MedicationID";

                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    cmd.Parameters.AddWithValue("@MedicationID", medicationID);
                    cmd.Parameters.AddWithValue("@Quantity", enteredQuantity);

                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Stock updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show(operation == "Get" ?
                                "Insufficient stock to retrieve the requested quantity." :
                                "Error updating stock. Please check the Equipment ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields correctly.");
            }
        }

        private void view_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chemedinv chemedinv = new chemedinv();
            chemedinv.Show();
            this.Hide();
        }

        private void add_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chemedupd chemedupd = new chemedupd();
            chemedupd.Show();
            this.Hide();
        }

        private void rep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chereps cherep = new chereps();
            cherep.Show();
            this.Hide();
        }

        private void env_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheenvrep cheenvrep = new cheenvrep();
            cheenvrep.Show();
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

        private void load_Click(object sender, EventArgs e)
        {
            fetchdata();
        }

        private void save_Click(object sender, EventArgs e)
        {
            UpdateQuantity();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            mid.Text = "";
            num.Value = 0;
            datepick.Value = DateTime.Now;
            rbget.Checked = false;
            rbstore.Checked = false;

            mid.Focus();
        }
    }
}
