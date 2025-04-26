//namespace Dependency_Inversion_Principle__CORRECT_.Services;
namespace DIP_DI_Con_Contenedor_IoC_Microsoft;
public class SmsNotifier : INotifier
{
  public void Send(string message)
  {
    // Lógica para enviar SMS
    Console.WriteLine($"Enviando SMS: {message}");
  }
}
