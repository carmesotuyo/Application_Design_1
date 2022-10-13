namespace InterfazUsuario
{
    partial class CrearPerfil
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
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.lblNuevoPerfil = new System.Windows.Forms.Label();
            this.txtPinConfirm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtAlias
            // 
            this.txtAlias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlias.Location = new System.Drawing.Point(277, 161);
            this.txtAlias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(409, 30);
            this.txtAlias.TabIndex = 1;
            this.txtAlias.Text = "Alias";
            // 
            // btnCrear
            // 
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.Location = new System.Drawing.Point(277, 360);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(409, 34);
            this.btnCrear.TabIndex = 4;
            this.btnCrear.Text = "Crear perfil";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtPin
            // 
            this.txtPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPin.Location = new System.Drawing.Point(277, 224);
            this.txtPin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(409, 30);
            this.txtPin.TabIndex = 2;
            this.txtPin.Text = "Pin de seguridad";
            // 
            // lblNuevoPerfil
            // 
            this.lblNuevoPerfil.AutoSize = true;
            this.lblNuevoPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevoPerfil.Location = new System.Drawing.Point(382, 82);
            this.lblNuevoPerfil.Name = "lblNuevoPerfil";
            this.lblNuevoPerfil.Size = new System.Drawing.Size(175, 36);
            this.lblNuevoPerfil.TabIndex = 4;
            this.lblNuevoPerfil.Text = "Nuevo perfil";
            this.lblNuevoPerfil.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPinConfirm
            // 
            this.txtPinConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPinConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPinConfirm.Location = new System.Drawing.Point(277, 289);
            this.txtPinConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPinConfirm.Name = "txtPinConfirm";
            this.txtPinConfirm.Size = new System.Drawing.Size(409, 30);
            this.txtPinConfirm.TabIndex = 3;
            this.txtPinConfirm.Text = "Confirmar pin";
            // 
            // CrearPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.txtPinConfirm);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.lblNuevoPerfil);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CrearPerfil";
            this.Size = new System.Drawing.Size(1000, 750);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label lblNuevoPerfil;
        private System.Windows.Forms.TextBox txtPinConfirm;
    }
}
