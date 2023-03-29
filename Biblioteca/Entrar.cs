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
    public partial class Entrar : Form
    {
        public Entrar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {  
            try
            {
                TextReader Inicio = new StreamReader(textBox1.Text + ".txt");
                if (Inicio.ReadLine() == textBox2.Text)
                {
                    MessageBox.Show("Se iniciado Sesion");
                    Form1 open = new Form1();
                    this.Hide();
                    open.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo Iniciar Sesion");

                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Hubo un error" + x, "Error");
                
            }
        }
    }
}
