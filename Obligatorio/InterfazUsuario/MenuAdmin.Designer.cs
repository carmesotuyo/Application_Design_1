﻿namespace InterfazUsuario
{
    partial class MenuAdmin
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
            this.lblPerfil = new System.Windows.Forms.LinkLabel();
            this.btnAltaPeli = new System.Windows.Forms.Button();
            this.btnBajaPeli = new System.Windows.Forms.Button();
            this.btnAltaGenero = new System.Windows.Forms.Button();
            this.btnBajaGenero = new System.Windows.Forms.Button();
            this.btnSorting = new System.Windows.Forms.Button();
            this.flpAdministrador = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAtras = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPerfil.Location = new System.Drawing.Point(13, 10);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(55, 25);
            this.lblPerfil.TabIndex = 0;
            this.lblPerfil.TabStop = true;
            this.lblPerfil.Text = "Perfil";
            this.lblPerfil.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPerfil_LinkClicked);
            // 
            // btnAltaPeli
            // 
            this.btnAltaPeli.Location = new System.Drawing.Point(82, 61);
            this.btnAltaPeli.Name = "btnAltaPeli";
            this.btnAltaPeli.Size = new System.Drawing.Size(140, 40);
            this.btnAltaPeli.TabIndex = 4;
            this.btnAltaPeli.Text = "Agregar pelicula";
            this.btnAltaPeli.UseVisualStyleBackColor = true;
            this.btnAltaPeli.Click += new System.EventHandler(this.btnAltaPeli_Click);
            // 
            // btnBajaPeli
            // 
            this.btnBajaPeli.Location = new System.Drawing.Point(245, 61);
            this.btnBajaPeli.Name = "btnBajaPeli";
            this.btnBajaPeli.Size = new System.Drawing.Size(140, 40);
            this.btnBajaPeli.TabIndex = 5;
            this.btnBajaPeli.Text = "Quitar pelicula";
            this.btnBajaPeli.UseVisualStyleBackColor = true;
            this.btnBajaPeli.Click += new System.EventHandler(this.btnBajaPeli_Click_1);
            // 
            // btnAltaGenero
            // 
            this.btnAltaGenero.Location = new System.Drawing.Point(574, 61);
            this.btnAltaGenero.Name = "btnAltaGenero";
            this.btnAltaGenero.Size = new System.Drawing.Size(140, 40);
            this.btnAltaGenero.TabIndex = 6;
            this.btnAltaGenero.Text = "Agregar género";
            this.btnAltaGenero.UseVisualStyleBackColor = true;
            this.btnAltaGenero.Click += new System.EventHandler(this.btnAltaGenero_Click);
            // 
            // btnBajaGenero
            // 
            this.btnBajaGenero.Location = new System.Drawing.Point(736, 61);
            this.btnBajaGenero.Name = "btnBajaGenero";
            this.btnBajaGenero.Size = new System.Drawing.Size(140, 40);
            this.btnBajaGenero.TabIndex = 7;
            this.btnBajaGenero.Text = "Quitar género";
            this.btnBajaGenero.UseVisualStyleBackColor = true;
            this.btnBajaGenero.Click += new System.EventHandler(this.btnBajaGenero_Click);
            // 
            // btnSorting
            // 
            this.btnSorting.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSorting.Location = new System.Drawing.Point(409, 61);
            this.btnSorting.Name = "btnSorting";
            this.btnSorting.Size = new System.Drawing.Size(140, 40);
            this.btnSorting.TabIndex = 8;
            this.btnSorting.Text = "Ordenar peliculas";
            this.btnSorting.UseVisualStyleBackColor = false;
            this.btnSorting.Click += new System.EventHandler(this.btnSorting_Click);
            // 
            // flpAdministrador
            // 
            this.flpAdministrador.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flpAdministrador.Location = new System.Drawing.Point(82, 131);
            this.flpAdministrador.Name = "flpAdministrador";
            this.flpAdministrador.Size = new System.Drawing.Size(794, 533);
            this.flpAdministrador.TabIndex = 9;
            // 
            // lblAtras
            // 
            this.lblAtras.AutoSize = true;
            this.lblAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblAtras.Location = new System.Drawing.Point(821, 10);
            this.lblAtras.Name = "lblAtras";
            this.lblAtras.Size = new System.Drawing.Size(73, 31);
            this.lblAtras.TabIndex = 10;
            this.lblAtras.TabStop = true;
            this.lblAtras.Text = "Atras";
            this.lblAtras.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAtras_LinkClicked);
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.lblAtras);
            this.Controls.Add(this.flpAdministrador);
            this.Controls.Add(this.btnSorting);
            this.Controls.Add(this.btnBajaGenero);
            this.Controls.Add(this.btnAltaGenero);
            this.Controls.Add(this.btnBajaPeli);
            this.Controls.Add(this.btnAltaPeli);
            this.Controls.Add(this.lblPerfil);
            this.Name = "MenuAdmin";
            this.Size = new System.Drawing.Size(1000, 750);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblPerfil;
        private System.Windows.Forms.Button btnAltaPeli;
        private System.Windows.Forms.Button btnBajaPeli;
        private System.Windows.Forms.Button btnAltaGenero;
        private System.Windows.Forms.Button btnBajaGenero;
        private System.Windows.Forms.Button btnSorting;
        private System.Windows.Forms.FlowLayoutPanel flpAdministrador;
        private System.Windows.Forms.LinkLabel lblAtras;
    }
}
