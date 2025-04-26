using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Inversion_Principle__CORRECT_.Services;

public class NotificationService
{
  private readonly INotifier _notifier;//inversion de dependencias.

  // Tecnica: Inyección de dependencias
  public NotificationService(INotifier notifier)
  {
    _notifier = notifier;
  }

  public void Alert(string message)
  {
    _notifier.Send(message);
  }
}
