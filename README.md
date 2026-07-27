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