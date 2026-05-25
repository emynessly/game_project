using System;
using RpgRoguelikeCore.Factories;
using RpgRoguelikeCore.Weapons;
using RpgRoguelikeCore.Enemies;
using RpgRoguelikeCore.Logging;

namespace RpgRoguelikeCore
{
    public class DemoRunner
    {
        private ILogger _logger;
        private GameSettings _settings;
        
        public DemoRunner(ILogger logger, GameSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }
        
        public void RunAllDemos()
        {
            _logger.Log($"Game Started with difficulty: {_settings.CurrentDifficulty}");
            
            DemoFactory();
            DemoPrototype();
            DemoDecorator();
        }
        
        private void DemoFactory()
        {
            EnemyFactory factory = new GoblinFactory();
            Enemy enemy = factory.CreateEnemy();

            _logger.Log("\n - Враг создан через фабрику - ");
            enemy.Attack();
        }
        
        private void DemoPrototype()
        {
            _logger.Log("\n - Работа Prototype - ");
    
            Enemy original = new Goblin();
            Enemy clone = original.Clone();

            _logger.Log($"Оригинал: здоровье {original.Health}, оружие {original.Weapon.Name}");

            clone.Health = 500;
            clone.Weapon.Name = "Топорик";

            _logger.Log($"Клон после изменений: здоровье {clone.Health}, оружие {clone.Weapon.Name}");
            _logger.Log($"Оригинал: здоровье {original.Health}, оружие {original.Weapon.Name}");
            _logger.Log($"Сравнение оригинала и клона. Они разные: {!ReferenceEquals(original, clone)}");
        }
        
        private void DemoDecorator()
        {
            _logger.Log("\n - Работа Decorator (цепочка декораторов) - ");
            
            IWeapon dagger = new Dagger();
            _logger.Log($"База: {dagger.GetName()} -> {dagger.GetDamage()} урона");
            
            dagger = new PoisonDecorator(dagger, 5);
            _logger.Log($"+Яд: {dagger.GetName()} -> {dagger.GetDamage()} урона");
            
            dagger = new FireDecorator(dagger, 4);
            _logger.Log($"+Огонь: {dagger.GetName()} -> {dagger.GetDamage()} урона");

            dagger = new RustDecorator(dagger, 3);
            _logger.Log($"+Ржавчина: {dagger.GetName()} -> {dagger.GetDamage()} урона");
            
            _logger.Log($"\nИтоговый урон: {dagger.GetDamage()}");
        }
    }
}