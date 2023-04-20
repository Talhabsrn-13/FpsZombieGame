
namespace Project3.Abstract.States
{
    public interface IState
    {
        void Tick();
        void OnExit();
        void OnEnter();
        void TickFixed();
        void TickLate();
    }
}
