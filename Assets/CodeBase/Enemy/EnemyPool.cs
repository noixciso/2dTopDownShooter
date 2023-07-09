using System.Collections.Generic;
using CodeBase.Infrastructure.Factory;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyPool
    {
        private List<GameObject> _pool = new List<GameObject>();
        private IGameFactory _gameFactory;
        private EnemySpawner _enemySpawner;
    
        public EnemyPool(IGameFactory gameFactory, EnemySpawner enemySpawner, int initialPoolSize)
        {
            _gameFactory = gameFactory;
            _enemySpawner = enemySpawner;
        
            for (int i = 0; i < initialPoolSize; i++)
            {
                CreateNewEnemy(_gameFactory, _enemySpawner.EnemyTypes[Random.Range(0, _enemySpawner.EnemyTypes.Count)]);
            }
        }
    
        public GameObject GetOrCreate(EnemyTypeId enemyType)
        {
            GameObject enemy = _pool.Find(o => !o.activeSelf);
        
            if (enemy == null)
            {
                enemy = CreateNewEnemy(_gameFactory, enemyType);
            }
        
            enemy.SetActive(true);
            return enemy;
        }

        private GameObject CreateNewEnemy(IGameFactory gameFactory, EnemyTypeId enemyTypeId)
        {
            GameObject newEnemy = gameFactory.CreateEnemy(enemyTypeId);
            newEnemy.transform.SetParent(_enemySpawner.transform);
            newEnemy.SetActive(false);
            _pool.Add(newEnemy);
            return newEnemy;
        }
    }
}