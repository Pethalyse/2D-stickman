using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States.Data
{
    [CreateAssetMenu(fileName = "[EnemyDodge] ", menuName = "Entity/State Data/Dodge State")]
    public class DDodgeState : ScriptableObject
    {
        public float dodgeSpeed = 10f;
        public float dodgeTime = 0.2f;
        public float dodgeCooldown = 2f;
        public Vector2 dodgeAngle;
    }
}
