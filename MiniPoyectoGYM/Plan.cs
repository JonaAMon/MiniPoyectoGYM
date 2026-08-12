using MiniPoyectoGYM.Generales;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPoyectoGYM
{
    public class Plan
    {
        private int id;
        private string? nombre;
        private double precio;
        private int duracionMeses;

        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }

        public double Precio
        {
            get => precio;
            set
            {
                if (value <= 0) throw new ArgumentException("El precio debe ser positivo.");
                precio = value;
            }
        }

        public int DuracionMeses
        {
            get => duracionMeses;
            set
            {
                if (value <= 0) throw new ArgumentException("La duración debe ser de al menos 1 mes.");
                duracionMeses = value;
            }
        }

        public Plan() { }

        public Plan(string nombre, double precio, int duracionMeses)
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.DuracionMeses = duracionMeses;
           
        }

        public void Imprimir()
        {
            Console.WriteLine($"[ID: #{this.Id}] Plan: {this.Nombre} | Duración: {this.DuracionMeses} mes(es) | Precio: ${this.Precio:F2}");
        }
    }
}
