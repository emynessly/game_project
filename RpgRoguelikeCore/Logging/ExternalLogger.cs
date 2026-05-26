using System;

namespace RpgRoguelikeCore.Logging
{
    public class ExternalLogger
    {
        public void WriteMessage(string text, int level)
        {
            string prefix = level switch
            {
                0 => "[INFO]",
                1 => "[WARN]",
                2 => "[ERROR]",
                _ => "[LOG]"
            };
            Console.WriteLine($"{prefix} {text}");
        }
    }
}