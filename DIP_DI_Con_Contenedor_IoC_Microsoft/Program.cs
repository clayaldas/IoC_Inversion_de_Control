
using Microsoft.Extensions.DependencyInjection;

namespace DIP_DI_Con_Contenedor_IoC_Microsoft
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("DIP y DI con contenedor IoC automático de Microsoft");
      Console.WriteLine();

      // IoC Container configurado con DI que viene en NET Core.
      var containerIoC = new ServiceCollection()
          .AddScoped<INotifier, EmailNotifier>() // DIP: INotifier → EmailNotifier.
          .AddScoped<NotificationService>() //  Registrar el servicio de alto nivel.
          .BuildServiceProvider();

      //  El contenedor IoC resuelve el servicio inyectado y crea la instancia automáticamente.
      var service = containerIoC.GetService<NotificationService>();
      service.Alert("¡Implementación de DIP y DI, utilizando un contenedor IoC automático!");

      // Utiizar la clase: EmailNotifier
      containerIoC = new ServiceCollection()
        .AddScoped<INotifier, SmsNotifier>()
        .AddScoped<NotificationService>()
        .BuildServiceProvider();

      service = containerIoC.GetService<NotificationService>();
      service.Alert("¡Implementación de DIP y DI, utilizando un contenedor IoC automático!");


      // Utiizar la clase: WhatsAppNotifier
      containerIoC = new ServiceCollection()
        .AddScoped<INotifier, WhatsAppNotifier>()
        .AddScoped<NotificationService>()
        .BuildServiceProvider();

      service = containerIoC.GetService<NotificationService>();
      service.Alert("¡Implementación de DIP y DI, utilizando un contenedor IoC automático!");


      //  ------------------------------------------
      //  ¿Qué se cumple en el proyecto?
      //  ------------------------------------------
      //  DIP (Dependency Inversion Principle):
      //      Se implementa. La clase NotificationService depende de interfaz la "INotifier", no
      //      de la clase "EmailNotifier".      
      //  DI  (Dependency Injection):
      //      Se implementa. El contenedor (container) inyecta INotifier al constructor.
      //  IoC (Inversión de Control):
      //      Se implementa. El contenedor (ServiceCollection) controla el ciclo de vida y
      //      creación de dependencias.
    }
  }
}
