using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace AgendaDeContactos
{
    class AccesoDatos
    {
        public AccesoDatos()
        {
        }

        public Boolean crearBD()
        {
            Boolean respuesta = false;

            Conexion conexion = new Conexion();
            conexion.abrir();

            try
            {
                string sql_drop = "DROP TABLE IF EXISTS contactos;";

                SQLiteCommand cmd_drop = new SQLiteCommand(sql_drop, conexion.conexion);
                cmd_drop.ExecuteNonQuery();

                string sql_create_table = "CREATE TABLE contactos(id_contacto integer PRIMARY KEY autoincrement,nombre nvarchar(100),direccion nvarchar(100), telefono int, email nvarchar(100));";

                SQLiteCommand cmd_create = new SQLiteCommand(sql_create_table, conexion.conexion);
                cmd_create.ExecuteNonQuery();

                respuesta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public Boolean agregarContacto(Contacto contacto)
        {
            Boolean respuesta = false;

            Conexion conexion = new Conexion();
            conexion.abrir();

            try
            {
                string nombre = contacto.Nombre;
                string direccion = contacto.Direccion;
                int telefono = contacto.Telefono;
                string email = contacto.Email;

                var query = new SQLiteCommand("INSERT INTO contactos(nombre, direccion, telefono, email) VALUES (@p0, @p1, @p2, @p3)", conexion.conexion);

                query.Parameters.AddWithValue("@p0", nombre);
                query.Parameters.AddWithValue("@p1", direccion);
                query.Parameters.AddWithValue("@p2", telefono);
                query.Parameters.AddWithValue("@p3", email);

                query.ExecuteNonQuery();

                respuesta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conexion.cerrar();

            return respuesta;
        }

        public Boolean editarContacto(Contacto contacto)
        {
            Boolean respuesta = false;

            Conexion conexion = new Conexion();
            conexion.abrir();

            try
            {
                int id_contacto = contacto.Id_contacto;
                string nombre = contacto.Nombre;
                string direccion = contacto.Direccion;
                int telefono = contacto.Telefono;
                string email = contacto.Email;

                var query = new SQLiteCommand("UPDATE contactos SET nombre = @p0, direccion = @p1, telefono = @p2, email = @p3 WHERE id_contacto = @p4", conexion.conexion);

                query.Parameters.AddWithValue("@p0", nombre);
                query.Parameters.AddWithValue("@p1", direccion);
                query.Parameters.AddWithValue("@p2", telefono);
                query.Parameters.AddWithValue("@p3", email);
                query.Parameters.AddWithValue("@p4", id_contacto);

                query.ExecuteNonQuery();

                respuesta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conexion.cerrar();

            return respuesta;
        }

        public Boolean borrarContacto(int id_contacto)
        {
            Boolean respuesta = false;

            Conexion conexion = new Conexion();
            conexion.abrir();

            try
            {
                var query = new SQLiteCommand("DELETE FROM contactos where id_contacto = @p0", conexion.conexion);

                query.Parameters.AddWithValue("@p0", id_contacto);

                query.ExecuteNonQuery();

                respuesta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conexion.cerrar();

            return respuesta;
        }

        public ArrayList cargarContactos()
        {
            ArrayList listaContactos= new ArrayList();
            Conexion conexion = new Conexion();
            conexion.abrir();
            conexion.comando.CommandText = "SELECT id_contacto, nombre, direccion, telefono, email FROM contactos";
            var reader = conexion.comando.ExecuteReader();
            while (reader.Read())
            {
                Contacto contacto = new Contacto();
                if (!reader.IsDBNull(0))
                {
                    contacto.Id_contacto = reader.GetInt32(0);
                }
                if (!reader.IsDBNull(1))
                {
                    contacto.Nombre = reader.GetString(1);
                }
                if (!reader.IsDBNull(2))
                {
                    contacto.Direccion = reader.GetString(2);
                }
                if (!reader.IsDBNull(3))
                {
                    contacto.Telefono = reader.GetInt32(3);
                }
                if (!reader.IsDBNull(4))
                {
                    contacto.Email = reader.GetString(4);
                }
                listaContactos.Add(contacto);
            }
            conexion.cerrar();
            return listaContactos;
        }

        public Contacto cargarContacto(int id_contacto)
        {
            Contacto contacto = new Contacto();
            Conexion conexion = new Conexion();
            conexion.abrir();

            var query = new SQLiteCommand("SELECT id_contacto, nombre, direccion, telefono, email FROM contactos WHERE id_contacto = @p0", conexion.conexion);
            query.Parameters.AddWithValue("@p0", id_contacto);

            var reader = query.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                if (!reader.IsDBNull(0))
                {
                    contacto.Id_contacto = reader.GetInt32(0);
                }
                if (!reader.IsDBNull(1))
                {
                    contacto.Nombre = reader.GetString(1);
                }
                if (!reader.IsDBNull(2))
                {
                    contacto.Direccion = reader.GetString(2);
                }
                if (!reader.IsDBNull(3))
                {
                    contacto.Telefono = reader.GetInt32(3);
                }
                if (!reader.IsDBNull(4))
                {
                    contacto.Email = reader.GetString(4);
                }
            }
            conexion.cerrar();
            return contacto;
        }

        public bool comprobar_existencia_contacto_crear(string nombre)
        {
            Boolean respuesta = false;

            Conexion conexion = new Conexion();
            conexion.abrir();
            var query = new SQLiteCommand("SELECT COUNT(*) FROM contactos WHERE nombre = @p0", conexion.conexion);
            query.Parameters.AddWithValue("@p0", nombre);
            var result = query.ExecuteScalar().ToString();
            int count = Convert.ToInt32(result);
            if (count >= 1)
            {
                respuesta = true;
            }
            conexion.cerrar();

            return respuesta;
        }

        public bool comprobar_existencia_contacto_editar(int id_contacto, string nombre)
        {
            Boolean respuesta = false;

            Conexion conexion = new Conexion();
            conexion.abrir();
            var query = new SQLiteCommand("SELECT COUNT(*) FROM contactos WHERE nombre = @p0 AND id_contacto != @p1", conexion.conexion);
            query.Parameters.AddWithValue("@p0", nombre);
            query.Parameters.AddWithValue("@p1", id_contacto);
            var result = query.ExecuteScalar().ToString();
            int count = Convert.ToInt32(result);
            if (count >= 1)
            {
                respuesta = true;
            }
            conexion.cerrar();

            return respuesta;
        }

    }
}
