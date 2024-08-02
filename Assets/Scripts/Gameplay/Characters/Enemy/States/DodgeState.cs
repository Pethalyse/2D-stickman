using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using Pethalyse.Gameplay.Core.CoreComponents;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States
{
	public class DodgeState : State {
		private Movement Movement => _movement ?? Core.GetCoreComponent(ref _movement);
		private CollisionSenses CollisionSenses => _collisionSenses ?? Core.GetCoreComponent(ref _collisionSenses);

		private Movement _movement;
		private CollisionSenses _collisionSenses;

		protected readonly DDodgeState StateData;

		protected bool PerformCloseRangeAction;
		protected bool IsPlayerInMaxAgroRange;
		protected bool IsGrounded;
		protected bool IsDodgeOver;

		public DodgeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DDodgeState stateData) : base(entity, stateMachine, animBoolName) {
			StateData = stateData;
		}

		public override void DoChecks() {
			base.DoChecks();

			PerformCloseRangeAction = Entity.CheckPlayerInCloseRangeAction();
			IsPlayerInMaxAgroRange = Entity.CheckPlayerInMaxAgroRange();
			IsGrounded = CollisionSenses.Ground;
		}

		public override void Enter() {
			base.Enter();

			IsDodgeOver = false;

			Movement?.SetVelocity(StateData.dodgeSpeed, StateData.dodgeAngle, -Movement.FacingDirection);
		}

		public override void LogicUpdate() {
			base.LogicUpdate();

			if (Time.time >= StartTime + StateData.dodgeTime && IsGrounded) {
				IsDodgeOver = true;
			}
		}
	}
}
