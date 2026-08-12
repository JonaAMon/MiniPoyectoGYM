using MiniPoyectoGYM.Generales;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPoyectoGYM
{
    public class Inscripcion
    {
        private int id;
        private int socioId;
        private int entrenadorId;
        private int planId;
        private Socio socio;
        private Entrenador entrenador;
        private Plan plan;
        private DateTime fechaInicio;
        private bool activa;

        public int Id { get => id; set => id = value; }
        public int SocioId { get => socioId; set => socioId = value; }
        public int EntrenadorId { get => entrenadorId; set => entrenadorId = value; }
        public int PlanId { get => planId; set => planId = value; }

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
            

        }

        public void Imprimir()
        {
            string estado = this.Activa ? "Activa" : "Inactiva/Cancelada";
            Console.WriteLine($"[Inscripción #{this.Id}] Socio: {this.Socio?.Nombre ?? "N/A"} | Plan: {this.Plan?.Nombre ?? "N/A"}");
            Console.WriteLine($"   Entrenador: {this.Entrenador?.Nombre ?? "N/A"} | Fecha: {this.FechaInicio.ToShortDateString()} | Estado: {estado}");
        }
    }
}
