using System;
using CodeBase.Camera;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;

        private Rigidbody2D _rigidbody;
        private Vector2 _movementInput;
        private Vector2 _smoothedMovementInput;
        private Vector2 _movementInputSmoothVelocity;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            SetVelocity();
            RotateInDirectionOfInput();
        }

        public void OnMove(InputValue inputValue)
        {
            _movementInput = inputValue.Get<Vector2>();
        }

        private void SetVelocity()
        {
            _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _movementInput,
                ref _movementInputSmoothVelocity, 0.1f);

            _rigidbody.velocity = _smoothedMovementInput * _moveSpeed;
        }

        private void RotateInDirectionOfInput()
        {
            if (_movementInput != Vector2.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
                Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
                    _rotationSpeed * Time.deltaTime);
                
                _rigidbody.MoveRotation(rotation);
            }
        }
    }
}
