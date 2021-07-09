namespace GUI
{
    partial class FormDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
            this.bt_DangNhap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataQuanLyNhanSu1 = new DAL.DataQuanLyNhanSu();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataQuanLyNhanSu1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_DangNhap
            // 
            this.bt_DangNhap.BackColor = System.Drawing.Color.OrangeRed;
            this.bt_DangNhap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bt_DangNhap.FlatAppearance.BorderSize = 0;
            this.bt_DangNhap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bt_DangNhap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bt_DangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_DangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DangNhap.ForeColor = System.Drawing.Color.White;
            this.bt_DangNhap.Location = new System.Drawing.Point(240, 255);
            this.bt_DangNhap.Name = "bt_DangNhap";
            this.bt_DangNhap.Size = new System.Drawing.Size(250, 30);
            this.bt_DangNhap.TabIndex = 12;
            this.bt_DangNhap.Text = "Đăng Nhập";
            this.bt_DangNhap.UseVisualStyleBackColor = false;
            this.bt_DangNhap.Click += new System.EventHandler(this.bt_DangNhap_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::GUI.Properties.Resources.Office_3601;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textPass);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 427);
            this.panel1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(323, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu:";
            // 
            // textPass
            // 
            this.textPass.BackColor = System.Drawing.Color.White;
            this.textPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPass.ForeColor = System.Drawing.Color.Black;
            this.textPass.Location = new System.Drawing.Point(240, 215);
            this.textPass.MaximumSize = new System.Drawing.Size(250, 30);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(250, 20);
            this.textPass.TabIndex = 9;
            this.textPass.Tag = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(310, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã nhân viên:";
            // 
            // textUser
            // 
            this.textUser.BackColor = System.Drawing.Color.White;
            this.textUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textUser.Location = new System.Drawing.Point(240, 170);
            this.textUser.MaximumSize = new System.Drawing.Size(250, 30);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(250, 20);
            this.textUser.TabIndex = 8;
            this.textUser.Tag = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("iCiel Cadena", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(248, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng Nhập";
            // 
            // dataQuanLyNhanSu1
            // 
            this.dataQuanLyNhanSu1.DataSetName = "DataQuanLyNhanSu";
            this.dataQuanLyNhanSu1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 427);
            this.Controls.Add(this.bt_DangNhap);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDangNhap";
            this.Text = "FormDangNhap";
            this.Load += new System.EventHandler(this.FormDangNhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataQuanLyNhanSu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_DangNhap;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DAL.DataQuanLyNhanSu dataQuanLyNhanSu1;

    }
}