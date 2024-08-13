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
    public partial class LoginForm : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\New folder\C#\M_L_P_N\My_L_N_P\My_L_N_P\dblibrary.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand Cmd = new SqlCommand();
        SqlDataReader DataReader;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            DialogResult result = MessageBox.Show("Are you sure you want to close the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // User clicked "Yes," so close the form
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Cmd = new SqlCommand("SELECT * FROM tbUser WHERE UserName=@UserName AND Password=@Password", Con);
                Cmd.Parameters.AddWithValue("@UserName", UserNametxt.Text);
                Cmd.Parameters.AddWithValue("@Password", Passwordtxt.Text);
                Con.Open();
                DataReader = Cmd.ExecuteReader();
                DataReader.Read();
                if (DataReader.HasRows)
                {
                    MessageBox.Show("Welcome " + DataReader["FullName"].ToString() + " | ", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm main = new MainForm();
                    this.Hide();
                    main.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Invalid username or password!!", "Access Denited", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxPass.Checked)
            {
                Passwordtxt.UseSystemPasswordChar = false;
            }
            else
            {
                Passwordtxt.UseSystemPasswordChar = true;
            }
        }

        private void LabClear_Click(object sender, EventArgs e)
        {
            UserNametxt.Clear();
            Passwordtxt.Clear();

        }
    }
}
