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
    public partial class ProductModuleForm : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\New folder\C#\M_L_P_N\My_L_N_P\My_L_N_P\dblibrary.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand Cmd = new SqlCommand();
        SqlDataReader DataReader;
        public ProductModuleForm()
        {
            InitializeComponent();
            LoadProduct();
        }

        public void LoadProduct()
        {
            comboQty.Items.Clear();
            Cmd = new SqlCommand("SELECT catname FROM tbCategory", Con);
            Con.Open();
            DataReader = Cmd.ExecuteReader();
            while (DataReader.Read())
            {
                comboQty.Items.Add(DataReader[0].ToString());

            }
            DataReader.Close();
            Con.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this product ?", "Saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cmd = new SqlCommand("INSERT INTO tbProduct(pname,pqty,pprice,pdescription,pcategory)Values(@pname,@pqty,@pprice,@pdescription,@pcategory)", Con);
                    Cmd.Parameters.AddWithValue("@pname", PNtxt.Text);
                    Cmd.Parameters.AddWithValue("@pqty", Convert.ToInt32(QPtxt.Text));
                    Cmd.Parameters.AddWithValue("@pprice", Convert.ToInt32(PPtxt.Text));
                    Cmd.Parameters.AddWithValue("@pdescription", DPtxt.Text);
                    Cmd.Parameters.AddWithValue("@pcategory", comboQty.Text);
                    if(Con.State==ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Product has been successfully saved.");
                    Clear();
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

        public void Clear()
        {
            PNtxt.Clear();
            QPtxt.Clear();
            PPtxt.Clear();
            DPtxt.Clear();
            comboQty.Text = "";

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Update this product ?", "Update record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cmd = new SqlCommand("UPDATE tbProduct SET pname=@pname, pqty=@pqty, pprice=@pprice, pdescription=@pdescription, pcategory=@pcategory WHERE pid LIKE '" + labIDP.Text + "'", Con);
                    Cmd.Parameters.AddWithValue("@pname", PNtxt.Text);
                    Cmd.Parameters.AddWithValue("@pqty", Convert.ToInt32(QPtxt.Text));
                    Cmd.Parameters.AddWithValue("@pprice", Convert.ToInt32(PPtxt.Text));
                    Cmd.Parameters.AddWithValue("@pdescription", DPtxt.Text);
                    Cmd.Parameters.AddWithValue("@pcategory", comboQty.Text);
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Product has been successfully Updated.");
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
    }
}
