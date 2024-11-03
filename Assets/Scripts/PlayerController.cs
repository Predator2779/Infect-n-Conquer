using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private PlayerControls _controls;
    private CharacterController _characterController;
    private Animator _animator;
    
    private void Awake()
    {
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
        var movementVector = new Vector3(inputVector.x, 0, inputVector.y);

        _animator.SetBool("IsRun", inputVector.magnitude != 0);
        
        if (inputVector.magnitude == 0) return;
        
        Quaternion targetRotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        
        var resultVector = movementVector * _speed * Time.deltaTime;
        _characterController.Move(resultVector);
    }

    private void OnDisable()
    {
        _controls.Gameplay.Disable();
    }
}