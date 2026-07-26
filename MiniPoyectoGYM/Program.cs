using System;
using System.Collections.Generic;

namespace MiniPoyectoGYM
{
    internal class Program
    {
        static List<Socio> listaSocios = new List<Socio>();
        static List<Entrenador> listaEntrenadores = new List<Entrenador>();
        static List<Plan> listaPlanes = new List<Plan>();
        static List<Inscripcion> listaInscripciones = new List<Inscripcion>();

        static void Main(string[] args)
        {
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("****************SISTEMA DE GESTIÓN GIMNASIO (GYM)****************");
                Console.WriteLine("Menú de Opciones:");
                Console.WriteLine("1.- Crear Socio");
                Console.WriteLine("2.- Listar Socios");
                Console.WriteLine("3.- Actualizar Socio");
                Console.WriteLine("4.- Eliminar Socio");
                Console.WriteLine("5.- Crear Entrenador");
                Console.WriteLine("6.- Listar Entrenadores");
                Console.WriteLine("7.- Actualizar Entrenador");
                Console.WriteLine("8.- Eliminar Entrenador");
                Console.WriteLine("9.- Crear Plan");
                Console.WriteLine("10.- Listar Planes");
                Console.WriteLine("11.- Actualizar Plan");
                Console.WriteLine("12.- Eliminar Plan");
                Console.WriteLine("13.- Crear Inscripción");
                Console.WriteLine("14.- Listar Inscripciones");
                Console.WriteLine("15.- Cambiar Estado Inscripción");
                Console.WriteLine("16.- Eliminar Inscripción");
                Console.WriteLine("17.- Salir");
                Console.WriteLine("");
                Console.Write("Ingrese una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0;
                }

                switch (opcion)
                {
                    case 1: crearSocio(); break;
                    case 2: listarSocios(); break;
                    case 3: actualizarSocio(); break;
                    case 4: eliminarSocio(); break;
                    case 5: crearEntrenador(); break;
                    case 6: listarEntrenadores(); break;
                    case 7: actualizarEntrenador(); break;
                    case 8: eliminarEntrenador(); break;
                    case 9: crearPlan(); break;
                    case 10: listarPlanes(); break;
                    case 11: actualizarPlan(); break;
                    case 12: eliminarPlan(); break;
                    case 13: crearInscripcion(); break;
                    case 14: listarInscripciones(); break;
                    case 15: cambiarEstadoInscripcion(); break;
                    case 16: eliminarInscripcion(); break;
                    case 17:
                        Console.WriteLine("Saliendo del sistema de gimnasio...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, intente nuevamente.");
                        Console.ReadLine();
                        break;
                }

            } while (opcion != 17);
        }

        static void crearSocio()
        {
            Console.Clear();
            Console.WriteLine("**********Crear Socio**********");
            try
            {
                Console.Write("Ingrese el nombre del socio: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese la cédula (10 dígitos): ");
                string cedula = Console.ReadLine();
                Console.Write("Ingrese la edad del socio: ");
                int edad = Convert.ToInt32(Console.ReadLine());

                listaSocios.Add(new Socio(nombre, cedula, edad));
                Console.WriteLine("Socio guardado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }

        static void listarSocios()
        {
            Console.Clear();
            Console.WriteLine("**********Lista de Socios**********");
            if (listaSocios.Count == 0)
            {
                Console.WriteLine("No hay socios registrados.");
            }
            else
            {
                foreach (var s in listaSocios)
                {
                    s.Imprimir();
                    Console.WriteLine("-----------------------------------");
                }
            }
            Console.ReadLine();
        }

        static void actualizarSocio()
        {
            Console.Clear();
            Console.WriteLine("**********Actualizar Socio**********");
            Console.Write("Ingrese el ID del socio a actualizar: ");
            int idU = Convert.ToInt32(Console.ReadLine());
            var socioU = listaSocios.Find(x => x.Id == idU);

            if (socioU != null)
            {
                try
                {
                    Console.Write($"Ingrese el nuevo nombre ({socioU.Nombre}): ");
                    string n = Console.ReadLine();
                    Console.Write($"Ingrese la nueva edad ({socioU.Edad}): ");
                    string eStr = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(n)) socioU.Nombre = n;
                    if (!string.IsNullOrWhiteSpace(eStr)) socioU.Edad = Convert.ToInt32(eStr);

                    Console.WriteLine("Socio actualizado exitosamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Socio no encontrado.");
            }
            Console.ReadLine();
        }

        static void eliminarSocio()
        {
            Console.Clear();
            Console.WriteLine("**********Eliminar Socio**********");
            Console.Write("Ingrese el ID del socio a eliminar: ");
            int idE = Convert.ToInt32(Console.ReadLine());
            var socioE = listaSocios.Find(x => x.Id == idE);

            if (socioE != null)
            {
                listaSocios.Remove(socioE);
                Console.WriteLine("Socio eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Socio no encontrado.");
            }
            Console.ReadLine();
        }

        static void crearEntrenador()
        {
            Console.Clear();
            Console.WriteLine("**********Crear Entrenador**********");
            try
            {
                Console.Write("Ingrese el nombre del entrenador: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese la especialidad: ");
                string especialidad = Console.ReadLine();

                listaEntrenadores.Add(new Entrenador(nombre, especialidad));
                Console.WriteLine("Entrenador guardado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }

        static void listarEntrenadores()
        {
            Console.Clear();
            Console.WriteLine("**********Lista de Entrenadores**********");
            if (listaEntrenadores.Count == 0)
            {
                Console.WriteLine("No hay entrenadores registrados.");
            }
            else
            {
                foreach (var e in listaEntrenadores)
                {
                    e.Imprimir();
                    Console.WriteLine("-----------------------------------");
                }
            }
            Console.ReadLine();
        }

        static void actualizarEntrenador()
        {
            Console.Clear();
            Console.WriteLine("**********Actualizar Entrenador**********");
            Console.Write("Ingrese el ID del entrenador a actualizar: ");
            int idU = Convert.ToInt32(Console.ReadLine());
            var entU = listaEntrenadores.Find(x => x.Id == idU);

            if (entU != null)
            {
                Console.Write($"Ingrese el nuevo nombre ({entU.Nombre}): ");
                string n = Console.ReadLine();
                Console.Write($"Ingrese la nueva especialidad ({entU.Especialidad}): ");
                string esp = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(n)) entU.Nombre = n;
                if (!string.IsNullOrWhiteSpace(esp)) entU.Especialidad = esp;

                Console.WriteLine("Entrenador actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Entrenador no encontrado.");
            }
            Console.ReadLine();
        }

        static void eliminarEntrenador()
        {
            Console.Clear();
            Console.WriteLine("**********Eliminar Entrenador**********");
            Console.Write("Ingrese el ID del entrenador a eliminar: ");
            int idE = Convert.ToInt32(Console.ReadLine());
            var entE = listaEntrenadores.Find(x => x.Id == idE);

            if (entE != null)
            {
                listaEntrenadores.Remove(entE);
                Console.WriteLine("Entrenador eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Entrenador no encontrado.");
            }
            Console.ReadLine();
        }


        static void crearPlan()
        {
            Console.Clear();
            Console.WriteLine("**********Crear Plan**********");
            try
            {
                Console.Write("Ingrese el nombre del plan: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese el precio ($): ");
                double precio = Convert.ToDouble(Console.ReadLine());
                Console.Write("Ingrese la duración en meses: ");
                int meses = Convert.ToInt32(Console.ReadLine());

                listaPlanes.Add(new Plan(nombre, precio, meses));
                Console.WriteLine("Plan creado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }

        static void listarPlanes()
        {
            Console.Clear();
            Console.WriteLine("**********Lista de Planes**********");
            if (listaPlanes.Count == 0)
            {
                Console.WriteLine("No hay planes registrados.");
            }
            else
            {
                foreach (var p in listaPlanes)
                {
                    p.Imprimir();
                    Console.WriteLine("-----------------------------------");
                }
            }
            Console.ReadLine();
        }

        static void actualizarPlan()
        {
            Console.Clear();
            Console.WriteLine("**********Actualizar Plan**********");
            Console.Write("Ingrese el ID del plan a actualizar: ");
            int idU = Convert.ToInt32(Console.ReadLine());
            var planU = listaPlanes.Find(x => x.Id == idU);

            if (planU != null)
            {
                try
                {
                    Console.Write($"Ingrese el nuevo nombre ({planU.Nombre}): ");
                    string n = Console.ReadLine();
                    Console.Write($"Ingrese el nuevo precio ({planU.Precio}): ");
                    string pStr = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(n)) planU.Nombre = n;
                    if (!string.IsNullOrWhiteSpace(pStr)) planU.Precio = Convert.ToDouble(pStr);

                    Console.WriteLine("Plan actualizado exitosamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Plan no encontrado.");
            }
            Console.ReadLine();
        }

        static void eliminarPlan()
        {
            Console.Clear();
            Console.WriteLine("**********Eliminar Plan**********");
            Console.Write("Ingrese el ID del plan a eliminar: ");
            int idE = Convert.ToInt32(Console.ReadLine());
            var planE = listaPlanes.Find(x => x.Id == idE);

            if (planE != null)
            {
                listaPlanes.Remove(planE);
                Console.WriteLine("Plan eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Plan no encontrado.");
            }
            Console.ReadLine();
        }

        static void crearInscripcion()
        {
            Console.Clear();
            Console.WriteLine("**********Crear Inscripción**********");
            if (listaSocios.Count == 0 || listaEntrenadores.Count == 0 || listaPlanes.Count == 0)
            {
                Console.WriteLine("Se requiere al menos 1 Socio, 1 Entrenador y 1 Plan registrado para inscribir.");
                Console.ReadLine();
                return;
            }

            try
            {
                Console.Write("Ingrese el ID del socio: ");
                int idS = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingrese el ID del entrenador: ");
                int idE = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingrese el ID del plan: ");
                int idP = Convert.ToInt32(Console.ReadLine());

                var s = listaSocios.Find(x => x.Id == idS);
                var e = listaEntrenadores.Find(x => x.Id == idE);
                var p = listaPlanes.Find(x => x.Id == idP);

                if (s != null && e != null && p != null)
                {
                    listaInscripciones.Add(new Inscripcion(s, e, p));
                    Console.WriteLine("¡Inscripción realizada exitosamente!");
                }
                else
                {
                    Console.WriteLine("Uno de los IDs ingresados no existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }

        static void listarInscripciones()
        {
            Console.Clear();
            Console.WriteLine("**********Lista de Inscripciones**********");
            if (listaInscripciones.Count == 0)
            {
                Console.WriteLine("No hay inscripciones registradas.");
            }
            else
            {
                foreach (var i in listaInscripciones)
                {
                    i.Imprimir();
                    Console.WriteLine("-----------------------------------");
                }
            }
            Console.ReadLine();
        }

        static void cambiarEstadoInscripcion()
        {
            Console.Clear();
            Console.WriteLine("**********Cambiar Estado de Inscripción**********");
            Console.Write("Ingrese el ID de la inscripción: ");
            int idU = Convert.ToInt32(Console.ReadLine());
            var insU = listaInscripciones.Find(x => x.Id == idU);

            if (insU != null)
            {
                insU.Activa = !insU.Activa;
                Console.WriteLine($"Estado actualizado a: {(insU.Activa ? "Activa" : "Inactiva")}");
            }
            else
            {
                Console.WriteLine("Inscripción no encontrada.");
            }
            Console.ReadLine();
        }

        static void eliminarInscripcion()
        {
            Console.Clear();
            Console.WriteLine("**********Eliminar Inscripción**********");
            Console.Write("Ingrese el ID de la inscripción a eliminar: ");
            int idDel = Convert.ToInt32(Console.ReadLine());
            var insDel = listaInscripciones.Find(x => x.Id == idDel);

            if (insDel != null)
            {
                listaInscripciones.Remove(insDel);
                Console.WriteLine("Inscripción eliminada exitosamente.");
            }
            else
            {
                Console.WriteLine("Inscripción no encontrada.");
            }
            Console.ReadLine();
        }


    }
}