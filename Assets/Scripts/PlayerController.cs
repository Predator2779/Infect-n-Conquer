using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook _cmFreeLook;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _camRotation;

    private Camera _camera;
    private PlayerControls _controls;
    private CharacterController _characterController;
    private Animator _animator;
    
    private void Awake()
    {
        _camera = Camera.main;
        _controls = new PlayerControls();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _controls.Gameplay.Enable();
    }

    private void Update()
    {
        var inputVector = _controls.Gameplay.Movement.ReadValue<Vector2>();
        var inputLook = _controls.Gameplay.Look.ReadValue<Vector2>();

        var movementVector = new Vector3(inputVector.x, 0, inputVector.y);
        movementVector = Quaternion.Euler(0, _camera.transform.eulerAngles.y, 0) * movementVector;

        _animator.SetBool("IsRun", inputVector.magnitude != 0);

        if (inputLook.magnitude != 0)
        {
            _cmFreeLook.m_XAxis.Value += inputLook.x * _camRotation * Time.deltaTime;
            _cmFreeLook.m_YAxis.Value += inputLook.y * Time.deltaTime;
        }
        
        if (inputVector.magnitude == 0) return;

        Quaternion targetRotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        
        var resultVector = movementVector.normalized * _speed * Time.deltaTime;
        _characterController.Move(resultVector);
    }

    private void OnDisable()
    {
        _controls.Gameplay.Disable();
    }
}
