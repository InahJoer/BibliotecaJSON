using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        Basededatos<Persona> bd = new Basededatos<Persona>("bd.json");

        void mostrar(List<Persona> lista)
        {
            dataGridView1.Rows.Clear();

            foreach (Persona p in lista)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.Cells.Add(new DataGridViewTextBoxCell() { Value = p.ISBN });
                fila.Cells.Add(new DataGridViewTextBoxCell() { Value = p.Titulo });
                fila.Cells.Add(new DataGridViewTextBoxCell() { Value = p.Autor });
                fila.Cells.Add(new DataGridViewTextBoxCell() { Value = p.Editorial });
                fila.Cells.Add(new DataGridViewTextBoxCell() { Value = p.Paginas });
                dataGridView1.Rows.Add(fila);
            }
        }

        public Form1()
        {

            InitializeComponent();
            bd.Cargar();
            mostrar(bd.valores);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void brnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Persona p = new Persona(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, int.Parse(textBox5.Text));
                bd.Insertar(p);
                mostrar(bd.valores);
            }
            catch (Exception)
            {
                MessageBox.Show("Debes llenar todos los Campos", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                int ISNB = int.Parse(textBox1.Text);
                string Titulo = textBox2.Text;
                string Autor = textBox3.Text;
                string Editorial = textBox4.Text;
                int Paginas = int.Parse(textBox5.Text);
                Persona p = new Persona(ISNB, Titulo, Autor, Editorial, Paginas);
                bd.Actualizar(x => x.ISBN == ISNB, p);
                bd.Actualizar(x => x.Titulo == Titulo, p);
                bd.Actualizar(x => x.Autor == Autor, p);
                bd.Actualizar(x => x.Editorial == Editorial, p);
                bd.Actualizar(x => x.Paginas == Paginas, p);
                mostrar(bd.valores);
            }
            catch (Exception)
            {

                MessageBox.Show("Debes llenar todos los Campos", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Persona p = bd.Buscar(x => x.ISBN.ToString() == dataGridView1.CurrentRow.Cells[0].Value.ToString())[0];
                textBox1.Text = p.ISBN.ToString();
                textBox2.Text = p.Titulo.ToString();
                textBox3.Text = p.Autor.ToString();
                textBox4.Text = p.Editorial.ToString();
                textBox5.Text = p.Paginas.ToString();
            }
            catch (Exception)
            {


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ISBN = int.Parse(textBox1.Text);
            bd.Eliminar(x => x.ISBN == ISBN);
            mostrar(bd.valores);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            var lista = bd.Buscar(x => x.Titulo.Contains(textBox6.Text));
            mostrar(lista);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
