using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States
{
    public class DeadState : State
    {
        protected readonly DDeadState StateData;

        public DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DDeadState stateData) : base(entity, stateMachine, animBoolName)
        {
            StateData = stateData;
        }

        public override void Enter()
        {
            base.Enter();

            Object.Instantiate(StateData.deathBloodParticle, Entity.transform.position, StateData.deathBloodParticle.transform.rotation);
            Object.Instantiate(StateData.deathChunkParticle, Entity.transform.position, StateData.deathChunkParticle.transform.rotation);

            Entity.gameObject.SetActive(false);
        }
    }
}
