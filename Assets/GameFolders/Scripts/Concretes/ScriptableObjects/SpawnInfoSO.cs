using Project3.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Spawner Info", menuName = "Combat/Spawner Info/Create New", order = 51)]
    public class SpawnInfoSO : ScriptableObject
    {
        [SerializeField] EnemyController _enemyPrefab;
        [SerializeField] float _minSpawnTime = 3;
        [SerializeField] float _maxSpawnTime = 15;

        public EnemyController EnemyPrefab => _enemyPrefab;
        public float GetRandomMaxSpawnTime => Random.Range(_minSpawnTime, _maxSpawnTime);
    }
}
