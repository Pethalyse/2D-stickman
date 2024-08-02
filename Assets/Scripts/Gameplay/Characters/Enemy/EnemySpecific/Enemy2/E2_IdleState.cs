using System.Collections;
using System.Collections.Generic;
using Pethalyse.Gameplay.Characters.Enemy.EnemySpecific.Enemy2;
using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using UnityEngine;

public class E2_IdleState : IdleState
{
    private Enemy2 enemy;

    public E2_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DIdleState stateData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        else if (IsIdleTimeOver)
        {
            StateMachine.ChangeState(enemy.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
    }
}
