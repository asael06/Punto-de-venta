namespace Punto_de_venta.Ventanas
{
    partial class Cobrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cobrar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCredito = new System.Windows.Forms.Button();
            this.btnEfectivo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.efectivo1 = new Punto_de_venta.Ventanas.Efectivo();
            this.credito1 = new Punto_de_venta.Controles_de_Usuario.Credito();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 52);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(198, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de pago";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCredito);
            this.panel3.Controls.Add(this.btnEfectivo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(144, 285);
            this.panel3.TabIndex = 0;
            // 
            // btnCredito
            // 
            this.btnCredito.FlatAppearance.BorderSize = 0;
            this.btnCredito.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(86)))), ((int)(((byte)(182)))));
            this.btnCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCredito.Image = ((System.Drawing.Image)(resources.GetObject("btnCredito.Image")));
            this.btnCredito.Location = new System.Drawing.Point(22, 151);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.Size = new System.Drawing.Size(100, 100);
            this.btnCredito.TabIndex = 2;
            this.btnCredito.TabStop = false;
            this.btnCredito.UseVisualStyleBackColor = true;
            this.btnCredito.Click += new System.EventHandler(this.btnCredito_Click);
            this.btnCredito.Enter += new System.EventHandler(this.btnCredito_Enter);
            this.btnCredito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCredito_KeyDown);
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.FlatAppearance.BorderSize = 0;
            this.btnEfectivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(86)))), ((int)(((byte)(182)))));
            this.btnEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEfectivo.Image = ((System.Drawing.Image)(resources.GetObject("btnEfectivo.Image")));
            this.btnEfectivo.Location = new System.Drawing.Point(22, 33);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(100, 100);
            this.btnEfectivo.TabIndex = 1;
            this.btnEfectivo.TabStop = false;
            this.btnEfectivo.UseVisualStyleBackColor = true;
            this.btnEfectivo.Click += new System.EventHandler(this.btnEfectivo_Click);
            this.btnEfectivo.Enter += new System.EventHandler(this.btnEfectivo_Enter);
            this.btnEfectivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEfectivo_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.efectivo1);
            this.panel2.Controls.Add(this.credito1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(144, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 285);
            this.panel2.TabIndex = 7;
            // 
            // efectivo1
            // 
            this.efectivo1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.efectivo1.acepta = false;
            this.efectivo1.aceptar = false;
            this.efectivo1.av = null;
            this.efectivo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efectivo1.Location = new System.Drawing.Point(0, 0);
            this.efectivo1.Name = "efectivo1";
            this.efectivo1.Size = new System.Drawing.Size(393, 285);
            this.efectivo1.TabIndex = 0;
            this.efectivo1.TabStop = false;
            this.efectivo1.verdad = false;
            this.efectivo1.VisibleChanged += new System.EventHandler(this.efectivo1_VisibleChanged);
            // 
            // credito1
            // 
            this.credito1.av = null;
            this.credito1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.credito1.Location = new System.Drawing.Point(0, 0);
            this.credito1.Name = "credito1";
            this.credito1.Size = new System.Drawing.Size(393, 285);
            this.credito1.TabIndex = 1;
            this.credito1.VisibleChanged += new System.EventHandler(this.credito1_VisibleChanged);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 25;
            this.bunifuElipse2.TargetControl = this.btnCredito;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 25;
            this.bunifuElipse3.TargetControl = this.btnEfectivo;
            // 
            // Cobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(537, 337);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Cobrar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobrar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;        
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Efectivo efectivo1;
        private System.Windows.Forms.Button btnCredito;
        private System.Windows.Forms.Button btnEfectivo;
        private System.Windows.Forms.Label label1;
        private Controles_de_Usuario.Credito credito1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
    }
}