using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Biblioteca
{
    public partial class Sesion : Form
    {
        public Sesion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                TextWriter RegistroUsuario = new StreamWriter(@"C:\Users\gonae\Downloads\BibliotecaJSON\Biblioteca\bin\Debug\net6.0-windows\" + textBox1.Text + ".txt", true);
                RegistroUsuario.WriteLine(textBox2.Text);
                RegistroUsuario.Close();

                MessageBox.Show("Se registro correctamente");
                Inicio open = new Inicio();
                this.Hide();
                open.ShowDialog();
                this.Close();
            }
            catch (Exception x)
            {

                MessageBox.Show("Hubo un error"+ x, "Error");
            }
        }
    }
}
