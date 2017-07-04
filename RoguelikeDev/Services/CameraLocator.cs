using RoguelikeDev.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Services
{
    public static class CameraLocator
    {
        static ICamera _camera;

        public static ICamera GetCamera()
        {
            return _camera;
        }

        public static void Provide(ICamera camera)
        {
            _camera = camera;
        }
    }
}
