using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Biblioteca
{
    public class Persona
    {
        public int ISBN;
        public string Titulo;
        public string Autor;
        public string Editorial;
        public int Paginas;
        public Persona(int isbn, string nombre, string autor, string editorial, int paginas)
        {
            this.ISBN = isbn;
            this.Titulo = nombre;
            this.Autor = autor;
            this.Editorial = editorial;
            this.Paginas = paginas;
        }
    }
    public class Basededatos<T>
    {
        public List<T> valores = new List<T>();
        public string ruta;

        public Basededatos(string r)
        {
            ruta = r;
        }
        public void Guardar()
        {
            string texto = JsonConvert.SerializeObject(valores);
            File.WriteAllText(ruta, texto);
        }

        public void Cargar()
        {
            try
            {
                string archivo = File.ReadAllText(ruta);
                valores = JsonConvert.DeserializeObject<List<T>>(archivo);
            }
            catch (Exception) { }
        }


        public void Insertar(T nuevo)
        {
            valores.Add(nuevo);
            Guardar();
        }

        public List<T> Buscar(Func<T, bool> criterio)
        {
            return valores.Where(criterio).ToList();
        }

        public void Eliminar(Func<T, bool> criterio)
        {
            valores = valores.Where(x => !criterio(x)).ToList();

        }

        public void Actualizar(Func<T, bool> criterio, T nuevo)
        {
            valores = valores.Select(x =>
            {
                if (criterio(x)) x = nuevo;
                return x;
            }).ToList();
        }
    }
}
