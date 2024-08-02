using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States.Data
{
    [CreateAssetMenu(fileName = "[EnemyMeleeAttack] ", menuName = "Entity/State Data/Melee Attack State")]
    public class DMeleeAttack : ScriptableObject
    {
        public float attackRadius = 0.5f;
        public float attackDamage = 10f;

        public Vector2 knockbackAngle = Vector2.one;
        public float knockbackStrength = 10f;

        public LayerMask whatIsPlayer;
    }
}
