using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPoyectoGYM.Generales
{
    public static class Database
    {
        private static readonly string rutaCarpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos");
        private static readonly string rutaSocios = Path.Combine(rutaCarpeta, "socios.json");
        private static readonly string rutaEntrenadores = Path.Combine(rutaCarpeta, "entrenadores.json");
        private static readonly string rutaPlanes = Path.Combine(rutaCarpeta, "planes.json");
        private static readonly string rutaInscripciones = Path.Combine(rutaCarpeta, "inscripciones.json");

        public static List<Socio> Socios { get; set; } = new List<Socio>();
        public static List<Entrenador> Entrenadores { get; set; } = new List<Entrenador>();
        public static List<Plan> Planes { get; set; } = new List<Plan>();
        public static List<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

        public static void CargarDatos()
        {
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            Socios = ArchivoJson.LeerArchivo<Socio>(rutaSocios);
            Entrenadores = ArchivoJson.LeerArchivo<Entrenador>(rutaEntrenadores);
            Planes = ArchivoJson.LeerArchivo<Plan>(rutaPlanes);
            Inscripciones = ArchivoJson.LeerArchivo<Inscripcion>(rutaInscripciones);
        }

        public static void GuardarSocios() => ArchivoJson.Guardar(rutaSocios, Socios);
        public static void GuardarEntrenadores() => ArchivoJson.Guardar(rutaEntrenadores, Entrenadores);
        public static void GuardarPlanes() => ArchivoJson.Guardar(rutaPlanes, Planes);
        public static void GuardarInscripciones() => ArchivoJson.Guardar(rutaInscripciones, Inscripciones);
    }
}