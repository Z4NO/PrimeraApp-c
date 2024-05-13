using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppWindows
{
    public partial class Form1 : Form
    {
        public List<Alumno> list = new List<Alumno>();

        private static String conexion = "server=localhost;port=3306;uid=root;pwd='';database=users;";
        private MySqlConnection conexionConnection = new MySqlConnection(conexion);
        private void ConectarBase()
        {
            try
            {
                conexionConnection.Open();
                MessageBox.Show("Connectado a la base de datos");
                conexionConnection.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"No se pudo conectar por el anterior error");
            }
        }
        public Form1()
        {
            InitializeComponent();
            ConectarBase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void LabeNombre_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
            }catch(Exception ex)
            {
                MessageBox.Show("No se pudo realizar la siguiente operacion por el siguiente motivo =  " + ex.Message);  
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Ventana2 = new Form2(list);
            Ventana2.ShowDialog();
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
    public Alumno(String name, String apellido, int id )
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
