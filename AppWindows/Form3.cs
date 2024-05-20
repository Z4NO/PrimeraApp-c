using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;



namespace AppWindows
{
    public partial class Form3 : Form
    {
        String Nombre;
        public Form3(String Nombre)
        {
            InitializeComponent();
            this.Nombre = Nombre;
            
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox1.Visible = false;
            BtnRestaurar.Visible = true;

        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            BtnRestaurar.Visible=false;
            pictureBox1.Visible=true;
        }

        private void panelControaldor_Paint(object sender, PaintEventArgs e)
        {

        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern IntPtr SendMessage(System.IntPtr hWnd, int wMsg,int WParam, int Pram);

        private void button2_Click(object sender, EventArgs e)
        {
            ChatRoom uno = new ChatRoom();
            uno.Show();
            
        }

        
    }
}
