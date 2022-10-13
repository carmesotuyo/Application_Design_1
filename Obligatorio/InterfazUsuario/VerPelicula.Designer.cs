namespace InterfazUsuario
{
    partial class VerPelicula
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
            this.imgPelicula = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblApta = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.btnNegativo = new System.Windows.Forms.Button();
            this.btnPositivo = new System.Windows.Forms.Button();
            this.btnMuyPositivo = new System.Windows.Forms.Button();
            this.btnVista = new System.Windows.Forms.Button();
            this.lblVolver = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.imgPelicula)).BeginInit();
            this.SuspendLayout();
            // 
            // imgPelicula
            // 
            this.imgPelicula.Location = new System.Drawing.Point(164, 108);
            this.imgPelicula.Name = "imgPelicula";
            this.imgPelicula.Size = new System.Drawing.Size(652, 364);
            this.imgPelicula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPelicula.TabIndex = 0;
            this.imgPelicula.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(159, 487);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(147, 20);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre Pelicula";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblGenero.Location = new System.Drawing.Point(159, 517);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(194, 20);
            this.lblGenero.TabIndex = 2;
            this.lblGenero.Text = "Genero: GeneroPrincipal";
            // 
            // lblApta
            // 
            this.lblApta.AutoSize = true;
            this.lblApta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblApta.Location = new System.Drawing.Point(639, 487);
            this.lblApta.Name = "lblApta";
            this.lblApta.Size = new System.Drawing.Size(176, 20);
            this.lblApta.TabIndex = 4;
            this.lblApta.Text = "Apta para todo público";
            this.lblApta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDescripcion.Location = new System.Drawing.Point(164, 548);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(651, 87);
            this.txtDescripcion.TabIndex = 5;
            this.txtDescripcion.Text = "Descripción";
            // 
            // btnNegativo
            // 
            this.btnNegativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnNegativo.Location = new System.Drawing.Point(164, 641);
            this.btnNegativo.Name = "btnNegativo";
            this.btnNegativo.Size = new System.Drawing.Size(57, 35);
            this.btnNegativo.TabIndex = 1;
            this.btnNegativo.Text = "-1";
            this.btnNegativo.UseVisualStyleBackColor = true;
            this.btnNegativo.Click += new System.EventHandler(this.btnNegativo_Click);
            // 
            // btnPositivo
            // 
            this.btnPositivo.Location = new System.Drawing.Point(237, 642);
            this.btnPositivo.Name = "btnPositivo";
            this.btnPositivo.Size = new System.Drawing.Size(57, 35);
            this.btnPositivo.TabIndex = 2;
            this.btnPositivo.Text = "+1";
            this.btnPositivo.UseVisualStyleBackColor = true;
            this.btnPositivo.Click += new System.EventHandler(this.btnPositivo_Click);
            // 
            // btnMuyPositivo
            // 
            this.btnMuyPositivo.Location = new System.Drawing.Point(311, 642);
            this.btnMuyPositivo.Name = "btnMuyPositivo";
            this.btnMuyPositivo.Size = new System.Drawing.Size(57, 35);
            this.btnMuyPositivo.TabIndex = 3;
            this.btnMuyPositivo.Text = "++1";
            this.btnMuyPositivo.UseVisualStyleBackColor = true;
            this.btnMuyPositivo.Click += new System.EventHandler(this.btnMuyPositivo_Click);
            // 
            // btnVista
            // 
            this.btnVista.Location = new System.Drawing.Point(680, 641);
            this.btnVista.Name = "btnVista";
            this.btnVista.Size = new System.Drawing.Size(136, 35);
            this.btnVista.TabIndex = 4;
            this.btnVista.Text = "Marcar como vista";
            this.btnVista.UseVisualStyleBackColor = true;
            this.btnVista.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblVolver
            // 
            this.lblVolver.AutoSize = true;
            this.lblVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblVolver.Location = new System.Drawing.Point(18, 16);
            this.lblVolver.Name = "lblVolver";
            this.lblVolver.Size = new System.Drawing.Size(56, 20);
            this.lblVolver.TabIndex = 6;
            this.lblVolver.TabStop = true;
            this.lblVolver.Text = "Volver";
            this.lblVolver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblVolver_LinkClicked);
            // 
            // VerPelicula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblVolver);
            this.Controls.Add(this.btnVista);
            this.Controls.Add(this.btnMuyPositivo);
            this.Controls.Add(this.btnPositivo);
            this.Controls.Add(this.btnNegativo);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblApta);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.imgPelicula);
            this.Name = "VerPelicula";
            this.Size = new System.Drawing.Size(1000, 750);
            ((System.ComponentModel.ISupportInitialize)(this.imgPelicula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgPelicula;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblApta;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Button btnNegativo;
        private System.Windows.Forms.Button btnPositivo;
        private System.Windows.Forms.Button btnMuyPositivo;
        private System.Windows.Forms.Button btnVista;
        private System.Windows.Forms.LinkLabel lblVolver;
    }
}
