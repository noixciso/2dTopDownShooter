using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace CodeBase.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private IInputService _inputService;
        private Rigidbody2D _rigidbody;
        private Vector2 _moveDirection;
        private Vector2 _smoothedMovementInput;
        private Vector2 _movementInputSmoothVelocity;
        private UnityEngine.Camera _camera;
        private Vector3 _mousePosition;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start() => 
            _camera = UnityEngine.Camera.main;

        private void Update()
        {
            _moveDirection = _camera.transform.TransformDirection(_inputService.Axis);
            _mousePosition = UnityEngine.Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            
            SetVelocity();
            RotateInDirectionMouse();
        }

        private void RotateInDirectionMouse()
        {
            _mousePosition.z = 0f;
            Vector2 direction = (_mousePosition - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _rigidbody.rotation = angle;
        }

        private void SetVelocity()
        {
            _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _moveDirection,
                ref _movementInputSmoothVelocity, 0.1f);

            _rigidbody.velocity = _smoothedMovementInput * _moveSpeed;
        }
    }
}
