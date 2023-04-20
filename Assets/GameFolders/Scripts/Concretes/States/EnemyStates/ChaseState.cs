using Project3.Abstract.Controller;
using Project3.Abstract.States;
using UnityEngine;
namespace Project3.States.EnemyStates
{
    public class ChaseState : IState
    {
        float _speed = 10f;
        IEntityController _entityController;
        Transform _target;
        public ChaseState(IEntityController entitityController, Transform target)
        {
            _entityController = entitityController;
            _target = target;
        }
        public void OnEnter()
        {
            Debug.Log($"{nameof(ChaseState)}{nameof(OnEnter)}");
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(ChaseState)}{nameof(OnExit)}");
        }

        public void Tick()
        {
            _entityController.Mover.MoveAction(_target.position, _speed);
        }
    }

}
