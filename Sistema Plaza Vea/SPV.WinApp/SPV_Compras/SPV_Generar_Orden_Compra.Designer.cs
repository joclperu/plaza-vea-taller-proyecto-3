namespace SPV.WinApp.SPV_Compras
{
    partial class SPV_Generar_Orden_Compra
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
            this.components = new System.ComponentModel.Container();
            this.tmrHora = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnDetener = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrHora
            // 
            this.tmrHora.Enabled = true;
            this.tmrHora.Interval = 1000;
            this.tmrHora.Tick += new System.EventHandler(this.tmrHora_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.BtnDetener);
            this.panel1.Controls.Add(this.BtnAceptar);
            this.panel1.Controls.Add(this.txtHora);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(20, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 54);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hora de Ejecución";
            // 
            // txtHora
            // 
            this.txtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Location = new System.Drawing.Point(172, 13);
            this.txtHora.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(91, 24);
            this.txtHora.TabIndex = 1;
            this.txtHora.Text = "16:00";
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Location = new System.Drawing.Point(273, 9);
            this.BtnAceptar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(155, 33);
            this.BtnAceptar.TabIndex = 2;
            this.BtnAceptar.Text = "ACEPTAR";
            this.BtnAceptar.UseVisualStyleBackColor = false;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnDetener
            // 
            this.BtnDetener.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnDetener.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnDetener.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDetener.Location = new System.Drawing.Point(438, 9);
            this.BtnDetener.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BtnDetener.Name = "BtnDetener";
            this.BtnDetener.Size = new System.Drawing.Size(155, 33);
            this.BtnDetener.TabIndex = 3;
            this.BtnDetener.Text = "DETENER";
            this.BtnDetener.UseVisualStyleBackColor = false;
            this.BtnDetener.Click += new System.EventHandler(this.BtnDetener_Click);
            // 
            // SPV_Generar_Orden_Compra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 88);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "SPV_Generar_Orden_Compra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servicio - Orden Compra";
            this.Load += new System.EventHandler(this.SPV_Generar_Orden_Compra_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrHora;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnDetener;
    }
}