namespace InterfazUsuario
{
    partial class Registro
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
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.LinkLabel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtConfClave = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.Location = new System.Drawing.Point(387, 79);
            this.lblBienvenido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(172, 36);
            this.lblBienvenido.TabIndex = 0;
            this.lblBienvenido.Text = "Bienvenido!";
            this.lblBienvenido.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCrear
            // 
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.Location = new System.Drawing.Point(279, 589);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(409, 34);
            this.btnCrear.TabIndex = 4;
            this.btnCrear.Text = "Crear mi cuenta";
            this.btnCrear.UseVisualStyleBackColor = true;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(275, 655);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(258, 25);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "¿Ya tienes una cuenta?";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(587, 655);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(130, 25);
            this.lblLogin.TabIndex = 6;
            this.lblLogin.TabStop = true;
            this.lblLogin.Text = "Inicia Sesión";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(279, 182);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(409, 30);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.Text = "Correo electrónico";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(279, 253);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(409, 30);
            this.txtUserName.TabIndex = 8;
            this.txtUserName.Text = "Nombre de usuario";
            // 
            // txtClave
            // 
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(279, 325);
            this.txtClave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(409, 30);
            this.txtClave.TabIndex = 9;
            this.txtClave.Text = "Contraseña";
            // 
            // txtConfClave
            // 
            this.txtConfClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfClave.Location = new System.Drawing.Point(279, 398);
            this.txtConfClave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConfClave.Name = "txtConfClave";
            this.txtConfClave.Size = new System.Drawing.Size(409, 30);
            this.txtConfClave.TabIndex = 10;
            this.txtConfClave.Text = "Confirmar contraseña";
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.txtConfClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.lblBienvenido);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Registro";
            this.Size = new System.Drawing.Size(1000, 750);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.LinkLabel lblLogin;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtConfClave;
    }
}
