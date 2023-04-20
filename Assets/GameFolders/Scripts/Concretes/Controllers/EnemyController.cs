using Project3.Abstract.Combats;
using Project3.Abstract.Controller;
using Project3.Abstract.Movements;
using Project3.Animations;
using Project3.Movements;
using Project3.States;
using Project3.States.EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Project3.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] Transform _playerPrefab;
       
        IMover _mover;
        IHealth _health;
      
        CharacterAnimation _animation;
        NavMeshAgent _navMeshAgent;
        InventoryController _inventroyController;
        StateMachine _stateMachine;
        Transform _playerTransform;
     
        bool _canAttack;

        public bool CanAttack => Vector3.Distance(_playerTransform.position, this.transform.position)
            <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;
        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
            _inventroyController = GetComponent<InventoryController>();
            _stateMachine = new StateMachine();
        }
        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerController>().transform;
            AttackState attackState = new AttackState();
            ChaseState chaseState = new ChaseState();
            DeadState deadState = new DeadState();

            _stateMachine.AddState(chaseState,attackState, () => CanAttack);
            _stateMachine.AddState(attackState, chaseState, () => !CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.IsDead);

            _stateMachine.SetState(chaseState);
        }
        private void Update()
        {
            if (_health.IsDead) return;
        
            _mover.MoveAction(_playerTransform.position, 10f);

            _stateMachine.Tick();
        }
        private void FixedUpdate()
        {
            if (_canAttack)
            {
                _inventroyController.CurrentWeapon.Attack();
            }
        }
        void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
            _animation.AttackAnimation(_canAttack);
            
        }
    }
}

