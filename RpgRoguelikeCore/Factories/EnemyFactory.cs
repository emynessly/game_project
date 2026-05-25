using RpgRoguelikeCore.Enemies;

namespace RpgRoguelikeCore.Factories
{
    public abstract class EnemyFactory
    {
        public abstract Enemy CreateEnemy();
    }
}