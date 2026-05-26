using RpgRoguelikeCore.Entities;

namespace RpgRoguelikeCore.Commands
{
    public class MoveCommand : ICommand
    {
        private Player _player;
        private int _deltaX;
        private int _deltaY;
        private int _previousX;
        private int _previousY;

        public MoveCommand(Player player, int deltaX, int deltaY)
        {
            _player = player;
            _deltaX = deltaX;
            _deltaY = deltaY;
        }

        public void Execute()
        {
            _previousX = _player.X;
            _previousY = _player.Y;
            _player.X += _deltaX;
            _player.Y += _deltaY;
        }

        public void Undo()
        {
            _player.SetPosition(_previousX, _previousY);
        }
    }
}