using RpgRoguelikeCore.Enemies;

namespace RpgRoguelikeCore.Factories
{
    public class GoblinFactory : EnemyFactory
    {
        public override Enemy CreateEnemy()
        {
            return new Goblin();
        }
    }
}