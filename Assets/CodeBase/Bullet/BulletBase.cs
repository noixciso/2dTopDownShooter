using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Bullet
{
    public class BulletBase : MonoBehaviour
    {
        public BulletType BulletType;
        public float Speed;
        public int Damage;
        private float _lifetime = 5;

        private void OnEnable()
        {
            CancelInvoke("Deactivate");
            Invoke("Deactivate", _lifetime);
        }

        private void Deactivate()
        {
            this.gameObject.SetActive(false);
        }

        private void Update()
        {
            MoveBullet();
        }

        private void MoveBullet()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
    }
}