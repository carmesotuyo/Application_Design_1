namespace InterfazUsuario
{
    partial class SeleccionarPerfil
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.flpListaPerfiles = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(381, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de perfiles";
            // 
            // flpListaPerfiles
            // 
            this.flpListaPerfiles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flpListaPerfiles.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.flpListaPerfiles.Location = new System.Drawing.Point(69, 210);
            this.flpListaPerfiles.Name = "flpListaPerfiles";
            this.flpListaPerfiles.Size = new System.Drawing.Size(856, 228);
            this.flpListaPerfiles.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAgregar.Location = new System.Drawing.Point(346, 574);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(289, 59);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar Perfil";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // SeleccionarPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.flpListaPerfiles);
            this.Controls.Add(this.label1);
            this.Name = "SeleccionarPerfil";
            this.Size = new System.Drawing.Size(1000, 750);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpListaPerfiles;
        private System.Windows.Forms.Button btnAgregar;
    }
}
