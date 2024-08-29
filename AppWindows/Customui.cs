using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppWindows
{
    internal class Customui
    {
        public static void LoadDefaultStyle(Form actualForm)
        {
            // Load default style
            foreach (Control control in actualForm.Controls)
            {
                ApplyStyle(control);
            }
        }

        private static void ApplyStyle(Control control)
        {
            if (control is Panel)
            {
                control.BackColor = Color.FromArgb(26, 32, 40);
            }
            else if (control is Button button)
            {
                button.BackColor = Color.FromArgb(37, 46, 59);
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
            }
            else if (control is TextBox textBox)
            {
                textBox.BackColor = Color.FromArgb(37, 46, 59);
                textBox.ForeColor = Color.White;
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is Label)
            {
                control.ForeColor = Color.White;
            }
            else if (control is DataGridView dgv)
            {
                dgv.BackgroundColor = Color.FromArgb(37, 46, 59);
                dgv.ForeColor = Color.White;
                dgv.BorderStyle = BorderStyle.None;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 46, 59);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 46, 59);
                dgv.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            }
            else if (control is ListBox)
            {
                control.BackColor = Color.FromArgb(37, 46, 59);
                control.ForeColor = Color.White;
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.BackColor = Color.FromArgb(37, 46, 59);
                comboBox.ForeColor = Color.White;
                comboBox.FlatStyle = FlatStyle.Flat;
            }
            else if (control is CheckBox)
            {
                control.ForeColor = Color.White;
            }
            else if (control is RadioButton)
            {
                control.ForeColor = Color.White;
            }
            else if (control is PictureBox)
            {
                control.BackColor = Color.FromArgb(37, 46, 59);
            }
            else if (control is NumericUpDown numericUpDown)
            {
                numericUpDown.BackColor = Color.FromArgb(37, 46, 59);
                numericUpDown.ForeColor = Color.White;
                numericUpDown.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is DateTimePicker dateTimePicker)
            {
                dateTimePicker.BackColor = Color.FromArgb(37, 46, 59);
                dateTimePicker.ForeColor = Color.White;
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = "dd/MM/yyyy";
            }
            else if (control is TabControl tabControl)
            {
                tabControl.BackColor = Color.FromArgb(37, 46, 59);
                tabControl.ForeColor = Color.White;
                foreach (TabPage tabPage in tabControl.TabPages)
                {
                    ApplyStyle(tabPage);
                }
            }
            else if (control is TabPage)
            {
                control.BackColor = Color.FromArgb(37, 46, 59);
                control.ForeColor = Color.White;
            }
            else if (control is GroupBox)
            {
                control.BackColor = Color.FromArgb(37, 46, 59);
                control.ForeColor = Color.White;
            }
            else if (control is RichTextBox richTextBox)
            {
                richTextBox.BackColor = Color.FromArgb(37, 46, 59);
                richTextBox.ForeColor = Color.White;
                richTextBox.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is ProgressBar progressBar)
            {
                progressBar.BackColor = Color.FromArgb(37, 46, 59);
                progressBar.ForeColor = Color.White;
                progressBar.Style = ProgressBarStyle.Continuous;
            }
            else if (control is ListView listView)
            {
                listView.BackColor = Color.FromArgb(37, 46, 59);
                listView.ForeColor = Color.White;
                listView.BorderStyle = BorderStyle.None;
            }
            else if (control is TreeView treeView)
            {
                treeView.BackColor = Color.FromArgb(37, 46, 59);
                treeView.ForeColor = Color.White;
                treeView.BorderStyle = BorderStyle.None;
            }

            // Aplicar estilo a los controles hijos
            foreach (Control childControl in control.Controls)
            {
                ApplyStyle(childControl);
            }
        }
    }
}
