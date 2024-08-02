using System.Collections;
using System.Collections.Generic;
using Pethalyse.Gameplay.Characters.Enemy.EnemySpecific.Enemy2;
using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using UnityEngine;

public class E2_DodgeState : DodgeState
{
    private Enemy2 enemy;

    public E2_DodgeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DDodgeState stateData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsDodgeOver)
        {
            if(IsPlayerInMaxAgroRange && PerformCloseRangeAction)
            {
                StateMachine.ChangeState(enemy.MeleeAttackState);
            }
            else if(IsPlayerInMaxAgroRange && !PerformCloseRangeAction)
            {
                StateMachine.ChangeState(enemy.RangedAttackState);
            }
            else if (!IsPlayerInMaxAgroRange)
            {
                StateMachine.ChangeState(enemy.LookForPlayerState);
            }

            //TODO: ranged attack state
        }
    }

    public override void PhysicsUpdate()
    {
    }
}
