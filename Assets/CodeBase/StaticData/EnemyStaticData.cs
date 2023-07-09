using CodeBase.Enemy;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyTypeId EnemyTypeId;
        public GameObject Prefab;
        
        [Range(1,100)] public int Health;
        [Range(1,100)] public int Damage;
        [Range(1,100)] public int MoveSpeed;
        [Range(1,100)] public int Cooldown;
    }
}