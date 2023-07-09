using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const int LeftMouseButton = 0;
        
        public Vector2 Axis =>
            new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));

        public bool IsAttackMouseButton() => 
            UnityEngine.Input.GetMouseButtonDown(LeftMouseButton);
    }
}