using CodeBase.Bullet;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace CodeBase.Weapon
{
    public class PlayerWeapon : WeaponBase
    {
        private IInputService _inputService;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }

        public override void Shot()
        {
            GameObject newBullet = BulletObjectPool.SpawnFromPool("PlayerBullets");
            newBullet.transform.position = FirePoint.position;
            newBullet.transform.rotation = FirePoint.rotation;
        }

        public override bool IsShotPossible()
        {
            return _attackTimer >= AttackCooldown && _inputService.IsAttackMouseButton();
        }
    }
}