using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States.Data
{
    [CreateAssetMenu(fileName = "[EnemyMovement] ", menuName = "Entity/State Data/Movement State")]
    public class DMoveState : ScriptableObject
    {
        public float movementSpeed = 3f;
    }
}
