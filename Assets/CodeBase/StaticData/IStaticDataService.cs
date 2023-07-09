using CodeBase.Enemy;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;

namespace CodeBase.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadResources();
        EnemyStaticData ForEnemy(EnemyTypeId typeId);
    }
}