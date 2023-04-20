using Project3.Abstract.States;
using UnityEngine;
namespace Project3.States.EnemyStates
{
    public class AttackState : IState
    {
        public void OnEnter()
        {
            Debug.Log($"{nameof(AttackState)}{nameof(OnEnter)}");
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(AttackState)}{nameof(OnExit)}");
        }


        public void Tick()
        {
            Debug.Log(nameof(ChaseState));
        }
    }

}
