using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ReportingFRG
{
    public partial class Form1 : Form
    {
        private SqlConnection conexion = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.ConnectionString = "Server = " + txt_host.Text + "; " + "Database = " + txt_base.Text + "; Integrated Security = false; User ID = " + txt_usuario.Text + "; Password = " + txt_contraseña.Text + ";";
                conexion.Open();
                MessageBox.Show("Conexion exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    conexion.Dispose();
                    MessageBox.Show("Base de datos desconectada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //Codigo para mostrar la contraseña de un textbox
            txt_contraseña.PasswordChar = '\0';
        }

        private void bt_ejecutar_Click(object sender, EventArgs e)
        {
            //Se debe quitar esto del indexer para hacer mas agil la consulta
            //dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            string consulta = txt_consulta.Text;
            try
            {
                SqlCommand comando = new SqlCommand(""+consulta, basededatos.ObtenerConexion(txt_host.Text, txt_base.Text, txt_usuario.Text, txt_contraseña.Text));
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(""+ex, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void bt_exportar_Click(object sender, EventArgs e)
        {
            exportExcel.exportaraexcel(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.ConnectionString = "Server = " + txt_host.Text + "; " + "Database = " + txt_base.Text + "; Integrated Security = True;";
                conexion.Open();
                MessageBox.Show("Conexion exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
