using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Core.CoreComponents;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States
{
	public class AttackState : State {

		private Movement Movement => _movement ?? Core.GetCoreComponent(ref _movement);
		private Movement _movement;

		protected readonly Transform AttackPosition;

		protected bool IsAnimationFinished;
		protected bool IsPlayerInMinAgroRange;

		public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName) {
			AttackPosition = attackPosition;
		}

		public override void DoChecks() {
			base.DoChecks();

			IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
		}

		public override void Enter() {
			base.Enter();

			Entity.Atsm.AttackState = this;
			IsAnimationFinished = false;
			Movement?.SetVelocityX(0f);
		}

		public override void LogicUpdate() {
			base.LogicUpdate();
			Movement?.SetVelocityX(0f);
		}

		public virtual void TriggerAttack() {

		}

		public virtual void FinishAttack() {
			IsAnimationFinished = true;
		}
	}
}
