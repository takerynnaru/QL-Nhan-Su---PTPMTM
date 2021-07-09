namespace GUI
{
    partial class ADAY
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
            this.panelADAY = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.labelCaChieu = new System.Windows.Forms.Label();
            this.labelCaSang = new System.Windows.Forms.Label();
            this.labelADAY = new System.Windows.Forms.Label();
            this.panelADAY.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelADAY
            // 
            this.panelADAY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelADAY.Controls.Add(this.button1);
            this.panelADAY.Controls.Add(this.labelCaChieu);
            this.panelADAY.Controls.Add(this.labelCaSang);
            this.panelADAY.Controls.Add(this.labelADAY);
            this.panelADAY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelADAY.Location = new System.Drawing.Point(0, 0);
            this.panelADAY.Name = "panelADAY";
            this.panelADAY.Size = new System.Drawing.Size(150, 100);
            this.panelADAY.TabIndex = 1;
            this.panelADAY.Click += new System.EventHandler(this.panelADAY_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Xem Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelCaChieu
            // 
            this.labelCaChieu.AutoSize = true;
            this.labelCaChieu.Location = new System.Drawing.Point(14, 49);
            this.labelCaChieu.Name = "labelCaChieu";
            this.labelCaChieu.Size = new System.Drawing.Size(43, 13);
            this.labelCaChieu.TabIndex = 2;
            this.labelCaChieu.Text = "Chiều : ";
            // 
            // labelCaSang
            // 
            this.labelCaSang.AutoSize = true;
            this.labelCaSang.Location = new System.Drawing.Point(14, 31);
            this.labelCaSang.Name = "labelCaSang";
            this.labelCaSang.Size = new System.Drawing.Size(38, 13);
            this.labelCaSang.TabIndex = 1;
            this.labelCaSang.Text = "Sáng :";
            // 
            // labelADAY
            // 
            this.labelADAY.AutoSize = true;
            this.labelADAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelADAY.Location = new System.Drawing.Point(55, 11);
            this.labelADAY.Name = "labelADAY";
            this.labelADAY.Size = new System.Drawing.Size(39, 17);
            this.labelADAY.TabIndex = 0;
            this.labelADAY.Text = "DAY";
            // 
            // ADAY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelADAY);
            this.Name = "ADAY";
            this.Size = new System.Drawing.Size(150, 100);
            this.panelADAY.ResumeLayout(false);
            this.panelADAY.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelADAY;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelCaChieu;
        private System.Windows.Forms.Label labelCaSang;
        private System.Windows.Forms.Label labelADAY;
    }
}
