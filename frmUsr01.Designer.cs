namespace Viagens
{
    partial class frmUsr01
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
            this.btEditar = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.btBloqueio = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btMudaSenha = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btEditar
            // 
            this.btEditar.Location = new System.Drawing.Point(73, 55);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(133, 23);
            this.btEditar.TabIndex = 19;
            this.btEditar.Text = "Editar";
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // btFechar
            // 
            this.btFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btFechar.Location = new System.Drawing.Point(25, 96);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(133, 23);
            this.btFechar.TabIndex = 13;
            this.btFechar.Text = "Fechar";
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btBloqueio
            // 
            this.btBloqueio.Location = new System.Drawing.Point(73, 84);
            this.btBloqueio.Name = "btBloqueio";
            this.btBloqueio.Size = new System.Drawing.Size(133, 23);
            this.btBloqueio.TabIndex = 21;
            this.btBloqueio.Text = "Bloquear/Desbloquear";
            this.btBloqueio.UseVisualStyleBackColor = true;
            this.btBloqueio.Click += new System.EventHandler(this.btBloqueio_Click);
            // 
            // btNovo
            // 
            this.btNovo.Location = new System.Drawing.Point(73, 26);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(133, 23);
            this.btNovo.TabIndex = 17;
            this.btNovo.Text = "Novo";
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(25, 149);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(507, 156);
            this.dgvUsuarios.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btNovo);
            this.groupBox1.Controls.Add(this.btEditar);
            this.groupBox1.Controls.Add(this.btBloqueio);
            this.groupBox1.Location = new System.Drawing.Point(281, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 118);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administração de Usuários";
            // 
            // btMudaSenha
            // 
            this.btMudaSenha.Location = new System.Drawing.Point(25, 38);
            this.btMudaSenha.Name = "btMudaSenha";
            this.btMudaSenha.Size = new System.Drawing.Size(133, 23);
            this.btMudaSenha.TabIndex = 11;
            this.btMudaSenha.Text = "Mudar Senha";
            this.btMudaSenha.UseVisualStyleBackColor = true;
            this.btMudaSenha.Click += new System.EventHandler(this.btMudaSenha_Click);
            // 
            // frmUsr01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btFechar;
            this.ClientSize = new System.Drawing.Size(544, 329);
            this.Controls.Add(this.btMudaSenha);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btFechar);
            this.Name = "frmUsr01";
            this.Text = "Pesquisa de Usuários";
            this.Load += new System.EventHandler(this.frmUsr01_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btBloqueio;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btMudaSenha;
    }
}