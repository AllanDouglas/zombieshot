using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{

    /// <summary>
    /// 
    /// </summary>
    public class EnemyFactory : IFactory<EnemyPayload, IEnemy>
    {
        public IEnemy Create(EnemyPayload payload)
        {
            return new BasicEnemy(
                payload.level,
                payload.speed,
                payload.health,
                payload.range
            );
        }
    }

    public struct EnemyPayload
    {
        public readonly int level;
        public readonly int speed;
        public readonly int range;
        public readonly int health;

        public EnemyPayload(int level, int speed, int range, int health)
        {
            this.level = level;
            this.speed = speed;
            this.range = range;
            this.health = health;
        }
    }

}
