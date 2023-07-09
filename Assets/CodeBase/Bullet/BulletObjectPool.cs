using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Bullet
{
    public class BulletObjectPool : MonoBehaviour
    {
        public static BulletObjectPool Instance;

        [System.Serializable]
        public class Pool
        {
            public string Name;
            public GameObject Prefab;
            public int Size;
        }

        public List<Pool> Pools;
        public Dictionary<string, Queue<GameObject>> PoolDictionary;
        public static List<GameObject> ParentsForBullets;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            PoolDictionary = new Dictionary<string, Queue<GameObject>>();
            ParentsForBullets = new List<GameObject>();

            foreach (Pool pool in Pools)
            {
                GameObject poolObject = new GameObject(pool.Name);
                ParentsForBullets.Add(poolObject);
                poolObject.transform.SetParent(transform);

                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.Size; i++)
                {
                    GameObject obj = Instantiate(pool.Prefab);
                    obj.SetActive(false);
                    obj.transform.SetParent(poolObject.transform);
                    objectPool.Enqueue(obj);
                }

                PoolDictionary.Add(pool.Name, objectPool);
            }
        }

        public static GameObject SpawnFromPool(string poolName)
        {
            if (!Instance.PoolDictionary.ContainsKey(poolName))
            {
                return null;
            }

            Queue<GameObject> objectPool = Instance.PoolDictionary[poolName];

            GameObject objToSpawn = null;

            foreach (GameObject obj in objectPool)
            {
                if (!obj.activeSelf)
                {
                    objToSpawn = obj;
                    break;
                }
            }

            if (objToSpawn == null)
            {
                Pool pool = Instance.Pools.Find(p => p.Name == poolName);
                if (pool != null)
                {
                    objToSpawn = Instantiate(pool.Prefab);
                    objToSpawn.transform.SetParent(ParentsForBullets.Find(p => p.name == poolName).transform);
                    objectPool.Enqueue(objToSpawn);
                }
            }

            if (objToSpawn != null)
            {
                objToSpawn.SetActive(true);
                return objToSpawn;
            }
            else
            {
                return null;
            }
        }
    }

}