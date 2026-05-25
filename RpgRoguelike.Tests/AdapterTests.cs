using RpgRoguelikeCore.Logging;
using Xunit;

namespace RpgRoguelike.Tests
{
    public class AdapterTests
    {
        [Fact]
        public void LoggerAdapter_ShouldCallExternalLogger_WithoutExceptions()
        {
            var externalLogger = new ExternalLogger();
            var adapter = new LoggerAdapter(externalLogger);

            var exception = Record.Exception(() => adapter.Log("Test message"));
            Assert.Null(exception);
        }
        
        [Fact]
        public void LoggerAdapter_LogWarning_ShouldWork()
        {
            var externalLogger = new ExternalLogger();
            var adapter = new LoggerAdapter(externalLogger);

            var exception = Record.Exception(() => adapter.LogWarning("Warning message"));
            Assert.Null(exception);
        }
        
        [Fact]
        public void LoggerAdapter_LogError_ShouldWork()
        {
            var externalLogger = new ExternalLogger();
            var adapter = new LoggerAdapter(externalLogger);

            var exception = Record.Exception(() => adapter.LogError("Error message"));
            Assert.Null(exception);
        }
    }
}