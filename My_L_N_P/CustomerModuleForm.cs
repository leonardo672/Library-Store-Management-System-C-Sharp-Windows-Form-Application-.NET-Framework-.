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

namespace My_L_N_P
{
    public partial class CustomerModuleForm : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\New folder\C#\M_L_P_N\My_L_N_P\My_L_N_P\dblibrary.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand Cmd = new SqlCommand();
        public CustomerModuleForm()
        {
            InitializeComponent();
        }

        private void btnCSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this user ?", "Saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cmd = new SqlCommand("INSERT INTO tbCustomer(Cname, Cphone)VALUES(@Cname, @Cphone)", Con);
                    Cmd.Parameters.AddWithValue("@UserName", txtCName.Text);
                    Cmd.Parameters.AddWithValue("@FullName", txtCphone.Text);
                   
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Customer has been successfully saved.");
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            txtCName.Clear();
            txtCphone.Clear();
        }

        private void btnCClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnCSave.Enabled = true;
            btnCUpdate.Enabled = false;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Customer ?", "Saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cmd = new SqlCommand("INSERT INTO tbCustomer(Cname, Cphone)VALUES(@Cname, @Cphone)", Con);
                    Cmd.Parameters.AddWithValue("@Cname", txtCName.Text);
                    Cmd.Parameters.AddWithValue("@Cphone", txtCphone.Text);
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Customer has been successfully saved.");
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Update this Customer ?", "Update record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cmd = new SqlCommand("UPDATE tbCustomer SET Cname=@Cname, Cphone=@Cphone WHERE Cid LIKE '" + labCID.Text + "'", Con);
                    Cmd.Parameters.AddWithValue("@Cname", txtCName.Text);
                    Cmd.Parameters.AddWithValue("@Cphone", txtCphone.Text);
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Customer has been successfully Updated.");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
