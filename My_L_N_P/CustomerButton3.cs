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
    public partial class CustomerButton3 : PictureBox
    {
        public CustomerButton3()
        {
            InitializeComponent();
        }

        private Image NormalImage;
        private Image HoverImage;

        public Image ImageNormal
        {
            get { return NormalImage; }
            set { NormalImage = value; }
        }

        public Image ImageHover
        {
            get { return HoverImage; }
            set { HoverImage = value; }
        }

        private void CustomerButton3_MouseLeave(object sender, EventArgs e)
        {
            this.Image = ImageNormal;
        }

        private void CustomerButton3_MouseHover(object sender, EventArgs e)
        {
            this.Image = ImageHover;
        }
    }
}
