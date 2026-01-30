using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInput), typeof(PlayerMovement), typeof(PlayerCamera))]
    public class PlayerController : MonoBehaviour
    {
        // SOLID
        private PlayerInput _input;
        private PlayerMovement _movement;
        private PlayerCamera _camera;
    
        private void Start()
        {
            _input = GetComponent<PlayerInput>();
            _movement = GetComponent<PlayerMovement>();
            _camera = GetComponent<PlayerCamera>();
        }

        private void Update()
        {
            _movement.UpdateMovement(_input.MoveDirection, _input.JumpPressed);
            _camera.UpdateLookDirection(_input.LookDirection);
        }
    }
}