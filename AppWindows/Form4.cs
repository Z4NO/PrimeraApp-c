using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppWindows
{
    public partial class Form4 : Form
    {
        private MySqlConnection conexionConnection;
        private String id;
        public Form4(MySqlConnection conexionConnection, string id)
        {
            InitializeComponent();
            this.conexionConnection = conexionConnection;
            this.id = id;
            Cargar_tareas();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        public void Cargar_tareas()
        {
            conexionConnection.Open();
            string selectAdminQuery = "SELECT * FROM tareas WHERE FK_ID = @id";
            using (MySqlCommand cmd = new MySqlCommand(selectAdminQuery, conexionConnection))
            {
                cmd.Parameters.AddWithValue("@id", this.id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.FieldCount > 0)
                    {
                        //limpiamos el datagridview
                        Limpiar();
                        while(reader.Read())
                        {
                            String Nombre = reader["Nombre"].ToString();
                            Boolean Completada = Convert.ToBoolean(reader["Completado"]);
                            String Archivo = reader["Archivo"].ToString().ToLower();
                            String fecha = Convert.ToDateTime(reader["fecha"]).ToString("dd/MM/yyyy");

                            int n = dataGridView1.Rows.Add();

                            dataGridView1.Rows[n].Cells[0].Value = Nombre;
                            dataGridView1.Rows[n].Cells[1].Value = fecha;
                            if(DateTime.Now > Convert.ToDateTime(fecha))
                            {
                                dataGridView1.Rows[n].Cells[1].Style.BackColor = Color.Red;
                            }
                            else
                            {
                                dataGridView1.Rows[n].Cells[1].Style.BackColor = Color.Green;
                            }
                            dataGridView1.Rows[n].Cells[2].Value = Completada;
                            if (dataGridView1.Rows[n].Cells[2].Value.ToString() == "True")
                            {
                                dataGridView1.Rows[n].Cells[2].Style.BackColor = Color.Green;
                            }
                            else
                            {
                                dataGridView1.Rows[n].Cells[2].Style.BackColor = Color.Red;
                            }
                            dataGridView1.Rows[n].Cells[3].Value = Archivo;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Todavía no tienes ninguna tarea asiganada o creada");
                    }
                }
            }
            conexionConnection.Close();
        }

        private void Limpiar()
        {
            this.dataGridView1.Rows.Clear();
        }
    }
}
