using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.EnemySpecific.Enemy2
{
    public class E2MeleeAttackState : MeleeAttackState
    {
        private readonly global::Pethalyse.Gameplay.Characters.Enemy.EnemySpecific.Enemy2.Enemy2 _enemy;
        public E2MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, DMeleeAttack stateData, global::Pethalyse.Gameplay.Characters.Enemy.EnemySpecific.Enemy2.Enemy2 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
        {
            _enemy = enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsAnimationFinished) return;
            if (IsPlayerInMinAgroRange)
            {
                StateMachine.ChangeState(_enemy.PlayerDetectedState);
            }
            else
            {
                StateMachine.ChangeState(_enemy.LookForPlayerState);
            }
        }

    }
}
