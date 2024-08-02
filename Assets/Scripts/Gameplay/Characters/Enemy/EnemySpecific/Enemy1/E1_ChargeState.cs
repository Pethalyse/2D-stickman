using System.Collections;
using System.Collections.Generic;
using Pethalyse.Gameplay.Characters.Enemy.EnemySpecific.Enemy1;
using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using UnityEngine;

public class E1_ChargeState : ChargeState
{
    private Enemy1 enemy;

    public E1_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DChargeState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        if (PerformCloseRangeAction)
        {
            StateMachine.ChangeState(enemy.MeleeAttackState);
        }
        else if (!IsDetectingLedge || IsDetectingWall)
        {
            StateMachine.ChangeState(enemy.LookForPlayerState);
        }
        else if (IsChargeTimeOver)
        {
            if (IsPlayerInMinAgroRange)
            {
                StateMachine.ChangeState(enemy.PlayerDetectedState);
            }
            else
            {
                StateMachine.ChangeState(enemy.LookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
    }
}
