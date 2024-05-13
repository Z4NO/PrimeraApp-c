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

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
