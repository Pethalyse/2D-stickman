using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States.Data
{
    [CreateAssetMenu(fileName = "[EnemyDead] ", menuName = "Entity/State Data/Dead State")]
    public class DDeadState : ScriptableObject
    {
        public GameObject deathChunkParticle;
        public GameObject deathBloodParticle;
    }
}
