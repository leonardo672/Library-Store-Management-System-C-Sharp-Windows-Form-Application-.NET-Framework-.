using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_L_N_P
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void OpenChildForm(Form ChildForm)
        {
               if (activeForm != null)
                activeForm.Close();
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(ChildForm);
            PanelMain.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        private void cusBut2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CustomerForm());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserForm());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CategoryForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductForm());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrderForm());
        }

       
    }
}
