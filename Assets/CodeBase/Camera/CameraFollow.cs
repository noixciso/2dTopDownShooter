using UnityEngine;

namespace CodeBase.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _damping;
    
        private Vector3 _velocity = Vector3.zero;

        private void FixedUpdate()
        {
            if (_target != null)
            {
                Vector3 targetPosition = _target.position + _offset;
                targetPosition.z = transform.position.z;
            
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _damping);
            }
        }
    }
}