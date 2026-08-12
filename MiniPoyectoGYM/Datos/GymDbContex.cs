using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPoyectoGYM.Datos
{
    public class GymDbContext: DbContext
    {
        // 1. DbSets para cada entidad del sistema
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }

        

        // 2. Configuración de la cadena de conexión
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                // Cambia 'Server' y 'Database' según los datos de tu servidor local SQL Server
                optionsBuilder.UseSqlServer("Server=DESKTOP-QE2VON0\\SQLEXPRESS;Database=GYM_JANCHUNDIA;User Id=sa;Password=1234;TrustServerCertificate=True;");
            }
        }

        // 3. Mapeo de llaves primarias y relaciones entre tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Llaves Primarias
            modelBuilder.Entity<Socio>().HasKey(s => s.Id);
            modelBuilder.Entity<Entrenador>().HasKey(e => e.Id);
            modelBuilder.Entity<Plan>().HasKey(p => p.Id);
            modelBuilder.Entity<Inscripcion>().HasKey(i => i.Id);

            // Configuración de la entidad Inscripcion y sus relaciones (Claves Foráneas)
            modelBuilder.Entity<Inscripcion>(entity =>
            {
                // Relación Inscripción -> Socio
                entity.HasOne(i => i.Socio)
                      .WithMany()
                      .HasForeignKey(i => i.SocioId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relación Inscripción -> Entrenador
                entity.HasOne(i => i.Entrenador)
                      .WithMany()
                      .HasForeignKey(i => i.EntrenadorId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relación Inscripción -> Plan
                entity.HasOne(i => i.Plan)
                      .WithMany()
                      .HasForeignKey(i => i.PlanId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
