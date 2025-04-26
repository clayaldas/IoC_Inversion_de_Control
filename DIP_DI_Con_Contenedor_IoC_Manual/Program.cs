namespace DIP_DI_Con_Contenedor_IoC_Manual
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("DIP y DI con contenedor IoC manual");
      Console.WriteLine();

      //  Crear el contenedor.
      MiniContainer container = new MiniContainer();

      //  Registramos interfaces con sus implementaciones.
      container.Register<INotifier, EmailNotifier>();
      //  Registrar el servicio de alto nivel.
      container.Register<NotificationService>();

      //  Resolución automática de dependencias.      
      NotificationService service = container.Resolve<NotificationService>();
      service.Alert("¡Implementación de DIP y DI, utilizando un mini contenedor IoC manual!");

      //  ------------------------------------------
      //  ¿Qué se cumple en el proyecto?
      //  ------------------------------------------
      //  DIP (Dependency Inversion Principle):
      //      Se implementa. La clase NotificationService depende de interfaz la "INotifier", no
      //      de la clase "EmailNotifier".      
      //  DI  (Dependency Injection):
      //      Se implementa. El contenedor (MiniContainer) inyecta INotifier al constructor.
      //  IoC (Inversión de Control):
      //      Se implementa. El contenedor (MiniContainer) gestiona la creación de dependencias.
    }
  }
}
