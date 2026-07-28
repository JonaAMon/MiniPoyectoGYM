using MiniPoyectoGYM.Generales;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPoyectoGYM
{
    public class Entrenador
    {
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
       
            this.Nombre = nombre;
            this.Especialidad = especialidad;
            this.Id = Database.Entrenadores.Count == 0 ? 1 : Database.Entrenadores.Max(e => e.Id) + 1;

        }

        public void Imprimir()
        {
            Console.WriteLine($"[ID: #{this.Id}] Entrenador: {this.Nombre} | Especialidad: {this.Especialidad}");
        }
    }
}
