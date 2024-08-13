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
    public partial class CustomerForm : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\New folder\C#\M_L_P_N\My_L_N_P\My_L_N_P\dblibrary.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand Cmd = new SqlCommand();
        SqlDataReader DataReader;
        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomer();
        }
        public void LoadCustomer()
        {
            int i = 0;
            DataGVC.Rows.Clear();
            Cmd = new SqlCommand("SELECT * FROM tbCustomer", Con);
            Con.Open();
            DataReader = Cmd.ExecuteReader();
            while (DataReader.Read())
            {
                i++;
                DataGVC.Rows.Add(i, DataReader[0].ToString(), DataReader[1].ToString(), DataReader[2].ToString());
            }
            DataReader.Close();
            Con.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerModuleForm ModuleForm = new CustomerModuleForm();
            ModuleForm.btnCSave.Enabled = true;
            ModuleForm.btnCUpdate.Enabled = false;
            ModuleForm.ShowDialog();
            LoadCustomer();
           // ModuleForm.btnCClear.Enabled = true;

        }

        private void DataGVC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = DataGVC.Columns[e.ColumnIndex].Name;
            if (ColName == "Edit")
            {
                CustomerModuleForm CustomerModule = new CustomerModuleForm();
                CustomerModule.labCID.Text = DataGVC.Rows[e.RowIndex].Cells[1].Value.ToString();
                CustomerModule.txtCName.Text = DataGVC.Rows[e.RowIndex].Cells[2].Value.ToString();
                CustomerModule.txtCphone.Text = DataGVC.Rows[e.RowIndex].Cells[3].Value.ToString();
                
                CustomerModule.btnCSave.Enabled = false;
                CustomerModule.btnCUpdate.Enabled = true;
                CustomerModule.ShowDialog();
            }
            else if (ColName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Customer ?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    Cmd = new SqlCommand("DELETE FROM tbCustomer WHERE Cid LIKE '" + DataGVC.Rows[e.RowIndex].Cells[1].Value.ToString()+"'",Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record has been successfully deleted.");
                }

            }
            LoadCustomer();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
