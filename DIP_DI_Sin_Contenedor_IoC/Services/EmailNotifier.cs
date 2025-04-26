namespace DIP_DI_Sin_Contenedor_IoC.Services
{
  public class EmailNotifier : INotifier
  {
    public void Send(string message)
    {
      Console.WriteLine($"Enviando email: {message}");
    }
  }
}
