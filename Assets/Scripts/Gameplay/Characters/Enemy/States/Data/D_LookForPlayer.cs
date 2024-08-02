using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States.Data
{
    [CreateAssetMenu(fileName = "[EnemyLookForPlayer] ", menuName = "Entity/State Data/Look For Player State")]
    public class DLookForPlayer : ScriptableObject
    {
        public int amountOfTurns = 2;
        public float timeBetweenTurns = 0.75f;
    }
}
