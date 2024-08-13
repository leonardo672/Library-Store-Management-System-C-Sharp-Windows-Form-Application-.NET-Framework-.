using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace My_L_N_P
{
    public partial class CategoryModuleFormcs : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\New folder\C#\M_L_P_N\My_L_N_P\My_L_N_P\dblibrary.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand Cmd = new SqlCommand();
        public CategoryModuleFormcs()
        {
            InitializeComponent();
        }

        private void btnCASave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this category ?", "Saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cmd = new SqlCommand("INSERT INTO tbCategory(catname)VALUES(@catname)", Con);
                    Cmd.Parameters.AddWithValue("@catname", txtCAName.Text);
                   
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Category has been successfully saved.");
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
            txtCAName.Clear();
        }

        private void btnCAClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnCASave.Enabled = true;
            btnCAUpdate.Enabled = false;
        }

        private void btnCAUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Update this Category ?", "Update record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cmd = new SqlCommand("UPDATE tbCategory SET catname=@catname WHERE catid LIKE '" + labCAID.Text + "'", Con);
                    Cmd.Parameters.AddWithValue("@catname", txtCAName.Text);
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Category has been successfully Updated.");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
