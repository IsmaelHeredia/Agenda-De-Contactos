namespace AgendaDeContactos
{
    partial class FormHome
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
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "ID");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Nombre");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn3 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Dirección");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn4 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 3", "Teléfono");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn5 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 4", "Email");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.btnAgregar = new Telerik.WinControls.UI.RadButton();
            this.gbContactos = new Telerik.WinControls.UI.RadGroupBox();
            this.lvContactos = new Telerik.WinControls.UI.RadListView();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.cmOptions = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.miEditar = new Telerik.WinControls.UI.RadMenuItem();
            this.miEliminar = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbContactos)).BeginInit();
            this.gbContactos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvContactos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(30, 276);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(151, 24);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar nuevo contacto";
            this.btnAgregar.ThemeName = "Office2013Light";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gbContactos
            // 
            this.gbContactos.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbContactos.Controls.Add(this.lvContactos);
            this.gbContactos.HeaderText = "Contactos";
            this.gbContactos.Location = new System.Drawing.Point(12, 12);
            this.gbContactos.Name = "gbContactos";
            this.gbContactos.Size = new System.Drawing.Size(521, 245);
            this.gbContactos.TabIndex = 2;
            this.gbContactos.Text = "Contactos";
            this.gbContactos.ThemeName = "Office2013Light";
            // 
            // lvContactos
            // 
            listViewDetailColumn1.HeaderText = "ID";
            listViewDetailColumn1.Visible = false;
            listViewDetailColumn2.HeaderText = "Nombre";
            listViewDetailColumn3.HeaderText = "Dirección";
            listViewDetailColumn4.HeaderText = "Teléfono";
            listViewDetailColumn5.HeaderText = "Email";
            this.lvContactos.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2,
            listViewDetailColumn3,
            listViewDetailColumn4,
            listViewDetailColumn5});
            this.lvContactos.ItemSpacing = -1;
            this.lvContactos.Location = new System.Drawing.Point(18, 35);
            this.lvContactos.Name = "lvContactos";
            this.lvContactos.Size = new System.Drawing.Size(476, 187);
            this.lvContactos.TabIndex = 0;
            this.lvContactos.Text = "radListView1";
            this.lvContactos.ThemeName = "Office2013Light";
            this.lvContactos.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.lvContactos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvContactos_MouseClick);
            // 
            // cmOptions
            // 
            this.cmOptions.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.miEditar,
            this.miEliminar});
            // 
            // miEditar
            // 
            this.miEditar.Name = "miEditar";
            this.miEditar.Text = "Editar";
            // 
            // miEliminar
            // 
            this.miEliminar.Name = "miEliminar";
            this.miEliminar.Text = "Eliminar";
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 321);
            this.Controls.Add(this.gbContactos);
            this.Controls.Add(this.btnAgregar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormHome";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Agenda de contactos 1.0 - Copyright © Ismael Heredia 2020";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.FormHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbContactos)).EndInit();
            this.gbContactos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvContactos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadButton btnAgregar;
        private Telerik.WinControls.UI.RadGroupBox gbContactos;
        private Telerik.WinControls.UI.RadListView lvContactos;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadContextMenu cmOptions;
        private Telerik.WinControls.UI.RadMenuItem miEditar;
        private Telerik.WinControls.UI.RadMenuItem miEliminar;
    }
}