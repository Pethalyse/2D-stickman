using Pethalyse.Gameplay.Characters.Enemy.States;
using UnityEngine;

namespace Pethalyse.Gameplay.Intermediaries
{
    public class AnimationToStatemachine : MonoBehaviour
    {
        public AttackState AttackState;

        private void TriggerAttack()
        {
            AttackState.TriggerAttack();
        }

        private void FinishAttack()
        {
            AttackState.FinishAttack();
        }
    }
}
