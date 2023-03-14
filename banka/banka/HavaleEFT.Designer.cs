namespace banka
{
    partial class HavaleEFT
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtNo = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMiktar = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDolar = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEuro = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.IndianRed;
            this.button1.Location = new System.Drawing.Point(175, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "HAVALE / EFT YAP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNo
            // 
            this.txtNo.ForeColor = System.Drawing.Color.IndianRed;
            this.txtNo.Location = new System.Drawing.Point(175, 103);
            this.txtNo.Mask = "000000000000";
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(118, 20);
            this.txtNo.TabIndex = 10;
            this.txtNo.ValidatingType = typeof(int);
            this.txtNo.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtNo_MaskInputRejected);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(93, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Alıcı Hesap No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(100, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "HAVALE / EFT İŞLEMİ";
            // 
            // txtMiktar
            // 
            this.txtMiktar.ForeColor = System.Drawing.Color.IndianRed;
            this.txtMiktar.Location = new System.Drawing.Point(175, 152);
            this.txtMiktar.Mask = "000000000000";
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(118, 20);
            this.txtMiktar.TabIndex = 13;
            this.txtMiktar.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.IndianRed;
            this.label3.Location = new System.Drawing.Point(93, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Miktar(TL):";
            // 
            // txtDolar
            // 
            this.txtDolar.ForeColor = System.Drawing.Color.IndianRed;
            this.txtDolar.Location = new System.Drawing.Point(175, 194);
            this.txtDolar.Mask = "000000000000";
            this.txtDolar.Name = "txtDolar";
            this.txtDolar.Size = new System.Drawing.Size(118, 20);
            this.txtDolar.TabIndex = 15;
            this.txtDolar.ValidatingType = typeof(int);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.IndianRed;
            this.label4.Location = new System.Drawing.Point(93, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Miktar(Dolar):";
            // 
            // txtEuro
            // 
            this.txtEuro.ForeColor = System.Drawing.Color.IndianRed;
            this.txtEuro.Location = new System.Drawing.Point(175, 237);
            this.txtEuro.Mask = "000000000000";
            this.txtEuro.Name = "txtEuro";
            this.txtEuro.Size = new System.Drawing.Size(118, 20);
            this.txtEuro.TabIndex = 17;
            this.txtEuro.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.IndianRed;
            this.label5.Location = new System.Drawing.Point(93, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Miktar(Euro):";
            // 
            // HavaleEFT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 395);
            this.Controls.Add(this.txtEuro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDolar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMiktar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HavaleEFT";
            this.Text = "HAVALE / EFT İŞLEMİ";
            this.Load += new System.EventHandler(this.HavaleEFT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox txtNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtMiktar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtDolar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtEuro;
        private System.Windows.Forms.Label label5;
    }
}