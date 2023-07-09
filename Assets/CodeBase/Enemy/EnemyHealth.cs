using CodeBase.Events;
using CodeBase.Interfaces;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private int _max;
        [SerializeField] private int _current;

        public int Current
        {
            get => _current;
            set => _current = value;
        }

        public int Max
        {
            get => _max;
            set => _max = value;
        }

        public void TakeDamage(int damage)
        {
            if (Current <= 0)
            {
                return;
            }

            Current -= damage;
            EventBus.Instance.EnemyHealthChanged?.Invoke();
        }

        public void ResetHealth()
        {
            Current = _max;
        }
    }
}