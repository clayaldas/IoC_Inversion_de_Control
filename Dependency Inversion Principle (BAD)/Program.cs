namespace Dependency_Inversion_Principle__BAD_;

// Ejemplo mal aplicado - Violación del DIP

// Clase de bajo nivel
public class EmailNotifier
{
  public void Send(string message)
  {
    // Lógica para enviar correo electrónico
    Console.WriteLine($"Enviando email: {message}");
  }
}

public class SmsNotifier
{
  public void Send(string message)
  {
    // Lógica para enviar SMS
    Console.WriteLine($"Enviando SMS: {message}");
  }
}

// Clase de alto nivel
public class NotificationService
{
  private EmailNotifier emailNotifier;
  //private SmsNotifier smsNotifier; ABIERTO (PARA LA EXTENSION)/CERRADO PARA LOS CAMBIOS EN LAS EXISTENTES


  public NotificationService()
  {
    this.emailNotifier = new EmailNotifier();
  }

  public void Alert(string message)
  {
    emailNotifier.Send(message);
  }
}

class Program
{
  static void Main(string[] args)
  {
    NotificationService service = new NotificationService();
    service.Alert("!!Hola que tal!!");
  }
}