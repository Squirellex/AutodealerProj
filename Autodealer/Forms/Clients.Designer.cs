
namespace Autodealer
{
    partial class Clients
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clients));
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new FontAwesome.Sharp.IconButton();
            this.myOrdersBtn = new FontAwesome.Sharp.IconButton();
            this.logoPan = new System.Windows.Forms.Panel();
            this.managementTC = new System.Windows.Forms.TabControl();
            this.Catalog = new System.Windows.Forms.TabPage();
            this.SearchTb = new System.Windows.Forms.TextBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.addToOrdersBtn = new FontAwesome.Sharp.IconButton();
            this.clientDG = new System.Windows.Forms.DataGridView();
            this.myOrders = new System.Windows.Forms.TabPage();
            this.orderSearchTB = new System.Windows.Forms.TextBox();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.orderDeleteBtn = new FontAwesome.Sharp.IconButton();
            this.ordersDG = new System.Windows.Forms.DataGridView();
            this.welcomePage = new System.Windows.Forms.TabPage();
            this.controlPan = new System.Windows.Forms.Panel();
            this.sidePan = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.catalogBtn = new FontAwesome.Sharp.IconButton();
            this.managementTC.SuspendLayout();
            this.Catalog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientDG)).BeginInit();
            this.myOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDG)).BeginInit();
            this.welcomePage.SuspendLayout();
            this.controlPan.SuspendLayout();
            this.sidePan.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Autodealer.Properties.Resources.logo3;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(158, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 305);
            this.panel1.TabIndex = 1;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Red;
            this.closeBtn.BackgroundImage = global::Autodealer.Properties.Resources.close;
            this.closeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Location = new System.Drawing.Point(686, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(45, 25);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Lucida Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.White;
            this.logoutBtn.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.logoutBtn.IconColor = System.Drawing.Color.White;
            this.logoutBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.logoutBtn.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.logoutBtn.Location = new System.Drawing.Point(0, 467);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(206, 59);
            this.logoutBtn.TabIndex = 3;
            this.logoutBtn.Text = "Сменить пользователя";
            this.logoutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // myOrdersBtn
            // 
            this.myOrdersBtn.FlatAppearance.BorderSize = 0;
            this.myOrdersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myOrdersBtn.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myOrdersBtn.ForeColor = System.Drawing.Color.White;
            this.myOrdersBtn.IconChar = FontAwesome.Sharp.IconChar.ListAlt;
            this.myOrdersBtn.IconColor = System.Drawing.Color.White;
            this.myOrdersBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.myOrdersBtn.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.myOrdersBtn.Location = new System.Drawing.Point(0, 214);
            this.myOrdersBtn.Name = "myOrdersBtn";
            this.myOrdersBtn.Size = new System.Drawing.Size(206, 59);
            this.myOrdersBtn.TabIndex = 2;
            this.myOrdersBtn.Text = "Мои заказы";
            this.myOrdersBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.myOrdersBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.myOrdersBtn.UseVisualStyleBackColor = true;
            this.myOrdersBtn.Click += new System.EventHandler(this.myOrdersBtn_Click);
            // 
            // logoPan
            // 
            this.logoPan.BackgroundImage = global::Autodealer.Properties.Resources.logo2;
            this.logoPan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoPan.Location = new System.Drawing.Point(0, 12);
            this.logoPan.Name = "logoPan";
            this.logoPan.Size = new System.Drawing.Size(212, 70);
            this.logoPan.TabIndex = 0;
            // 
            // managementTC
            // 
            this.managementTC.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.managementTC.Controls.Add(this.Catalog);
            this.managementTC.Controls.Add(this.myOrders);
            this.managementTC.Controls.Add(this.welcomePage);
            this.managementTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managementTC.Location = new System.Drawing.Point(206, 32);
            this.managementTC.Margin = new System.Windows.Forms.Padding(0);
            this.managementTC.Name = "managementTC";
            this.managementTC.Padding = new System.Drawing.Point(0, 0);
            this.managementTC.SelectedIndex = 0;
            this.managementTC.Size = new System.Drawing.Size(743, 531);
            this.managementTC.TabIndex = 6;
            // 
            // Catalog
            // 
            this.Catalog.Controls.Add(this.SearchTb);
            this.Catalog.Controls.Add(this.iconButton1);
            this.Catalog.Controls.Add(this.addToOrdersBtn);
            this.Catalog.Controls.Add(this.clientDG);
            this.Catalog.Location = new System.Drawing.Point(4, 25);
            this.Catalog.Name = "Catalog";
            this.Catalog.Size = new System.Drawing.Size(735, 502);
            this.Catalog.TabIndex = 5;
            this.Catalog.Text = "Каталог";
            this.Catalog.UseVisualStyleBackColor = true;
            // 
            // SearchTb
            // 
            this.SearchTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.SearchTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchTb.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTb.Location = new System.Drawing.Point(35, 13);
            this.SearchTb.Name = "SearchTb";
            this.SearchTb.Size = new System.Drawing.Size(189, 19);
            this.SearchTb.TabIndex = 48;
            this.SearchTb.Click += new System.EventHandler(this.SearchTb_Click);
            this.SearchTb.TextChanged += new System.EventHandler(this.SearchTb_TextChanged);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Lucida Sans", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 25;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.iconButton1.Location = new System.Drawing.Point(3, 3);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(231, 38);
            this.iconButton1.TabIndex = 49;
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // addToOrdersBtn
            // 
            this.addToOrdersBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.addToOrdersBtn.FlatAppearance.BorderSize = 0;
            this.addToOrdersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addToOrdersBtn.Font = new System.Drawing.Font("Lucida Sans", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToOrdersBtn.ForeColor = System.Drawing.Color.White;
            this.addToOrdersBtn.IconChar = FontAwesome.Sharp.IconChar.Percent;
            this.addToOrdersBtn.IconColor = System.Drawing.Color.White;
            this.addToOrdersBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.addToOrdersBtn.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.addToOrdersBtn.Location = new System.Drawing.Point(3, 446);
            this.addToOrdersBtn.Name = "addToOrdersBtn";
            this.addToOrdersBtn.Size = new System.Drawing.Size(236, 48);
            this.addToOrdersBtn.TabIndex = 47;
            this.addToOrdersBtn.Text = "Добавить в заказ";
            this.addToOrdersBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addToOrdersBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addToOrdersBtn.UseVisualStyleBackColor = false;
            this.addToOrdersBtn.Click += new System.EventHandler(this.addToOrdersBtn_Click);
            // 
            // clientDG
            // 
            this.clientDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clientDG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.clientDG.BackgroundColor = System.Drawing.SystemColors.Control;
            this.clientDG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clientDG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clientDG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.clientDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.clientDG.DefaultCellStyle = dataGridViewCellStyle2;
            this.clientDG.Location = new System.Drawing.Point(3, 47);
            this.clientDG.Name = "clientDG";
            this.clientDG.ReadOnly = true;
            this.clientDG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.clientDG.RowHeadersVisible = false;
            this.clientDG.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.clientDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientDG.Size = new System.Drawing.Size(729, 393);
            this.clientDG.TabIndex = 0;
            this.clientDG.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.clientDG_CellMouseClick);
            // 
            // myOrders
            // 
            this.myOrders.Controls.Add(this.orderSearchTB);
            this.myOrders.Controls.Add(this.iconButton2);
            this.myOrders.Controls.Add(this.orderDeleteBtn);
            this.myOrders.Controls.Add(this.ordersDG);
            this.myOrders.Location = new System.Drawing.Point(4, 25);
            this.myOrders.Name = "myOrders";
            this.myOrders.Size = new System.Drawing.Size(735, 502);
            this.myOrders.TabIndex = 6;
            this.myOrders.Text = "Мои заказы";
            this.myOrders.UseVisualStyleBackColor = true;
            // 
            // orderSearchTB
            // 
            this.orderSearchTB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.orderSearchTB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.orderSearchTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.orderSearchTB.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderSearchTB.Location = new System.Drawing.Point(35, 13);
            this.orderSearchTB.Name = "orderSearchTB";
            this.orderSearchTB.Size = new System.Drawing.Size(189, 19);
            this.orderSearchTB.TabIndex = 50;
            this.orderSearchTB.Click += new System.EventHandler(this.orderSearchTB_Click);
            this.orderSearchTB.TextChanged += new System.EventHandler(this.orderSearchTB_TextChanged);
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Lucida Sans", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 25;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.iconButton2.Location = new System.Drawing.Point(3, 3);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(231, 38);
            this.iconButton2.TabIndex = 51;
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // orderDeleteBtn
            // 
            this.orderDeleteBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.orderDeleteBtn.FlatAppearance.BorderSize = 0;
            this.orderDeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orderDeleteBtn.Font = new System.Drawing.Font("Lucida Sans", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderDeleteBtn.ForeColor = System.Drawing.Color.White;
            this.orderDeleteBtn.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.orderDeleteBtn.IconColor = System.Drawing.Color.White;
            this.orderDeleteBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.orderDeleteBtn.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.orderDeleteBtn.Location = new System.Drawing.Point(3, 446);
            this.orderDeleteBtn.Name = "orderDeleteBtn";
            this.orderDeleteBtn.Size = new System.Drawing.Size(236, 48);
            this.orderDeleteBtn.TabIndex = 48;
            this.orderDeleteBtn.Text = "Убрать из заказа";
            this.orderDeleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.orderDeleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.orderDeleteBtn.UseVisualStyleBackColor = false;
            this.orderDeleteBtn.Click += new System.EventHandler(this.orderDeleteBtn_Click);
            // 
            // ordersDG
            // 
            this.ordersDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ordersDG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ordersDG.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ordersDG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ordersDG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ordersDG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ordersDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ordersDG.DefaultCellStyle = dataGridViewCellStyle4;
            this.ordersDG.Location = new System.Drawing.Point(3, 47);
            this.ordersDG.Name = "ordersDG";
            this.ordersDG.ReadOnly = true;
            this.ordersDG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ordersDG.RowHeadersVisible = false;
            this.ordersDG.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ordersDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ordersDG.Size = new System.Drawing.Size(729, 393);
            this.ordersDG.TabIndex = 1;
            // 
            // welcomePage
            // 
            this.welcomePage.BackColor = System.Drawing.SystemColors.Control;
            this.welcomePage.Controls.Add(this.panel1);
            this.welcomePage.Location = new System.Drawing.Point(4, 25);
            this.welcomePage.Name = "welcomePage";
            this.welcomePage.Size = new System.Drawing.Size(735, 502);
            this.welcomePage.TabIndex = 4;
            this.welcomePage.Text = "welcomePage";
            // 
            // controlPan
            // 
            this.controlPan.BackColor = System.Drawing.Color.White;
            this.controlPan.Controls.Add(this.closeBtn);
            this.controlPan.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPan.Location = new System.Drawing.Point(206, 0);
            this.controlPan.Name = "controlPan";
            this.controlPan.Size = new System.Drawing.Size(743, 32);
            this.controlPan.TabIndex = 5;
            this.controlPan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.controlPan_MouseDown);
            this.controlPan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.controlPan_MouseMove);
            this.controlPan.MouseUp += new System.Windows.Forms.MouseEventHandler(this.controlPan_MouseUp);
            // 
            // sidePan
            // 
            this.sidePan.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.sidePan.Controls.Add(this.label3);
            this.sidePan.Controls.Add(this.label2);
            this.sidePan.Controls.Add(this.label1);
            this.sidePan.Controls.Add(this.logoutBtn);
            this.sidePan.Controls.Add(this.myOrdersBtn);
            this.sidePan.Controls.Add(this.catalogBtn);
            this.sidePan.Controls.Add(this.logoPan);
            this.sidePan.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePan.Location = new System.Drawing.Point(0, 0);
            this.sidePan.Name = "sidePan";
            this.sidePan.Size = new System.Drawing.Size(206, 563);
            this.sidePan.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(67, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Добро пожаловать";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // catalogBtn
            // 
            this.catalogBtn.FlatAppearance.BorderSize = 0;
            this.catalogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.catalogBtn.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catalogBtn.ForeColor = System.Drawing.Color.White;
            this.catalogBtn.IconChar = FontAwesome.Sharp.IconChar.Car;
            this.catalogBtn.IconColor = System.Drawing.Color.White;
            this.catalogBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.catalogBtn.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.catalogBtn.Location = new System.Drawing.Point(0, 149);
            this.catalogBtn.Name = "catalogBtn";
            this.catalogBtn.Size = new System.Drawing.Size(206, 59);
            this.catalogBtn.TabIndex = 0;
            this.catalogBtn.Text = "Каталог";
            this.catalogBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.catalogBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.catalogBtn.UseVisualStyleBackColor = true;
            this.catalogBtn.Click += new System.EventHandler(this.catalogBtn_Click);
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 563);
            this.Controls.Add(this.managementTC);
            this.Controls.Add(this.controlPan);
            this.Controls.Add(this.sidePan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Clients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autodealer";
            this.managementTC.ResumeLayout(false);
            this.Catalog.ResumeLayout(false);
            this.Catalog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientDG)).EndInit();
            this.myOrders.ResumeLayout(false);
            this.myOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDG)).EndInit();
            this.welcomePage.ResumeLayout(false);
            this.controlPan.ResumeLayout(false);
            this.sidePan.ResumeLayout(false);
            this.sidePan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeBtn;
        private FontAwesome.Sharp.IconButton logoutBtn;
        private FontAwesome.Sharp.IconButton myOrdersBtn;
        private System.Windows.Forms.Panel logoPan;
        private System.Windows.Forms.TabControl managementTC;
        private System.Windows.Forms.TabPage welcomePage;
        private System.Windows.Forms.Panel controlPan;
        private System.Windows.Forms.Panel sidePan;
        private FontAwesome.Sharp.IconButton catalogBtn;
        private System.Windows.Forms.TabPage Catalog;
        private System.Windows.Forms.TabPage myOrders;
        private System.Windows.Forms.DataGridView clientDG;
        private FontAwesome.Sharp.IconButton addToOrdersBtn;
        private FontAwesome.Sharp.IconButton orderDeleteBtn;
        private System.Windows.Forms.DataGridView ordersDG;
        private System.Windows.Forms.TextBox SearchTb;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.TextBox orderSearchTB;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}