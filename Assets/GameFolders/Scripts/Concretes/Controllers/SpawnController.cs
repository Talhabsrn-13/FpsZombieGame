using Project3.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Controllers
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] SpawnInfoSO _spawnInfo;

        float _currentSpawntime = 0f;
        float _maxSpawnTime;

        private void Start()
        {
            _maxSpawnTime = _spawnInfo.GetRandomMaxSpawnTime;
        }

        private void Update()
        {
            _currentSpawntime += Time.deltaTime;

            if (_currentSpawntime > _maxSpawnTime)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            EnemyController newEnemy = Instantiate(_spawnInfo.EnemyPrefab, transform.position, Quaternion.identity);
            _currentSpawntime = 0f;
            _maxSpawnTime = _spawnInfo.GetRandomMaxSpawnTime;
        }
    }
}
