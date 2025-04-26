namespace DIP_DI_Con_Contenedor_IoC_Manual
{
  //  Este contenedor permite registrar tipos de servicios y sus implementaciones, y luego
  //  resolverlos dinámicamente cuando sean necesarios, inyectando sus dependencias
  //  automáticamente.
  internal class MiniContainer
  {
    //  Atributos del contenedor:
    //  _registrations: Es un diccionario que mapea un tipo de servicio (Type) a
    //  su implementación concreta (Type).    
    //    a) El primer parámetro (Type) recibe el tipo de servicio (por ejemplo, INotifier).
    //    b) E segundo parámetro (Type) recibe la implementación de ese servicio
    //       (por ejemplo, EmailNotifier).
    //  Este diccionario guarda la relación entre la interfaz (o clase base) y la
    //  implementación concreta de un servicio que vamos a resolver.
    private readonly Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

    //  Método Register<TService, TImplementation>():
    //  Este método permite registrar una relación entre un servicio y su implementación
    //  concreta.
    //  TService: Es el tipo de interfaz o clase base que se quiere inyectar
    //  (por ejemplo, INotifier).
    //  TImplementation: Es el tipo de clase concreta que implementa ese servicio
    //  (por ejemplo, EmailNotifier).
    //
    //  Este método agrega al diccionario _registrations la relación entre el tipo del servicio
    //  (TService) y el tipo de su implementación (TImplementation).
    public void Register<TService, TImplementation>()
    {
      _registrations[typeof(TService)] = typeof(TImplementation);
    }

    //  Este método ("sobrecargado") es una versión más simple del anterior, y está diseñado
    //  para registrar un servicio sin una implementación explícita.
    //  a) Registra un tipo que no tiene dependencias o que simplemente se va a usar tal
    //     cual está.
    //  b) Este método utiliza el tipo de "TService" tanto para el servicio como para la
    //     implementación (por ejemplo, si "TService" es una clase concreta sin depender de
    //     ninguna interfaz, este tipo se usará como la implementación).
    public void Register<TService>()
    {
      _registrations[typeof(TService)] = typeof(TService);
    }

    //  Este método es el corazón del contenedor. Se encarga de resolver una instancia
    //  de servicio cuando se le solicita, basándose en el tipo de servicio.
    public object Resolve(Type serviceType)
    {
      //  1) Verificar si el servicio está registrado: Si el tipo no está en el
      //  diccionario "_registrations", lanza una excepción.
      if (!_registrations.ContainsKey(serviceType))
        throw new Exception($"Tipo no registrado: {serviceType.Name}");

      //  2) Obtener la implementación del servicio del array "_registrations":
      //     Recupera el tipo de implementación correspondiente (implementationType).
      Type implementationType = _registrations[serviceType];

      //  3) Obtener el constructor: Usa GetConstructors().First() para obtener
      //     el primer constructor disponible de la clase que implementa el servicio.
      var constructor = implementationType.GetConstructors().First();

      //  4) Resolver las dependencias del constructor:
      //     a) Obtiene los parámetros del constructor (GetParameters()).
      //     b) Llama recursivamente a Resolve() para cada parámetro, es decir, resuelve las
      //     dependencias de los parámetros del constructor.
      var parameters = constructor.GetParameters()
          .Select(p => Resolve(p.ParameterType)).ToArray();

      // 5) Crear la instancia: Una vez que se tienen todas las dependencias resueltas, se crea
      //    una nueva instancia de la clase con Activator.CreateInstance() pasando los
      //    parámetros al constructor.
      return Activator.CreateInstance(implementationType, parameters);
    }

    //  Este es un método (Sobrecarga) de conveniencia que utiliza la versión
    //  Resolve(Type serviceType) pero para un tipo genérico (T).
    //  Permite que el usuario resuelva un servicio de forma sencilla sin tener que pasar
    //  el tipo Type manualmente
    public T Resolve<T>() => (T)Resolve(typeof(T));
  }
}
