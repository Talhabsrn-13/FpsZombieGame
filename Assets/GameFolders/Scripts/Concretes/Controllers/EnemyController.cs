using Project3.Abstract.Controller;
using Project3.Abstract.Movements;
using Project3.Animations;
using Project3.Movements;
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
        CharacterAnimation _animation;
        NavMeshAgent _navMeshAgent;
        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            _mover.MoveAction(_playerPrefab.transform.position, 10f);
        }
        void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
            
        }
    }
}

