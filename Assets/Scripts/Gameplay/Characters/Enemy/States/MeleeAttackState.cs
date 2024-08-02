using System.Collections.Generic;
using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using Pethalyse.Gameplay.Core.CoreComponents;
using Pethalyse.Gameplay.Enum;
using Pethalyse.Gameplay.Interfaces;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States
{
	public class MeleeAttackState : AttackState {
		private Movement Movement => _movement ?? Core.GetCoreComponent(ref _movement);
		private CollisionSenses CollisionSenses => _collisionSenses ?? Core.GetCoreComponent(ref _collisionSenses);

		private Movement _movement;
		private CollisionSenses _collisionSenses;

		protected readonly DMeleeAttack StateData;

		public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, DMeleeAttack stateData) : base(entity, stateMachine, animBoolName, attackPosition) {
			StateData = stateData;
		}
		
		public override void Exit() {
		}

		public override void PhysicsUpdate() {
		}

		public override void TriggerAttack() {
			base.TriggerAttack();

			var detectedObjects = new List<Collider2D>();
			var filter = new ContactFilter2D
			{
				layerMask = StateData.whatIsPlayer
			};
			Physics2D.OverlapCircle(AttackPosition.position, StateData.attackRadius, filter, detectedObjects);

			foreach (var collider in detectedObjects) {
				var damageable = collider.GetComponent<IDamageable>();

				damageable?.Damage(10, EnumDamageType.Physic);

				var knockBackable = collider.GetComponent<IKnockBackable>();

				knockBackable?.KnockBack(StateData.knockbackAngle, StateData.knockbackStrength, Movement.FacingDirection);
			}
		}
	}
}
