namespace MaestroCliente
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTipoDocumentoColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NumeroDeDocumentoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarRegistro = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.CodigoColumn,
            this.RazonSocialColumn,
            this.cmbTipoDocumentoColumn,
            this.NumeroDeDocumentoColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(647, 354);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // IdColumn
            // 
            this.IdColumn.DataPropertyName = "id";
            this.IdColumn.HeaderText = "ID";
            this.IdColumn.MinimumWidth = 6;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Width = 125;
            // 
            // CodigoColumn
            // 
            this.CodigoColumn.DataPropertyName = "codigo";
            this.CodigoColumn.HeaderText = "Codigo";
            this.CodigoColumn.MinimumWidth = 6;
            this.CodigoColumn.Name = "CodigoColumn";
            this.CodigoColumn.ReadOnly = true;
            this.CodigoColumn.Width = 125;
            // 
            // RazonSocialColumn
            // 
            this.RazonSocialColumn.DataPropertyName = "razon_social";
            this.RazonSocialColumn.HeaderText = "Razon Social";
            this.RazonSocialColumn.MinimumWidth = 6;
            this.RazonSocialColumn.Name = "RazonSocialColumn";
            this.RazonSocialColumn.ReadOnly = true;
            this.RazonSocialColumn.Width = 125;
            // 
            // cmbTipoDocumentoColumn
            // 
            this.cmbTipoDocumentoColumn.DataPropertyName = "IDtipo_documento";
            this.cmbTipoDocumentoColumn.HeaderText = "Tipo de Documento";
            this.cmbTipoDocumentoColumn.Items.AddRange(new object[] {
            "ruc",
            "pasaporte",
            "dni"});
            this.cmbTipoDocumentoColumn.MinimumWidth = 6;
            this.cmbTipoDocumentoColumn.Name = "cmbTipoDocumentoColumn";
            this.cmbTipoDocumentoColumn.ReadOnly = true;
            this.cmbTipoDocumentoColumn.Width = 125;
            // 
            // NumeroDeDocumentoColumn
            // 
            this.NumeroDeDocumentoColumn.DataPropertyName = "numero_documento";
            this.NumeroDeDocumentoColumn.HeaderText = "Numero de Documento";
            this.NumeroDeDocumentoColumn.MinimumWidth = 6;
            this.NumeroDeDocumentoColumn.Name = "NumeroDeDocumentoColumn";
            this.NumeroDeDocumentoColumn.Width = 125;
            // 
            // btnAgregarRegistro
            // 
            this.btnAgregarRegistro.Location = new System.Drawing.Point(665, 204);
            this.btnAgregarRegistro.Name = "btnAgregarRegistro";
            this.btnAgregarRegistro.Size = new System.Drawing.Size(123, 50);
            this.btnAgregarRegistro.TabIndex = 1;
            this.btnAgregarRegistro.Text = "Agregar Registro";
            this.btnAgregarRegistro.UseVisualStyleBackColor = true;
            this.btnAgregarRegistro.Click += new System.EventHandler(this.btnAgregarRegistro_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(665, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "ExportarExcel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAgregarRegistro);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAgregarRegistro;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocialColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbTipoDocumentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDeDocumentoColumn;
    }
}

