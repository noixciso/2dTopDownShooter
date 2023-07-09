using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private float _stoppingDistance = 2f;

        private Transform _player;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _player = FindObjectOfType<PlayerMove>().transform;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_player.transform != null)
            {
                var direction = CalculateDirection();
        
                var distance = CalculateDistance();

                if (distance <= _stoppingDistance)
                {
                    StopMovement();
                }
                else
                {
                    Move(direction);
                }

                Rotate(direction);
            }
        }

        private Vector2 CalculateDirection()
        {
            Vector2 direction = (_player.position - transform.position).normalized;
            return direction;
        }

        private void Rotate(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _rigidbody2D.rotation = angle;
        }

        private void Move(Vector2 direction)
        {
            _rigidbody2D.velocity = direction * _moveSpeed;
        }

        private float CalculateDistance()
        {
            float distance = Vector2.Distance(transform.position, _player.position);
            return distance;
        }

        private void StopMovement()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

}
