MiniPoyectoGYM
26-07-2026
	Se encapsuló la clase Program dentro del namespace MiniPoyectoGYM.
	Se eliminaron errores de sintaxis y llamadas a métodos static fuera de contexto.
	Se mantuvo la lógica del menú principal y métodos CRUD en memoria.

	
Actualización de la persistencia de datos:
	Se creo la clase Database y la clase ArchivoJson para implementar un sistema de almacenamiento persistente en formato JSON,
	que garantiza que los datos no se pierdan al cerrar la aplicacion.
	Ademas, se refactorizo la clase Program para actualizar las llamadas directas a las listas locales y operar a traves del gestor de persistencia Database.
	Tambien se organizo la estructura encapsulando la clase dentro del namespace MiniPoyectoGYM y se solucionaron los errores de alcance en los metodos estaticos.

27-07-2026
	Generación dinámica de IDs y mejoras en Database
	Se eliminó el uso de `contadorId` en las clases `Entrenador`, `Inscripcion`, `Plan` y `Socio`, reemplazándolo por una lógica 
	dinámica basada en las listas de la clase `Database`. 
	Se agregó el espacio de nombres `MiniPoyectoGYM.Generales` en las clases mencionadas. 
	En `Database`, se ajustó el método `CargarDatos` para mejorar la legibilidad al verificar y crear directorios si no existen. 
	Se reorganizó la asignación de propiedades en los constructores para reflejar los cambios en la lógica de IDs.
