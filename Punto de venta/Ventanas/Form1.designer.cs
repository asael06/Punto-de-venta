using Bunifu;
namespace Punto_de_venta
{
    partial class Home
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
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRestaurar = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMinimizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMaximizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnConfiguracion = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRegistro = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnInventario = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnProductos = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnClientes = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnVentas = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnCerrar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAbrir = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.Ventas = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.btnUsuarios = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ventas1 = new Punto_de_venta.Ventas();
            this.usuarios2 = new Punto_de_venta.Usuarios();
            this.registro1 = new Punto_de_venta.Registro();
            this.configuración1 = new Punto_de_venta.Configuración();
            this.clientes1 = new Punto_de_venta.Clientes();
            this.inventario1 = new Punto_de_venta.Inventario();
            this.productos1 = new Punto_de_venta.Productos();
            this.btnCerrarCesion = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.Ventas.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 52);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRestaurar);
            this.panel2.Controls.Add(this.bunifuImageButton1);
            this.panel2.Controls.Add(this.btnMinimizar);
            this.panel2.Controls.Add(this.btnMaximizar);
            this.Ventas.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(880, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(118, 50);
            this.panel2.TabIndex = 3;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Ventas.SetDecoration(this.btnRestaurar, BunifuAnimatorNS.DecorationType.None);
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.ImageActive = null;
            this.btnRestaurar.Location = new System.Drawing.Point(45, 11);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(27, 26);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Zoom = 10;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Ventas.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(78, 11);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(27, 26);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bunifuImageButton1.TabIndex = 0;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Ventas.SetDecoration(this.btnMinimizar, BunifuAnimatorNS.DecorationType.None);
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.ImageActive = null;
            this.btnMinimizar.Location = new System.Drawing.Point(12, 11);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(27, 26);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Zoom = 10;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Ventas.SetDecoration(this.btnMaximizar, BunifuAnimatorNS.DecorationType.None);
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.ImageActive = null;
            this.btnMaximizar.Location = new System.Drawing.Point(45, 11);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(27, 26);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMaximizar.TabIndex = 1;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Zoom = 10;
            this.btnMaximizar.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.btnCerrarCesion);
            this.panel3.Controls.Add(this.btnConfiguracion);
            this.panel3.Controls.Add(this.btnUsuarios);
            this.panel3.Controls.Add(this.btnRegistro);
            this.panel3.Controls.Add(this.btnInventario);
            this.panel3.Controls.Add(this.btnProductos);
            this.panel3.Controls.Add(this.btnClientes);
            this.panel3.Controls.Add(this.btnVentas);
            this.panel3.Controls.Add(this.panel4);
            this.Ventas.SetDecoration(this.panel3, BunifuAnimatorNS.DecorationType.None);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 548);
            this.panel3.TabIndex = 1;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Activecolor = System.Drawing.Color.LightGray;
            this.btnConfiguracion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfiguracion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfiguracion.BorderRadius = 0;
            this.btnConfiguracion.ButtonText = "  Configuración";
            this.btnConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ventas.SetDecoration(this.btnConfiguracion, BunifuAnimatorNS.DecorationType.None);
            this.btnConfiguracion.DisabledColor = System.Drawing.Color.Gray;
            this.btnConfiguracion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConfiguracion.Iconcolor = System.Drawing.Color.Transparent;
            this.btnConfiguracion.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnConfiguracion.Iconimage")));
            this.btnConfiguracion.Iconimage_right = null;
            this.btnConfiguracion.Iconimage_right_Selected = null;
            this.btnConfiguracion.Iconimage_Selected = null;
            this.btnConfiguracion.IconMarginLeft = 0;
            this.btnConfiguracion.IconMarginRight = 0;
            this.btnConfiguracion.IconRightVisible = true;
            this.btnConfiguracion.IconRightZoom = 0D;
            this.btnConfiguracion.IconVisible = true;
            this.btnConfiguracion.IconZoom = 90D;
            this.btnConfiguracion.IsTab = true;
            this.btnConfiguracion.Location = new System.Drawing.Point(0, 500);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnConfiguracion.OnHovercolor = System.Drawing.Color.Silver;
            this.btnConfiguracion.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.btnConfiguracion.selected = false;
            this.btnConfiguracion.Size = new System.Drawing.Size(210, 48);
            this.btnConfiguracion.TabIndex = 14;
            this.btnConfiguracion.TabStop = false;
            this.btnConfiguracion.Text = "  Configuración";
            this.btnConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.Textcolor = System.Drawing.Color.DimGray;
            this.btnConfiguracion.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguración_Click);
            // 
            // btnRegistro
            // 
            this.btnRegistro.Activecolor = System.Drawing.Color.LightGray;
            this.btnRegistro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegistro.BorderRadius = 0;
            this.btnRegistro.ButtonText = "  Registro";
            this.btnRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ventas.SetDecoration(this.btnRegistro, BunifuAnimatorNS.DecorationType.None);
            this.btnRegistro.DisabledColor = System.Drawing.Color.Gray;
            this.btnRegistro.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegistro.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRegistro.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnRegistro.Iconimage")));
            this.btnRegistro.Iconimage_right = null;
            this.btnRegistro.Iconimage_right_Selected = null;
            this.btnRegistro.Iconimage_Selected = null;
            this.btnRegistro.IconMarginLeft = 0;
            this.btnRegistro.IconMarginRight = 0;
            this.btnRegistro.IconRightVisible = true;
            this.btnRegistro.IconRightZoom = 0D;
            this.btnRegistro.IconVisible = true;
            this.btnRegistro.IconZoom = 90D;
            this.btnRegistro.IsTab = true;
            this.btnRegistro.Location = new System.Drawing.Point(0, 241);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnRegistro.OnHovercolor = System.Drawing.Color.Silver;
            this.btnRegistro.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.btnRegistro.selected = false;
            this.btnRegistro.Size = new System.Drawing.Size(210, 48);
            this.btnRegistro.TabIndex = 12;
            this.btnRegistro.TabStop = false;
            this.btnRegistro.Text = "  Registro";
            this.btnRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistro.Textcolor = System.Drawing.Color.Gray;
            this.btnRegistro.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.Activecolor = System.Drawing.Color.LightGray;
            this.btnInventario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInventario.BorderRadius = 0;
            this.btnInventario.ButtonText = "  Inventario";
            this.btnInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ventas.SetDecoration(this.btnInventario, BunifuAnimatorNS.DecorationType.None);
            this.btnInventario.DisabledColor = System.Drawing.Color.Gray;
            this.btnInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventario.Iconcolor = System.Drawing.Color.Transparent;
            this.btnInventario.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnInventario.Iconimage")));
            this.btnInventario.Iconimage_right = null;
            this.btnInventario.Iconimage_right_Selected = null;
            this.btnInventario.Iconimage_Selected = null;
            this.btnInventario.IconMarginLeft = 0;
            this.btnInventario.IconMarginRight = 0;
            this.btnInventario.IconRightVisible = true;
            this.btnInventario.IconRightZoom = 0D;
            this.btnInventario.IconVisible = true;
            this.btnInventario.IconZoom = 90D;
            this.btnInventario.IsTab = true;
            this.btnInventario.Location = new System.Drawing.Point(0, 193);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnInventario.OnHovercolor = System.Drawing.Color.Silver;
            this.btnInventario.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.btnInventario.selected = false;
            this.btnInventario.Size = new System.Drawing.Size(210, 48);
            this.btnInventario.TabIndex = 11;
            this.btnInventario.TabStop = false;
            this.btnInventario.Text = "  Inventario";
            this.btnInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.Textcolor = System.Drawing.Color.Gray;
            this.btnInventario.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Activecolor = System.Drawing.Color.LightGray;
            this.btnProductos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProductos.BorderRadius = 0;
            this.btnProductos.ButtonText = "  Productos";
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ventas.SetDecoration(this.btnProductos, BunifuAnimatorNS.DecorationType.None);
            this.btnProductos.DisabledColor = System.Drawing.Color.Gray;
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.Iconcolor = System.Drawing.Color.Transparent;
            this.btnProductos.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnProductos.Iconimage")));
            this.btnProductos.Iconimage_right = null;
            this.btnProductos.Iconimage_right_Selected = null;
            this.btnProductos.Iconimage_Selected = null;
            this.btnProductos.IconMarginLeft = 0;
            this.btnProductos.IconMarginRight = 0;
            this.btnProductos.IconRightVisible = true;
            this.btnProductos.IconRightZoom = 0D;
            this.btnProductos.IconVisible = true;
            this.btnProductos.IconZoom = 90D;
            this.btnProductos.IsTab = true;
            this.btnProductos.Location = new System.Drawing.Point(0, 145);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnProductos.OnHovercolor = System.Drawing.Color.Silver;
            this.btnProductos.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.btnProductos.selected = false;
            this.btnProductos.Size = new System.Drawing.Size(210, 48);
            this.btnProductos.TabIndex = 10;
            this.btnProductos.TabStop = false;
            this.btnProductos.Text = "  Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Textcolor = System.Drawing.Color.Gray;
            this.btnProductos.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Activecolor = System.Drawing.Color.LightGray;
            this.btnClientes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClientes.BorderRadius = 0;
            this.btnClientes.ButtonText = "  Clientes";
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ventas.SetDecoration(this.btnClientes, BunifuAnimatorNS.DecorationType.None);
            this.btnClientes.DisabledColor = System.Drawing.Color.Gray;
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.Iconcolor = System.Drawing.Color.Transparent;
            this.btnClientes.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnClientes.Iconimage")));
            this.btnClientes.Iconimage_right = null;
            this.btnClientes.Iconimage_right_Selected = null;
            this.btnClientes.Iconimage_Selected = null;
            this.btnClientes.IconMarginLeft = 0;
            this.btnClientes.IconMarginRight = 0;
            this.btnClientes.IconRightVisible = true;
            this.btnClientes.IconRightZoom = 0D;
            this.btnClientes.IconVisible = true;
            this.btnClientes.IconZoom = 90D;
            this.btnClientes.IsTab = true;
            this.btnClientes.Location = new System.Drawing.Point(0, 97);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnClientes.OnHovercolor = System.Drawing.Color.Silver;
            this.btnClientes.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.btnClientes.selected = false;
            this.btnClientes.Size = new System.Drawing.Size(210, 48);
            this.btnClientes.TabIndex = 9;
            this.btnClientes.TabStop = false;
            this.btnClientes.Text = "  Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Textcolor = System.Drawing.Color.Gray;
            this.btnClientes.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Activecolor = System.Drawing.Color.LightGray;
            this.btnVentas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVentas.BorderRadius = 0;
            this.btnVentas.ButtonText = "  Ventas";
            this.btnVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ventas.SetDecoration(this.btnVentas, BunifuAnimatorNS.DecorationType.None);
            this.btnVentas.DisabledColor = System.Drawing.Color.Gray;
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.Iconcolor = System.Drawing.Color.Transparent;
            this.btnVentas.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnVentas.Iconimage")));
            this.btnVentas.Iconimage_right = null;
            this.btnVentas.Iconimage_right_Selected = null;
            this.btnVentas.Iconimage_Selected = null;
            this.btnVentas.IconMarginLeft = 0;
            this.btnVentas.IconMarginRight = 0;
            this.btnVentas.IconRightVisible = true;
            this.btnVentas.IconRightZoom = 0D;
            this.btnVentas.IconVisible = true;
            this.btnVentas.IconZoom = 90D;
            this.btnVentas.IsTab = true;
            this.btnVentas.Location = new System.Drawing.Point(0, 49);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnVentas.OnHovercolor = System.Drawing.Color.Silver;
            this.btnVentas.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.btnVentas.selected = false;
            this.btnVentas.Size = new System.Drawing.Size(210, 48);
            this.btnVentas.TabIndex = 8;
            this.btnVentas.TabStop = false;
            this.btnVentas.Text = "  Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Textcolor = System.Drawing.Color.Gray;
            this.btnVentas.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.Ventas.SetDecoration(this.panel4, BunifuAnimatorNS.DecorationType.None);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(210, 49);
            this.panel4.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnCerrar);
            this.panel6.Controls.Add(this.btnAbrir);
            this.Ventas.SetDecoration(this.panel6, BunifuAnimatorNS.DecorationType.None);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(159, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(51, 49);
            this.panel6.TabIndex = 4;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Activecolor = System.Drawing.Color.LightGray;
            this.btnCerrar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.BorderRadius = 0;
            this.btnCerrar.ButtonText = "";
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ventas.SetDecoration(this.btnCerrar, BunifuAnimatorNS.DecorationType.None);
            this.btnCerrar.DisabledColor = System.Drawing.Color.Gray;
            this.btnCerrar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCerrar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Iconimage")));
            this.btnCerrar.Iconimage_right = null;
            this.btnCerrar.Iconimage_right_Selected = null;
            this.btnCerrar.Iconimage_Selected = null;
            this.btnCerrar.IconMarginLeft = 0;
            this.btnCerrar.IconMarginRight = 0;
            this.btnCerrar.IconRightVisible = true;
            this.btnCerrar.IconRightZoom = 0D;
            this.btnCerrar.IconVisible = true;
            this.btnCerrar.IconZoom = 90D;
            this.btnCerrar.IsTab = true;
            this.btnCerrar.Location = new System.Drawing.Point(3, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnCerrar.OnHovercolor = System.Drawing.Color.Silver;
            this.btnCerrar.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.btnCerrar.selected = false;
            this.btnCerrar.Size = new System.Drawing.Size(45, 48);
            this.btnCerrar.TabIndex = 16;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Textcolor = System.Drawing.Color.Gray;
            this.btnCerrar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Click += new System.EventHandler(this.bunifuFlatButton2_Click_1);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Activecolor = System.Drawing.Color.LightGray;
            this.btnAbrir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAbrir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbrir.BorderRadius = 0;
            this.btnAbrir.ButtonText = "";
            this.btnAbrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ventas.SetDecoration(this.btnAbrir, BunifuAnimatorNS.DecorationType.None);
            this.btnAbrir.DisabledColor = System.Drawing.Color.Gray;
            this.btnAbrir.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAbrir.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Iconimage")));
            this.btnAbrir.Iconimage_right = null;
            this.btnAbrir.Iconimage_right_Selected = null;
            this.btnAbrir.Iconimage_Selected = null;
            this.btnAbrir.IconMarginLeft = 0;
            this.btnAbrir.IconMarginRight = 0;
            this.btnAbrir.IconRightVisible = true;
            this.btnAbrir.IconRightZoom = 0D;
            this.btnAbrir.IconVisible = true;
            this.btnAbrir.IconZoom = 90D;
            this.btnAbrir.IsTab = true;
            this.btnAbrir.Location = new System.Drawing.Point(3, 0);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnAbrir.OnHovercolor = System.Drawing.Color.Silver;
            this.btnAbrir.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.btnAbrir.selected = false;
            this.btnAbrir.Size = new System.Drawing.Size(45, 48);
            this.btnAbrir.TabIndex = 15;
            this.btnAbrir.TabStop = false;
            this.btnAbrir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbrir.Textcolor = System.Drawing.Color.Gray;
            this.btnAbrir.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrir.Click += new System.EventHandler(this.bunifuFlatButton7_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ventas1);
            this.panel5.Controls.Add(this.usuarios2);
            this.panel5.Controls.Add(this.registro1);
            this.panel5.Controls.Add(this.configuración1);
            this.panel5.Controls.Add(this.clientes1);
            this.panel5.Controls.Add(this.inventario1);
            this.panel5.Controls.Add(this.productos1);
            this.Ventas.SetDecoration(this.panel5, BunifuAnimatorNS.DecorationType.None);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(210, 52);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(790, 548);
            this.panel5.TabIndex = 2;
            // 
            // Ventas
            // 
            this.Ventas.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.Ventas.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.Ventas.DefaultAnimation = animation1;
            this.Ventas.Interval = 2;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Activecolor = System.Drawing.Color.LightGray;
            this.btnUsuarios.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsuarios.BorderRadius = 0;
            this.btnUsuarios.ButtonText = "  Usuarios";
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ventas.SetDecoration(this.btnUsuarios, BunifuAnimatorNS.DecorationType.None);
            this.btnUsuarios.DisabledColor = System.Drawing.Color.Gray;
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUsuarios.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Iconimage")));
            this.btnUsuarios.Iconimage_right = null;
            this.btnUsuarios.Iconimage_right_Selected = null;
            this.btnUsuarios.Iconimage_Selected = null;
            this.btnUsuarios.IconMarginLeft = 0;
            this.btnUsuarios.IconMarginRight = 0;
            this.btnUsuarios.IconRightVisible = true;
            this.btnUsuarios.IconRightZoom = 0D;
            this.btnUsuarios.IconVisible = true;
            this.btnUsuarios.IconZoom = 90D;
            this.btnUsuarios.IsTab = true;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 289);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnUsuarios.OnHovercolor = System.Drawing.Color.Silver;
            this.btnUsuarios.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.btnUsuarios.selected = false;
            this.btnUsuarios.Size = new System.Drawing.Size(210, 48);
            this.btnUsuarios.TabIndex = 13;
            this.btnUsuarios.TabStop = false;
            this.btnUsuarios.Text = "  Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Textcolor = System.Drawing.Color.Gray;
            this.btnUsuarios.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // ventas1
            // 
            this.Ventas.SetDecoration(this.ventas1, BunifuAnimatorNS.DecorationType.None);
            this.ventas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ventas1.Location = new System.Drawing.Point(0, 0);
            this.ventas1.Name = "ventas1";
            this.ventas1.Size = new System.Drawing.Size(790, 548);
            this.ventas1.TabIndex = 0;
            this.ventas1.TabStop = false;
            this.ventas1.Click += new System.EventHandler(this.bunifuFlatButton2_Click_1);
            // 
            // usuarios2
            // 
            this.Ventas.SetDecoration(this.usuarios2, BunifuAnimatorNS.DecorationType.None);
            this.usuarios2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usuarios2.Location = new System.Drawing.Point(0, 0);
            this.usuarios2.Name = "usuarios2";
            this.usuarios2.Size = new System.Drawing.Size(790, 548);
            this.usuarios2.TabIndex = 1;
            this.usuarios2.TabStop = false;
            // 
            // registro1
            // 
            this.Ventas.SetDecoration(this.registro1, BunifuAnimatorNS.DecorationType.None);
            this.registro1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registro1.Location = new System.Drawing.Point(0, 0);
            this.registro1.Name = "registro1";
            this.registro1.Size = new System.Drawing.Size(790, 548);
            this.registro1.TabIndex = 6;
            this.registro1.TabStop = false;
            // 
            // configuración1
            // 
            this.configuración1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Ventas.SetDecoration(this.configuración1, BunifuAnimatorNS.DecorationType.None);
            this.configuración1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configuración1.Location = new System.Drawing.Point(0, 0);
            this.configuración1.Name = "configuración1";
            this.configuración1.Size = new System.Drawing.Size(790, 548);
            this.configuración1.TabIndex = 7;
            this.configuración1.TabStop = false;
            // 
            // clientes1
            // 
            this.Ventas.SetDecoration(this.clientes1, BunifuAnimatorNS.DecorationType.None);
            this.clientes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientes1.Location = new System.Drawing.Point(0, 0);
            this.clientes1.Name = "clientes1";
            this.clientes1.Size = new System.Drawing.Size(790, 548);
            this.clientes1.TabIndex = 0;
            this.clientes1.TabStop = false;
            // 
            // inventario1
            // 
            this.Ventas.SetDecoration(this.inventario1, BunifuAnimatorNS.DecorationType.None);
            this.inventario1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventario1.Location = new System.Drawing.Point(0, 0);
            this.inventario1.Name = "inventario1";
            this.inventario1.Size = new System.Drawing.Size(790, 548);
            this.inventario1.TabIndex = 0;
            this.inventario1.TabStop = false;
            // 
            // productos1
            // 
            this.Ventas.SetDecoration(this.productos1, BunifuAnimatorNS.DecorationType.None);
            this.productos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productos1.Location = new System.Drawing.Point(0, 0);
            this.productos1.Name = "productos1";
            this.productos1.Size = new System.Drawing.Size(790, 548);
            this.productos1.TabIndex = 0;
            this.productos1.TabStop = false;
            // 
            // btnCerrarCesion
            // 
            this.btnCerrarCesion.Activecolor = System.Drawing.Color.LightGray;
            this.btnCerrarCesion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCerrarCesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrarCesion.BorderRadius = 0;
            this.btnCerrarCesion.ButtonText = "  Cerrar sesión";
            this.btnCerrarCesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ventas.SetDecoration(this.btnCerrarCesion, BunifuAnimatorNS.DecorationType.None);
            this.btnCerrarCesion.DisabledColor = System.Drawing.Color.Gray;
            this.btnCerrarCesion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCerrarCesion.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCerrarCesion.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnCerrarCesion.Iconimage")));
            this.btnCerrarCesion.Iconimage_right = null;
            this.btnCerrarCesion.Iconimage_right_Selected = null;
            this.btnCerrarCesion.Iconimage_Selected = null;
            this.btnCerrarCesion.IconMarginLeft = 0;
            this.btnCerrarCesion.IconMarginRight = 0;
            this.btnCerrarCesion.IconRightVisible = true;
            this.btnCerrarCesion.IconRightZoom = 0D;
            this.btnCerrarCesion.IconVisible = true;
            this.btnCerrarCesion.IconZoom = 90D;
            this.btnCerrarCesion.IsTab = true;
            this.btnCerrarCesion.Location = new System.Drawing.Point(0, 337);
            this.btnCerrarCesion.Name = "btnCerrarCesion";
            this.btnCerrarCesion.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnCerrarCesion.OnHovercolor = System.Drawing.Color.Silver;
            this.btnCerrarCesion.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.btnCerrarCesion.selected = false;
            this.btnCerrarCesion.Size = new System.Drawing.Size(210, 48);
            this.btnCerrarCesion.TabIndex = 15;
            this.btnCerrarCesion.TabStop = false;
            this.btnCerrarCesion.Text = "  Cerrar sesión";
            this.btnCerrarCesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarCesion.Textcolor = System.Drawing.Color.Gray;
            this.btnCerrarCesion.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarCesion.MouseUp += new System.EventHandler(this.btnCerrarCesion_MouseUp);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Ventas.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimizar;
        private Bunifu.Framework.UI.BunifuImageButton btnMaximizar;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuImageButton btnRestaurar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private BunifuAnimatorNS.BunifuTransition Ventas;
        private Ventas ventas1;
        private Usuarios usuarios2;
        private System.Windows.Forms.Panel panel6;
        private Productos productos1;
        private Inventario inventario1;
        private Registro registro1;
        private Configuración configuración1;
        private Clientes clientes1;
        private Bunifu.Framework.UI.BunifuFlatButton btnConfiguracion;
        private Bunifu.Framework.UI.BunifuFlatButton btnRegistro;
        private Bunifu.Framework.UI.BunifuFlatButton btnInventario;
        private Bunifu.Framework.UI.BunifuFlatButton btnProductos;
        private Bunifu.Framework.UI.BunifuFlatButton btnClientes;
        private Bunifu.Framework.UI.BunifuFlatButton btnVentas;
        private Bunifu.Framework.UI.BunifuFlatButton btnCerrar;
        private Bunifu.Framework.UI.BunifuFlatButton btnAbrir;
        private Bunifu.Framework.UI.BunifuFlatButton btnUsuarios;
        private Bunifu.Framework.UI.BunifuFlatButton btnCerrarCesion;
    }
}

