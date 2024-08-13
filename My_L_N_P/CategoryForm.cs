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
    public partial class CategoryForm : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\New folder\C#\M_L_P_N\My_L_N_P\My_L_N_P\dblibrary.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand Cmd = new SqlCommand();
        SqlDataReader DataReader;
        public CategoryForm()
        {
            InitializeComponent();
            LoadCutegory();
        }

        public void LoadCutegory()
        {
            int i = 0;
            DataGVCA.Rows.Clear();
            Cmd = new SqlCommand("SELECT * FROM tbCategory", Con);
            Con.Open();
            DataReader = Cmd.ExecuteReader();
            while (DataReader.Read())
            {
                i++;
                DataGVCA.Rows.Add(i, DataReader[0].ToString(), DataReader[1].ToString());
            }
            DataReader.Close();
            Con.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CategoryModuleFormcs CategoryModule = new CategoryModuleFormcs();
            CategoryModule.btnCASave.Enabled = true;
            CategoryModule.btnCAUpdate.Enabled = false;
            CategoryModule.ShowDialog();
        }

        private void DataGVCA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = DataGVCA.Columns[e.ColumnIndex].Name;
            if (ColName == "Edit")
            {
                CategoryModuleFormcs CategoryModule = new CategoryModuleFormcs();
                CategoryModule.labCAID.Text = DataGVCA.Rows[e.RowIndex].Cells[1].Value.ToString();
                CategoryModule.txtCAName.Text = DataGVCA.Rows[e.RowIndex].Cells[2].Value.ToString();
                CategoryModule.btnCASave.Enabled = false;
                CategoryModule.btnCAUpdate.Enabled = true;
                CategoryModule.ShowDialog();
            }
            else if (ColName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this category ?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    Cmd = new SqlCommand("DELETE FROM tbCategory WHERE catid LIKE '" + DataGVCA.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record has been successfully deleted.");
                }

            }
            LoadCutegory();
        }
    }
    
}
