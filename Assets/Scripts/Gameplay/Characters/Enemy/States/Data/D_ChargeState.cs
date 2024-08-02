using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States.Data
{
    [CreateAssetMenu(fileName = "[EnemyCharged] ", menuName = "Entity/State Data/Charged State")]
    public class DChargeState : ScriptableObject
    {
        public float chargeSpeed = 6f;

        public float chargeTime = 2f;
    }
}
