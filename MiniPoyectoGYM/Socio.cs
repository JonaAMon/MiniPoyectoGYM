using MiniPoyectoGYM.Generales;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPoyectoGYM
{
    public class Socio
    {
        private string? nombre;
        private string? cedula;
        private int edad;
        private int id;

        public int Id
        {
            get => id;
            set => id = value;
        }
        public string? Nombre { get => nombre; set => nombre = value; }

        public string? Cedula
        {
            get => cedula;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 10)
                    throw new ArgumentException("La cédula debe tener 10 dígitos.");
                cedula = value;
            }
        }

        public int Edad
        {
            get => edad;
            set
            {
                if (value < 14) throw new ArgumentException("El socio debe tener al menos 14 años.");
                edad = value;
            }
        }

        public Socio() { }

        public Socio(string nombre, string cedula, int edad)
        {
            this.Nombre = nombre;
            this.Cedula = cedula;
            this.Edad = edad;

        }

        public void Imprimir()
        {
            Console.WriteLine($"[ID: #{this.Id}] Socio: {this.Nombre} | Cédula: {this.Cedula} | Edad: {this.Edad} años");
        }
    }
}

