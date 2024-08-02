using System.Collections;
using System.Collections.Generic;
using Pethalyse.Gameplay.Characters.Enemy.EnemySpecific.Enemy2;
using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using UnityEngine;

public class E2_LookForPlayerState : LookForPlayerState
{
    private Enemy2 enemy;
    public E2_LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DLookForPlayer stateData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        if (IsPlayerInMinAgroRange)
        {
            StateMachine.ChangeState(enemy.PlayerDetectedState);
        }
        else if (IsAllTurnsTimeDone)
        {
            StateMachine.ChangeState(enemy.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
    }
}
