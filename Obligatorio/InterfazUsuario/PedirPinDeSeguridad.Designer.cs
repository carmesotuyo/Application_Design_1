namespace InterfazUsuario
{
    partial class PedirPinDeSeguridad
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
            this.lblIngresarPin = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblAtras = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblTitulo.Location = new System.Drawing.Point(416, 107);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(141, 31);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Hola alias!";
            // 
            // lblIngresarPin
            // 
            this.lblIngresarPin.AutoSize = true;
            this.lblIngresarPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblIngresarPin.Location = new System.Drawing.Point(417, 239);
            this.lblIngresarPin.Name = "lblIngresarPin";
            this.lblIngresarPin.Size = new System.Drawing.Size(140, 25);
            this.lblIngresarPin.TabIndex = 2;
            this.lblIngresarPin.Text = "Ingrese su pin:";
            // 
            // txtPin
            // 
            this.txtPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtPin.Location = new System.Drawing.Point(372, 279);
            this.txtPin.Name = "txtPin";
            this.txtPin.PasswordChar = '*';
            this.txtPin.Size = new System.Drawing.Size(225, 41);
            this.txtPin.TabIndex = 3;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnIngresar.Location = new System.Drawing.Point(422, 347);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(130, 47);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblAtras
            // 
            this.lblAtras.AutoSize = true;
            this.lblAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAtras.Location = new System.Drawing.Point(26, 26);
            this.lblAtras.Name = "lblAtras";
            this.lblAtras.Size = new System.Drawing.Size(56, 20);
            this.lblAtras.TabIndex = 5;
            this.lblAtras.TabStop = true;
            this.lblAtras.Text = "Volver";
            this.lblAtras.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAtras_LinkClicked);
            // 
            // PedirPinDeSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblAtras);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.lblIngresarPin);
            this.Controls.Add(this.lblTitulo);
            this.Name = "PedirPinDeSeguridad";
            this.Size = new System.Drawing.Size(1000, 750);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIngresarPin;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.LinkLabel lblAtras;
    }
}
