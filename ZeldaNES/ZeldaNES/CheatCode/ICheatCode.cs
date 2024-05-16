namespace ZeldaNES.CheatCode
{
    public interface ICheatcode
    {
        void Add(string str);
        int CheatDetected();
        void resetCheat();
    }
}