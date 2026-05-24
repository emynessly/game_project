using RpgRoguelikeCore.Enemies;

namespace RpgRoguelikeCore.Factories
{
    public class SkeletonFactory : EnemyFactory
    {
        public override Enemy CreateEnemy()
        {
            return new Skeleton();
        }
    }
}