namespace Dependency_Inversion_Principle__CORRECT_.Services;

public class EmailNotifier : INotifier
{
  public void Send(string message)
  {
    // Lógica para enviar correo electrónico
    Console.WriteLine($"Enviando email: {message}");
  }
}
