namespace MaestroCliente
{
    partial class Form2
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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.comboBoxTipoDocumento = new System.Windows.Forms.ComboBox();
            this.btnEliminarRegistro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(367, 171);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Razon Social";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(173, 82);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 22);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(173, 171);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(100, 22);
            this.txtRazonSocial.TabIndex = 4;
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(367, 268);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "tipo_documento";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "numero_documento";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(173, 311);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(100, 22);
            this.txtNumeroDocumento.TabIndex = 9;
            // 
            // comboBoxTipoDocumento
            // 
            this.comboBoxTipoDocumento.FormattingEnabled = true;
            this.comboBoxTipoDocumento.Items.AddRange(new object[] {
            "RUC",
            "PASAPORTE",
            "DNI"});
            this.comboBoxTipoDocumento.Location = new System.Drawing.Point(173, 236);
            this.comboBoxTipoDocumento.Name = "comboBoxTipoDocumento";
            this.comboBoxTipoDocumento.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTipoDocumento.TabIndex = 10;
            // 
            // btnEliminarRegistro
            // 
            this.btnEliminarRegistro.Location = new System.Drawing.Point(563, 245);
            this.btnEliminarRegistro.Name = "btnEliminarRegistro";
            this.btnEliminarRegistro.Size = new System.Drawing.Size(106, 55);
            this.btnEliminarRegistro.TabIndex = 11;
            this.btnEliminarRegistro.Text = "Eliminar Registro";
            this.btnEliminarRegistro.UseVisualStyleBackColor = true;
            this.btnEliminarRegistro.Click += new System.EventHandler(this.btnEliminarRegistro_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEliminarRegistro);
            this.Controls.Add(this.comboBoxTipoDocumento);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNuevo);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCodigo;
        public System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtNumeroDocumento;
        public System.Windows.Forms.ComboBox comboBoxTipoDocumento;
        private System.Windows.Forms.Button btnEliminarRegistro;
    }
}