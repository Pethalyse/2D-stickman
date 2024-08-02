using Pethalyse.Gameplay.Characters.Enemy.State_Machine;
using Pethalyse.Gameplay.Characters.Enemy.States.Data;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States
{
    public class RangedAttackState : AttackState
    {
        protected readonly DRangedAttackState StateData;

        protected GameObject Projectile;
        protected Projectile ProjectileScript;

        public RangedAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, DRangedAttackState stateData) : base(entity, stateMachine, animBoolName, attackPosition)
        {
            StateData = stateData;
        }

        public override void Exit()
        {
        }

        public override void PhysicsUpdate()
        {
        }

        public override void TriggerAttack()
        {
            base.TriggerAttack();

            Projectile = Object.Instantiate(StateData.projectile, AttackPosition.position, AttackPosition.rotation);
            ProjectileScript = Projectile.GetComponent<Projectile>();
            ProjectileScript.FireProjectile(StateData.projectileSpeed, StateData.projectileTravelDistance, StateData.projectileDamage);
        }
    }
}
