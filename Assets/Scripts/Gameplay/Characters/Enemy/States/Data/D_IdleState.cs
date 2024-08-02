using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States.Data
{
    [CreateAssetMenu(fileName = "[EnemyIdle] ", menuName = "Entity/State Data/Idle State")]
    public class DIdleState : ScriptableObject
    {
        public float minIdleTime = 1f;
        public float maxIdleTime = 2f;
    }
}
