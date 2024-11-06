using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 100)]
    public class PlayerConfig : ScriptableObject
    {
        public float camRotationSpeed;
    }
}