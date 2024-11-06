using System.Collections;
using Configs;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Animator))]
    public class Unit : MonoBehaviour, IUnit
    {
        [SerializeField] private UnitConfig _config;
        
        private CharacterController _characterController;
        private Animator _animator;
        
        private static readonly int IsRun = Animator.StringToHash("IsRun"); // перенсти в отд. файл
        private static readonly int IsAttack = Animator.StringToHash("IsAttack");

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }
        
        public void Idle()
        {
            _animator.SetBool(IsRun, false);
        }

        public void Move(Vector3 direction)
        {
            _animator.SetBool(IsRun, true);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _config.rotationSpeed * Time.deltaTime);

            var resultVector = direction.normalized * _config.movementSpeed * Time.deltaTime;
            _characterController.Move(resultVector);
        }

        public void Attack(bool isAttack)
        {
            _animator.SetBool(IsAttack, isAttack);
        }
    }
}