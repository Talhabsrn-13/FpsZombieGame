using Project3.Abstract.States;
using UnityEngine;
namespace Project3.States.EnemyStates
{
    public class ChaseState : IState
    {
        public void OnEnter()
        {
            Debug.Log($"{nameof (ChaseState)}{nameof (OnEnter)}");
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(ChaseState)}{nameof(OnExit)}");
        }

        public void Tick()
        {
            Debug.Log(nameof(ChaseState));
        }
    }

}
