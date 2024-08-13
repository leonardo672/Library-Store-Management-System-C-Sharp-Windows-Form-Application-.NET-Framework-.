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
    public partial class OrderForm : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\New folder\C#\M_L_P_N\My_L_N_P\My_L_N_P\dblibrary.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand Cmd = new SqlCommand();
        SqlDataReader DataReader;
        public OrderForm()
        {
            InitializeComponent();
            LoadOrder();
        }

        public void LoadOrder()
        {
            int Total = 0;
            int i = 0;
            DataGVO.Rows.Clear();
            Cmd = new SqlCommand("SELECT orderid, odate, O.pid, P.pname, O.cid, C.Cname, qty, price, total FROM tborder As O JOIN tbCustomer As C ON O.cid=C.Cid JOIN tbProduct As P ON O.pid=P.pid Where CONCAT(orderid, odate, O.pid, P.pname, O.cid, C.Cname, qty, price) LIKE '%"+ Searchtxt.Text + "%'", Con);
            Con.Open();
            DataReader = Cmd.ExecuteReader();
            while (DataReader.Read())
            {
                i++;
                DataGVO.Rows.Add(i, DataReader[0].ToString(), Convert.ToDateTime(DataReader[1].ToString()).ToString("dd/MM/yyyy"), DataReader[2].ToString(),  DataReader[3].ToString(), DataReader[4].ToString(), DataReader[5].ToString(), DataReader[6].ToString(), DataReader[7].ToString(), DataReader[8].ToString());
                Total += Convert.ToInt32(DataReader[8].ToString());
            }
            DataReader.Close();
            Con.Close();

            Qtytext.Text = i.ToString();
            Totaltxt.Text = Total.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderModuleForm ModuleForm = new OrderModuleForm();
           // ModuleForm.btn_Insert.Enabled = true;
           // ModuleForm.btn_Update.Enabled = false;
            ModuleForm.ShowDialog();
            LoadOrder();
        }

        private void DataGVO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = DataGVO.Columns[e.ColumnIndex].Name;
          /*  if (ColName == "Edit")
            {
                OrderModuleForm OrderModule = new OrderModuleForm();
                OrderModule.LabOrId.Text = DataGVO.Rows[e.RowIndex].Cells[1].Value.ToString();
                OrderModule.dateTimeO.Text = DataGVO.Rows[e.RowIndex].Cells[2].Value.ToString();
                OrderModule.ProductIDtxt.Text = DataGVO.Rows[e.RowIndex].Cells[3].Value.ToString();
                OrderModule.CusIDtxt.Text = DataGVO.Rows[e.RowIndex].Cells[4].Value.ToString();
                OrderModule.QtyProduct.Text = DataGVO.Rows[e.RowIndex].Cells[5].Value.ToString();
                OrderModule.PriceNametxt.Text = DataGVO.Rows[e.RowIndex].Cells[6].Value.ToString();

                OrderModule.btn_Insert.Enabled = false;
                OrderModule.btn_Update.Enabled = true;
                OrderModule.btn_Clear.Enabled = false;
                OrderModule.ShowDialog();
            }*/
            if (ColName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this order ?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    Cmd = new SqlCommand("DELETE FROM tborder WHERE orderid LIKE '" + DataGVO.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record has been successfully deleted.");
                    //dataGridView's both rows and Columns start at 0 index
                    Cmd = new SqlCommand("Update tbProduct SET pqty=(pqty+@pqty) Where pid LIKE '" + DataGVO.Rows[e.RowIndex].Cells[3].Value.ToString() + "'", Con);
                    Cmd.Parameters.AddWithValue("pqty", Convert.ToInt32(DataGVO.Rows[e.RowIndex].Cells[7].Value.ToString()));

                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();

                }

            }
            LoadOrder();
        }

        private void Searchtxt_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
