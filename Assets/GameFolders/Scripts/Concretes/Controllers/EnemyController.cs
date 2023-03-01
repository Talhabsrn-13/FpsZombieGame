using Project3.Abstract.Controller;
using Project3.Abstract.Movements;
using Project3.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] Transform _playerPrefab;
        IMover _mover;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
        }
        private void Update()
        {
            _mover.MoveAction(_playerPrefab.transform.position, 10f);
        }
    }
}

