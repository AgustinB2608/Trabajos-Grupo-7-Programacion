namespace TP1_Grupo_7
{
    partial class Ejercicio2Form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GpbNombreYApellido = new System.Windows.Forms.GroupBox();
            this.TxtApellido = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblApellido = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.GpbElementos = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BtnBorrar = new System.Windows.Forms.Button();
            this.GpbNombreYApellido.SuspendLayout();
            this.GpbElementos.SuspendLayout();
            this.SuspendLayout();
            // 
            // GpbNombreYApellido
            // 
            this.GpbNombreYApellido.Controls.Add(this.TxtApellido);
            this.GpbNombreYApellido.Controls.Add(this.TxtNombre);
            this.GpbNombreYApellido.Controls.Add(this.LblApellido);
            this.GpbNombreYApellido.Controls.Add(this.LblNombre);
            this.GpbNombreYApellido.Controls.Add(this.BtnAgregar);
            this.GpbNombreYApellido.Location = new System.Drawing.Point(12, 26);
            this.GpbNombreYApellido.Name = "GpbNombreYApellido";
            this.GpbNombreYApellido.Size = new System.Drawing.Size(248, 323);
            this.GpbNombreYApellido.TabIndex = 0;
            this.GpbNombreYApellido.TabStop = false;
            this.GpbNombreYApellido.Text = "Ingreso de Datos";
            this.GpbNombreYApellido.Enter += new System.EventHandler(this.GpbNombreYApellido_Enter);
            // 
            // TxtApellido
            // 
            this.TxtApellido.Location = new System.Drawing.Point(99, 138);
            this.TxtApellido.Name = "TxtApellido";
            this.TxtApellido.Size = new System.Drawing.Size(120, 20);
            this.TxtApellido.TabIndex = 4;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(99, 109);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(120, 20);
            this.TxtNombre.TabIndex = 3;
            this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            // 
            // LblApellido
            // 
            this.LblApellido.AutoSize = true;
            this.LblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblApellido.Location = new System.Drawing.Point(35, 141);
            this.LblApellido.Name = "LblApellido";
            this.LblApellido.Size = new System.Drawing.Size(56, 13);
            this.LblApellido.TabIndex = 2;
            this.LblApellido.Text = "Apellido:";
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre.Location = new System.Drawing.Point(35, 109);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(54, 13);
            this.LblNombre.TabIndex = 1;
            this.LblNombre.Text = "Nombre:";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(84, 195);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(80, 40);
            this.BtnAgregar.TabIndex = 0;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // GpbElementos
            // 
            this.GpbElementos.Controls.Add(this.listBox1);
            this.GpbElementos.Controls.Add(this.BtnBorrar);
            this.GpbElementos.Location = new System.Drawing.Point(317, 26);
            this.GpbElementos.Name = "GpbElementos";
            this.GpbElementos.Size = new System.Drawing.Size(255, 323);
            this.GpbElementos.TabIndex = 1;
            this.GpbElementos.TabStop = false;
            this.GpbElementos.Text = "Elementos";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(24, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(207, 238);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 1;
            // 
            // BtnBorrar
            // 
            this.BtnBorrar.Location = new System.Drawing.Point(90, 274);
            this.BtnBorrar.Name = "BtnBorrar";
            this.BtnBorrar.Size = new System.Drawing.Size(80, 40);
            this.BtnBorrar.TabIndex = 0;
            this.BtnBorrar.Text = "Borrar";
            this.BtnBorrar.UseVisualStyleBackColor = true;
            this.BtnBorrar.Click += new System.EventHandler(this.BtnBorrar_Click);
            // 
            // Ejercicio2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.GpbElementos);
            this.Controls.Add(this.GpbNombreYApellido);
            this.Name = "Ejercicio2Form";
            this.Text = "Nombre y Apellido";
            this.GpbNombreYApellido.ResumeLayout(false);
            this.GpbNombreYApellido.PerformLayout();
            this.GpbElementos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GpbNombreYApellido;
        private System.Windows.Forms.TextBox TxtApellido;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label LblApellido;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.GroupBox GpbElementos;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnBorrar;
    }
}