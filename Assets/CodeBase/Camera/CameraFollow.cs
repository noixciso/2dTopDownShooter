using UnityEngine;

namespace CodeBase.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _damping;

        private Transform _following;
        private Vector3 _velocity = Vector3.zero;

        private void FixedUpdate()
        {
            if (_following != null)
            {
                Vector3 targetPosition = _following.position + _offset;
                targetPosition.z = transform.position.z;
            
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _damping);
            }
        }
        
        public void Follow(GameObject following)
        {
            _following = following.transform;
        }
    }
}