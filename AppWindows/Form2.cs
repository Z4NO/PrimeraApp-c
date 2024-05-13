using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWindows
{
    public partial class Form2 : Form
    {
        private List<Alumno> list = new List<Alumno>();
        private static String conexion = "server=localhost;port=3306;uid=root;pwd='';database=users;";
        private MySqlConnection conexionConnection = new MySqlConnection(conexion);
        public Form2(List<Alumno> lista)
        {
            InitializeComponent();
            this.list = lista;
            RellenarData();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
        private void RellenarData()
        {
            foreach (Alumno alumno in list)
            {
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = alumno.Name;
                dataGridView1.Rows[n].Cells[1].Value = alumno.Apelliddo;
                dataGridView1.Rows[n].Cells[2].Value = alumno.Id;
            }

        }
        private void CargarUsuarios()
        {
            try
            {
                conexionConnection.Open();

                // Consulta SQL SELECT
                string consulta = "SELECT * FROM users";

                // Crear el comando con la consulta SQL y la conexión
                MySqlCommand cmd = new MySqlCommand(consulta, conexionConnection);

                // Ejecutar el comando y obtener un lector de datos
                MySqlDataReader reader = cmd.ExecuteReader();

                // Iterar sobre los resultados
                while (reader.Read())
                {
                    // Acceder a los datos de cada fila usando los nombres de las columnas o sus índices
                    string nombre = reader["Nombre"].ToString();
                    string apellido = reader["Apellido"].ToString();
                    int id = Convert.ToInt32(reader["ID"]);

                    Alumno alum = new Alumno(nombre,apellido, id);
                    list.Add(alum);

                    int n = dataGridView1.Rows.Add();

                    dataGridView1.Rows[n].Cells[0].Value = alum.Name;
                    dataGridView1.Rows[n].Cells[1].Value = alum.Apelliddo;
                    dataGridView1.Rows[n].Cells[2].Value = alum.Id;
                }

                // Cerrar el lector de datos
                reader.Close();

                // Cerrar la conexión
                conexionConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
