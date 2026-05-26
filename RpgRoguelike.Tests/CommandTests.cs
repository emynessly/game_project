using RpgRoguelikeCore.Entities;
using RpgRoguelikeCore.Logging;
using RpgRoguelikeCore.Commands;
using Xunit;

namespace RpgRoguelike.Tests
{
    public class CommandTests
    {
        private class TestLogger : ILogger
        {
            public void Log(string message) { }
        }
        
        // Тесты для MoveCommand
        [Fact]
        public void MoveCommand_Execute_ShouldChangePosition()
        {
            var logger = new TestLogger();
            var player = new Player(logger);
            player.X = 0;
            player.Y = 0;
            var moveCommand = new MoveCommand(player, 1, 0);
            
            moveCommand.Execute();
            
            Assert.Equal(1, player.X);
            Assert.Equal(0, player.Y);
        }
        
        [Fact]
        public void MoveCommand_Undo_ShouldRestorePreviousPosition()
        {
            var logger = new TestLogger();
            var player = new Player(logger);
            player.X = 0;
            player.Y = 0;
            var moveCommand = new MoveCommand(player, 1, 0);
            
            moveCommand.Execute();
            moveCommand.Undo();
            
            Assert.Equal(0, player.X);
            Assert.Equal(0, player.Y);
        }
        
        [Fact]
        public void MultipleMoves_Undo_ShouldRestoreInReverseOrder()
        {
            var logger = new TestLogger();
            var player = new Player(logger);
            player.X = 0;
            player.Y = 0;
            var moveRight = new MoveCommand(player, 1, 0);
            var moveDown = new MoveCommand(player, 0, 1);
            
            moveRight.Execute();
            moveDown.Execute();
            moveDown.Undo();
            moveRight.Undo();
            
            Assert.Equal(0, player.X);
            Assert.Equal(0, player.Y);
        }
        
        [Fact]
        public void MoveCommand_Execute_ShouldChangeYPosition()
        {
            var logger = new TestLogger();
            var player = new Player(logger);
            player.X = 5;
            player.Y = 5;
            var moveCommand = new MoveCommand(player, 0, -2);
            
            moveCommand.Execute();
            
            Assert.Equal(5, player.X);
            Assert.Equal(3, player.Y);
        }
        
        [Fact]
        public void MoveCommand_Undo_AfterMultipleMoves_ShouldRestoreCorrectly()
        {
            var logger = new TestLogger();
            var player = new Player(logger);
            player.X = 0;
            player.Y = 0;
            var move1 = new MoveCommand(player, 2, 0);
            var move2 = new MoveCommand(player, 0, 3);
            
            move1.Execute();
            move2.Execute();
            move2.Undo();
            
            Assert.Equal(2, player.X);
            Assert.Equal(0, player.Y);
        }
    }
}