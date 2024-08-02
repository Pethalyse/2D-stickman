﻿using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.EnemySpecific.Enemy2
{
    public class Enemy2 : Entity
    {   
        public E2_MoveState MoveState { get; private set; }
        public E2_IdleState IdleState { get; private set; }
        public E2_PlayerDetectedState PlayerDetectedState { get; private set; }
        public E2MeleeAttackState MeleeAttackState { get; private set; }
        public E2_LookForPlayerState LookForPlayerState { get; private set; }
        public E2_StunState StunState { get; private set; }
        public E2_DeadState DeadState { get; private set; }
        public E2_DodgeState DodgeState { get; private set; }
        public E2_RangedAttackState RangedAttackState { get; private set; }

        [SerializeField]
        private DMoveState moveStateData;
        [SerializeField]
        private DIdleState idleStateData;
        [SerializeField]
        private DPlayerDetected playerDetectedStateData;
        [SerializeField]
        private DMeleeAttack meleeAttackStateData;
        [SerializeField]
        private DLookForPlayer lookForPlayerStateData;
        [SerializeField]
        private DStunState stunStateData;
        [SerializeField]
        private DDeadState deadStateData;
        [SerializeField]
        public DDodgeState dodgeStateData;
        [SerializeField]
        private DRangedAttackState rangedAttackStateData;

        [SerializeField]
        private Transform meleeAttackPosition;
        [SerializeField]
        private Transform rangedAttackPosition;

        public override void Awake()
        {
            base.Awake();

            MoveState = new E2_MoveState(this, StateMachine, "move", moveStateData, this);
            IdleState = new E2_IdleState(this, StateMachine, "idle", idleStateData, this);
            PlayerDetectedState = new E2_PlayerDetectedState(this, StateMachine, "playerDetected", playerDetectedStateData, this);
            MeleeAttackState = new E2MeleeAttackState(this, StateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
            LookForPlayerState = new E2_LookForPlayerState(this, StateMachine, "lookForPlayer", lookForPlayerStateData, this);
            StunState = new E2_StunState(this, StateMachine, "stun", stunStateData, this);
            DeadState = new E2_DeadState(this, StateMachine, "dead", deadStateData, this);
            DodgeState = new E2_DodgeState(this, StateMachine, "dodge", dodgeStateData, this);
            RangedAttackState = new E2_RangedAttackState(this, StateMachine, "rangedAttack", rangedAttackPosition, rangedAttackStateData, this);

            // Stats.Poise.OnCurrentValueZero += HandlePoiseZero;
        }

        private void HandlePoiseZero()
        {
            StateMachine.ChangeState(StunState);
        }

        private void OnDestroy()
        {
            // Stats.Poise.OnCurrentValueZero -= HandlePoiseZero;
        }

        private void Start()
        {
            StateMachine.Initialize(MoveState);        
        }

        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
        }

        public Enemy2(int lastDamageDirection) : base(lastDamageDirection)
        {
        }
    }
}