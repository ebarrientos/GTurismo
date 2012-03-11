namespace Viagens
{
    partial class frmPar02
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
            this.mtbCheque = new AMS.TextBox.MaskedTextBox();
            this.mtbConta = new AMS.TextBox.MaskedTextBox();
            this.mtbAgencia = new AMS.TextBox.MaskedTextBox();
            this.brtCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mtbBanco = new AMS.TextBox.MaskedTextBox();
            this.SuspendLayout();
            // 
            // mtbCheque
            // 
            this.mtbCheque.Flags = 0;
            this.mtbCheque.Location = new System.Drawing.Point(163, 128);
            this.mtbCheque.Mask = "######";
            this.mtbCheque.Name = "mtbCheque";
            this.mtbCheque.Size = new System.Drawing.Size(70, 20);
            this.mtbCheque.TabIndex = 19;
            // 
            // mtbConta
            // 
            this.mtbConta.Flags = 0;
            this.mtbConta.Location = new System.Drawing.Point(163, 96);
            this.mtbConta.Mask = "";
            this.mtbConta.Name = "mtbConta";
            this.mtbConta.Size = new System.Drawing.Size(70, 20);
            this.mtbConta.TabIndex = 18;
            // 
            // mtbAgencia
            // 
            this.mtbAgencia.Flags = 0;
            this.mtbAgencia.Location = new System.Drawing.Point(163, 64);
            this.mtbAgencia.Mask = "####";
            this.mtbAgencia.Name = "mtbAgencia";
            this.mtbAgencia.Size = new System.Drawing.Size(70, 20);
            this.mtbAgencia.TabIndex = 17;
            // 
            // brtCancel
            // 
            this.brtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.brtCancel.Location = new System.Drawing.Point(163, 173);
            this.brtCancel.Name = "brtCancel";
            this.brtCancel.Size = new System.Drawing.Size(70, 33);
            this.brtCancel.TabIndex = 26;
            this.brtCancel.Text = "Cancelar";
            this.brtCancel.UseVisualStyleBackColor = true;
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(62, 173);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(70, 33);
            this.btOk.TabIndex = 25;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Número do Cheque";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Conta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Agência";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Banco";
            // 
            // mtbBanco
            // 
            this.mtbBanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mtbBanco.Flags = 0;
            this.mtbBanco.Location = new System.Drawing.Point(163, 32);
            this.mtbBanco.Mask = "";
            this.mtbBanco.Name = "mtbBanco";
            this.mtbBanco.Size = new System.Drawing.Size(70, 20);
            this.mtbBanco.TabIndex = 5;
            // 
            // frmPar02
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.brtCancel;
            this.ClientSize = new System.Drawing.Size(288, 231);
            this.Controls.Add(this.mtbBanco);
            this.Controls.Add(this.mtbCheque);
            this.Controls.Add(this.mtbConta);
            this.Controls.Add(this.mtbAgencia);
            this.Controls.Add(this.brtCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmPar02";
            this.Text = "Dados do Cheque";
            this.Load += new System.EventHandler(this.frmPar02_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AMS.TextBox.MaskedTextBox mtbCheque;
        private AMS.TextBox.MaskedTextBox mtbConta;
        private AMS.TextBox.MaskedTextBox mtbAgencia;
        private System.Windows.Forms.Button brtCancel;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private AMS.TextBox.MaskedTextBox mtbBanco;

    }
}