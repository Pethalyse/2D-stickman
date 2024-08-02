using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using Pethalyse.Gameplay.Core.CoreComponents;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States
{
	public class IdleState : State {
		private Movement Movement => _movement ?? Core.GetCoreComponent(ref _movement);
		private CollisionSenses CollisionSenses => _collisionSenses ?? Core.GetCoreComponent(ref _collisionSenses);

		private Movement _movement;
		private CollisionSenses _collisionSenses;

		protected readonly DIdleState StateData;

		protected bool FlipAfterIdle;
		protected bool IsIdleTimeOver;
		protected bool IsPlayerInMinAgroRange;

		protected float IdleTime;

		public IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DIdleState stateData) : base(entity, stateMachine, animBoolName) {
			StateData = stateData;
		}

		public override void DoChecks() {
			base.DoChecks();
			IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
		}

		public override void Enter() {
			base.Enter();

			Movement?.SetVelocityX(0f);
			IsIdleTimeOver = false;
			SetRandomIdleTime();
		}

		public override void Exit() {
			base.Exit();

			if (FlipAfterIdle) {
				Movement?.Flip();
			}
		}

		public override void LogicUpdate() {
			base.LogicUpdate();

			Movement?.SetVelocityX(0f);

			if (Time.time >= StartTime + IdleTime) {
				IsIdleTimeOver = true;
			}
		}

		public void SetFlipAfterIdle(bool flip) {
			FlipAfterIdle = flip;
		}

		private void SetRandomIdleTime() {
			IdleTime = Random.Range(StateData.minIdleTime, StateData.maxIdleTime);
		}
	}
}
