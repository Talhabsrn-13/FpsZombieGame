using Project3.Abstract.Controller;
using Project3.Abstract.States;
using UnityEngine;
namespace Project3.States.EnemyStates
{
    public class DeadState : IState
    {
        IEnemyController _enemyController;
        float _currentTime =0;
        float _maxtTime = 5f;
        public DeadState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            Debug.Log($"{nameof(DeadState)}{nameof(OnEnter)}");
            _enemyController.Dead.DeadAction();
            _enemyController.Animation.DeadAnimation();
            _enemyController.transform.GetComponent<CapsuleCollider>().enabled = false;
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(DeadState)}{nameof(OnExit)}");
        }

        public void Tick()
        {
            return;
        }

        public void TickFixed()
        {
            return;
        }

        public void TickLate()
        {
            return;   
        }
    }
}
