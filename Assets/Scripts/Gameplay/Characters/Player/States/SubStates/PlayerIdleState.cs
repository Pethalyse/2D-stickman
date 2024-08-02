using Pethalyse.Gameplay.Characters.Player.States.SuperStates;

namespace Pethalyse.Gameplay.Characters.Player.States.SubStates
{
    public class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(StateMachine.Player player, string animBoolName) : base(player, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            Movement.SetVelocityZero();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (XInput != 0 || YInput != 0)
            {
                Player.StateMachine.ChangeState(Player.MoveState);
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