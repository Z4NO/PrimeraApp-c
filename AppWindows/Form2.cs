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
            CargarUsuarios();
            this.FormClosed += Form2_FormClosed;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
        private void Form2_FormClosed(Object sender, FormClosedEventArgs e)
        {
            //Por si queremos notifiacr al usuario de que se ha cerrado la ventana
            /*
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "FormClosed Event");
            */
            this.dataGridView1.Rows.Clear();

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
                if (reader.FieldCount == 0)
                {
                    MessageBox.Show("Todavía no hay alumnos cargados en la base de datos");
                }
                else
                {
                    while (reader.Read())
                    {
                        // Acceder a los datos de cada fila usando los nombres de las columnas o sus índices
                        string nombre = reader["Nombre"].ToString();
                        string apellido = reader["Apellido"].ToString();
                        int id = Convert.ToInt32(reader["ID"]);

                        Alumno alum = new Alumno(nombre, apellido, id);
                        list.Add(alum);

                        int n = dataGridView1.Rows.Add();

                        dataGridView1.Rows[n].Cells[0].Value = alum.Name;
                        dataGridView1.Rows[n].Cells[1].Value = alum.Apelliddo;
                        dataGridView1.Rows[n].Cells[2].Value = alum.Id;
                    }

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alumno NewAlumno = new Alumno(textBox1.Text, textBox2.Text);
            SetId(NewAlumno);
            list.Add(NewAlumno);
            textBox1.Text = "";
            textBox2.Text = "";
            try
            {

                conexionConnection.Open();

                // Crear la consulta SQL con parámetros
                string Insert = "INSERT INTO users(Nombre, Apellido, ID) VALUES (@Nombre, @Apellido, @ID)";

                // Crear el comando con la consulta SQL y la conexión
                MySqlCommand cmd = new MySqlCommand(Insert, conexionConnection);

                // Asignar valores a los parámetros
                cmd.Parameters.AddWithValue("@Nombre", NewAlumno.Name);
                cmd.Parameters.AddWithValue("@Apellido", NewAlumno.Apelliddo);
                cmd.Parameters.AddWithValue("@ID", NewAlumno.Id);

                // Ejecutar el comando
                cmd.ExecuteNonQuery();

                // Cerrar la conexión
                conexionConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la siguiente operacion por el siguiente motivo =  " + ex.Message);
            }
        }
        private void SetId(Alumno al)
        {
            list = list.OrderBy(x => x.Id).ToList();
            if (list != null && list.Count > 0)
            {
                Alumno UltimoAlumno = list.FindLast(x => x.Id != null);
                al.SetId = UltimoAlumno.Id + 1;
            }
            else
            {
                al.SetId = 1;
            }

        }
    }
}
public class Alumno
{
    private String _name { get; set; }
    private int _id { get; set; }
    private String _apellido { get; set; }
    private Boolean _registraddo { get; set; }


    public Alumno(String name, String apellido)
    {
        this._name = name;
        this._apellido = apellido;
        this._registraddo = false;
    }
    public Alumno(String name, String apellido, int id)
    {
        this._name = name;
        this._apellido = apellido;
        this._registraddo = false;
        this._id = id;
    }

    public String Name { get { return _name; } }
    public String Apelliddo { get { return _apellido; } }
    public int Id { get { return _id; } }

    public int SetId
    {
        get => _id;
        set
        {
            _id = value;
        }
    }
}
