namespace InterfazUsuario
{
    partial class AgregarPelicula
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.ckbEsApta = new System.Windows.Forms.CheckBox();
            this.ckbEsPatrocinada = new System.Windows.Forms.CheckBox();
            this.cbGeneros = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imgPoster = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbGeneros = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPoster = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitulo.Location = new System.Drawing.Point(310, 17);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(153, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Agregar pelicula";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(86, 69);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(59, 16);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(89, 88);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(263, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(86, 126);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(82, 16);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "Descripción:";
            // 
            // ckbEsApta
            // 
            this.ckbEsApta.AutoSize = true;
            this.ckbEsApta.Location = new System.Drawing.Point(414, 260);
            this.ckbEsApta.Name = "ckbEsApta";
            this.ckbEsApta.Size = new System.Drawing.Size(183, 20);
            this.ckbEsApta.TabIndex = 6;
            this.ckbEsApta.Text = "Es apta para todo público";
            this.ckbEsApta.UseVisualStyleBackColor = true;
            // 
            // ckbEsPatrocinada
            // 
            this.ckbEsPatrocinada.AutoSize = true;
            this.ckbEsPatrocinada.Location = new System.Drawing.Point(414, 289);
            this.ckbEsPatrocinada.Name = "ckbEsPatrocinada";
            this.ckbEsPatrocinada.Size = new System.Drawing.Size(120, 20);
            this.ckbEsPatrocinada.TabIndex = 7;
            this.ckbEsPatrocinada.Text = "Es patrocinada";
            this.ckbEsPatrocinada.UseVisualStyleBackColor = true;
            // 
            // cbGeneros
            // 
            this.cbGeneros.FormattingEnabled = true;
            this.cbGeneros.Location = new System.Drawing.Point(415, 86);
            this.cbGeneros.Name = "cbGeneros";
            this.cbGeneros.Size = new System.Drawing.Size(263, 24);
            this.cbGeneros.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Género:";
            // 
            // imgPoster
            // 
            this.imgPoster.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imgPoster.Location = new System.Drawing.Point(89, 261);
            this.imgPoster.Name = "imgPoster";
            this.imgPoster.Size = new System.Drawing.Size(263, 113);
            this.imgPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPoster.TabIndex = 11;
            this.imgPoster.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAgregar.Location = new System.Drawing.Point(276, 451);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(217, 46);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(89, 146);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(263, 77);
            this.txtDescripcion.TabIndex = 3;
            this.txtDescripcion.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Géneros secundarios:";
            // 
            // lbGeneros
            // 
            this.lbGeneros.FormattingEnabled = true;
            this.lbGeneros.ItemHeight = 16;
            this.lbGeneros.Location = new System.Drawing.Point(415, 146);
            this.lbGeneros.Name = "lbGeneros";
            this.lbGeneros.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbGeneros.Size = new System.Drawing.Size(261, 84);
            this.lbGeneros.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Poster:";
            // 
            // btnPoster
            // 
            this.btnPoster.Location = new System.Drawing.Point(89, 380);
            this.btnPoster.Name = "btnPoster";
            this.btnPoster.Size = new System.Drawing.Size(98, 28);
            this.btnPoster.TabIndex = 5;
            this.btnPoster.Text = "Seleccionar";
            this.btnPoster.UseVisualStyleBackColor = true;
            this.btnPoster.Click += new System.EventHandler(this.btnPoster_Click);
            // 
            // AgregarPelicula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPoster);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbGeneros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.imgPoster);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbGeneros);
            this.Controls.Add(this.ckbEsPatrocinada);
            this.Controls.Add(this.ckbEsApta);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.Name = "AgregarPelicula";
            this.Size = new System.Drawing.Size(794, 533);
            this.Load += new System.EventHandler(this.AgregarPelicula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.CheckBox ckbEsApta;
        private System.Windows.Forms.CheckBox ckbEsPatrocinada;
        private System.Windows.Forms.ComboBox cbGeneros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox imgPoster;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbGeneros;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPoster;
    }
}
