using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using Pethalyse.Gameplay.Core.CoreComponents;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States
{
	public class ChargeState : State {
		private Movement Movement => _movement ?? Core.GetCoreComponent(ref _movement);
		private CollisionSenses CollisionSenses => _collisionSenses ?? Core.GetCoreComponent(ref _collisionSenses);

		private Movement _movement;
		private CollisionSenses _collisionSenses;


		protected readonly DChargeState StateData;

		protected bool IsPlayerInMinAgroRange;
		protected bool IsDetectingLedge;
		protected bool IsDetectingWall;
		protected bool IsChargeTimeOver;
		protected bool PerformCloseRangeAction;

		public ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DChargeState stateData) : base(entity, stateMachine, animBoolName) {
			StateData = stateData;
		}

		public override void DoChecks() {
			base.DoChecks();

			IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
			IsDetectingLedge = CollisionSenses.LedgeVertical;
			IsDetectingWall = CollisionSenses.WallFront;

			PerformCloseRangeAction = Entity.CheckPlayerInCloseRangeAction();
		}

		public override void Enter() {
			base.Enter();

			IsChargeTimeOver = false;
			Movement?.SetVelocityX(StateData.chargeSpeed * Movement.FacingDirection);
		}

		public override void LogicUpdate() {
			base.LogicUpdate();

			Movement?.SetVelocityX(StateData.chargeSpeed * Movement.FacingDirection);

			if (Time.time >= StartTime + StateData.chargeTime) {
				IsChargeTimeOver = true;
			}
		}
	}
}
