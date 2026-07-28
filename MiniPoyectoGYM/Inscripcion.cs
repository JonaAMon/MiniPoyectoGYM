using MiniPoyectoGYM.Generales;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPoyectoGYM
{
    public class Inscripcion
    {
        private int id;
        private Socio socio;
        private Entrenador entrenador;
        private Plan plan;
        private DateTime fechaInicio;
        private bool activa;

        public int Id { get => id; set => id = value; }
        public Socio Socio { get => socio; set => socio = value; }
        public Entrenador Entrenador { get => entrenador; set => entrenador = value; }
        public Plan Plan { get => plan; set => plan = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public bool Activa { get => activa; set => activa = value; }

        public Inscripcion() { }

        public Inscripcion(Socio socio, Entrenador entrenador, Plan plan)
        {
            this.Socio = socio;
            this.Entrenador = entrenador;
            this.Plan = plan;
            this.FechaInicio = DateTime.Now;
            this.Activa = true;
            this.Id = Database.Inscripciones.Count == 0 ? 1 : Database.Inscripciones.Max(i => i.Id) + 1;

        }

        public void Imprimir()
        {
            string estado = this.Activa ? "Activa" : "Inactiva/Cancelada";
            Console.WriteLine($"[Inscripción #{this.Id}] Socio: {this.Socio?.Nombre ?? "N/A"} | Plan: {this.Plan?.Nombre ?? "N/A"}");
            Console.WriteLine($"   Entrenador: {this.Entrenador?.Nombre ?? "N/A"} | Fecha: {this.FechaInicio.ToShortDateString()} | Estado: {estado}");
        }
    }
}
