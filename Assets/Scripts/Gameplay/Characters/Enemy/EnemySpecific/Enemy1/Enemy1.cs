using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pethalyse.Gameplay.Characters.Enemy.EnemySpecific.Enemy1
{
    public class Enemy1 : Entity
    {
        public E1_IdleState IdleState { get; private set; }
        public E1_MoveState MoveState { get; private set; }
        public E1_PlayerDetectedState PlayerDetectedState { get; private set; }
        public E1_ChargeState ChargeState { get; private set; }
        public E1_LookForPlayerState LookForPlayerState { get; private set; }
        public E1MeleeAttackState MeleeAttackState { get; private set; }
        public E1_StunState StunState { get; private set; }
        public E1_DeadState DeadState { get; private set; }

        [SerializeField]
        private DIdleState idleStateData;
        [SerializeField]
        private DMoveState moveStateData;
        [SerializeField]
        private DPlayerDetected playerDetectedData;
        [SerializeField]
        private DChargeState chargeStateData;
        [SerializeField]
        private DLookForPlayer lookForPlayerStateData; 
        [SerializeField]
        private DMeleeAttack meleeAttackStateData;
        [SerializeField]
        private DStunState stunStateData;
        [SerializeField]
        private DDeadState deadStateData;


        [SerializeField]
        private Transform meleeAttackPosition;

        public override void Awake()
        {
            base.Awake();

            MoveState = new E1_MoveState(this, StateMachine, "move", moveStateData, this);
            IdleState = new E1_IdleState(this, StateMachine, "idle", idleStateData, this);
            PlayerDetectedState = new E1_PlayerDetectedState(this, StateMachine, "playerDetected", playerDetectedData, this);
            ChargeState = new E1_ChargeState(this, StateMachine, "charge", chargeStateData, this);
            LookForPlayerState = new E1_LookForPlayerState(this, StateMachine, "lookForPlayer", lookForPlayerStateData, this);
            MeleeAttackState = new E1MeleeAttackState(this, StateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
            StunState = new E1_StunState(this, StateMachine, "stun", stunStateData, this);
            DeadState = new E1_DeadState(this, StateMachine, "dead", deadStateData, this);

            // Stats.Poise.OnCurrentValueZero += HandlePoiseZero;
        }

        private void HandlePoiseZero()
        {
            StateMachine.ChangeState(StunState);
        }

        private void Start()
        {
            StateMachine.Initialize(MoveState);        
        }

        private void OnDestroy()
        {
            // Stats.Poise.OnCurrentValueZero -= HandlePoiseZero;
        }

        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            //Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
        }

        public Enemy1(int lastDamageDirection) : base(lastDamageDirection)
        {
        }
    }
}
