using System;
using CodeBase.Enemy;
using CodeBase.Events;
using CodeBase.Interfaces;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private int _max = 100; 
        [SerializeField] private int _current;
        
        public int Max
        {
            get => _max;
            set => _max = value;
        }

        public int Current
        {
            get => _current;
            set => _current = value;
        }
        
        private void Start()
        {
            _current = _max; 
        }

        public void TakeDamage(int damage)
        {
            if (_current <= 0)
            {
                Die();
                return;
            }

            _current -= damage;
            EventBus.Instance.PlayerHealthChanged?.Invoke();
        }

        private void Die()
        {
            //Destroy(gameObject);
        }
    }
}