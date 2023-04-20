using Project3.Abstract.Controller;
using Project3.Abstract.States;
using UnityEngine;
namespace Project3.States.EnemyStates
{
    public class AttackState : IState
    {
        IEnemyController _enemyController;
        public AttackState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            Debug.Log($"{nameof(AttackState)}{nameof(OnEnter)}");
        }

        public void OnExit()
        {
            _enemyController.Animation.AttackAnimation(false);
        }


        public void Tick()
        {
            //TODO Look At Target
            _enemyController.transform.LookAt(_enemyController.Target);
            _enemyController.transform.eulerAngles = new Vector3(0f, _enemyController.transform.eulerAngles.y, 0f);
        }

        public void TickFixed()
        {
            _enemyController.Inventory.CurrentWeapon.Attack();
        }
        public void TickLate()
        {
            _enemyController.Animation.AttackAnimation(true);
        }
    }

}
