using System.Collections.Generic;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public List<Transform> SpawnPoints;
        public float spawnInterval = 1f;

        private GameFactory _gameFactory;
        private EnemyPool _enemyPool;
    
        private float timer = 0f;
    
        private void Start()
        {
            _gameFactory = new GameFactory(new AssetProvider(), new StaticDataService());
            _enemyPool = new EnemyPool(_gameFactory,10);
        }
    
        private void Update()
        {
            timer += Time.deltaTime;
        
            if (timer >= spawnInterval)
            {
                SpawnEnemy();
                timer = 0f;
            }
        }
    
        private void SpawnEnemy()
        {
            GameObject enemy = _enemyPool.GetOrAdd();
            enemy.transform.position = SpawnPoints[Random.Range(0, SpawnPoints.Count)].position;
        }
        
    }
}