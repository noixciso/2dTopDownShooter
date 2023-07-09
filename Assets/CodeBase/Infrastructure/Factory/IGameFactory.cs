using CodeBase.Enemy;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateEnemy(EnemyTypeId enemyTypeId);
        GameObject CreatePlayer();
        GameObject CreateEnemySpawner();
        GameObject CreateCanvas();
        GameObject CreateBulletPool();
    }
}