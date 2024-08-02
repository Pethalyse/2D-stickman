using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using Pethalyse.Gameplay.Core.CoreComponents;
using Pethalyse.Gameplay.Intermediaries;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.State_Machine
{
	public class Entity : MonoBehaviour {
		private Movement Movement => _movement ?? Core.GetCoreComponent(ref _movement);

		private Movement _movement;

		public FiniteStateMachine StateMachine;

		public DEntity entityData;

		public Animator Anim { get; private set; }
		public AnimationToStatemachine Atsm { get; private set; }
		public int LastDamageDirection { get; private set; }
		public Core.Core Core { get; private set; }

		[SerializeField]
		private Transform wallCheck;
		[SerializeField]
		private Transform ledgeCheck;
		[SerializeField]
		private Transform playerCheck;
		[SerializeField]
		private Transform groundCheck;

		private float _currentHealth;
		private float _currentStunResistance;
		private float _lastDamageTime;

		private Vector2 _velocityWorkspace;

		protected bool IsStunned;
		protected bool IsDead;

		protected Stats Stats;

		public Entity(int lastDamageDirection)
		{
			LastDamageDirection = lastDamageDirection;
		}

		public virtual void Awake() {
			Core = GetComponentInChildren<Core.Core>();

			Core.GetCoreComponent(ref Stats);

			_currentHealth = entityData.maxHealth;
			_currentStunResistance = entityData.stunResistance;

			Anim = GetComponent<Animator>();
			Atsm = GetComponent<AnimationToStatemachine>();

			StateMachine = new FiniteStateMachine();
		}

		public virtual void Update() {
			Core.LogicUpdate();
			StateMachine.CurrentState.LogicUpdate();

			Anim.SetFloat("yVelocity", Movement.Rb.velocity.y);

			if (Time.time >= _lastDamageTime + entityData.stunRecoveryTime) {
				ResetStunResistance();
			}
		}

		public virtual void FixedUpdate() {
			StateMachine.CurrentState.PhysicsUpdate();
		}

		public virtual bool CheckPlayerInMinAgroRange() {
			return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
		}

		public virtual bool CheckPlayerInMaxAgroRange() {
			return Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
		}

		public virtual bool CheckPlayerInCloseRangeAction() {
			return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
		}

		public virtual void DamageHop(float velocity) {
			_velocityWorkspace.Set(Movement.Rb.velocity.x, velocity);
			Movement.Rb.velocity = _velocityWorkspace;
		}

		public virtual void ResetStunResistance() {
			IsStunned = false;
			_currentStunResistance = entityData.stunResistance;
		}

		public virtual void OnDrawGizmos()
		{
			if (Core == null) return;
			Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * Movement.FacingDirection * entityData.wallCheckDistance));
			Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));

			Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance), 0.2f);
			Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAgroDistance), 0.2f);
			Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgroDistance), 0.2f);
		}
	}
}
