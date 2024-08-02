using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using Pethalyse.Gameplay.Core.CoreComponents;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States
{
	public class PlayerDetectedState : State {
		protected Movement Movement => _movement ?? Core.GetCoreComponent(ref _movement);
		private CollisionSenses CollisionSenses => _collisionSenses ?? Core.GetCoreComponent(ref _collisionSenses);

		private Movement _movement;
		private CollisionSenses _collisionSenses;

		protected readonly DPlayerDetected StateData;

		protected bool IsPlayerInMinAgroRange;
		protected bool IsPlayerInMaxAgroRange;
		protected bool PerformLongRangeAction;
		protected bool PerformCloseRangeAction;
		protected bool IsDetectingLedge;

		public PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DPlayerDetected stateData) : base(entity, stateMachine, animBoolName) {
			StateData = stateData;
		}

		public override void DoChecks() {
			base.DoChecks();

			IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
			IsPlayerInMaxAgroRange = Entity.CheckPlayerInMaxAgroRange();
			IsDetectingLedge = CollisionSenses.LedgeVertical;
			PerformCloseRangeAction = Entity.CheckPlayerInCloseRangeAction();
		}

		public override void Enter() {
			base.Enter();

			PerformLongRangeAction = false;
			Movement?.SetVelocityX(0f);
		}

		public override void LogicUpdate() {
			base.LogicUpdate();

			Movement?.SetVelocityX(0f);

			if (Time.time >= StartTime + StateData.longRangeActionTime) {
				PerformLongRangeAction = true;
			}
		}
	}
}
