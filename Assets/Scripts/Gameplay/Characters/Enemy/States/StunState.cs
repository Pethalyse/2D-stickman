using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using Pethalyse.Gameplay.Core.CoreComponents;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States
{
	public class StunState : State {
		private Movement Movement => _movement ?? Core.GetCoreComponent(ref _movement);
		private CollisionSenses CollisionSenses => _collisionSenses ?? Core.GetCoreComponent(ref _collisionSenses);

		private Movement _movement;
		private CollisionSenses _collisionSenses;

		protected readonly DStunState StateData;

		protected bool IsStunTimeOver;
		protected bool IsGrounded;
		protected bool IsMovementStopped;
		protected bool PerformCloseRangeAction;
		protected bool IsPlayerInMinAgroRange;

		public StunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DStunState stateData) : base(entity, stateMachine, animBoolName) {
			StateData = stateData;
		}

		public override void DoChecks() {
			base.DoChecks();

			IsGrounded = CollisionSenses.Ground;
			PerformCloseRangeAction = Entity.CheckPlayerInCloseRangeAction();
			IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
		}

		public override void Enter() {
			base.Enter();

			IsStunTimeOver = false;
			IsMovementStopped = false;
			Movement?.SetVelocity(StateData.stunKnockbackSpeed, StateData.stunKnockbackAngle, Entity.LastDamageDirection);

		}

		public override void Exit() {
			base.Exit();
			Entity.ResetStunResistance();
		}

		public override void LogicUpdate() {
			base.LogicUpdate();

			if (Time.time >= StartTime + StateData.stunTime) {
				IsStunTimeOver = true;
			}

			if (!IsGrounded || !(Time.time >= StartTime + StateData.stunKnockbackTime) || IsMovementStopped) return;
			IsMovementStopped = true;
			Movement?.SetVelocityX(0f);
		}
		
	}
}
