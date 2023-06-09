﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DDAEA_Lab_S3
{
    public partial class Form1 : Form
    {
        //SqlConnection nos permite manejar el acceso al servidor
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnConectar_Click_1(object sender, EventArgs e)
        {
            //Declaramos variables para almacenar los valores de los TextBox
            //y definimos una cadena de conexion
            String servidor = txtServidor.Text;
            String bd = txtBaseDatos.Text;
            String user = txtUsuario.Text;
            String pwd = txtPassword.Text;

            String str = "Server=" + servidor + ";DataBase=" + bd + ";";

            //La cadena de conexion cambia en funcion del estado del CheckBox
            if (chkAutenticacion.Checked)
                str += "Integrated Security=true";
            else
                str += "User Id=" + user + ";Password=" + pwd + ";";

            //Abrir una conexion con el servidor, usando la cadena de conexion
            try
            {
                conn = new SqlConnection(str);
                conn.Open();
                MessageBox.Show("Conectado satisfactoriamente");
                btnDesconectar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar el servidor: \n" + ex.ToString());
            }



        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            //Intentamos obtener el estado de la conexion, y en caso esté abierta,
            //recuperamos informacion de la misma
            try
            {
                if (conn.State == ConnectionState.Open)
                    MessageBox.Show("Estado del servidor: " + conn.State +
                        "\nVersion del servidor: " + conn.ServerVersion +
                        "\nBase de datos: " + conn.Database);
                else
                    MessageBox.Show("Estado del servidor: " + conn.State);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Imposible determinar el estado del servidor: \n" +
                    ex.ToString());
            }
        }

        private void chkAutenticacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutenticacion.Checked)
            {
                txtUsuario.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsuario.Enabled = true;
                txtPassword.Enabled = true;
            }

        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            //Para cerrar la coneción verificamos que no este cerrada
            try
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    MessageBox.Show("Conexión cerrada satisfactoriamente");
                }
                else
                    MessageBox.Show("La conexión ya esta cerrado");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cerrar la conexión: \n" + ex.ToString());
            }
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona(conn);
            persona.Show();
        }
    }
}
