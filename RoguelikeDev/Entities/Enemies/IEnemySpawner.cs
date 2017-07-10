using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeDev.Entities.Enemies
{
    public interface IEnemySpawner
    {
        List<Vector2> GetActiveEnemyLocations();
    }
}
