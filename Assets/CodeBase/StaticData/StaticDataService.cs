using System.Collections.Generic;
using System.Linq;
using CodeBase.Enemy;
using CodeBase.Player;
using UnityEngine;

namespace CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyTypeId, EnemyStaticData> _enemyes;

        
        public void LoadResources()
        {
            _enemyes = Resources.LoadAll<EnemyStaticData>("StaticData/Enemy")
                .ToDictionary(x => x.EnemyTypeId, x => x);
        }
        
        public EnemyStaticData ForEnemy(EnemyTypeId typeId) => 
            _enemyes.TryGetValue(typeId, out EnemyStaticData staticData) ? staticData : null;
        
    }
}