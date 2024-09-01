namespace TP1_Grupo_7
{
    partial class Ejercicio1Form
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
            this.lblNOMBRES = new System.Windows.Forms.Label();
            this.txtNOMBRE = new System.Windows.Forms.TextBox();
            this.btnAÑADIR = new System.Windows.Forms.Button();
            this.lbNombres = new System.Windows.Forms.ListBox();
            this.btnPasar = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnPasarTodos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNOMBRES
            // 
            this.lblNOMBRES.AutoSize = true;
            this.lblNOMBRES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNOMBRES.Location = new System.Drawing.Point(38, 46);
            this.lblNOMBRES.Name = "lblNOMBRES";
            this.lblNOMBRES.Size = new System.Drawing.Size(139, 16);
            this.lblNOMBRES.TabIndex = 0;
            this.lblNOMBRES.Text = "Ingrese un nombre:";
            // 
            // txtNOMBRE
            // 
            this.txtNOMBRE.Location = new System.Drawing.Point(188, 45);
            this.txtNOMBRE.Name = "txtNOMBRE";
            this.txtNOMBRE.Size = new System.Drawing.Size(196, 20);
            this.txtNOMBRE.TabIndex = 1;
            this.txtNOMBRE.TextChanged += new System.EventHandler(this.txtNOMBRE_TextChanged);
            // 
            // btnAÑADIR
            // 
            this.btnAÑADIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAÑADIR.Location = new System.Drawing.Point(435, 33);
            this.btnAÑADIR.Name = "btnAÑADIR";
            this.btnAÑADIR.Size = new System.Drawing.Size(110, 40);
            this.btnAÑADIR.TabIndex = 2;
            this.btnAÑADIR.Text = "Agregar";
            this.btnAÑADIR.UseVisualStyleBackColor = true;
            this.btnAÑADIR.Click += new System.EventHandler(this.btnACEPTAR_Click);
            // 
            // lbNombres
            // 
            this.lbNombres.FormattingEnabled = true;
            this.lbNombres.Location = new System.Drawing.Point(41, 113);
            this.lbNombres.Margin = new System.Windows.Forms.Padding(2);
            this.lbNombres.Name = "lbNombres";
            this.lbNombres.Size = new System.Drawing.Size(180, 212);
            this.lbNombres.TabIndex = 3;
            // 
            // btnPasar
            // 
            this.btnPasar.Location = new System.Drawing.Point(260, 185);
            this.btnPasar.Margin = new System.Windows.Forms.Padding(2);
            this.btnPasar.Name = "btnPasar";
            this.btnPasar.Size = new System.Drawing.Size(70, 30);
            this.btnPasar.TabIndex = 4;
            this.btnPasar.Text = ">";
            this.btnPasar.UseVisualStyleBackColor = true;
            this.btnPasar.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(365, 113);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(180, 212);
            this.listBox2.TabIndex = 5;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // btnPasarTodos
            // 
            this.btnPasarTodos.Location = new System.Drawing.Point(260, 232);
            this.btnPasarTodos.Name = "btnPasarTodos";
            this.btnPasarTodos.Size = new System.Drawing.Size(70, 30);
            this.btnPasarTodos.TabIndex = 6;
            this.btnPasarTodos.Text = ">>";
            this.btnPasarTodos.UseVisualStyleBackColor = true;
            this.btnPasarTodos.Click += new System.EventHandler(this.btnPasarTodos_Click);
            // 
            // Ejercicio1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.btnPasarTodos);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.btnPasar);
            this.Controls.Add(this.lbNombres);
            this.Controls.Add(this.btnAÑADIR);
            this.Controls.Add(this.txtNOMBRE);
            this.Controls.Add(this.lblNOMBRES);
            this.Name = "Ejercicio1Form";
            this.Text = "Nombres";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNOMBRES;
        private System.Windows.Forms.TextBox txtNOMBRE;
        private System.Windows.Forms.Button btnAÑADIR;
        private System.Windows.Forms.ListBox lbNombres;
        private System.Windows.Forms.Button btnPasar;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnPasarTodos;
    }
}