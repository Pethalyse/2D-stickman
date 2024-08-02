using Pethalyse.Gameplay.Characters.Player.States.SuperStates;

namespace Pethalyse.Gameplay.Characters.Player.States.SubStates
{
    public class PlayerJumpState : PlayerAbilityState
    {
        public PlayerJumpState(StateMachine.Player player, string animBoolName) : base(player, animBoolName)
        {
        }
    }
}