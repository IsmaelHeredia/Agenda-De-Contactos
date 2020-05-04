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
    public partial class FormAgregar : Telerik.WinControls.UI.RadForm
    {
        public string titulo;
        public FormHome formHome;

        public FormAgregar(FormHome formHome_recibido)
        {
            InitializeComponent();
            titulo = System.Configuration.ConfigurationManager.AppSettings["titulo_programa"];
            formHome = formHome_recibido;
            RadMessageBox.SetThemeName("Office2013Light");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            int telefono = 0;
            if (Regex.IsMatch(txtTelefono.Text, @"^\d+$"))
            {
                telefono = Convert.ToInt32(txtTelefono.Text);
            }
            string email = txtEmail.Text;

            if (nombre != "" && direccion != "" && telefono != 0 && email != "")
            {
                AccesoDatos datos = new AccesoDatos();
                Contacto contacto = new Contacto();
                contacto.Nombre = nombre;
                contacto.Direccion = direccion;
                contacto.Telefono = telefono;
                contacto.Email = email;
                if (datos.comprobar_existencia_contacto_crear(nombre))
                {
                    RadMessageBox.Show("El nombre ya existe", titulo, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (datos.agregarContacto(contacto))
                    {
                        RadMessageBox.Show("El contacto fue creado correctamente", titulo, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                        formHome.cargarContactos();
                        FormAgregar.ActiveForm.Close();

                    }
                    else
                    {
                        RadMessageBox.Show("Error creando el contacto", titulo, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                RadMessageBox.Show("Complete los datos del contacto", titulo, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
