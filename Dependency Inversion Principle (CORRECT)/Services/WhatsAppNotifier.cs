namespace Dependency_Inversion_Principle__CORRECT_.Services;

public class WhatsAppNotifier : INotifier
{
  public void Send(string message)
  {
    // Lógica para enviar WhatsApp
    Console.WriteLine($"Enviando WhatsApp: {message}");
  }
}
