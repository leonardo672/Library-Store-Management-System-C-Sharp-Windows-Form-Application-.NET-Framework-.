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
    public partial class ProductForm : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\New folder\C#\M_L_P_N\My_L_N_P\My_L_N_P\dblibrary.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand Cmd = new SqlCommand();
        SqlDataReader DataReader;
        public ProductForm()
        {
            InitializeComponent();
            LoadProduct();
        }

        public void LoadProduct()
        {

            int i = 0;
            DataGVP.Rows.Clear();
            Cmd = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pname,pqty,pprice,pdescription,pcategory) LIKE '%" + SearchBox.Text + "%'", Con);
            Con.Open();
            DataReader = Cmd.ExecuteReader();
            while (DataReader.Read())
            {
                i++;
                DataGVP.Rows.Add(i, DataReader[0].ToString(), DataReader[1].ToString(), DataReader[2].ToString(), DataReader[3].ToString(), DataReader[4].ToString(), DataReader[5].ToString());
            }
            DataReader.Close();
            Con.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModuleForm ModuleForm = new ProductModuleForm();
            ModuleForm.btnSave.Enabled = true;
            ModuleForm.btnUpdate.Enabled = false;
            ModuleForm.ShowDialog();
            LoadProduct();
        }

        private void DataGVP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = DataGVP.Columns[e.ColumnIndex].Name;
            if (ColName == "Edit")
            {
                ProductModuleForm ProductModule = new ProductModuleForm();
                ProductModule.labIDP.Text = DataGVP.Rows[e.RowIndex].Cells[1].Value.ToString();
                ProductModule.PNtxt.Text = DataGVP.Rows[e.RowIndex].Cells[2].Value.ToString();
                ProductModule.QPtxt.Text = DataGVP.Rows[e.RowIndex].Cells[3].Value.ToString();
                ProductModule.PPtxt.Text = DataGVP.Rows[e.RowIndex].Cells[4].Value.ToString();
                ProductModule.DPtxt.Text = DataGVP.Rows[e.RowIndex].Cells[5].Value.ToString();
                ProductModule.comboQty.Text = DataGVP.Rows[e.RowIndex].Cells[6].Value.ToString();
                
                ProductModule.btnSave.Enabled = false;
                ProductModule.btnUpdate.Enabled = true;
                // ProductModule.btnClear.Enabled = false; 
                ProductModule.ShowDialog();
            }
            else if (ColName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this product ?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    Cmd = new SqlCommand("DELETE FROM tbProduct WHERE pid LIKE '" + DataGVP.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record has been successfully deleted.");
                }

            }
            LoadProduct();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
    
}
