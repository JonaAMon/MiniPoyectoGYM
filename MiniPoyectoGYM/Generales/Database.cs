using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPoyectoGYM.Generales
{
    internal class Database
    {
        // Colecciones en memoria para reemplazar la base de datos
        static List<Socio> listaSocios = new List<Socio>();
        static List<Entrenador> listaEntrenadores = new List<Entrenador>();
        static List<Plan> listaPlanes = new List<Plan>();
        static List<Inscripcion> listaInscripciones     = new List<Inscripcion>();
    }
}
