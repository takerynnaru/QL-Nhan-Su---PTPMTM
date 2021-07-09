namespace GUI
{
    partial class DailyCa
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
            this.panelmain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonChamCong = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNgay = new System.Windows.Forms.Label();
            this.panelmain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelmain
            // 
            this.panelmain.Controls.Add(this.panel2);
            this.panelmain.Controls.Add(this.buttonChamCong);
            this.panelmain.Controls.Add(this.panel1);
            this.panelmain.Location = new System.Drawing.Point(2, 3);
            this.panelmain.Name = "panelmain";
            this.panelmain.Size = new System.Drawing.Size(432, 496);
            this.panelmain.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(7, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 381);
            this.panel2.TabIndex = 2;
            // 
            // buttonChamCong
            // 
            this.buttonChamCong.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonChamCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChamCong.ForeColor = System.Drawing.Color.White;
            this.buttonChamCong.Location = new System.Drawing.Point(119, 444);
            this.buttonChamCong.Name = "buttonChamCong";
            this.buttonChamCong.Size = new System.Drawing.Size(184, 42);
            this.buttonChamCong.TabIndex = 1;
            this.buttonChamCong.Text = "Chấm Công";
            this.buttonChamCong.UseVisualStyleBackColor = false;
            this.buttonChamCong.Click += new System.EventHandler(this.buttonChamCong_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OrangeRed;
            this.panel1.Controls.Add(this.labelNgay);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 43);
            this.panel1.TabIndex = 0;
            // 
            // labelNgay
            // 
            this.labelNgay.AutoSize = true;
            this.labelNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNgay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNgay.Location = new System.Drawing.Point(15, 8);
            this.labelNgay.Name = "labelNgay";
            this.labelNgay.Size = new System.Drawing.Size(285, 25);
            this.labelNgay.TabIndex = 0;
            this.labelNgay.Text = "Chấm Công, Ngày dd/mm/yyyy";
            // 
            // DailyCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 501);
            this.Controls.Add(this.panelmain);
            this.Name = "DailyCa";
            this.Text = "DailyCa";
            this.panelmain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelmain;
        private System.Windows.Forms.Button buttonChamCong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelNgay;
        private System.Windows.Forms.Panel panel2;
    }
}