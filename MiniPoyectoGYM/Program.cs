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

   
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(@"
    .-.                                                                          .-.
  .-| |--------------------------------------------------------------------------| |-.
  | | |                                                                          | | |
  | | |   .------------------------------------------------------------------.   | | |
  |-| |---|  ██████╗ ██╗   ██╗███╗   ███╗      ██████╗ ██████╗ ███╗   ███╗   |---| |-|
  | | |   |  ██╔════╝╚██╗ ██╔╝████╗ ████║      ██╔════╝██╔═══██╗████╗ ████║  |   | | |
  | | |   |  ██║  ███╗╚████╔╝ ██╔████╔██║  ██╗ ██║     ██║   ██║██╔████╔██║  |   | | |
  |-| |---|  ██║   ██║ ╚██╔╝  ██║╚██╔╝██║  ╚═╝ ██║     ██║   ██║██║╚██╔╝██║  |---| |-|
  | | |   |  ╚██████╔╝  ██║   ██║ ╚═╝ ██║      ╚██████╗╚██████╔╝██║ ╚═╝ ██║  |   | | |
  | | |   |   ╚═════╝   ╚═╝   ╚═╝     ╚═╝       ╚═════╝ ╚═════╝ ╚═╝     ╚═╝  |   | | |
  '-| |---|------------------------------------------------------------------|---| |-'
    '-'                                                                          '-'
    ");

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                                MENÚ DE OPCIONES                                   ║");
    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════════════════╣");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("║  [1]  Crear Socio          [5]  Crear Entrenador       [9]  Crear Plan            ║");
    Console.WriteLine("║  [2]  Listar Socios        [6]  Listar Entrenadores    [10] Listar Planes         ║");
    Console.WriteLine("║  [3]  Actualizar Socio     [7]  Actualizar Entrenador  [11] Actualizar Plan       ║");
    Console.WriteLine("║  [4]  Eliminar Socio       [8]  Eliminar Entrenador    [12] Eliminar Plan         ║");
    Console.WriteLine("║ --------------------------------------------------------------------------------- ║");
    Console.WriteLine("║  [13] Crear Inscripción    [14] Listar Inscripciones   [15] Actualizar Inscripción║");
    Console.WriteLine("║  [16] Eliminar Inscripción                             [17] Salir al Torneo       ║");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════╝");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("\n» Ingrese una opción: ");

    int.TryParse(Console.ReadLine(), out opcion);

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
        case 15: actualizarInscripcion(); break;
        case 16: eliminarInscripcion(); break;
        case 17: Console.WriteLine("Saliendo del sistema de gimnasio..."); break;
        default:
            Console.WriteLine("Opción inválida. Presione Enter para reintentar.");
            Console.ReadLine();
            break;
    }

} while (opcion != 17);

int LeerEntero(string mensaje)
{
    int numero;
    Console.Write(mensaje);
    while (!int.TryParse(Console.ReadLine(), out numero))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Entrada no válida. Por favor ingrese un número entero: ");
        Console.ForegroundColor = ConsoleColor.White;
    }
    return numero;
}

double LeerDouble(string mensaje)
{
    double numero;
    Console.Write(mensaje);
    while (!double.TryParse(Console.ReadLine(), out numero) || numero < 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Entrada no válida. Por favor ingrese un monto correcto: ");
        Console.ForegroundColor = ConsoleColor.White;
    }
    return numero;
}

string LeerTextoObligatorio(string mensaje)
{
    Console.Write(mensaje);
    string entrada = Console.ReadLine()?.Trim();
    while (string.IsNullOrWhiteSpace(entrada))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("El campo no puede estar vacío. Intente de nuevo: ");
        Console.ForegroundColor = ConsoleColor.White;
        entrada = Console.ReadLine()?.Trim();
    }
    return entrada;
}


void crearSocio()
{
    Console.Clear();
    Console.WriteLine("**********Crear Socio**********");
    try
    {
        string nombre = LeerTextoObligatorio("Ingrese el nombre del socio: ");
        string cedula = LeerTextoObligatorio("Ingrese la cédula: ");
        int edad = LeerEntero("Ingrese la edad del socio: ");

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
        if (!socios.Any())
        {
            Console.WriteLine("No hay socios registrados.");
        }
        else
        {
            foreach (var s in socios)
            {
                s.Imprimir();
                Console.WriteLine("-----------------------------------");
            }
        }
    }
    Console.ReadLine();
}

void actualizarSocio()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Socio**********");
    int idU = LeerEntero("Ingrese el ID del socio a actualizar: ");

    using (var db = new GymDbContext())
    {
        var socioU = db.Socios.Find(idU);
        if (socioU != null)
        {
            Console.WriteLine($"Ingrese el nuevo nombre ({socioU.Nombre}) [Enter para omitir]: ");
            string n = Console.ReadLine()?.Trim();

            Console.WriteLine($"Ingrese la nueva cédula ({socioU.Cedula}) [Enter para omitir]: ");
            string c = Console.ReadLine()?.Trim();

            Console.WriteLine($"Ingrese la nueva edad ({socioU.Edad}) [Enter para omitir]: ");
            string eStr = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(n)) socioU.Nombre = n;
            if (!string.IsNullOrWhiteSpace(c)) socioU.Cedula = c;
            if (int.TryParse(eStr, out int nuevaEdad)) socioU.Edad = nuevaEdad;

            db.SaveChanges();
            Console.WriteLine("Socio actualizado exitosamente.");
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
    int idE = LeerEntero("Ingrese el ID del socio a eliminar: ");

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
        string nombre = LeerTextoObligatorio("Ingrese el nombre del entrenador: ");
        string especialidad = LeerTextoObligatorio("Ingrese la especialidad: ");

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
        if (!entrenadores.Any())
        {
            Console.WriteLine("No hay entrenadores registrados.");
        }
        else
        {
            foreach (var e in entrenadores)
            {
                e.Imprimir();
                Console.WriteLine("-----------------------------------");
            }
        }
    }
    Console.ReadLine();
}

void actualizarEntrenador()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Entrenador**********");
    int idU = LeerEntero("Ingrese el ID del entrenador a actualizar: ");

    using (var db = new GymDbContext())
    {
        var entU = db.Entrenadores.Find(idU);
        if (entU != null)
        {
            Console.WriteLine($"Ingrese el nuevo nombre ({entU.Nombre}) [Enter para omitir]: ");
            string n = Console.ReadLine()?.Trim();

            Console.WriteLine($"Ingrese la nueva especialidad ({entU.Especialidad}) [Enter para omitir]: ");
            string esp = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(n)) entU.Nombre = n;
            if (!string.IsNullOrWhiteSpace(esp)) entU.Especialidad = esp;

            db.SaveChanges();
            Console.WriteLine("Entrenador actualizado exitosamente.");
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
    int idE = LeerEntero("Ingrese el ID del entrenador a eliminar: ");

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
        string nombre = LeerTextoObligatorio("Ingrese el nombre del plan: ");
        double precio = LeerDouble("Ingrese el precio ($): ");
        int meses = LeerEntero("Ingrese la duración en meses: ");

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
        if (!planes.Any())
        {
            Console.WriteLine("No hay planes registrados.");
        }
        else
        {
            foreach (var p in planes)
            {
                p.Imprimir();
                Console.WriteLine("-----------------------------------");
            }
        }
    }
    Console.ReadLine();
}

void actualizarPlan()
{
    Console.Clear();
    Console.WriteLine("**** Actualizar Plan ****");

    int id = LeerEntero("Ingrese el ID del plan a modificar: ");
    using (var db = new GymDbContext())
    {
        var plan = db.Planes.Find(id);

        if (plan != null)
        {
            Console.WriteLine($"Nombre actual: {plan.Nombre}");
            Console.WriteLine("Ingrese el nuevo nombre [Enter para mantener actual]:");
            string nuevoNombre = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(nuevoNombre)) plan.Nombre = nuevoNombre;

            Console.WriteLine($"Precio actual: {plan.Precio}");
            Console.WriteLine("Ingrese el nuevo precio [Enter para mantener actual]:");
            string inputPrecio = Console.ReadLine()?.Trim();
            if (double.TryParse(inputPrecio, out double nuevoPrecio)) plan.Precio = nuevoPrecio;

            Console.WriteLine($"Duración actual: {plan.DuracionMeses} meses");
            Console.WriteLine("Ingrese la nueva duración en meses [Enter para mantener actual]:");
            string inputDuracion = Console.ReadLine()?.Trim();
            if (int.TryParse(inputDuracion, out int nuevaDuracion)) plan.DuracionMeses = nuevaDuracion;

            db.SaveChanges();
            Console.WriteLine("¡Plan actualizado correctamente!");
        }
        else
        {
            Console.WriteLine("No se encontró ningún plan con ese ID.");
        }
    }
    Console.ReadLine();
}

void eliminarPlan()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Plan**********");
    int idE = LeerEntero("Ingrese el ID del plan a eliminar: ");

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

        int idS = LeerEntero("Ingrese el ID del socio: ");
        int idE = LeerEntero("Ingrese el ID del entrenador: ");
        int idP = LeerEntero("Ingrese el ID del plan: ");

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
            db.SaveChanges();
            Console.WriteLine("¡Inscripción realizada exitosamente!");
        }
        else
        {
            Console.WriteLine("Uno o más IDs ingresados no existen en la base de datos.");
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

            if (!inscripciones.Any())
            {
                Console.WriteLine("No se encontraron inscripciones registradas.");
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

void actualizarInscripcion()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Inscripción**********");
    int idU = LeerEntero("Ingrese el ID de la inscripción a modificar: ");

    using (var db = new GymDbContext())
    {
        var insU = db.Inscripciones
                     .Include(i => i.Socio)
                     .Include(i => i.Entrenador)
                     .Include(i => i.Plan)
                     .FirstOrDefault(i => i.Id == idU);

        if (insU != null)
        {
            Console.WriteLine($"Socio actual (ID {insU.SocioId}): {insU.Socio?.Nombre}");
            Console.WriteLine("Ingrese el nuevo ID de Socio [Enter para mantener]:");
            string inputSocio = Console.ReadLine()?.Trim();
            if (int.TryParse(inputSocio, out int nuevoSocioId) && db.Socios.Any(s => s.Id == nuevoSocioId))
            {
                insU.SocioId = nuevoSocioId;
            }

            Console.WriteLine($"Entrenador actual (ID {insU.EntrenadorId}): {insU.Entrenador?.Nombre}");
            Console.WriteLine("Ingrese el nuevo ID de Entrenador [Enter para mantener]:");
            string inputEnt = Console.ReadLine()?.Trim();
            if (int.TryParse(inputEnt, out int nuevoEntId) && db.Entrenadores.Any(e => e.Id == nuevoEntId))
            {
                insU.EntrenadorId = nuevoEntId;
            }

            Console.WriteLine($"Plan actual (ID {insU.PlanId}): {insU.Plan?.Nombre}");
            Console.WriteLine("Ingrese el nuevo ID de Plan [Enter para mantener]:");
            string inputPlan = Console.ReadLine()?.Trim();
            if (int.TryParse(inputPlan, out int nuevoPlanId) && db.Planes.Any(p => p.Id == nuevoPlanId))
            {
                insU.PlanId = nuevoPlanId;
            }

            Console.WriteLine($"Estado actual: {(insU.Activa ? "Activa" : "Inactiva")}");
            Console.WriteLine("¿Desea cambiar el estado? (S/N o Enter para omitir):");
            string cambiarEstado = Console.ReadLine()?.Trim().ToUpper();
            if (cambiarEstado == "S")
            {
                insU.Activa = !insU.Activa;
            }

            db.SaveChanges();
            Console.WriteLine("¡Inscripción actualizada exitosamente!");
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
    int idDel = LeerEntero("Ingrese el ID de la inscripción a eliminar: ");

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