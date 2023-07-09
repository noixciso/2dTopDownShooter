using UnityEngine;

namespace CodeBase.Weapon
{
    public abstract class WeaponBase : MonoBehaviour
    {
        public GameObject BulletPrefab;
        public Transform FirePoint;
        public float AttackCooldown;
        public int Damage;

        protected float _attackTimer;

        private void Update()
        {
            _attackTimer += Time.deltaTime;

            if (IsShotPossible())
            {
                Shot();
                
                _attackTimer = 0f;
            }
        }
        public abstract void Shot();
        public abstract bool IsShotPossible();
    }
}