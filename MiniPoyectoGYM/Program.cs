using MiniPoyectoGYM;
using MiniPoyectoGYM.Generales;

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
        case 1:
            crearSocio();
            break;
        case 2:
            listarSocios();
            break;
        case 3:
            actualizarSocio();
            break;
        case 4:
            eliminarSocio();
            break;
        case 5:
            crearEntrenador();
            break;
        case 6:
            listarEntrenadores();
            break;
        case 7:
            actualizarEntrenador();
            break;
        case 8:
            eliminarEntrenador();
            break;
        case 9:
            crearPlan();
            break;
        case 10:
            listarPlanes();
            break;
        case 11:
            actualizarPlan();
            break;
        case 12:
            eliminarPlan();
            break;
        case 13:
            crearInscripcion();
            break;
        case 14:
            listarInscripciones();
            break;
        case 15:
            cambiarEstadoInscripcion();
            break;
        case 16:
            eliminarInscripcion();
            break;
        case 17:
            Console.WriteLine("Saliendo del sistema de gimnasio...");
            break;
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

        Database.Socios.Add(new Socio(nombre, cedula, edad));
        Database.GuardarSocios();
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
    foreach (var s in Database.Socios)
    {
        s.Imprimir();
        Console.WriteLine("-----------------------------------");
    }
    Console.ReadLine();
}

void actualizarSocio()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Socio**********");
    Console.WriteLine("Ingrese el ID del socio a actualizar: ");
    int idU = Convert.ToInt32(Console.ReadLine());
    var socioU = Database.Socios.Find(x => x.Id == idU);

    if (socioU != null)
    {
        try
        {
            Console.WriteLine($"Ingrese el nuevo nombre ({socioU.Nombre}): ");
            string n = Console.ReadLine();
            Console.WriteLine($"Ingrese la nueva edad ({socioU.Edad}): ");
            string eStr = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(n)) socioU.Nombre = n;
            if (!string.IsNullOrWhiteSpace(eStr)) socioU.Edad = Convert.ToInt32(eStr);

            Database.GuardarSocios();
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

void eliminarSocio()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Socio**********");
    Console.WriteLine("Ingrese el ID del socio a eliminar: ");
    int idE = Convert.ToInt32(Console.ReadLine());
    var socioE = Database.Socios.Find(x => x.Id == idE);

    if (socioE != null)
    {
        Database.Socios.Remove(socioE);
        Database.GuardarSocios();
        Console.WriteLine("Socio eliminado exitosamente.");
    }
    else
    {
        Console.WriteLine("Socio no encontrado.");
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

        Database.Entrenadores.Add(new Entrenador(nombre, especialidad));
        Database.GuardarEntrenadores();
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
    foreach (var e in Database.Entrenadores)
    {
        e.Imprimir();
        Console.WriteLine("-----------------------------------");
    }
    Console.ReadLine();
}

void actualizarEntrenador()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Entrenador**********");
    Console.WriteLine("Ingrese el ID del entrenador a actualizar: ");
    int idU = Convert.ToInt32(Console.ReadLine());
    var entU = Database.Entrenadores.Find(x => x.Id == idU);

    if (entU != null)
    {
        Console.WriteLine($"Ingrese el nuevo nombre ({entU.Nombre}): ");
        string n = Console.ReadLine();
        Console.WriteLine($"Ingrese la nueva especialidad ({entU.Especialidad}): ");
        string esp = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(n)) entU.Nombre = n;
        if (!string.IsNullOrWhiteSpace(esp)) entU.Especialidad = esp;

        Database.GuardarEntrenadores();
        Console.WriteLine("Entrenador actualizado exitosamente.");
    }
    else
    {
        Console.WriteLine("Entrenador no encontrado.");
    }
    Console.ReadLine();
}

void eliminarEntrenador()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Entrenador**********");
    Console.WriteLine("Ingrese el ID del entrenador a eliminar: ");
    int idE = Convert.ToInt32(Console.ReadLine());
    var entE = Database.Entrenadores.Find(x => x.Id == idE);

    if (entE != null)
    {
        Database.Entrenadores.Remove(entE);
        Database.GuardarEntrenadores();
        Console.WriteLine("Entrenador eliminado exitosamente.");
    }
    else
    {
        Console.WriteLine("Entrenador no encontrado.");
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

        Database.Planes.Add(new Plan(nombre, precio, meses));
        Database.GuardarPlanes();
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
    foreach (var p in Database.Planes)
    {
        p.Imprimir();
        Console.WriteLine("-----------------------------------");
    }
    Console.ReadLine();
}

void actualizarPlan()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Plan**********");
    Console.WriteLine("Ingrese el ID del plan a actualizar: ");
    int idU = Convert.ToInt32(Console.ReadLine());
    var planU = Database.Planes.Find(x => x.Id == idU);

    if (planU != null)
    {
        try
        {
            Console.WriteLine($"Ingrese el nuevo nombre ({planU.Nombre}): ");
            string n = Console.ReadLine();
            Console.WriteLine($"Ingrese el nuevo precio ({planU.Precio}): ");
            string pStr = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(n)) planU.Nombre = n;
            if (!string.IsNullOrWhiteSpace(pStr)) planU.Precio = Convert.ToDouble(pStr);

            Database.GuardarPlanes();
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

void eliminarPlan()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Plan**********");
    Console.WriteLine("Ingrese el ID del plan a eliminar: ");
    int idE = Convert.ToInt32(Console.ReadLine());
    var planE = Database.Planes.Find(x => x.Id == idE);

    if (planE != null)
    {
        Database.Planes.Remove(planE);
        Database.GuardarPlanes();
        Console.WriteLine("Plan eliminado exitosamente.");
    }
    else
    {
        Console.WriteLine("Plan no encontrado.");
    }
    Console.ReadLine();
}

void crearInscripcion()
{
    Console.Clear();
    Console.WriteLine("**********Crear Inscripción**********");
    if (Database.Socios.Count == 0 || Database.Entrenadores.Count == 0 || Database.Planes.Count == 0)
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

    var s = Database.Socios.Find(x => x.Id == idS);
    var e = Database.Entrenadores.Find(x => x.Id == idE);
    var p = Database.Planes.Find(x => x.Id == idP);

    if (s != null && e != null && p != null)
    {
        Database.Inscripciones.Add(new Inscripcion(s, e, p));
        Database.GuardarInscripciones();
        Console.WriteLine("¡Inscripción realizada exitosamente!");
    }
    else
    {
        Console.WriteLine("Uno de los IDs no existe.");
    }
    Console.ReadLine();
}

void listarInscripciones()
{
    Console.Clear();
    Console.WriteLine("**********Lista de Inscripciones**********");
    foreach (var i in Database.Inscripciones)
    {
        i.Imprimir();
        Console.WriteLine("-----------------------------------");
    }
    Console.ReadLine();
}

void cambiarEstadoInscripcion()
{
    Console.Clear();
    Console.WriteLine("**********Cambiar Estado de Inscripción**********");
    Console.WriteLine("Ingrese el ID de la inscripción: ");
    int idU = Convert.ToInt32(Console.ReadLine());
    var insU = Database.Inscripciones.Find(x => x.Id == idU);

    if (insU != null)
    {
        insU.Activa = !insU.Activa;
        Database.GuardarInscripciones();
        Console.WriteLine($"Estado actualizado a: {(insU.Activa ? "Activa" : "Inactiva")}");
    }
    else
    {
        Console.WriteLine("Inscripción no encontrada.");
    }
    Console.ReadLine();
}

void eliminarInscripcion()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Inscripción**********");
    Console.WriteLine("Ingrese el ID de la inscripción a eliminar: ");
    int idDel = Convert.ToInt32(Console.ReadLine());
    var insDel = Database.Inscripciones.Find(x => x.Id == idDel);

    if (insDel != null)
    {
        Database.Inscripciones.Remove(insDel);
        Database.GuardarInscripciones();
        Console.WriteLine("Inscripción eliminada exitosamente.");
    }
    else
    {
        Console.WriteLine("Inscripción no encontrada.");
    }
    Console.ReadLine();
}
