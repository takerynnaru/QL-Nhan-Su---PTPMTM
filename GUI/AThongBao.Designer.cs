namespace GUI
{
    partial class AThongBao
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxNguoiDang = new System.Windows.Forms.PictureBox();
            this.labelTieuDe = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelNgayDang = new System.Windows.Forms.Label();
            this.buttonXem = new System.Windows.Forms.Button();
            this.labelTenNguoiDang = new System.Windows.Forms.Label();
            this.labelNọiDung = new System.Windows.Forms.Label();
            this.labelMaTB = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNguoiDang)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelMaTB);
            this.panel1.Controls.Add(this.labelTenNguoiDang);
            this.panel1.Controls.Add(this.buttonXem);
            this.panel1.Controls.Add(this.labelNgayDang);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.labelTieuDe);
            this.panel1.Controls.Add(this.pictureBoxNguoiDang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 150);
            this.panel1.TabIndex = 0;
            // 
            // pictureBoxNguoiDang
            // 
            this.pictureBoxNguoiDang.Location = new System.Drawing.Point(23, 20);
            this.pictureBoxNguoiDang.Name = "pictureBoxNguoiDang";
            this.pictureBoxNguoiDang.Size = new System.Drawing.Size(109, 107);
            this.pictureBoxNguoiDang.TabIndex = 0;
            this.pictureBoxNguoiDang.TabStop = false;
            // 
            // labelTieuDe
            // 
            this.labelTieuDe.AutoSize = true;
            this.labelTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTieuDe.Location = new System.Drawing.Point(151, 18);
            this.labelTieuDe.Name = "labelTieuDe";
            this.labelTieuDe.Size = new System.Drawing.Size(63, 17);
            this.labelTieuDe.TabIndex = 1;
            this.labelTieuDe.Text = "Tiêu đề";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Snow;
            this.flowLayoutPanel1.Controls.Add(this.labelNọiDung);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(154, 45);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(705, 74);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // labelNgayDang
            // 
            this.labelNgayDang.AutoSize = true;
            this.labelNgayDang.Location = new System.Drawing.Point(764, 126);
            this.labelNgayDang.Name = "labelNgayDang";
            this.labelNgayDang.Size = new System.Drawing.Size(58, 13);
            this.labelNgayDang.TabIndex = 3;
            this.labelNgayDang.Text = "ngày đăng";
            // 
            // buttonXem
            // 
            this.buttonXem.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonXem.Location = new System.Drawing.Point(894, 83);
            this.buttonXem.Name = "buttonXem";
            this.buttonXem.Size = new System.Drawing.Size(72, 36);
            this.buttonXem.TabIndex = 4;
            this.buttonXem.Text = "Xem";
            this.buttonXem.UseVisualStyleBackColor = false;
            // 
            // labelTenNguoiDang
            // 
            this.labelTenNguoiDang.AutoSize = true;
            this.labelTenNguoiDang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenNguoiDang.Location = new System.Drawing.Point(154, 126);
            this.labelTenNguoiDang.Name = "labelTenNguoiDang";
            this.labelTenNguoiDang.Size = new System.Drawing.Size(100, 13);
            this.labelTenNguoiDang.TabIndex = 5;
            this.labelTenNguoiDang.Text = "Tên Người Đăng";
            // 
            // labelNọiDung
            // 
            this.labelNọiDung.AutoSize = true;
            this.labelNọiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNọiDung.Location = new System.Drawing.Point(3, 0);
            this.labelNọiDung.Name = "labelNọiDung";
            this.labelNọiDung.Size = new System.Drawing.Size(133, 17);
            this.labelNọiDung.TabIndex = 0;
            this.labelNọiDung.Text = "Nội dung thông báo";
            // 
            // labelMaTB
            // 
            this.labelMaTB.AutoSize = true;
            this.labelMaTB.Location = new System.Drawing.Point(940, 5);
            this.labelMaTB.Name = "labelMaTB";
            this.labelMaTB.Size = new System.Drawing.Size(36, 13);
            this.labelMaTB.TabIndex = 6;
            this.labelMaTB.Text = "MaTB";
            // 
            // AThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AThongBao";
            this.Size = new System.Drawing.Size(1004, 150);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNguoiDang)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxNguoiDang;
        private System.Windows.Forms.Label labelTenNguoiDang;
        private System.Windows.Forms.Button buttonXem;
        private System.Windows.Forms.Label labelNgayDang;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelNọiDung;
        private System.Windows.Forms.Label labelTieuDe;
        private System.Windows.Forms.Label labelMaTB;
    }
}
