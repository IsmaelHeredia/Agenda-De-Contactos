// Agenda de contactos 1.0
// Copyright © Ismael Heredia 2020

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Text.RegularExpressions;

namespace AgendaDeContactos
{
    public partial class FormEditar : Telerik.WinControls.UI.RadForm
    {
        public string titulo;
        public int id_contacto;
        public FormHome formHome;

        public FormEditar(FormHome formHome_recibido, int id_contacto_recibido)
        {
            InitializeComponent();
            titulo = System.Configuration.ConfigurationManager.AppSettings["titulo_programa"];
            id_contacto = id_contacto_recibido;
            formHome = formHome_recibido;
            RadMessageBox.SetThemeName("Office2013Light");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id_contacto = Convert.ToInt32(txtID.Text);
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            int telefono = 0;
            if (Regex.IsMatch(txtTelefono.Text, @"^\d+$"))
            {
                telefono = Convert.ToInt32(txtTelefono.Text);
            }
            string email = txtEmail.Text;

            if (id_contacto != 0 && nombre != "" && direccion != "" && telefono != 0 && email != "")
            {
                Contacto contacto = new Contacto();
                contacto.Id_contacto = Convert.ToInt32(id_contacto);
                contacto.Nombre = nombre;
                contacto.Direccion = direccion;
                contacto.Telefono = telefono;
                contacto.Email = email;
                AccesoDatos datos = new AccesoDatos();
                if (datos.comprobar_existencia_contacto_editar(id_contacto, nombre))
                {
                    RadMessageBox.Show("El nombre ya existe", titulo, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (datos.editarContacto(contacto))
                    {
                        RadMessageBox.Show("El contacto fue editado correctamente", titulo, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                        formHome.cargarContactos();
                        FormAgregar.ActiveForm.Close();
                    }
                    else
                    {
                        RadMessageBox.Show("Error editando el contacto", titulo, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                RadMessageBox.Show("Complete los datos del contacto", titulo, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
            }
        }

        private void FormEditar_Load(object sender, EventArgs e)
        {
            txtID.Text = Convert.ToString(id_contacto);
            AccesoDatos datos = new AccesoDatos();
            Contacto contacto = datos.cargarContacto(id_contacto);
            string nombre = contacto.Nombre;
            string direccion = contacto.Direccion;
            int telefono = contacto.Telefono;
            string email = contacto.Email;
            txtNombre.Text = nombre;
            txtDireccion.Text = direccion;
            txtTelefono.Text = telefono.ToString();
            txtEmail.Text = email;
        }
    }
}
