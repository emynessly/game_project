namespace RpgRoguelikeCore.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}