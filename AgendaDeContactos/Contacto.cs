using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaDeContactos
{
    class Contacto
    {
        int id_contacto;
        string nombre;
        string direccion;
        int telefono;
        string email;

        public int Id_contacto
        {
            get
            {
                return id_contacto;
            }

            set
            {
                id_contacto = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public int Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
    }
}
