using CodeBase.Bullet;
using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BulletBase bullet))
            {
                if (bullet.BulletType == BulletType.ForPlayer)
                {
                    gameObject.GetComponent<EnemyHealth>().TakeDamage(bullet.Damage);
                    bullet.gameObject.SetActive(false);
                }
                else if (bullet.BulletType == BulletType.ForEnemy)
                {
                    bullet.gameObject.SetActive(false);
                }
            }
        }
    }
}