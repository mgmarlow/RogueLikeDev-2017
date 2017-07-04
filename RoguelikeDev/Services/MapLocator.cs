using RogueSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Services
{
    public static class MapLocator
    {
        private static IMap _map;

        public static IMap GetMap()
        {
            return _map;
        }

        public static void Provide(IMap map)
        {
            _map = map;
        }
    }
}
