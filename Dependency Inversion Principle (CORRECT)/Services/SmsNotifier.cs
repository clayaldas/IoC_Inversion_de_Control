namespace Dependency_Inversion_Principle__CORRECT_.Services;

public class SmsNotifier : INotifier
{
  public void Send(string message)
  {
    // Lógica para enviar SMS
    Console.WriteLine($"Enviando SMS: {message}");
  }
}
