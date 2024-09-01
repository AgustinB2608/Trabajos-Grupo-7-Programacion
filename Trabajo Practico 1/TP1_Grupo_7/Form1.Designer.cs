namespace TP1_Grupo_7
{
    partial class FormularioPrincipal
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnEjercicio1 = new System.Windows.Forms.Button();
            this.BtnEjercicio2 = new System.Windows.Forms.Button();
            this.BtnEjercicio3 = new System.Windows.Forms.Button();
            this.LblIntegrantes = new System.Windows.Forms.Label();
            this.LstIntegrantes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // BtnEjercicio1
            // 
            this.BtnEjercicio1.BackColor = System.Drawing.Color.LightGray;
            this.BtnEjercicio1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnEjercicio1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEjercicio1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEjercicio1.Location = new System.Drawing.Point(61, 63);
            this.BtnEjercicio1.Name = "BtnEjercicio1";
            this.BtnEjercicio1.Size = new System.Drawing.Size(100, 50);
            this.BtnEjercicio1.TabIndex = 0;
            this.BtnEjercicio1.Text = "EJERCICIO 1";
            this.BtnEjercicio1.UseVisualStyleBackColor = false;
            this.BtnEjercicio1.Click += new System.EventHandler(this.BtnEjercicio1_Click);
            // 
            // BtnEjercicio2
            // 
            this.BtnEjercicio2.BackColor = System.Drawing.Color.LightGray;
            this.BtnEjercicio2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnEjercicio2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEjercicio2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEjercicio2.Location = new System.Drawing.Point(167, 63);
            this.BtnEjercicio2.Name = "BtnEjercicio2";
            this.BtnEjercicio2.Size = new System.Drawing.Size(100, 50);
            this.BtnEjercicio2.TabIndex = 1;
            this.BtnEjercicio2.Text = "EJERCICIO 2";
            this.BtnEjercicio2.UseVisualStyleBackColor = false;
            this.BtnEjercicio2.Click += new System.EventHandler(this.BtnEjercicio2_Click);
            // 
            // BtnEjercicio3
            // 
            this.BtnEjercicio3.BackColor = System.Drawing.Color.LightGray;
            this.BtnEjercicio3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnEjercicio3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEjercicio3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEjercicio3.Location = new System.Drawing.Point(273, 63);
            this.BtnEjercicio3.Name = "BtnEjercicio3";
            this.BtnEjercicio3.Size = new System.Drawing.Size(100, 50);
            this.BtnEjercicio3.TabIndex = 2;
            this.BtnEjercicio3.Text = "EJERCICIO 3";
            this.BtnEjercicio3.UseVisualStyleBackColor = false;
            this.BtnEjercicio3.Click += new System.EventHandler(this.BtnEjercicio3_Click);
            // 
            // LblIntegrantes
            // 
            this.LblIntegrantes.AutoSize = true;
            this.LblIntegrantes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIntegrantes.Location = new System.Drawing.Point(58, 148);
            this.LblIntegrantes.Name = "LblIntegrantes";
            this.LblIntegrantes.Size = new System.Drawing.Size(86, 20);
            this.LblIntegrantes.TabIndex = 3;
            this.LblIntegrantes.Text = "Integrantes:";
            // 
            // LstIntegrantes
            // 
            this.LstIntegrantes.BackColor = System.Drawing.Color.LightGray;
            this.LstIntegrantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LstIntegrantes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstIntegrantes.FormattingEnabled = true;
            this.LstIntegrantes.ItemHeight = 16;
            this.LstIntegrantes.Items.AddRange(new object[] {
            "Agustin Abraham Bernal",
            "Oriana Belén Manrique",
            "Abril Agustina López",
            "Maximiliano Fabeiro",
            "Juan Manuel Asselborn"});
            this.LstIntegrantes.Location = new System.Drawing.Point(121, 181);
            this.LstIntegrantes.Name = "LstIntegrantes";
            this.LstIntegrantes.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.LstIntegrantes.Size = new System.Drawing.Size(146, 96);
            this.LstIntegrantes.TabIndex = 10;
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(432, 327);
            this.Controls.Add(this.LstIntegrantes);
            this.Controls.Add(this.LblIntegrantes);
            this.Controls.Add(this.BtnEjercicio3);
            this.Controls.Add(this.BtnEjercicio2);
            this.Controls.Add(this.BtnEjercicio1);
            this.Name = "FormularioPrincipal";
            this.Text = "Formulario Principal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEjercicio1;
        private System.Windows.Forms.Button BtnEjercicio2;
        private System.Windows.Forms.Button BtnEjercicio3;
        private System.Windows.Forms.Label LblIntegrantes;
        private System.Windows.Forms.ListBox LstIntegrantes;
    }
}

