namespace DIP_DI_Con_Contenedor_IoC_Manual
{
  //  DIP: (Dependency Inversion Principle-DIP) El principio SOLID de inversión de dependencia
  //  establece que las clases deben depender de interfaces o clases abstractas en lugar de
  //  clases y métodos concretos.

  //  NOTA: Esta clase contiene la "Lógica de Negocio".
  //        Esta es la clase de alto nivel.
  public class NotificationService
  {
    //  Declaramos una "Interface" no una "clase".
    private readonly INotifier _notifier;

    // DI: (Dependency Injection, DI)-Inyección de Dependencias por constructor.
    // La inyección de dependencias es una de las técnicas utilizadas para implementar
    // el principio de inversión de dependencias (SOLID).
    public NotificationService(INotifier notifier)
    {
      _notifier = notifier;
    }

    //  El método "Alert" depende de una "interfaz" no de una "clase".
    public void Alert(string message)
    {
      _notifier.Send(message);
    }
  }
}
