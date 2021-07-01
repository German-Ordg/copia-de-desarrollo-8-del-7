﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Pantallas_proyecto
{
    public class ClsConexionBD
    {
        SqlDataAdapter da;
        DataTable dt;
        public SqlConnection conexion = new SqlConnection("Data Source = SQL5053.site4now.net; Initial Catalog = db_a75e9e_bderickmoncada; User Id = db_a75e9e_bderickmoncada_admin; Password = grp5admin");
        public void abrir()
        {
            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error al abrir BD " ,ex.Message);
            }
        }
        public void cerrar()
        {
            conexion.Close();
        }
        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection("Data Source = SQL5053.site4now.net; Initial Catalog = db_a75e9e_bderickmoncada; User Id = db_a75e9e_bderickmoncada_admin; Password = grp5admin");
        }

        public void CargaDeUsuarios(ComboBox cmb)
        {
            try
            {
                SqlCommand comando = new SqlCommand("select nombre_usuario from Usuarios",conexion);
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    cmb.Items.Add(registro["nombre_usuario"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos!", "ERROR",
                                MessageBoxButtons.OK);
            }
        }

        public string correo()
        {
            //Recuperar correo desde sql
            string cont = "g";
            conexion.Close();
            conexion.Open();
            SqlCommand comando = new SqlCommand("select correo from Administrativa", conexion);

            SqlDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {
                cont = registro["correo"].ToString();
            }
            conexion.Close();
            return cont;


        }
        public string contra()
        {
            //Recuperar contrasena del correo desde sql

            string cont = "g";
            conexion.Close();
            conexion.Open();
            SqlCommand comando = new SqlCommand("select contrasena from Administrativa", conexion);

            SqlDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {
                cont = registro["contrasena"].ToString();
            }
            conexion.Close();
            return cont;


        }


       

        public void CargarDatosUsuario(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("select * from Usuarios", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Error al cargar base de datos!", "ERROR...!"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void cargarDatosEmpleados(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("Select * From Empleados", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden cargar los datos" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cargarMetodosPago(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("SELECT * FROM Metodo_Pago", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden cargar los datos" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cargarDatosProductos(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("Select * From Productos", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden cargar los datos" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }


}
