using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States.Data
{
    [CreateAssetMenu(fileName = "[EnemyPlayerDetected] ", menuName = "Entity/State Data/Player Detected State")]
    public class DPlayerDetected : ScriptableObject
    {
        public float longRangeActionTime = 1.5f;
    }
}
