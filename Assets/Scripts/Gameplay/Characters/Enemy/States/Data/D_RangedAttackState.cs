using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States.Data
{
    [CreateAssetMenu(fileName = "[EnemyRangedAttack] ", menuName = "Entity/State Data/Ranged Attack State")]
    public class DRangedAttackState : ScriptableObject
    {
        public GameObject projectile;
        public float projectileDamage = 10f;
        public float projectileSpeed = 12f;
        public float projectileTravelDistance;
    }
}
