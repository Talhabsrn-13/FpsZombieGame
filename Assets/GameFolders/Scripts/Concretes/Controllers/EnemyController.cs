using Project3.Abstract.Combats;
using Project3.Abstract.Controller;
using Project3.Abstract.Movements;
using Project3.Animations;
using Project3.Combats;
using Project3.Managers;
using Project3.Movements;
using Project3.States;
using Project3.States.EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Project3.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {

        IHealth _health;

        NavMeshAgent _navMeshAgent;
        StateMachine _stateMachine;
        Transform _playerTransform;

        bool _canAttack;
        public IMover Mover { get; private set; }

        public bool CanAttack => Vector3.Distance(Target.position, this.transform.position)
            <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;

        public InventoryController Inventory { get; private set; }

        public CharacterAnimation Animation { get; private set; }
        public Transform Target { get; set; }
        public float Magnitude => _navMeshAgent.velocity.magnitude;

        public Dead Dead { get; private set; }

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
            _stateMachine = new StateMachine();

            Mover = new MoveWithNavMesh(this);
            Animation = new CharacterAnimation(this);
            Inventory = GetComponent<InventoryController>();
            Dead = GetComponent<Dead>();
        }
        private void Start()
        {
            Target = FindObjectOfType<PlayerController>().transform;
            AttackState attackState = new AttackState(this);
            ChaseState chaseState = new ChaseState(this);
            DeadState deadState = new DeadState(this);

            _stateMachine.AddState(chaseState, attackState, () => CanAttack);
            _stateMachine.AddState(attackState, chaseState, () => !CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.IsDead);

            _stateMachine.SetState(chaseState);
        }
        private void Update()
        {
            _stateMachine.Tick();
        }
        private void FixedUpdate()
        {
            _stateMachine.TickFixed();
        }
        void LateUpdate()
        {
            _stateMachine.TickLate();
        }

        private void OnDestroy()
        {
            EnemyManager.Instance.RemoveEnemyController(this);
        }
    }
}

