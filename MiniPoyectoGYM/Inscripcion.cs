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
        public DateOnly FechaInicio { get; set; }
        public bool Activa { get => activa; set => activa = value; }

        public Inscripcion() { }

        public Inscripcion(Socio socio, Entrenador entrenador, Plan plan)
        {
            this.Socio = socio;
            this.Entrenador = entrenador;
            this.Plan = plan;
            if (socio != null) this.SocioId = socio.Id;
            if (entrenador != null) this.EntrenadorId = entrenador.Id;
            if (plan != null) this.PlanId = plan.Id;
                FechaInicio = DateOnly.FromDateTime(DateTime.Now);
                Activa = true;
            

        }

        public void Imprimir()
        {
            string nombreSocio = Socio != null ? Socio.Nombre : "Sin Socio";
            string nombrePlan = Plan != null ? Plan.Nombre : "Sin Plan";
            string nombreEntrenador = Entrenador != null ? Entrenador.Nombre : "Sin Entrenador";
            string estado = Activa ? "Activa" : "Inactiva/Cancelada";

            Console.WriteLine($"[Inscripción #{Id}] Socio: {nombreSocio} | Plan: {nombrePlan}");
            Console.WriteLine($"Entrenador: {nombreEntrenador} | Fecha: {FechaInicio.ToShortDateString()} | Estado: {estado}");
        }
    }
}
