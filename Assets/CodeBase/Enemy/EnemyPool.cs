using System.Collections.Generic;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyPool
    {
        private List<GameObject> _pool = new List<GameObject>();
        private GameObject _enemyPrefab;
    
        public EnemyPool(GameFactory gameFactory, int initialPoolSize)
        {
            this._enemyPrefab = gameFactory.CreateEnemy();
        
            for (int i = 0; i < initialPoolSize; i++)
            {
                AddNewEnemy();
            }
        }
    
        public GameObject GetOrAdd()
        {
            GameObject obj = _pool.Find(o => !o.activeSelf);
        
            if (obj == null)
            {
                obj = AddNewEnemy();
            }
        
            obj.SetActive(true);
            return obj;
        }
    
        public void Release(GameObject obj)
        {
            obj.SetActive(false);
        }
    
        private GameObject AddNewEnemy()
        {
            GameObject newObj = Object.Instantiate(_enemyPrefab);
            newObj.SetActive(false);
            _pool.Add(newObj);
            return newObj;
        }
    }
}