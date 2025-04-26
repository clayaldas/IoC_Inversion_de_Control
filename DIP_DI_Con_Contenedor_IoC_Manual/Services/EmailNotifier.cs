namespace DIP_DI_Con_Contenedor_IoC_Manual
{
  public class EmailNotifier : INotifier
  {
    public void Send(string message)
    {
      Console.WriteLine($"Enviando email: {message}");
    }
  }
}
