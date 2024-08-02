using System;
using Pethalyse.Gameplay.Characters.Player.States.SuperStates;
using Pethalyse.Gameplay.Enum;
using Telepathy;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Player.States.SubStates
{
    public class PlayerMoveState : PlayerGroundedState
    {
        public PlayerMoveState(StateMachine.Player player, string animBoolName) : base(player, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
            Movement.SetVelocityZero();
        }

        public override void LogicUpdate()
        {
            try
            {
                base.LogicUpdate();
            
                Movement.CheckIfShouldFlip(XInput);
        
                Movement.SetVelocityX(
                    Stats.GetStat(EnumStats.Speed).GetValueWithBonus() * XInput
                );
                
                if (XInput != 0 || YInput != 0) return;
                Player.StateMachine.ChangeState(Player.IdleState);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}