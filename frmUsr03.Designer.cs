namespace Viagens
{
    partial class frmUsr03
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
            this.components = new System.ComponentModel.Container();
            this.tbSenhaAtual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNovaSenha1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNovaSenha2 = new System.Windows.Forms.TextBox();
            this.btOk = new System.Windows.Forms.Button();
            this.BtCancelar = new System.Windows.Forms.Button();
            this.ep1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tbApelido = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ep1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSenhaAtual
            // 
            this.tbSenhaAtual.Location = new System.Drawing.Point(153, 47);
            this.tbSenhaAtual.Name = "tbSenhaAtual";
            this.tbSenhaAtual.Size = new System.Drawing.Size(120, 20);
            this.tbSenhaAtual.TabIndex = 11;
            this.tbSenhaAtual.Validating += new System.ComponentModel.CancelEventHandler(this.tbSenhaAtual_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Senha Atual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nova Senha";
            // 
            // tbNovaSenha1
            // 
            this.tbNovaSenha1.Location = new System.Drawing.Point(153, 73);
            this.tbNovaSenha1.Name = "tbNovaSenha1";
            this.tbNovaSenha1.Size = new System.Drawing.Size(120, 20);
            this.tbNovaSenha1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirmação da Senha";
            // 
            // tbNovaSenha2
            // 
            this.tbNovaSenha2.Location = new System.Drawing.Point(153, 99);
            this.tbNovaSenha2.Name = "tbNovaSenha2";
            this.tbNovaSenha2.Size = new System.Drawing.Size(120, 20);
            this.tbNovaSenha2.TabIndex = 15;
            this.tbNovaSenha2.Validating += new System.ComponentModel.CancelEventHandler(this.tbNovaSenha2_Validating);
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(55, 137);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 17;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // BtCancelar
            // 
            this.BtCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtCancelar.Location = new System.Drawing.Point(181, 137);
            this.BtCancelar.Name = "BtCancelar";
            this.BtCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtCancelar.TabIndex = 19;
            this.BtCancelar.Text = "Cancelar";
            this.BtCancelar.UseVisualStyleBackColor = true;
            this.BtCancelar.Click += new System.EventHandler(this.BtCancelar_Click);
            // 
            // ep1
            // 
            this.ep1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Usuário";
            // 
            // tbApelido
            // 
            this.tbApelido.Location = new System.Drawing.Point(153, 18);
            this.tbApelido.Name = "tbApelido";
            this.tbApelido.Size = new System.Drawing.Size(120, 20);
            this.tbApelido.TabIndex = 9;
            // 
            // frmUsr03
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtCancelar;
            this.ClientSize = new System.Drawing.Size(298, 172);
            this.Controls.Add(this.tbApelido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtCancelar);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNovaSenha2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNovaSenha1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSenhaAtual);
            this.Name = "frmUsr03";
            this.Text = "Alteração de Senha";
            this.Load += new System.EventHandler(this.frmUsr03_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSenhaAtual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNovaSenha1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNovaSenha2;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button BtCancelar;
        private System.Windows.Forms.ErrorProvider ep1;
        private System.Windows.Forms.TextBox tbApelido;
        private System.Windows.Forms.Label label4;
    }
}