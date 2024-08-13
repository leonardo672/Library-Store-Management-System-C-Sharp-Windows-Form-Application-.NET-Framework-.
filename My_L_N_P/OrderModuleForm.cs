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
    public partial class OrderModuleForm : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\New folder\C#\M_L_P_N\My_L_N_P\My_L_N_P\dblibrary.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand Cmd = new SqlCommand();
        SqlDataReader DataReader;
        int Qty = 0;
        public OrderModuleForm()
        {
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        public void LoadCustomer()
        {
            int i = 0;
            DataGVC.Rows.Clear();
            Cmd = new SqlCommand("SELECT * FROM tbCustomer WHERE CONCAT(Cid,Cname) LIKE '%" + SearchBoxCus.Text + "%'", Con);
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

        public void LoadProduct()
        {

            int i = 0;
            DataGVP.Rows.Clear();
            Cmd = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pname,pqty,pprice,pdescription,pcategory) LIKE '%" + SearchBoxPro.Text + "%'", Con);
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

        private void SearchBoxCus_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void SearchBoxPro_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        /* private void DataGVC_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             CusIDtxt.Text = DataGVC.Rows[e.RowIndex].Cells[1].Value.ToString();
             CusNamtxt.Text = DataGVC.Rows[e.RowIndex].Cells[2].Value.ToString();
         }*/


        /* private void DataGVP_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {

             ProductIDtxt.Text = DataGVP.Rows[e.RowIndex].Cells[1].Value.ToString();
             ProductNamtxt.Text = DataGVP.Rows[e.RowIndex].Cells[2].Value.ToString();
             PriceNametxt.Text = DataGVP.Rows[e.RowIndex].Cells[4].Value.ToString();
             Qty = Convert.ToInt32(DataGVP.Rows[e.RowIndex].Cells[3].Value.ToString());

         }*/
        

        private void QtyProduct_ValueChanged(object sender, EventArgs e)
        {
            GetQty();
            if (Convert.ToInt32(QtyProduct.Value) > Qty)
            {
                MessageBox.Show("In Stock quantity is not enough!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                QtyProduct.Value = QtyProduct.Value - 1;
                return;
            }
            if (Convert.ToInt32(QtyProduct.Value) > 0)
            {
                int total = Convert.ToInt32(PriceNametxt.Text) * Convert.ToInt32(QtyProduct.Value);
                TotalAP.Text = total.ToString();
            }
            
        }

        private void DataGVC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CusIDtxt.Text = DataGVC.Rows[e.RowIndex].Cells[1].Value.ToString();
            CusNamtxt.Text = DataGVC.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
       
        private void DataGVP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductIDtxt.Text = DataGVP.Rows[e.RowIndex].Cells[1].Value.ToString();
            ProductNamtxt.Text = DataGVP.Rows[e.RowIndex].Cells[2].Value.ToString();
            PriceNametxt.Text = DataGVP.Rows[e.RowIndex].Cells[4].Value.ToString();
          //  Qty = Convert.ToInt32(DataGVP.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                if (CusIDtxt.Text == "")
                {
                    MessageBox.Show("Please select customer!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ProductIDtxt.Text == "")
                {
                    MessageBox.Show("Please select product!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to insert this order?", "Saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    Cmd = new SqlCommand("INSERT INTO tborder(odate, pid, cid, qty, price, total)VALUES(@odate, @pid, @cid, @qty, @price, @total)", Con);
                    Cmd.Parameters.AddWithValue("@odate", dateTimeO.Value);
                    Cmd.Parameters.AddWithValue("@pid", Convert.ToInt32(ProductIDtxt.Text));
                    Cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(CusIDtxt.Text));
                    Cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(QtyProduct.Value));
                    Cmd.Parameters.AddWithValue("@price", Convert.ToInt32(PriceNametxt.Text));
                    Cmd.Parameters.AddWithValue("@total", Convert.ToInt32(TotalAP.Text));
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Order has been successfully inserted.");

                    Cmd = new SqlCommand("Update tbProduct SET pqty=(pqty-@pqty) Where pid LIKE '" + ProductIDtxt.Text + "'", Con);
                    Cmd.Parameters.AddWithValue("pqty", Convert.ToInt32(QtyProduct.Text));

                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();

                    Clear();
                    LoadProduct();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         public void Clear()
        {
            CusIDtxt.Clear();
            ProductIDtxt.Clear();
            dateTimeO.Value = DateTime.Now;
            ProductIDtxt.Clear();
            CusIDtxt.Clear();
            QtyProduct.Value = 0;
            ProductNamtxt.Clear();
            TotalAP.Clear();
            CusNamtxt.Clear();
            PriceNametxt.Clear();

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
         //   btn_Insert.Enabled = true;
         //   btn_Update.Enabled = false;
        }

        public void GetQty()
        {
            Cmd = new SqlCommand("Select pqty From tbProduct Where pid='" + ProductIDtxt.Text + "'", Con);
            Con.Open();
            DataReader = Cmd.ExecuteReader();
            while (DataReader.Read())
            {
                Qty = Convert.ToInt32(DataReader[0].ToString());
            }
            DataReader.Close();
            Con.Close();



        }
    }
}
