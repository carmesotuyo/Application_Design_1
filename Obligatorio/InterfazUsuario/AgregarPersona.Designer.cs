namespace InterfazUsuario
{
    partial class AgregarPersona
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.DTFechaNac = new System.Windows.Forms.DateTimePicker();
            this.btnFoto = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.imgPoster = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitulo.Location = new System.Drawing.Point(278, 34);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(206, 25);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Agregar Actor/Director";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAgregar.Location = new System.Drawing.Point(267, 448);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(217, 46);
            this.btnAgregar.TabIndex = 16;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(252, 149);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(169, 20);
            this.lblFechaNac.TabIndex = 18;
            this.lblFechaNac.Text = "Fecha de nacimiento:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(255, 112);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(263, 22);
            this.txtNombre.TabIndex = 14;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(252, 92);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 16);
            this.lblNombre.TabIndex = 17;
            this.lblNombre.Text = "Nombre";
            // 
            // DTFechaNac
            // 
            this.DTFechaNac.Location = new System.Drawing.Point(257, 175);
            this.DTFechaNac.Name = "DTFechaNac";
            this.DTFechaNac.Size = new System.Drawing.Size(260, 22);
            this.DTFechaNac.TabIndex = 19;
            // 
            // btnFoto
            // 
            this.btnFoto.Location = new System.Drawing.Point(257, 349);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(98, 28);
            this.btnFoto.TabIndex = 20;
            this.btnFoto.Text = "Seleccionar";
            this.btnFoto.UseVisualStyleBackColor = true;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Foto Perfil:";
            // 
            // imgPoster
            // 
            this.imgPoster.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imgPoster.Location = new System.Drawing.Point(257, 230);
            this.imgPoster.Name = "imgPoster";
            this.imgPoster.Size = new System.Drawing.Size(136, 113);
            this.imgPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPoster.TabIndex = 21;
            this.imgPoster.TabStop = false;
            // 
            // AgregarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFoto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.imgPoster);
            this.Controls.Add(this.DTFechaNac);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.Name = "AgregarPersona";
            this.Size = new System.Drawing.Size(794, 533);
            ((System.ComponentModel.ISupportInitialize)(this.imgPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.DateTimePicker DTFechaNac;
        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox imgPoster;
    }
}
