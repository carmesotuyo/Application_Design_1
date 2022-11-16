namespace InterfazUsuario
{
    partial class AsociarPersona
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
            this.LBPersonas = new System.Windows.Forms.ListBox();
            this.CBPeliculas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CBPersonas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LBPapeles = new System.Windows.Forms.ListBox();
            this.btnDesasociarDirector = new System.Windows.Forms.Button();
            this.btnDesasociarPapel = new System.Windows.Forms.Button();
            this.RBDirector = new System.Windows.Forms.RadioButton();
            this.RBActor = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPapel = new System.Windows.Forms.TextBox();
            this.btnAsociar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitulo.Location = new System.Drawing.Point(283, 19);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(240, 31);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Asociar / Desasociar";
            // 
            // LBPersonas
            // 
            this.LBPersonas.FormattingEnabled = true;
            this.LBPersonas.ItemHeight = 16;
            this.LBPersonas.Location = new System.Drawing.Point(104, 156);
            this.LBPersonas.Name = "LBPersonas";
            this.LBPersonas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LBPersonas.Size = new System.Drawing.Size(233, 100);
            this.LBPersonas.TabIndex = 7;
            // 
            // CBPeliculas
            // 
            this.CBPeliculas.FormattingEnabled = true;
            this.CBPeliculas.Location = new System.Drawing.Point(272, 85);
            this.CBPeliculas.Name = "CBPeliculas";
            this.CBPeliculas.Size = new System.Drawing.Size(233, 24);
            this.CBPeliculas.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Seleccionar Pelicula:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Asociar Persona:";
            // 
            // CBPersonas
            // 
            this.CBPersonas.FormattingEnabled = true;
            this.CBPersonas.Location = new System.Drawing.Point(476, 161);
            this.CBPersonas.Name = "CBPersonas";
            this.CBPersonas.Size = new System.Drawing.Size(233, 24);
            this.CBPersonas.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Directores:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Papeles:";
            // 
            // LBPapeles
            // 
            this.LBPapeles.FormattingEnabled = true;
            this.LBPapeles.ItemHeight = 16;
            this.LBPapeles.Location = new System.Drawing.Point(106, 329);
            this.LBPapeles.Name = "LBPapeles";
            this.LBPapeles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LBPapeles.Size = new System.Drawing.Size(233, 100);
            this.LBPapeles.TabIndex = 13;
            // 
            // btnDesasociarDirector
            // 
            this.btnDesasociarDirector.Location = new System.Drawing.Point(104, 262);
            this.btnDesasociarDirector.Name = "btnDesasociarDirector";
            this.btnDesasociarDirector.Size = new System.Drawing.Size(107, 26);
            this.btnDesasociarDirector.TabIndex = 15;
            this.btnDesasociarDirector.Text = "Desasociar";
            this.btnDesasociarDirector.UseVisualStyleBackColor = true;
            // 
            // btnDesasociarPapel
            // 
            this.btnDesasociarPapel.Location = new System.Drawing.Point(106, 435);
            this.btnDesasociarPapel.Name = "btnDesasociarPapel";
            this.btnDesasociarPapel.Size = new System.Drawing.Size(105, 30);
            this.btnDesasociarPapel.TabIndex = 16;
            this.btnDesasociarPapel.Text = "Desasociar";
            this.btnDesasociarPapel.UseVisualStyleBackColor = true;
            // 
            // RBDirector
            // 
            this.RBDirector.AutoSize = true;
            this.RBDirector.Location = new System.Drawing.Point(476, 191);
            this.RBDirector.Name = "RBDirector";
            this.RBDirector.Size = new System.Drawing.Size(75, 20);
            this.RBDirector.TabIndex = 17;
            this.RBDirector.Text = "Director";
            this.RBDirector.UseVisualStyleBackColor = true;
            this.RBDirector.CheckedChanged += new System.EventHandler(this.RBDirector_CheckedChanged);
            // 
            // RBActor
            // 
            this.RBActor.AutoSize = true;
            this.RBActor.Checked = true;
            this.RBActor.Location = new System.Drawing.Point(646, 191);
            this.RBActor.Name = "RBActor";
            this.RBActor.Size = new System.Drawing.Size(59, 20);
            this.RBActor.TabIndex = 18;
            this.RBActor.TabStop = true;
            this.RBActor.Text = "Actor";
            this.RBActor.UseVisualStyleBackColor = true;
            this.RBActor.CheckedChanged += new System.EventHandler(this.RBActor_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Papel:";
            // 
            // txtPapel
            // 
            this.txtPapel.Location = new System.Drawing.Point(476, 249);
            this.txtPapel.Name = "txtPapel";
            this.txtPapel.Size = new System.Drawing.Size(233, 22);
            this.txtPapel.TabIndex = 20;
            // 
            // btnAsociar
            // 
            this.btnAsociar.Location = new System.Drawing.Point(523, 278);
            this.btnAsociar.Name = "btnAsociar";
            this.btnAsociar.Size = new System.Drawing.Size(151, 53);
            this.btnAsociar.TabIndex = 21;
            this.btnAsociar.Text = "Asociar";
            this.btnAsociar.UseVisualStyleBackColor = true;
            // 
            // AsociarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAsociar);
            this.Controls.Add(this.txtPapel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RBActor);
            this.Controls.Add(this.RBDirector);
            this.Controls.Add(this.btnDesasociarPapel);
            this.Controls.Add(this.btnDesasociarDirector);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LBPapeles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CBPersonas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBPeliculas);
            this.Controls.Add(this.LBPersonas);
            this.Controls.Add(this.lblTitulo);
            this.Name = "AsociarPersona";
            this.Size = new System.Drawing.Size(794, 533);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListBox LBPersonas;
        private System.Windows.Forms.ComboBox CBPeliculas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBPersonas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox LBPapeles;
        private System.Windows.Forms.Button btnDesasociarDirector;
        private System.Windows.Forms.Button btnDesasociarPapel;
        private System.Windows.Forms.RadioButton RBDirector;
        private System.Windows.Forms.RadioButton RBActor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPapel;
        private System.Windows.Forms.Button btnAsociar;
    }
}
