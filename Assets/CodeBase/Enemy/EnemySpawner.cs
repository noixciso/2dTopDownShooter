using System.Collections.Generic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public List<EnemyTypeId> EnemyTypes = new List<EnemyTypeId>();
        public float MinSpawnInterval = 1f;
        public float MaxSpawnInterval = 3f;
        public int PoolSize;
        public float SpawnRadius = 10f;

        private IGameFactory _gameFactory;
        private EnemyPool _enemyPool;
        private Transform _playerTransform;
        private float _timer = 0f;
        private float _spawnInterval = 0f;

        private void Awake()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
            _enemyPool = new EnemyPool(_gameFactory, this, PoolSize);
        }

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMove>().transform;
            ResetSpawnInterval();
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _spawnInterval)
            {
                SpawnEnemy();
                ResetSpawnInterval();
            }
        }

        private void SpawnEnemy()
        {
            GameObject enemy = _enemyPool.GetOrCreate(EnemyTypes[Random.Range(0, EnemyTypes.Count)]);
            Vector2 randomPosition = Random.insideUnitCircle.normalized * SpawnRadius;
            Vector3 spawnPosition = new Vector3(randomPosition.x, randomPosition.y) + _playerTransform.position;
            enemy.transform.position = spawnPosition;
        }

        private void ResetSpawnInterval()
        {
            _timer = 0f;
            _spawnInterval = Random.Range(MinSpawnInterval, MaxSpawnInterval);
        }
    }
}