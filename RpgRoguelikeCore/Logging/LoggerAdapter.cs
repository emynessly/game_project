namespace RpgRoguelikeCore.Logging
{
    public class LoggerAdapter : ILogger
    {
        private ExternalLogger _externalLogger;
        
        public LoggerAdapter(ExternalLogger externalLogger)
        {
            _externalLogger = externalLogger;
        }
        
        public void Log(string message)
        {
            _externalLogger.WriteMessage(message, 0);
        }

        public void LogWarning(string message)
        {
            _externalLogger.WriteMessage(message, 1);
        }
        
        public void LogError(string message)
        {
            _externalLogger.WriteMessage(message, 2);
        }
    }
}