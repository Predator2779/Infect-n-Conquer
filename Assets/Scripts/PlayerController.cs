using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _characterController;
    private Animator _animator;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        _animator.SetBool("IsRun", inputVector.magnitude != 0);
        
        if (inputVector.magnitude == 0) return;
        
        var movementVector = inputVector * _speed * Time.deltaTime;
        _characterController.Move(movementVector);
    }
}