using CodeBase.Events;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;

        private void Start()
        {
            EventBus.Instance.EnemyHealthChanged += OnHealthChanged;
        }

        private void OnDestroy()
        {
            EventBus.Instance.EnemyHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (_enemyHealth.Current <= 0)
            {
                Die();
                EventBus.Instance.EnemyDied?.Invoke();
            }
        }
        
        private void Die()
        {
            EnemyCounterData.CountOfKilled++;
            gameObject.SetActive(false);
            _enemyHealth.ResetHealth();
        }
    }
}