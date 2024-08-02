using UnityEngine;
using Time = UnityEngine.Time;

namespace Pethalyse.Gameplay.Characters.Player.StateMachine
{
    public class PlayerState
    {
        protected readonly Core.Core Core;
        
        protected readonly Player Player;

        protected float StartTime;
        
        private readonly string _animBoolName;
        protected bool IsAnimationFinish;
        protected bool IsExitingState;

        public PlayerState(Player player, string animBoolName)
        {
            Player = player;
            _animBoolName = animBoolName;
            Core = Player.Core;
        }

        public virtual void Enter()
        {
            DoChecks();
            Player.Anim.SetBool(_animBoolName, true);
            StartTime = Time.time;
            IsAnimationFinish = false;
            IsExitingState = false;
        }

        public virtual void Exit()
        {
            Player.Anim.SetBool(_animBoolName, false);
            IsExitingState = true;
        }

        public virtual void LogicUpdate()
        {
            
        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {
            
        }

        public virtual void AnimationFinishTrigger() => IsAnimationFinish = true;
    }
}
