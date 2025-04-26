using DIP_DI_Sin_Contenedor_IoC.Services;

namespace DIP_DI_Sin_Contenedor_IoC
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("DIP y DI sin contenedor IoC");
      Console.WriteLine();

      //  1. Crear manualmente la implementación concreta.
      //  DIP: depende de una interfaz, no de una clase concreta directa.
      INotifier notifier = new EmailNotifier();

      //  2. Inyectar manualmente la dependencia en el servicio (clase).
      //  DI manual.
      NotificationService notificationService = new NotificationService(notifier);

      // 3. Usar el servicio (clase).
      notificationService.Alert("Implementación de DIP y DI");

      //  ------------------------------------------
      //  ¿Qué se cumple en el proyecto?
      //  ------------------------------------------
      //  DIP (Dependency Inversion Principle):
      //      Se implementa. La clase NotificationService depende de interfaz la "INotifier", no
      //      de la clase "EmailNotifier".      
      //  DI  (Dependency Injection):
      //      Se implementa de "forma manual". Se instancia "EmailNotifier" y se "Inyecta" es
      //      decir se pasa como parámetro en el constructor.
      //  IoC (Inversión de Control):
      //      Es parcial. No se utiliza un contenedor, se cede el control de creación y el flujo
      //      se debe realizar de forma manual en el "Main" o en otra clase.

      //  ------------------------------------------
      //  Conclusión
      //  ------------------------------------------
      //  Incluso sin usar un contenedor (IoC), se puede aplicar los principios SOLID y
      //  de diseño de software correctamente.
      //  Lo importante es no acoplar las clases directamente a sus dependencias, y permitir
      //  que otro(usted mismo, un contenedor o un framework) se las proporcione.
    }
  }
}
