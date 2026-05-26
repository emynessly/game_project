using System;
using System.Collections.Generic;
using RpgRoguelikeCore.Commands;

namespace RpgRoguelikeCore.Input
{
    public class InputHandler
    {
        private Dictionary<ConsoleKey, ICommand> _commands = new();
        
        public void BindKey(ConsoleKey key, ICommand command)
        {
            _commands[key] = command;
        }
        
        public ICommand? GetCommand()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (_commands.ContainsKey(key.Key))
                {
                    return _commands[key.Key];
                }
            }
            return null;
        }
    }
}