using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyMleeAttack : MonoBehaviour
    {
        [SerializeField] private int _damage;

        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }
    }
}