
namespace My_L_N_P
{
    partial class CategoryModuleFormcs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryModuleFormcs));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.labCAID = new System.Windows.Forms.Label();
            this.btnCAClear = new System.Windows.Forms.Button();
            this.btnCAUpdate = new System.Windows.Forms.Button();
            this.btnCASave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCAName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 51);
            this.panel1.TabIndex = 73;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(22, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "Category Module";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(607, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 33);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // labCAID
            // 
            this.labCAID.AutoSize = true;
            this.labCAID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labCAID.Location = new System.Drawing.Point(43, 158);
            this.labCAID.Name = "labCAID";
            this.labCAID.Size = new System.Drawing.Size(97, 18);
            this.labCAID.TabIndex = 82;
            this.labCAID.Text = "Category ID";
            this.labCAID.Visible = false;
            // 
            // btnCAClear
            // 
            this.btnCAClear.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnCAClear.FlatAppearance.BorderSize = 0;
            this.btnCAClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCAClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCAClear.Location = new System.Drawing.Point(448, 141);
            this.btnCAClear.Name = "btnCAClear";
            this.btnCAClear.Size = new System.Drawing.Size(90, 35);
            this.btnCAClear.TabIndex = 80;
            this.btnCAClear.Text = "Clear";
            this.btnCAClear.UseVisualStyleBackColor = false;
            this.btnCAClear.Click += new System.EventHandler(this.btnCAClear_Click);
            // 
            // btnCAUpdate
            // 
            this.btnCAUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(195)))), ((int)(((byte)(165)))));
            this.btnCAUpdate.FlatAppearance.BorderSize = 0;
            this.btnCAUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCAUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCAUpdate.Location = new System.Drawing.Point(322, 141);
            this.btnCAUpdate.Name = "btnCAUpdate";
            this.btnCAUpdate.Size = new System.Drawing.Size(90, 35);
            this.btnCAUpdate.TabIndex = 79;
            this.btnCAUpdate.Text = "Update";
            this.btnCAUpdate.UseVisualStyleBackColor = false;
            this.btnCAUpdate.Click += new System.EventHandler(this.btnCAUpdate_Click);
            // 
            // btnCASave
            // 
            this.btnCASave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(169)))), ((int)(((byte)(109)))));
            this.btnCASave.FlatAppearance.BorderSize = 0;
            this.btnCASave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCASave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCASave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCASave.Location = new System.Drawing.Point(194, 141);
            this.btnCASave.Name = "btnCASave";
            this.btnCASave.Size = new System.Drawing.Size(90, 35);
            this.btnCASave.TabIndex = 78;
            this.btnCASave.Text = "Save";
            this.btnCASave.UseVisualStyleBackColor = false;
            this.btnCASave.Click += new System.EventHandler(this.btnCASave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(32)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 197);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(643, 29);
            this.panel2.TabIndex = 77;
            // 
            // txtCAName
            // 
            this.txtCAName.Location = new System.Drawing.Point(167, 86);
            this.txtCAName.Name = "txtCAName";
            this.txtCAName.Size = new System.Drawing.Size(414, 22);
            this.txtCAName.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 18);
            this.label1.TabIndex = 74;
            this.label1.Text = "Category Name:";
            // 
            // CategoryModuleFormcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 226);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labCAID);
            this.Controls.Add(this.btnCAClear);
            this.Controls.Add(this.btnCAUpdate);
            this.Controls.Add(this.btnCASave);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtCAName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CategoryModuleFormcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoryModuleFormcs";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.Label labCAID;
        public System.Windows.Forms.Button btnCAClear;
        public System.Windows.Forms.Button btnCAUpdate;
        public System.Windows.Forms.Button btnCASave;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txtCAName;
        private System.Windows.Forms.Label label1;
    }
}