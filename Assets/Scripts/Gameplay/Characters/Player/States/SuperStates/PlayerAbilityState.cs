using Pethalyse.Gameplay.Characters.Player.StateMachine;

namespace Pethalyse.Gameplay.Characters.Player.States.SuperStates
{
    public class PlayerAbilityState : PlayerState
    {
        protected bool IsAbilityDone;
        public PlayerAbilityState(StateMachine.Player player, string animBoolName) : base(player, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            IsAbilityDone = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (IsAbilityDone)
            {
                Player.StateMachine.ChangeState(Player.IdleState);
            }
        }
    }
}