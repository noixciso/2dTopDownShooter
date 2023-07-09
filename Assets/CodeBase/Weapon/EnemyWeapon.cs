using CodeBase.Bullet;
using UnityEngine;

namespace CodeBase.Weapon
{
    public class EnemyWeapon : WeaponBase
    {
        public override void Shot()
        {
            GameObject newBullet = BulletObjectPool.SpawnFromPool("EnemyBullets");
            newBullet.GetComponent<BulletBase>().Damage = Damage;
            newBullet.transform.position = FirePoint.position;
            newBullet.transform.rotation = FirePoint.rotation;
        }

        public override bool IsShotPossible()
        {
            return _attackTimer >= AttackCooldown;
        }
    }
}