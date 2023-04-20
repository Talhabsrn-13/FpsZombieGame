using Project3.Abstract.States;
using UnityEngine;
namespace Project3.States.EnemyStates
{
    public class DeadState : IState
    {
        public void OnEnter()
        {
            Debug.Log($"{nameof(DeadState)}{nameof(OnEnter)}");
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(DeadState)}{nameof(OnExit)}");
        }

        public void Tick()
        {
            Debug.Log("DeadState");
        }

        public void TickFixed()
        {
            throw new System.NotImplementedException();
        }

        public void TickLate()
        {
            throw new System.NotImplementedException();
        }
    }
}
