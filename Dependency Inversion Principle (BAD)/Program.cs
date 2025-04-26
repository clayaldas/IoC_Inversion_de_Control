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

// Clase de alto nivel
public class NotificationService
{
  private EmailNotifier emailNotifier;

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