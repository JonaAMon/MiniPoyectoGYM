using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MiniPoyectoGYM;
using MiniPoyectoGYM.Generales;
using MiniPoyectoGYM.Datos;

// Asegura que la base de datos existe antes de ejecutar las operaciones
using (var db = new GymDbContext())
{
    db.Database.EnsureCreated();
}

int opcion = 0;

do
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine(@"
    _   _   _________________________________   _   _
   | |_| | /                                 \ | |_| |
   |  _  | |   SISTEMA DE GESTION GIMNASIO   | |  _  |
   |_| |_| \_________________________________/ |_| |_|
   [_____]                                     [_____]
    ");
    Console.ForegroundColor = ConsoleColor.White;
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
    Console.WriteLine("17.- Salir al Torneo de Fútbol");
    Console.WriteLine("");
    Console.Write("Ingrese una opción: ");

    opcion = Convert.ToInt32(Console.ReadLine());

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
        case 17: Console.WriteLine("Saliendo del sistema de gimnasio..."); break;
        default:
            Console.WriteLine("Opción inválida. Por favor, intente nuevamente.");
            Console.ReadLine();
            break;
    }

} while (opcion != 17);
void crearSocio()
{
    Console.Clear();
    Console.WriteLine("**********Crear Socio**********");
    try
    {
        Console.WriteLine("Ingrese el nombre del socio: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese la cédula (10 dígitos): ");
        string cedula = Console.ReadLine();
        Console.WriteLine("Ingrese la edad del socio: ");
        int edad = Convert.ToInt32(Console.ReadLine());

        using (var db = new GymDbContext())
        {
            db.Socios.Add(new Socio(nombre, cedula, edad));
            db.SaveChanges();
        }
        Console.WriteLine("Socio guardado exitosamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    Console.ReadLine();
}

void listarSocios()
{
    Console.Clear();
    Console.WriteLine("**********Lista de Socios**********");
    using (var db = new GymDbContext())
    {
        var socios = db.Socios.ToList();
        foreach (var s in socios)
        {
            s.Imprimir();
            Console.WriteLine("-----------------------------------");
        }
    }
    Console.ReadLine();
}

void actualizarSocio()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Socio**********");
    Console.WriteLine("Ingrese el ID del socio a actualizar: ");
    int idU = Convert.ToInt32(Console.ReadLine());

    using (var db = new GymDbContext())
    {
        var socioU = db.Socios.Find(idU);
        if (socioU != null)
        {
            try
            {
                Console.WriteLine($"Ingrese el nuevo nombre ({socioU.Nombre}): ");
                string n = Console.ReadLine();
                Console.WriteLine($"Ingrese la nueva cédula ({socioU.Cedula}): ");
                string c = Console.ReadLine();
                Console.WriteLine($"Ingrese la nueva edad ({socioU.Edad}): ");
                string eStr = Console.ReadLine();
                

                if (!string.IsNullOrWhiteSpace(n)) socioU.Nombre = n;
                if (!string.IsNullOrWhiteSpace(c)) socioU.Cedula = c;
                if (!string.IsNullOrWhiteSpace(eStr)) socioU.Edad = Convert.ToInt32(eStr);

                db.SaveChanges();
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
    }
    Console.ReadLine();
}

void eliminarSocio()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Socio**********");
    Console.WriteLine("Ingrese el ID del socio a eliminar: ");
    int idE = Convert.ToInt32(Console.ReadLine());

    using (var db = new GymDbContext())
    {
        var socioE = db.Socios.Find(idE);
        if (socioE != null)
        {
            db.Socios.Remove(socioE);
            db.SaveChanges();
            Console.WriteLine("Socio eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("Socio no encontrado.");
        }
    }
    Console.ReadLine();
}
void crearEntrenador()
{
    Console.Clear();
    Console.WriteLine("**********Crear Entrenador**********");
    try
    {
        Console.WriteLine("Ingrese el nombre del entrenador: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese la especialidad: ");
        string especialidad = Console.ReadLine();

        using (var db = new GymDbContext())
        {
            db.Entrenadores.Add(new Entrenador(nombre, especialidad));
            db.SaveChanges();
        }
        Console.WriteLine("Entrenador guardado exitosamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    Console.ReadLine();
}

void listarEntrenadores()
{
    Console.Clear();
    Console.WriteLine("**********Lista de Entrenadores**********");
    using (var db = new GymDbContext())
    {
        var entrenadores = db.Entrenadores.ToList();
        foreach (var e in entrenadores)
        {
            e.Imprimir();
            Console.WriteLine("-----------------------------------");
        }
    }
    Console.ReadLine();
}

void actualizarEntrenador()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Entrenador**********");
    Console.WriteLine("Ingrese el ID del entrenador a actualizar: ");
    int idU = Convert.ToInt32(Console.ReadLine());

    using (var db = new GymDbContext())
    {
        var entU = db.Entrenadores.Find(idU);
        if (entU != null)
        {
            try
            {
                Console.WriteLine($"Ingrese el nuevo nombre ({entU.Nombre}): ");
                string n = Console.ReadLine();
                Console.WriteLine($"Ingrese la nueva especialidad ({entU.Especialidad}): ");
                string esp = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(n)) entU.Nombre = n;
                if (!string.IsNullOrWhiteSpace(esp)) entU.Especialidad = esp;

                db.SaveChanges();
                Console.WriteLine("Entrenador actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Entrenador no encontrado.");
        }
    }
    Console.ReadLine();
}

void eliminarEntrenador()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Entrenador**********");
    Console.WriteLine("Ingrese el ID del entrenador a eliminar: ");
    int idE = Convert.ToInt32(Console.ReadLine());

    using (var db = new GymDbContext())
    {
        var entE = db.Entrenadores.Find(idE);
        if (entE != null)
        {
            db.Entrenadores.Remove(entE);
            db.SaveChanges();
            Console.WriteLine("Entrenador eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("Entrenador no encontrado.");
        }
    }
    Console.ReadLine();
}
void crearPlan()
{
    Console.Clear();
    Console.WriteLine("**********Crear Plan**********");
    try
    {
        Console.WriteLine("Ingrese el nombre del plan: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese el precio ($): ");
        double precio = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Ingrese la duración en meses: ");
        int meses = Convert.ToInt32(Console.ReadLine());

        using (var db = new GymDbContext())
        {
            db.Planes.Add(new Plan(nombre, precio, meses));
            db.SaveChanges();
        }
        Console.WriteLine("Plan creado exitosamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    Console.ReadLine();
}

void listarPlanes()
{
    Console.Clear();
    Console.WriteLine("**********Lista de Planes**********");
    using (var db = new GymDbContext())
    {
        var planes = db.Planes.ToList();
        foreach (var p in planes)
        {
            p.Imprimir();
            Console.WriteLine("-----------------------------------");
        }
    }
    Console.ReadLine();
}

void actualizarPlan()
{
    Console.Clear();
    Console.WriteLine("**** Actualizar Plan ****");

    using (var db = new GymDbContext())
    {
        Console.WriteLine("Ingrese el ID del plan a modificar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var plan = db.Planes.Find(id);

            if (plan != null)
            {
                // 1. Pedir Nuevo Nombre
                Console.WriteLine($"Nombre actual: {plan.Nombre}");
                Console.WriteLine("Ingrese el nuevo nombre (o presione Enter para mantener el actual):");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    plan.Nombre = nuevoNombre;
                }

                // 2. Pedir Nuevo Precio
                Console.WriteLine($"Precio actual: {plan.Precio}");
                Console.WriteLine("Ingrese el nuevo precio (o presione Enter para mantener el actual):");
                string inputPrecio = Console.ReadLine();
                if (double.TryParse(inputPrecio, out double nuevoPrecio))
                {
                    plan.Precio = nuevoPrecio;
                }

                // 3. PEDIR NUEVA DURACIÓN EN MESES (Asegúrate de tener esta sección)
                Console.WriteLine($"Duración actual: {plan.DuracionMeses} meses");
                Console.WriteLine("Ingrese la nueva duración en meses (o presione Enter para mantener la actual):");
                string inputDuracion = Console.ReadLine();
                if (int.TryParse(inputDuracion, out int nuevaDuracion))
                {
                    plan.DuracionMeses = nuevaDuracion;
                }

                // 4. Guardar cambios en SQL Server
                db.SaveChanges();
                Console.WriteLine("¡Plan actualizado correctamente!");
            }
            else
            {
                Console.WriteLine("No se encontró ningún plan con ese ID.");
            }
        }
        else
        {
            Console.WriteLine("ID no válido.");
        }
    }
    Console.ReadLine();
}

void eliminarPlan()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Plan**********");
    Console.WriteLine("Ingrese el ID del plan a eliminar: ");
    int idE = Convert.ToInt32(Console.ReadLine());

    using (var db = new GymDbContext())
    {
        var planE = db.Planes.Find(idE);
        if (planE != null)
        {
            db.Planes.Remove(planE);
            db.SaveChanges();
            Console.WriteLine("Plan eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("Plan no encontrado.");
        }
    }
    Console.ReadLine();
}
void crearInscripcion()
{
    Console.Clear();
    Console.WriteLine("***Crear Inscripción***");

    using (var db = new GymDbContext())
    {
        if (!db.Socios.Any() || !db.Entrenadores.Any() || !db.Planes.Any())
        {
            Console.WriteLine("Se requiere al menos 1 Socio, 1 Entrenador y 1 Plan para inscribir.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Ingrese el ID del socio: ");
        int idS = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el ID del entrenador: ");
        int idE = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el ID del plan: ");
        int idP = Convert.ToInt32(Console.ReadLine());

        var s = db.Socios.Find(idS);
        var e = db.Entrenadores.Find(idE);
        var p = db.Planes.Find(idP);

        if (s != null && e != null && p != null)
        {
            
            var nuevaInscripcion = new Inscripcion
            {
                SocioId = s.Id,
                EntrenadorId = e.Id,
                PlanId = p.Id,
                Socio = s,
                Entrenador = e,
                Plan = p,
                FechaInicio = DateOnly.FromDateTime(DateTime.Now),
                Activa = true
            };

            db.Inscripciones.Add(nuevaInscripcion);
            int filasAfectadas = db.SaveChanges(); 

            if (filasAfectadas > 0)
            {
                Console.WriteLine("¡Inscripción realizada exitosamente!");
            }
            else
            {
                Console.WriteLine("Advertencia: No se pudo guardar el registro en la base de datos.");
            }
        }
        else
        {
            Console.WriteLine("Uno de los IDs no existe.");
        }
    }
    Console.ReadLine();
}

void listarInscripciones()
{
    Console.Clear();
    Console.WriteLine("***Lista de Inscripciones***");

    try
    {
        using (var db = new GymDbContext())
        {
            var inscripciones = db.Inscripciones
                                  .Include(i => i.Socio)
                                  .Include(i => i.Entrenador)
                                  .Include(i => i.Plan)
                                  .ToList();

           
            if (inscripciones == null || inscripciones.Count == 0)
            {
                Console.WriteLine("No se encontraron inscripciones registradas en la base de datos.");
            }
            else
            {
                foreach (var i in inscripciones)
                {
                    i.Imprimir();
                    Console.WriteLine("----------------------------------");
                }
            }
        }
    }
    catch (Exception ex)
    {
       
        Console.WriteLine($"Error al consultar inscripciones: {ex.Message}");
    }

    Console.ReadLine(); 
}

void cambiarEstadoInscripcion()
{
    Console.Clear();
    Console.WriteLine("**********Cambiar Estado de Inscripción**********");
    Console.WriteLine("Ingrese el ID de la inscripción: ");
    int idU = Convert.ToInt32(Console.ReadLine());

    using (var db = new GymDbContext())
    {
        var insU = db.Inscripciones.Find(idU);
        if (insU != null)
        {
            insU.Activa = !insU.Activa;
            db.SaveChanges();
            Console.WriteLine($"Estado actualizado a: {(insU.Activa ? "Activa" : "Inactiva")}");
        }
        else
        {
            Console.WriteLine("Inscripción no encontrada.");
        }
    }
    Console.ReadLine();
}

void eliminarInscripcion()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Inscripción**********");
    Console.WriteLine("Ingrese el ID de la inscripción a eliminar: ");
    int idDel = Convert.ToInt32(Console.ReadLine());

    using (var db = new GymDbContext())
    {
        var insDel = db.Inscripciones.Find(idDel);
        if (insDel != null)
        {
            db.Inscripciones.Remove(insDel);
            db.SaveChanges();
            Console.WriteLine("Inscripción eliminada exitosamente.");
        }
        else
        {
            Console.WriteLine("Inscripción no encontrada.");
        }
    }
    Console.ReadLine();
}