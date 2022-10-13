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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPeriles = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtAlias
            // 
            this.txtAlias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlias.Location = new System.Drawing.Point(277, 205);
            this.txtAlias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(409, 30);
            this.txtAlias.TabIndex = 1;
            // 
            // btnCrear
            // 
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.Location = new System.Drawing.Point(277, 418);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(409, 63);
            this.btnCrear.TabIndex = 4;
            this.btnCrear.Text = "Crear perfil";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtPin
            // 
            this.txtPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPin.Location = new System.Drawing.Point(277, 268);
            this.txtPin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPin.Name = "txtPin";
            this.txtPin.PasswordChar = '*';
            this.txtPin.Size = new System.Drawing.Size(409, 30);
            this.txtPin.TabIndex = 2;
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
            this.txtPinConfirm.Location = new System.Drawing.Point(277, 333);
            this.txtPinConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPinConfirm.Name = "txtPinConfirm";
            this.txtPinConfirm.PasswordChar = '*';
            this.txtPinConfirm.Size = new System.Drawing.Size(409, 30);
            this.txtPinConfirm.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(273, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Alias:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(273, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Pin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(273, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Confirmar Pin:";
            // 
            // lblPeriles
            // 
            this.lblPeriles.AutoSize = true;
            this.lblPeriles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPeriles.Location = new System.Drawing.Point(22, 17);
            this.lblPeriles.Name = "lblPeriles";
            this.lblPeriles.Size = new System.Drawing.Size(76, 25);
            this.lblPeriles.TabIndex = 11;
            this.lblPeriles.TabStop = true;
            this.lblPeriles.Text = "Perfiles";
            this.lblPeriles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPeriles_LinkClicked);
            // 
            // CrearPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblPeriles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lblPeriles;
    }
}
