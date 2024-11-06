using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "Configs/UnitConfig", order = 100)]
    public class UnitConfig : ScriptableObject
    {
        public float movementSpeed;
        public float rotationSpeed;
    }
}