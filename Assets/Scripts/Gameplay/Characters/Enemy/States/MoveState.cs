using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using Pethalyse.Gameplay.Core.CoreComponents;

namespace Pethalyse.Gameplay.Characters.Enemy.States
{
	public class MoveState : State {
		private Movement Movement => _movement ?? Core.GetCoreComponent(ref _movement);
		private CollisionSenses CollisionSenses => _collisionSenses ?? Core.GetCoreComponent(ref _collisionSenses);

		private Movement _movement;
		private CollisionSenses _collisionSenses;

		protected readonly DMoveState StateData;

		protected bool IsDetectingWall;
		protected bool IsDetectingLedge;
		protected bool IsPlayerInMinAgroRange;

		public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DMoveState stateData) : base(entity, stateMachine, animBoolName) {
			StateData = stateData;
		}

		public override void DoChecks() {
			base.DoChecks();

			IsDetectingLedge = CollisionSenses.LedgeVertical;
			IsDetectingWall = CollisionSenses.WallFront;
			IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
		}

		public override void Enter() {
			base.Enter();
			Movement?.SetVelocityX(StateData.movementSpeed * Movement.FacingDirection);

		}

		public override void LogicUpdate() {
			base.LogicUpdate();
			Movement?.SetVelocityX(StateData.movementSpeed * Movement.FacingDirection);
		}

	}
}
