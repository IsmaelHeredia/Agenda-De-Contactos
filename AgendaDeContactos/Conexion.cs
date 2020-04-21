using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Configuration;

namespace AgendaDeContactos
{
    class Conexion
    {
        public SQLiteConnection conexion;
        public SQLiteCommand comando;
        public SQLiteDataReader dr;
        public DataTable dt;

        public Conexion()
        {
            conexion = new SQLiteConnection();
            comando = new SQLiteCommand();
            dt = new DataTable();
            dr = null;
        }

        public void abrir()
        {
            string basededatos = System.Configuration.ConfigurationManager.AppSettings["basededatos"];
            conexion.ConnectionString = "Data Source = " + basededatos + "; Version = 3; New = True; Compress = True;";
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            conexion.Open();
            comando.Connection = conexion;
        }
        public void cerrar()
        {
            conexion.Close();
        }
    }
}
