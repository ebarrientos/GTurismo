namespace Viagens
{
    partial class frmUsr02
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
            this.label5 = new System.Windows.Forms.Label();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.atbApelido = new AMS.TextBox.AlphanumericTextBox();
            this.tbPasswd = new System.Windows.Forms.TextBox();
            this.cbTipoUsr = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Senha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Apelido";
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(99, 69);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(169, 20);
            this.tbNome.TabIndex = 9;
            // 
            // atbApelido
            // 
            this.atbApelido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.atbApelido.Flags = 0;
            this.atbApelido.InvalidChars = new char[] {
        '%',
        '\'',
        '*',
        '\"',
        '+',
        '?',
        '>',
        '<',
        ':',
        '\\'};
            this.atbApelido.Location = new System.Drawing.Point(99, 38);
            this.atbApelido.MaxLength = 20;
            this.atbApelido.Name = "atbApelido";
            this.atbApelido.Size = new System.Drawing.Size(100, 20);
            this.atbApelido.TabIndex = 7;
            // 
            // tbPasswd
            // 
            this.tbPasswd.Location = new System.Drawing.Point(99, 100);
            this.tbPasswd.Name = "tbPasswd";
            this.tbPasswd.Size = new System.Drawing.Size(100, 20);
            this.tbPasswd.TabIndex = 11;
            // 
            // cbTipoUsr
            // 
            this.cbTipoUsr.FormattingEnabled = true;
            this.cbTipoUsr.Location = new System.Drawing.Point(99, 137);
            this.cbTipoUsr.Name = "cbTipoUsr";
            this.cbTipoUsr.Size = new System.Drawing.Size(141, 21);
            this.cbTipoUsr.TabIndex = 13;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(99, 169);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(141, 21);
            this.cbStatus.TabIndex = 15;
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(41, 226);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 17;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(165, 226);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 19;
            this.btCancel.Text = "Cancelar";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // frmUsr02
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(292, 272);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbTipoUsr);
            this.Controls.Add(this.tbPasswd);
            this.Controls.Add(this.atbApelido);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmUsr02";
            this.Text = "Dados do Usuário";
            this.Load += new System.EventHandler(this.frmUsr02_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNome;
        private AMS.TextBox.AlphanumericTextBox atbApelido;
        private System.Windows.Forms.TextBox tbPasswd;
        private System.Windows.Forms.ComboBox cbTipoUsr;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
    }
}