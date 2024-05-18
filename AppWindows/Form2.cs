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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using System.Net.Mail;
using System.Net;



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
            var row = dataGridView1.Rows[e.RowIndex];
            var id = row.Cells["ID"].Value.ToString();

            

            //CONSULTA SQL UPDATE DE RESGISTRADO
            try
            {
                

                // Crear la consulta SQL con parámetros
                string Insert = "UPDATE users SET Registrado = true WHERE ID = @id";
                MySqlCommand cmd = new MySqlCommand(Insert, conexionConnection);
                if (row.Cells["Registrado"].Value.ToString() == "True")
                {
                    MessageBox.Show("El alumno ya se encuentra registrado");
                    return;
                }
                else
                {
                    string EMIAL = Interaction.InputBox("Ingrese el email del alumno con ID = " + id, "Email", "", -1, -1);
                    if (EMIAL == null || EMIAL == "")
                    {
                        MessageBox.Show("No se ha ingresado un email");
                        return;
                    }
                    else
                    {
                        //Para actualizar el email
                        conexionConnection.Open();
                        string InsertEmail = "UPDATE users SET Email = @Email WHERE ID = @id";
                        MySqlCommand cmdEmail = new MySqlCommand(InsertEmail, conexionConnection);
                        cmdEmail.Parameters.AddWithValue("@Email", EMIAL);
                        cmdEmail.Parameters.AddWithValue("@id", id);    
                        cmdEmail.ExecuteNonQuery();
                        row.Cells["Email"].Value = EMIAL;
                        conexionConnection.Close();
                        //Actualizar el email en el usuario
                        list.Find(x => x.Id == Convert.ToInt32(id)).SetEmail = EMIAL;
                        //Actualizar el estado de registrado
                        conexionConnection.Open();
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        conexionConnection.Close();

                        row.Cells["Registrado"].Value = true;
                        row.Cells["Registrado"].Style.BackColor = Color.Green;

                        MessageBox.Show("Se ha registrado el alumno con ID = " + id);
                    }  
                }
            }catch(Exception ex)
            {
                MessageBox.Show("No se pudo realizar la siguiente operacion por el siguiente motivo =  " + ex.Message);
            }

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
                        Boolean registrado =  Convert.ToBoolean(reader["Registrado"]);
                        dynamic email = reader["Email"].ToString();

                        Alumno alum = new Alumno(nombre, apellido, id, registrado, email);
                        list.Add(alum);

                        int n = dataGridView1.Rows.Add();

                        dataGridView1.Rows[n].Cells[0].Value = alum.Name;
                        dataGridView1.Rows[n].Cells[1].Value = alum.Apelliddo;
                        dataGridView1.Rows[n].Cells[2].Value = alum.Id;
                        dataGridView1.Rows[n].Cells[3].Value = alum.Registrado;
                        if (dataGridView1.Rows[n].Cells[3].Value.ToString() == "True")
                        {
                            dataGridView1.Rows[n].Cells[3].Style.BackColor = Color.Green;
                        }
                        else
                        {
                            dataGridView1.Rows[n].Cells[3].Style.BackColor = Color.Red;
                        }
                        dataGridView1.Rows[n].Cells[4].Value = alum.email;
                        if(dataGridView1.Rows[n].Cells[4].Value.ToString() == "")
                        {
                            dataGridView1.Rows[n].Cells[4].Value = "No tiene email";
                        }
                        else
                        {
                            dataGridView1.Rows[n].Cells[4].Value = alum.email;
                        }
                        
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
        private void Limpiar()
        {
            this.dataGridView1.Rows.Clear();
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
            Limpiar();
            CargarUsuarios();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String busqueda = textBox3.Text;
            if (busqueda == "")
            {
                dataGridView1.Rows.Clear();
                CargarUsuarios();
            }
            else
            {
                List <Alumno> alumno_encontrados = list.FindAll(x => x.Name == busqueda);
                if (alumno_encontrados == null)
                {
                    MessageBox.Show("No se ha encontrado un alumno con ID = " + busqueda);
                    return;
                }
                else
                {
                   foreach(Alumno al in alumno_encontrados)
                   {
                        dataGridView1.Rows.Clear();
                        dataGridView1.Rows.Add(al.Name, al.Apelliddo, al.Id, al.Registrado, al.email);
                   }
                   
                }
            }   
        }
        private void Enviar_Email(String body)
        {
            String user = Interaction.InputBox("Ingrese el nombre o ID del alumno para enciar el emial", "Enviar Email", "", -1, -1);
            String asunto = Interaction.InputBox("Ingrese el asunto del email", "Asunto", "", -1, -1); 
            String emsg = "Error al enviar el email, pómgase en contacto con el provedor del software";
            String from = "s7200084@gmail.com";
            String displayName = "Sistema de registro de alumnos";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(list.Find(x => x.Name == user || x.Id.ToString() == user).email);
                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(from, "Baloncesto2005");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                MessageBox.Show("Se ha enviado el email al alumno con nombre o ID = " + user);
            }catch(Exception ex)
            {
                MessageBox.Show(emsg + " = " + ex.Message);
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Nos permite enviar los emails a todos los alumnos registrados
            if (comboBox3.Text == "Dar de Baja")
            {
                String serach = Interaction.InputBox("Ingrese el nombre o ID del alumno a dar de baja", "Dar de baja", "", -1, -1);
                try
                {
                    conexionConnection.Open();
                    string delete = "DELETE FROM users WHERE Nombre = @nombre OR ID = @id";
                    MySqlCommand cmd = new MySqlCommand(delete, conexionConnection);
                    cmd.Parameters.AddWithValue("@nombre", serach);
                    cmd.Parameters.AddWithValue("@id", serach);
                    cmd.ExecuteNonQuery();
                    conexionConnection.Close();
                    dataGridView1.Rows.Clear();
                    CargarUsuarios();
                    MessageBox.Show("Se ha dado de baja al alumno con nombre o ID = " + serach);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo realizar la siguiente operacion por el siguiente motivo =  " + ex.Message);
                }
            }
            else if (comboBox3.Text == "Enviar Email")
            {
                String body = @"<!DOCTYPE html>
                                <html lang='es'>
                                <head>
                                    <meta charset='UTF-8'>
                                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                    <title>Bienvenido a la Aplicación</title>
                                    <style>
                                        body {
                                            font-family: Arial, sans-serif;
                                            background-color: #f4f4f4;
                                            margin: 0;
                                            padding: 0;
                                        }
                                        .container {
                                            max-width: 600px;
                                            margin: 20px auto;
                                            background-color: #ffffff;
                                            padding: 20px;
                                            border: 1px solid #dddddd;
                                            border-radius: 5px;
                                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                                        }
                                        h1 {
                                            color: #333333;
                                        }
                                        p {
                                            color: #555555;
                                        }
                                        .footer {
                                            margin-top: 20px;
                                            text-align: center;
                                            color: #999999;
                                            font-size: 12px;
                                        }
                                    </style>
                                </head>
                                <body>
                                    <div class='container'>
                                        <h1>¡Bienvenido a Nuestra Aplicación!</h1>
                                        <p>Hola,</p>
                                        <p>Nos complace informarte que has sido dado de alta en nuestra aplicación. Tu correo electrónico registrado es: <strong>email</strong></p>
                                        <p>Si tienes alguna pregunta o necesitas ayuda, no dudes en contactarnos.</p>
                                        <p>¡Gracias por unirte a nosotros!</p>
                                        <div class='footer'>
                                            <p>Este es un mensaje automático, por favor no respondas a este correo.</p>
                                        </div>
                                    </div>
                                </body>
                                </html>
                                ";
                Enviar_Email(body);
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
    dynamic _email { get; set; }    


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
    public Alumno(String name, String apellido, int id, Boolean registrado, dynamic email)
    {
        this._name = name;
        this._apellido = apellido;
        this._registraddo = registrado;
        this._id = id;
        this._email = email;
    }

    public String Name { get { return _name; } }
    public String Apelliddo { get { return _apellido; } }
    public int Id { get { return _id; } }
    public Boolean Registrado {  get { return _registraddo; } }
    public dynamic email { get { return _email; } }

    public dynamic SetEmail
    {
        get => _email;
        set
        {
            _email = value;
        }
    }

    public int SetId
    {
        get => _id;
        set
        {
            _id = value;
        }
    }
}
