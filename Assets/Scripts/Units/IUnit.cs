using UnityEngine;

namespace Units
{
    public interface IUnit
    {
        public void Idle();
        public void Move(Vector3 direction);
        public void Attack(bool isAttack);
    }
}