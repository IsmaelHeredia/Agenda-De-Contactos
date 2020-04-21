// Agenda de contactos 1.0
// Copyright © Ismael Heredia 2020

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Configuration;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace AgendaDeContactos
{
    public partial class FormHome : Telerik.WinControls.UI.RadForm
    {
        public string basededatos;
        public string titulo;
        FormAgregar formAgregar = new FormAgregar(null);
        FormEditar formEditar = new FormEditar(null,0);

        public FormHome()
        {
            InitializeComponent();
            basededatos = System.Configuration.ConfigurationManager.AppSettings["basededatos"];
            titulo = System.Configuration.ConfigurationManager.AppSettings["titulo_programa"];
            miEditar.Click += miEditar_Click;
            miEliminar.Click += miEliminar_Click;
            RadMessageBox.SetThemeName("Office2013Light");
        }

        public void cargarContactos()
        {
            lvContactos.Items.Clear();
            if (File.Exists(Path.GetFullPath(basededatos)))
            {
                AccesoDatos datos = new AccesoDatos();
                ArrayList listaContactos = datos.cargarContactos();
                foreach (Contacto contacto in listaContactos)
                {
                    int id_contacto = contacto.Id_contacto;
                    string nombre = contacto.Nombre;
                    string direccion = contacto.Direccion;
                    int telefono = contacto.Telefono;
                    string email = contacto.Email;
                    ListViewDataItem item = new ListViewDataItem();
                    item.SubItems.Add(id_contacto);
                    item.SubItems.Add(nombre);
                    item.SubItems.Add(direccion);
                    item.SubItems.Add(telefono);
                    item.SubItems.Add(email);
                    lvContactos.Items.Add(item);
                }
                gbContactos.Text = "Contactos : " + lvContactos.Items.Count + " encontrados";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!formAgregar.Visible)
            {
                formAgregar = new FormAgregar(this);
                formAgregar.Show();
            }
        }

        private void miEditar_Click(object sender, EventArgs e)
        {
            if (!formEditar.Visible)
            {
                var id_contacto = Convert.ToInt32(lvContactos.SelectedItem[0]);
                formEditar = new FormEditar(this,id_contacto);
                formEditar.Show();
            }
        }

        private void miEliminar_Click(object sender, EventArgs e)
        {
            DialogResult ds = RadMessageBox.Show(this, "Esta seguro de borrar el contacto ?", titulo, MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (ds.ToString() == "Yes")
            {
                var id_contacto = Convert.ToInt32(lvContactos.SelectedItem[0]);
                AccesoDatos datos = new AccesoDatos();
                if (datos.borrarContacto(id_contacto))
                {
                    RadMessageBox.Show("Contacto eliminado", titulo, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    RadMessageBox.Show("Error borrando el contacto", titulo, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
                cargarContactos();
            }
        }

        private void lvContactos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvContactos.SelectedIndex > -1)
                {
                    cmOptions.Show(Cursor.Position);
                }
            }
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Path.GetFullPath(basededatos)))
            {
                AccesoDatos datos = new AccesoDatos();
                datos.crearBD();
            }
            cargarContactos();

        }
    }
}
