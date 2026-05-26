using System;
using RpgRoguelikeCore.Entities;
using RpgRoguelikeCore.Logging;

namespace RpgRoguelikeCore.UI
{
    public class ConsoleHUD
    {
        private ILogger _logger;

        public ConsoleHUD(ILogger logger)
        {
            _logger = logger;
        }

        public void Subscribe(Player player)
        {
            player.OnHealthChanged += UpdateHealthDisplay;
        }

        public void Unsubscribe(Player player)
        {
            player.OnHealthChanged -= UpdateHealthDisplay;
        }


        private void UpdateHealthDisplay(Player player)
        {
            int percent = (player.Health * 100) / player.MaxHealth;
            int filledBars = percent / 10;
            int emptyBars = 10 - filledBars;

            string bar = new string('█', filledBars) + new string('░', emptyBars);

            _logger.Log($"[HP: {bar}] {player.Health}/{player.MaxHealth}");
        }
    }
}