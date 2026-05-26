using RpgRoguelikeCore.Enemies;

namespace RpgRoguelikeCore.Strategies
{
    public interface IAttackStrategy
    {
        void Execute(Enemy enemy);
    }
}