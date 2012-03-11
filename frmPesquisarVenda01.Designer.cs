namespace Viagens
{
    partial class frmPesquisarVenda01
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDataF = new System.Windows.Forms.DateTimePicker();
            this.dtpDataI = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFornecedor = new System.Windows.Forms.TextBox();
            this.tbProduto = new System.Windows.Forms.TextBox();
            this.tbCidade = new System.Windows.Forms.TextBox();
            this.tbCliente = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.btSelecionar = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpDataF);
            this.groupBox1.Controls.Add(this.dtpDataI);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbStatus);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbFornecedor);
            this.groupBox1.Controls.Add(this.tbProduto);
            this.groupBox1.Controls.Add(this.tbCidade);
            this.groupBox1.Controls.Add(this.tbCliente);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(249, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 165);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // dtpDataF
            // 
            this.dtpDataF.Location = new System.Drawing.Point(275, 102);
            this.dtpDataF.Name = "dtpDataF";
            this.dtpDataF.Size = new System.Drawing.Size(200, 20);
            this.dtpDataF.TabIndex = 44;
            this.dtpDataF.ValueChanged += new System.EventHandler(this.dtpDataF_ValueChanged);
            // 
            // dtpDataI
            // 
            this.dtpDataI.Location = new System.Drawing.Point(275, 49);
            this.dtpDataI.Name = "dtpDataI";
            this.dtpDataI.Size = new System.Drawing.Size(200, 20);
            this.dtpDataI.TabIndex = 43;
            this.dtpDataI.ValueChanged += new System.EventHandler(this.dtpDataI_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Data Final";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Ativa",
            "Finalizada",
            "Cancelada"});
            this.cbStatus.Location = new System.Drawing.Point(89, 126);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(150, 21);
            this.cbStatus.TabIndex = 40;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Status";
            // 
            // tbFornecedor
            // 
            this.tbFornecedor.Location = new System.Drawing.Point(89, 102);
            this.tbFornecedor.Name = "tbFornecedor";
            this.tbFornecedor.ReadOnly = true;
            this.tbFornecedor.Size = new System.Drawing.Size(150, 20);
            this.tbFornecedor.TabIndex = 37;
            this.tbFornecedor.Click += new System.EventHandler(this.tbFornecedor_Click);
            this.tbFornecedor.TextChanged += new System.EventHandler(this.tbFornecedor_TextChanged);
            // 
            // tbProduto
            // 
            this.tbProduto.Location = new System.Drawing.Point(89, 50);
            this.tbProduto.Name = "tbProduto";
            this.tbProduto.ReadOnly = true;
            this.tbProduto.Size = new System.Drawing.Size(150, 20);
            this.tbProduto.TabIndex = 33;
            this.tbProduto.Click += new System.EventHandler(this.tbProduto_Click);
            this.tbProduto.TextChanged += new System.EventHandler(this.tbProduto_TextChanged);
            // 
            // tbCidade
            // 
            this.tbCidade.Location = new System.Drawing.Point(89, 76);
            this.tbCidade.Name = "tbCidade";
            this.tbCidade.ReadOnly = true;
            this.tbCidade.Size = new System.Drawing.Size(150, 20);
            this.tbCidade.TabIndex = 35;
            this.tbCidade.Click += new System.EventHandler(this.tbCidade_Click);
            this.tbCidade.TextChanged += new System.EventHandler(this.tbCidade_TextChanged);
            // 
            // tbCliente
            // 
            this.tbCliente.Location = new System.Drawing.Point(89, 24);
            this.tbCliente.Name = "tbCliente";
            this.tbCliente.ReadOnly = true;
            this.tbCliente.Size = new System.Drawing.Size(150, 20);
            this.tbCliente.TabIndex = 31;
            this.tbCliente.Click += new System.EventHandler(this.tbCliente_Click);
            this.tbCliente.TextChanged += new System.EventHandler(this.tbCliente_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(272, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Data Inicial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Operadora";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Produto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Cidade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Cliente";
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(12, 197);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(736, 230);
            this.dgv1.TabIndex = 5;
            // 
            // btSelecionar
            // 
            this.btSelecionar.Location = new System.Drawing.Point(26, 70);
            this.btSelecionar.Name = "btSelecionar";
            this.btSelecionar.Size = new System.Drawing.Size(94, 23);
            this.btSelecionar.TabIndex = 2;
            this.btSelecionar.Text = "Editar";
            this.btSelecionar.UseVisualStyleBackColor = true;
            this.btSelecionar.Click += new System.EventHandler(this.btSelecionar_Click);
            // 
            // btFechar
            // 
            this.btFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btFechar.Location = new System.Drawing.Point(26, 123);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(94, 23);
            this.btFechar.TabIndex = 4;
            this.btFechar.Text = "Fechar";
            this.btFechar.UseVisualStyleBackColor = true;
            // 
            // btEliminar
            // 
            this.btEliminar.Location = new System.Drawing.Point(26, 96);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(94, 23);
            this.btEliminar.TabIndex = 3;
            this.btEliminar.Text = "Remover";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btNovo
            // 
            this.btNovo.Location = new System.Drawing.Point(26, 39);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(94, 23);
            this.btNovo.TabIndex = 1;
            this.btNovo.Text = "Novo";
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // frmPesquisarVenda01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 439);
            this.Controls.Add(this.btSelecionar);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPesquisarVenda01";
            this.Text = "Pesquisa de Vendas";
            this.Load += new System.EventHandler(this.frmPesquisarVenda01_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbFornecedor;
        private System.Windows.Forms.TextBox tbProduto;
        private System.Windows.Forms.TextBox tbCidade;
        private System.Windows.Forms.TextBox tbCliente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDataF;
        private System.Windows.Forms.DateTimePicker dtpDataI;
        private System.Windows.Forms.Button btSelecionar;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btNovo;
    }
}