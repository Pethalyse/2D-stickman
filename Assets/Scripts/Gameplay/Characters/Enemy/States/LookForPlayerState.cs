using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using Pethalyse.Gameplay.Core.CoreComponents;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States
{
	public class LookForPlayerState : State {
		private Movement Movement => _movement ?? Core.GetCoreComponent(ref _movement);
		private CollisionSenses CollisionSenses => _collisionSenses ?? Core.GetCoreComponent(ref _collisionSenses);

		private Movement _movement;
		private CollisionSenses _collisionSenses;

		protected readonly DLookForPlayer StateData;

		protected bool TurnImmediately;
		protected bool IsPlayerInMinAgroRange;
		protected bool IsAllTurnsDone;
		protected bool IsAllTurnsTimeDone;

		protected float LastTurnTime;

		protected int AmountOfTurnsDone;

		public LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DLookForPlayer stateData) : base(entity, stateMachine, animBoolName) {
			StateData = stateData;
		}

		public override void DoChecks() {
			base.DoChecks();

			IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
		}

		public override void Enter() {
			base.Enter();

			IsAllTurnsDone = false;
			IsAllTurnsTimeDone = false;

			LastTurnTime = StartTime;
			AmountOfTurnsDone = 0;

			Movement?.SetVelocityX(0f);
		}

		public override void LogicUpdate() {
			base.LogicUpdate();

			Movement?.SetVelocityX(0f);

			if (TurnImmediately) {
				Movement?.Flip();
				LastTurnTime = Time.time;
				AmountOfTurnsDone++;
				TurnImmediately = false;
			} else if (Time.time >= LastTurnTime + StateData.timeBetweenTurns && !IsAllTurnsDone) {
				Movement?.Flip();
				LastTurnTime = Time.time;
				AmountOfTurnsDone++;
			}

			if (AmountOfTurnsDone >= StateData.amountOfTurns) {
				IsAllTurnsDone = true;
			}

			if (Time.time >= LastTurnTime + StateData.timeBetweenTurns && IsAllTurnsDone) {
				IsAllTurnsTimeDone = true;
			}
		}

		public void SetTurnImmediately(bool flip) {
			TurnImmediately = flip;
		}
	}
}
