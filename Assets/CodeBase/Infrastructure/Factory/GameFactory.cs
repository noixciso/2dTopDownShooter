using CodeBase.Infrastructure.AssetManagement;
using CodeBase.StaticData;
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
    
        public GameObject CreateEnemy()
        {
            GameObject enemyPrefab = _assets.Instantiate(AssetPath.EnemyPrefabPath);
            
            // Додаткові дії при створенні ворога, якщо потрібно
            
            return enemyPrefab;
        }
        
        public GameObject CreatePlayer(GameObject findWithTag)
        {
            GameObject player = _assets.Instantiate(AssetPath.PlayerPrefabPath);
            player.transform.position = Vector3.zero;

            return player;
        }
        
    }
}