using Cinemachine;
using Configs;
using Units;
using UnityEngine;

namespace Input
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Unit _player; // интерфейс
        [SerializeField] private PlayerConfig _config;
        
        private CinemachineFreeLook _cmFreeLook;
        
        private Camera _camera;
        private PlayerControls _controls;

        private void Awake()
        {
            if (_cmFreeLook == null) _cmFreeLook = FindObjectOfType<CinemachineFreeLook>(); // переделать
            _camera = Camera.main;
            _controls = new PlayerControls();
        }

        private void OnEnable()
        {
            _controls.Gameplay.Enable();
        }

        private void Update()
        {
            var moveInput = _controls.Gameplay.Movement.ReadValue<Vector2>();
            var camInput = _controls.Gameplay.Look.ReadValue<Vector2>();
            var isAttackInput = _controls.Gameplay.Attack.IsPressed();

            Attack(isAttackInput);
            LookAround(camInput);
            MoveUnit(moveInput);
        }

        private void OnDisable()
        {
            _controls.Gameplay.Disable();
        }

        private void Attack(bool isAttack)
        {
            _player.Attack(isAttack);
        }

        private void MoveUnit(Vector2 inputVector)
        {
            if (inputVector.magnitude == 0)
            {
                _player.Idle();
                return;
            }

            var moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
            moveDirection = Quaternion.Euler(0, _camera.transform.eulerAngles.y, 0) * moveDirection;

            _player.Move(moveDirection);
        }

        private void LookAround(Vector2 inputLook)
        {
            if (inputLook.magnitude == 0) return;

            _cmFreeLook.m_XAxis.Value += inputLook.x * _config.camRotationSpeed * Time.deltaTime;
            _cmFreeLook.m_YAxis.Value += inputLook.y * Time.deltaTime;
        }
    }
}