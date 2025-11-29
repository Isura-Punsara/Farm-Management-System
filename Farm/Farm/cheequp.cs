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
    public partial class cheequp : Form
    {
        public cheequp()
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

        private void eqadd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheeqad cheeqad = new cheeqad();
            cheeqad.Show();
            this.Hide();
        }

        private void view_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cheeqviw cheeqviw = new cheeqviw();
            cheeqviw.Show();
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

        private void fetchdata()
        {
            string equipmentID = eid.Text.Trim();
            if (!string.IsNullOrEmpty(equipmentID))
            {
                string connectionString = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sql = "SELECT Quantity FROM EqInventory WHERE EquipmentID = @EquipmentID";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@EquipmentID", equipmentID);

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
                            MessageBox.Show("Equipment not found!");
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
                MessageBox.Show("Please enter Equipment ID.");
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            fetchdata();
        }

        private void UpdateQuantity()
        {
            string equipmentID = eid.Text.Trim();
            int enteredQuantity = (int)num.Value;
            string operation = rbget.Checked ? "Get" : "Store";

            if (!string.IsNullOrEmpty(equipmentID) && enteredQuantity > 0)
            {
                string cs = "Data Source = BIMSARA\\; Initial Catalog = Farm; Integrated Security = True";
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string updateQuery = operation == "Get" ?
                        "UPDATE EqInventory SET Quantity = Quantity - @Quantity WHERE EquipmentID = @EquipmentID AND Quantity >= @Quantity" :
                        "UPDATE EqInventory SET Quantity = Quantity + @Quantity WHERE EquipmentID = @EquipmentID";

                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    cmd.Parameters.AddWithValue("@EquipmentID", equipmentID);
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

        private void save_Click(object sender, EventArgs e)
        {
            UpdateQuantity();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            eid.Text = "";
            num.Value = 0;
            datepick.Value = DateTime.Now;
            rbget.Checked = false;
            rbstore.Checked = false;

            eid.Focus();
        }
    }
}
