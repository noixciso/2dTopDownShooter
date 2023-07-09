using CodeBase.Bullet;
using CodeBase.Enemy;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BulletBase bullet))
            {
                gameObject.GetComponent<PlayerHealth>().TakeDamage(bullet.Damage);
                bullet.gameObject.SetActive(false);
            }
            else if (other.TryGetComponent(out EnemyMleeAttack enemyMleeAttack))
            {
                gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyMleeAttack.Damage);
            }
        }
    }
}