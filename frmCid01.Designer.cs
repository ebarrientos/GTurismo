namespace Viagens
{
    partial class frmCid01
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
            this.tbCidade = new System.Windows.Forms.TextBox();
            this.tbEstado = new System.Windows.Forms.TextBox();
            this.tbDDD = new System.Windows.Forms.TextBox();
            this.tbPais = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btNovo = new System.Windows.Forms.Button();
            this.btRemover = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.lblTotalPaises = new System.Windows.Forms.Label();
            this.btSelecionar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cidade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "DDD:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Pais";
            // 
            // tbCidade
            // 
            this.tbCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCidade.Location = new System.Drawing.Point(84, 22);
            this.tbCidade.Name = "tbCidade";
            this.tbCidade.Size = new System.Drawing.Size(167, 20);
            this.tbCidade.TabIndex = 21;
            this.tbCidade.TextChanged += new System.EventHandler(this.tbCidade_TextChanged);
            // 
            // tbEstado
            // 
            this.tbEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbEstado.Location = new System.Drawing.Point(84, 49);
            this.tbEstado.Name = "tbEstado";
            this.tbEstado.Size = new System.Drawing.Size(167, 20);
            this.tbEstado.TabIndex = 22;
            this.tbEstado.TextChanged += new System.EventHandler(this.tbEstado_TextChanged);
            // 
            // tbDDD
            // 
            this.tbDDD.Location = new System.Drawing.Point(84, 75);
            this.tbDDD.Name = "tbDDD";
            this.tbDDD.Size = new System.Drawing.Size(167, 20);
            this.tbDDD.TabIndex = 23;
            this.tbDDD.TextChanged += new System.EventHandler(this.tbDDD_TextChanged);
            // 
            // tbPais
            // 
            this.tbPais.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbPais.Location = new System.Drawing.Point(84, 102);
            this.tbPais.Name = "tbPais";
            this.tbPais.ReadOnly = true;
            this.tbPais.Size = new System.Drawing.Size(167, 20);
            this.tbPais.TabIndex = 24;
            this.tbPais.Click += new System.EventHandler(this.textBox4_Click);
            this.tbPais.TextChanged += new System.EventHandler(this.tbPais_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbEstado);
            this.groupBox1.Controls.Add(this.tbPais);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbDDD);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbCidade);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(147, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 136);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fitros";
            // 
            // btNovo
            // 
            this.btNovo.Location = new System.Drawing.Point(27, 33);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(94, 23);
            this.btNovo.TabIndex = 9;
            this.btNovo.Text = "Novo";
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // btRemover
            // 
            this.btRemover.Location = new System.Drawing.Point(27, 90);
            this.btRemover.Name = "btRemover";
            this.btRemover.Size = new System.Drawing.Size(94, 23);
            this.btRemover.TabIndex = 16;
            this.btRemover.Text = "Remover";
            this.btRemover.UseVisualStyleBackColor = true;
            this.btRemover.Click += new System.EventHandler(this.btRemover_Click);
            // 
            // btFechar
            // 
            this.btFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btFechar.Location = new System.Drawing.Point(27, 117);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(94, 23);
            this.btFechar.TabIndex = 18;
            this.btFechar.Text = "Fechar";
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // dgv1
            // 
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(12, 184);
            this.dgv1.Name = "dgv1";
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(408, 159);
            this.dgv1.TabIndex = 20;
            this.dgv1.DataSourceChanged += new System.EventHandler(this.dgv1_DataSourceChanged);
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            this.dgv1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv1_RowHeaderMouseDoubleClick);
            // 
            // lblTotalPaises
            // 
            this.lblTotalPaises.AutoSize = true;
            this.lblTotalPaises.Location = new System.Drawing.Point(315, 352);
            this.lblTotalPaises.Name = "lblTotalPaises";
            this.lblTotalPaises.Size = new System.Drawing.Size(0, 13);
            this.lblTotalPaises.TabIndex = 13;
            // 
            // btSelecionar
            // 
            this.btSelecionar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSelecionar.Location = new System.Drawing.Point(27, 64);
            this.btSelecionar.Name = "btSelecionar";
            this.btSelecionar.Size = new System.Drawing.Size(94, 23);
            this.btSelecionar.TabIndex = 14;
            this.btSelecionar.Text = "Selecionar";
            this.btSelecionar.UseVisualStyleBackColor = true;
            this.btSelecionar.Click += new System.EventHandler(this.dtSelecionar_Click);
            // 
            // frmCid01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 374);
            this.Controls.Add(this.btSelecionar);
            this.Controls.Add(this.lblTotalPaises);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.btRemover);
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCid01";
            this.Text = "Cadastro de Cidades";
            this.Load += new System.EventHandler(this.frmCid01_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCidade;
        private System.Windows.Forms.TextBox tbEstado;
        private System.Windows.Forms.TextBox tbDDD;
        private System.Windows.Forms.TextBox tbPais;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Button btRemover;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label lblTotalPaises;
        private System.Windows.Forms.Button btSelecionar;
    }
}