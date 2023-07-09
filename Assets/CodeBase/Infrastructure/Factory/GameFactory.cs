using CodeBase.Enemy;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Interfaces;
using CodeBase.StaticData;
using CodeBase.Weapon;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private IStaticDataService _staticData;

        public GameFactory(IAssetProvider assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }
    
        public GameObject CreateEnemy(EnemyTypeId enemyTypeId)
        {
            EnemyStaticData enemyData = _staticData.ForEnemy(enemyTypeId);

            GameObject enemy = Object.Instantiate(enemyData.Prefab);

            IHealth health = enemy.GetComponent<IHealth>();
            health.Current = enemyData.Health;
            health.Max = enemyData.Health;

            if (enemyTypeId == EnemyTypeId.WithWeapon)
            {
                enemy.GetComponent<EnemyWeapon>().Damage = enemyData.Damage;
            }
            else if (enemyTypeId == EnemyTypeId.WithoutWeapon)
            {
                enemy.GetComponent<EnemyMleeAttack>().Damage = enemyData.Damage;
            }
            
            return enemy;
        }

        public GameObject CreatePlayer()
        {
            GameObject player = Object.Instantiate(_assets.Load(AssetPath.PlayerPrefabPath));

            return player;
        }

        public GameObject CreateEnemySpawner()
        {
            GameObject spawner = Object.Instantiate(_assets.Load(AssetPath.EnemySpawnerPrefabPath));

            return spawner;
        }
        
        public GameObject CreateCanvas()
        {
            GameObject canvas = Object.Instantiate(_assets.Load(AssetPath.CanvasPrefabPath));

            return canvas;
        }

        public GameObject CreateBulletPool()
        {
            GameObject bulletPool = Object.Instantiate(_assets.Load(AssetPath.BulletPoolPrefabPath));

            return bulletPool;
        }
    }
}