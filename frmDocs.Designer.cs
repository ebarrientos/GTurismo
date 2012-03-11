namespace Viagens
{
    partial class frmDocs
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
            this.btNovo = new System.Windows.Forms.Button();
            this.btRemover = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.ofdDoc = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            this.SuspendLayout();
            // 
            // btNovo
            // 
            this.btNovo.Location = new System.Drawing.Point(12, 12);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(116, 28);
            this.btNovo.TabIndex = 0;
            this.btNovo.Text = "Novo";
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // btRemover
            // 
            this.btRemover.Location = new System.Drawing.Point(12, 46);
            this.btRemover.Name = "btRemover";
            this.btRemover.Size = new System.Drawing.Size(116, 28);
            this.btRemover.TabIndex = 1;
            this.btRemover.Text = "Eliminar";
            this.btRemover.UseVisualStyleBackColor = true;
            this.btRemover.Click += new System.EventHandler(this.btRemover_Click);
            // 
            // btFechar
            // 
            this.btFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btFechar.Location = new System.Drawing.Point(12, 80);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(116, 28);
            this.btFechar.TabIndex = 2;
            this.btFechar.Text = "Cancelar";
            this.btFechar.UseVisualStyleBackColor = true;
            // 
            // dgvDocs
            // 
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDocs.Location = new System.Drawing.Point(0, 164);
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.Size = new System.Drawing.Size(787, 232);
            this.dgvDocs.TabIndex = 3;
            // 
            // ofdDoc
            // 
            this.ofdDoc.Multiselect = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(12, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Fechar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 396);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvDocs);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.btRemover);
            this.Controls.Add(this.btNovo);
            this.Name = "frmDocs";
            this.Text = "Cadastro de Documentos";
            this.Load += new System.EventHandler(this.frmDocs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Button btRemover;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.OpenFileDialog ofdDoc;
        private System.Windows.Forms.Button button1;
    }
}