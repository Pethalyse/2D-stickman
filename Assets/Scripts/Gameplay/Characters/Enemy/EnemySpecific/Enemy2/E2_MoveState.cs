using System.Collections;
using System.Collections.Generic;
using Pethalyse.Gameplay.Characters.Enemy.EnemySpecific.Enemy2;
using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using UnityEngine;

public class E2_MoveState : MoveState
{
    private Enemy2 enemy;

    public E2_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DMoveState stateData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsPlayerInMinAgroRange)
        {
            StateMachine.ChangeState(enemy.PlayerDetectedState);
        }
        else if(IsDetectingWall || !IsDetectingLedge)
        {
            enemy.IdleState.SetFlipAfterIdle(true);
            StateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
