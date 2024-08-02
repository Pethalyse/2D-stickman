using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.EnemySpecific.Enemy1
{
    public class E1MeleeAttackState : MeleeAttackState
    {
        private readonly Enemy1 _enemy;

        public E1MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, DMeleeAttack stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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
