using System;
using Pethalyse.Gameplay.Characters.Player.StateMachine;
using Pethalyse.Gameplay.Core.CoreComponents;

namespace Pethalyse.Gameplay.Characters.Player.States.SuperStates
{
    public class PlayerGroundedState : PlayerState
    {
        protected int XInput;
        protected int YInput;

        protected Movement Movement => _movement ??= Core.GetCoreComponent(ref _movement);
        private Movement _movement;
        
        protected Stats Stats => _stats ??= Core.GetCoreComponent(ref _stats);
        private Stats _stats;
        
        public PlayerGroundedState(StateMachine.Player player, string animBoolName) : base(player, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            XInput = Player.InputsHandler.NormInputX;
            YInput = Player.InputsHandler.NormInputY;

            if (Player.InputsHandler.AttackInputs)
            {
                Player.StateMachine.ChangeState(Player.AttackState);
                throw new Exception($"State Change from {this} to AttackState");
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }
    }
}