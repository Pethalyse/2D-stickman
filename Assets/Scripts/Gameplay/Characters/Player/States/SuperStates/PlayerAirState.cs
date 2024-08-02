using Pethalyse.Gameplay.Characters.Player.StateMachine;

namespace Pethalyse.Gameplay.Characters.Player.States.SuperStates
{
    public abstract class PlayerAirState : PlayerState
    {
        protected PlayerAirState(StateMachine.Player player, string animBoolName) : base(player, animBoolName)
        {
        }
    }
}