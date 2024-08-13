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
    public partial class UserForm : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\New folder\C#\M_L_P_N\My_L_N_P\My_L_N_P\dblibrary.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand Cmd = new SqlCommand();
        SqlDataReader DataReader;
        public UserForm()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {
            int i = 0;
            DataGVU.Rows.Clear();
            Cmd = new SqlCommand("SELECT * FROM tbUser", Con);
            Con.Open();
            DataReader = Cmd.ExecuteReader();
            while (DataReader.Read())
            {
                i++;
                DataGVU.Rows.Add(i, DataReader[0].ToString(), DataReader[1].ToString(), DataReader[2].ToString(), DataReader[3].ToString()); 
            }
            DataReader.Close();
            Con.Close();

        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModuleForm UserModule = new UserModuleForm();
            UserModule.btnSave.Enabled = true;
            UserModule.btnUpdate.Enabled = false;
            UserModule.ShowDialog();
            LoadUser();
        }

        private void DataGVU_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = DataGVU.Columns[e.ColumnIndex].Name;
            if (ColName == "Edit")
            {
                UserModuleForm UserModule = new UserModuleForm();
                UserModule.UserNametxt.Text = DataGVU.Rows[e.RowIndex].Cells[1].Value.ToString();
                UserModule.FullNametxt.Text = DataGVU.Rows[e.RowIndex].Cells[2].Value.ToString();
                UserModule.Passwordtxt.Text = DataGVU.Rows[e.RowIndex].Cells[3].Value.ToString();
                UserModule.Phonetxt.Text = DataGVU.Rows[e.RowIndex].Cells[4].Value.ToString();
                
                UserModule.btnSave.Enabled = false;
                UserModule.btnUpdate.Enabled = true;
                UserModule.UserNametxt.Enabled = false;
                UserModule.ShowDialog();
            }
            else if (ColName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this user ?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    Cmd = new SqlCommand("DELETE FROM tbUser WHERE UserName LIKE '" + DataGVU.Rows[e.RowIndex].Cells[1].Value.ToString()+ "'",Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record has been successfully deleted.");
                }

            }
            LoadUser();
        }
    }
}
