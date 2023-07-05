using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        public GameObject CreateEnemy();
        public GameObject CreatePlayer(GameObject findWithTag);
    }
}