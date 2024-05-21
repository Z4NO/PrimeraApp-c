using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWindows
{
    internal class Customui
    {
        public static void LoadDefaultStyle(Form actualFrom)
        {
            // Load default style
            foreach (Control control in actualFrom.Controls)
            {
                if(control is Panel)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(26, 32, 40);
                }
                else if(control is Button)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is TextBox)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is Label)
                {
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is DataGridView)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is ListBox)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is ComboBox)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is CheckBox)
                {
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is RadioButton)
                {
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is PictureBox)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                }
                else if(control is NumericUpDown)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is DateTimePicker)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is TabControl)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is TabPage)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is GroupBox)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is RichTextBox)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is Panel)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                }
                else if(control is ProgressBar)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is ListView)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    control.ForeColor = System.Drawing.Color.White;
                }
                else if(control is TreeView)
                {
                    control.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                    
                }

            }
        }
    }
}
