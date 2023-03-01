using Project3.Abstract.Controller;
using Project3.Abstract.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Project3.Movements
{
    public class MoveWithNavMesh :MonoBehaviour, IMover
    {
        NavMeshAgent _navMeshAgent;
        public MoveWithNavMesh(IEntityController entityController)
        {
            _navMeshAgent = entityController.transform.GetComponent<NavMeshAgent>();
        }
        public void MoveAction(Vector3 direction, float moveSpeed)
        {
            _navMeshAgent.SetDestination(direction);
        }
    }

}
