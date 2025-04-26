using Dependency_Inversion_Principle__CORRECT_.Services;

namespace Dependency_Inversion_Principle__CORRECT_
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Inyección de dependencias (DI-Dependency Inyection-TÉCNICA-PATRÓN)");
      Console.WriteLine("Inversión de dependencias (DIP-Dependency Inversion Principle-SOLID)");
      Console.WriteLine();

      INotifier notifier = new EmailNotifier(); //Clase de bajo nivel


      NotificationService notificationService = new NotificationService(notifier);//DI, DIP

      notificationService.Alert("Implementado con DIP por medio de DI");

      INotifier smsNotifier = new SmsNotifier();
      NotificationService notificationServiceSMS = new NotificationService(smsNotifier);//DIP, DI
      notificationServiceSMS.Alert("mplementado con DIP por medio de DI");

      INotifier whatsAppNotifier = new WhatsAppNotifier();
      NotificationService notificationServiceWhatsApp = new NotificationService(whatsAppNotifier);//DIP, DI
      notificationServiceWhatsApp.Alert("mplementado con DIP por medio de DI");

    }
  }
}
