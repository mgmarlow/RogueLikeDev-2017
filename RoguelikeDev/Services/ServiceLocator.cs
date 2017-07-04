using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Services
{
    /// <summary>
    /// Used to provide global services throughout the application. This pattern exposes
    /// an interface, rather than the actual instance of the provided class. This way
    /// different implementations can easily be swapped in/out.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ServiceLocator<T>
    {
        static T _service;

        public static T GetService()
        {
            return _service;
        }

        public static void Provide(T service)
        {
            _service = service;
        }
    }
}
