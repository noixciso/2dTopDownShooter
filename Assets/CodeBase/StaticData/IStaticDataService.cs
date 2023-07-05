using CodeBase.Infrastructure.States;

namespace CodeBase.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadResources();
    }
}