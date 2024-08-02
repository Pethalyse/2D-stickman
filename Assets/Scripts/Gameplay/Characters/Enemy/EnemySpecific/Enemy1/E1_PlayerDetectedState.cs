using System.Collections;
using System.Collections.Generic;
using Pethalyse.Gameplay.Characters.Enemy.EnemySpecific.Enemy1;
using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using UnityEngine;

public class E1_PlayerDetectedState : PlayerDetectedState {
	private Enemy1 enemy;

	public E1_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DPlayerDetected stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData) {
		this.enemy = enemy;
	}

	public override void Enter() {
		base.Enter();
	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		if (PerformCloseRangeAction) {
			StateMachine.ChangeState(enemy.MeleeAttackState);
		} else if (PerformLongRangeAction) {
			StateMachine.ChangeState(enemy.ChargeState);
		} else if (!IsPlayerInMaxAgroRange) {
			StateMachine.ChangeState(enemy.LookForPlayerState);
		} else if (!IsDetectingLedge) {
			Movement?.Flip();
			StateMachine.ChangeState(enemy.MoveState);
		}

	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}
}
