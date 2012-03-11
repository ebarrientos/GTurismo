namespace Viagens
{
    partial class frmPar01
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.brtCancel = new System.Windows.Forms.Button();
            this.cbBandeira = new System.Windows.Forms.ComboBox();
            this.mtbVcto = new AMS.TextBox.MaskedTextBox();
            this.mtbNumCar = new AMS.TextBox.MaskedTextBox();
            this.mtbCodSeg = new AMS.TextBox.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bandeira";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vencimento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Número";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Código de Segurança";
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(74, 169);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(70, 33);
            this.btOk.TabIndex = 11;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // brtCancel
            // 
            this.brtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.brtCancel.Location = new System.Drawing.Point(175, 169);
            this.brtCancel.Name = "brtCancel";
            this.brtCancel.Size = new System.Drawing.Size(70, 33);
            this.brtCancel.TabIndex = 13;
            this.brtCancel.Text = "Cancelar";
            this.brtCancel.UseVisualStyleBackColor = true;
            // 
            // cbBandeira
            // 
            this.cbBandeira.FormattingEnabled = true;
            this.cbBandeira.Location = new System.Drawing.Point(175, 32);
            this.cbBandeira.Name = "cbBandeira";
            this.cbBandeira.Size = new System.Drawing.Size(121, 21);
            this.cbBandeira.TabIndex = 6;
            // 
            // mtbVcto
            // 
            this.mtbVcto.Flags = 0;
            this.mtbVcto.Location = new System.Drawing.Point(175, 60);
            this.mtbVcto.Mask = "##/##";
            this.mtbVcto.Name = "mtbVcto";
            this.mtbVcto.Size = new System.Drawing.Size(70, 20);
            this.mtbVcto.TabIndex = 7;
            // 
            // mtbNumCar
            // 
            this.mtbNumCar.Flags = 0;
            this.mtbNumCar.Location = new System.Drawing.Point(175, 92);
            this.mtbNumCar.Mask = "";
            this.mtbNumCar.Name = "mtbNumCar";
            this.mtbNumCar.Size = new System.Drawing.Size(121, 20);
            this.mtbNumCar.TabIndex = 8;
            // 
            // mtbCodSeg
            // 
            this.mtbCodSeg.Flags = 0;
            this.mtbCodSeg.Location = new System.Drawing.Point(175, 124);
            this.mtbCodSeg.Mask = "###";
            this.mtbCodSeg.Name = "mtbCodSeg";
            this.mtbCodSeg.Size = new System.Drawing.Size(52, 20);
            this.mtbCodSeg.TabIndex = 9;
            // 
            // frmPar01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 227);
            this.Controls.Add(this.mtbCodSeg);
            this.Controls.Add(this.mtbNumCar);
            this.Controls.Add(this.mtbVcto);
            this.Controls.Add(this.cbBandeira);
            this.Controls.Add(this.brtCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmPar01";
            this.Text = "Dados do Cartão";
            this.Load += new System.EventHandler(this.frmPar01_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button brtCancel;
        private System.Windows.Forms.ComboBox cbBandeira;
        private AMS.TextBox.MaskedTextBox mtbVcto;
        private AMS.TextBox.MaskedTextBox mtbNumCar;
        private AMS.TextBox.MaskedTextBox mtbCodSeg;
    }
}