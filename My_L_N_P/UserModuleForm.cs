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
    public partial class UserModuleForm : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\New folder\C#\M_L_P_N\My_L_N_P\My_L_N_P\dblibrary.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand Cmd = new SqlCommand();

        public UserModuleForm()
        {
            InitializeComponent();
        }

      /*  private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }*/

    /*    private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Passwordtxt.Text != Conf_Pass.Text)
                {
                    MessageBox.Show("Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to save this user ?", "Saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cmd = new SqlCommand("INSERT INTO tbUser(UserName, FullName, Password, Phone)VALUES(@UserName, @FullName, @Password, @Phone)", Con);
                    Cmd.Parameters.AddWithValue("@UserName", UserNametxt.Text);
                    Cmd.Parameters.AddWithValue("@FullName", FullNametxt.Text);
                    Cmd.Parameters.AddWithValue("@Password", Passwordtxt.Text);
                    Cmd.Parameters.AddWithValue("@Phone", Conf_Pass.Text);
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("User has been successfully saved.");
                    Clear();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/
        public void Clear()
        {
            UserNametxt.Clear();
            FullNametxt.Clear();
            Passwordtxt.Clear();
            Phonetxt.Clear();
            Conf_Pass.Clear();

        }

      /*  private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }*/

        private void UserModuleForm_Load(object sender, EventArgs e)
        {

        }

        private void UserNametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void FullNametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Passwordtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Phonetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Passwordtxt.Text != Conf_Pass.Text)
                {
                    MessageBox.Show("Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to save this user ?", "Saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cmd = new SqlCommand("INSERT INTO tbUser(UserName, FullName, Password, Phone)VALUES(@UserName, @FullName, @Password, @Phone)", Con);
                    Cmd.Parameters.AddWithValue("@UserName", UserNametxt.Text);
                    Cmd.Parameters.AddWithValue("@FullName", FullNametxt.Text);
                    Cmd.Parameters.AddWithValue("@Password", Passwordtxt.Text);
                    Cmd.Parameters.AddWithValue("@Phone", Phonetxt.Text);
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("User has been successfully saved.");
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Passwordtxt.Text != Conf_Pass.Text)
                {
                    MessageBox.Show("Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to Update this user ?", "Update record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cmd = new SqlCommand("UPDATE tbUser SET FullName=@FullName, Password=@Password, Phone=@Phone WHERE UserName LIKE '" + UserNametxt.Text + "'", Con);
                    Cmd.Parameters.AddWithValue("@FullName", FullNametxt.Text);
                    Cmd.Parameters.AddWithValue("@Password", Passwordtxt.Text);
                    Cmd.Parameters.AddWithValue("@Phone", Phonetxt.Text);
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("User has been successfully Updated.");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /* private void btnUpdate_Click(object sender, EventArgs e)
         {
             try
             {
                 if (Passwordtxt.Text != Conf_Pass.Text)
                 {
                     MessageBox.Show("Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
                 if (MessageBox.Show("Are you sure you want to Update this user ?", "Update record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                     Cmd = new SqlCommand("UPDATE tbUser SET FullName=@FullName, Password=@Password, Phone=@Phone WHERE UserName LIKE '"+ UserNametxt.Text + "'", Con);
                     Cmd.Parameters.AddWithValue("@FullName", FullNametxt.Text);
                     Cmd.Parameters.AddWithValue("@Password", Passwordtxt.Text);
                     Cmd.Parameters.AddWithValue("@Phone", Conf_Pass.Text);
                     Con.Open();
                     Cmd.ExecuteNonQuery();
                     Con.Close();
                     MessageBox.Show("User has been successfully Updated.");
                     this.Dispose();
                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }*/




    }
}
