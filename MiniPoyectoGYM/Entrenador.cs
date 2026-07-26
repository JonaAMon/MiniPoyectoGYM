using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPoyectoGYM
{
    public class Entrenador
    {
        private static int contadorId = 0;
        private int id;
        private string nombre;
        private string especialidad;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public string Especialidad
        {
            get => especialidad;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("La especialidad no puede estar vacía.");
                especialidad = value;
            }
        }

        public Entrenador() { }

        public Entrenador(string nombre, string especialidad)
        {
            contadorId++;
            this.Id = contadorId;
            this.Nombre = nombre;
            this.Especialidad = especialidad;
            
        }

        public void Imprimir()
        {
            Console.WriteLine($"[ID: #{this.Id}] Entrenador: {this.Nombre} | Especialidad: {this.Especialidad}");
        }
    }
}
