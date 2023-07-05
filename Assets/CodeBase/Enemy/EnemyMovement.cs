using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public float moveSpeed = 3f;

        private Transform player;
        private Rigidbody2D rb;

        private void Start()
        {
            player = FindObjectOfType<PlayerMovement>().transform;
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // Обчислюємо вектор спрямування до гравця
            Vector2 direction = (player.position - transform.position).normalized;

            // Рухаємо ворога в напрямку гравця
            rb.velocity = direction * moveSpeed;

            // Обертання ворога в напрямку руху
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }
}
