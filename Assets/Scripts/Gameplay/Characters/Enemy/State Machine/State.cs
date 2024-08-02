using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.State_Machine
{
    public class State
    {
        protected readonly FiniteStateMachine StateMachine;
        protected readonly Entity Entity;
        protected Core.Core Core;    

        public float StartTime { get; protected set; }

        protected readonly string AnimBoolName;

        public State(Entity entity, FiniteStateMachine stateMachine, string animBoolName)
        {
            Entity = entity;
            StateMachine = stateMachine;
            AnimBoolName = animBoolName;
            Core = Entity.Core;
        }

        public virtual void Enter()
        {
            StartTime = Time.time;
            Entity.Anim.SetBool(AnimBoolName, true);
            DoChecks();
        }

        public virtual void Exit()
        {
            Entity.Anim.SetBool(AnimBoolName, false);
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
    }
}
