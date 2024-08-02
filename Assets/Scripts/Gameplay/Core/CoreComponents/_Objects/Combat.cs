using Pethalyse.Gameplay.Enum;
using Pethalyse.Gameplay.Interfaces;
using UnityEngine;

namespace Pethalyse.Gameplay.Core.CoreComponents
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Combat : CoreComponent, IDamageable, IHealable
    {
        private CoreComp<Stats> _stats;

        protected override void Awake()
        {
            base.Awake();

            _stats = new CoreComp<Stats>(Core);
        }

        public void Damage(int amount, EnumDamageType damageType)
        {
            _stats.Comp?.ReduceHealth(_stats.Comp.CalculateReduction(damageType, amount));
        }

        public void DamageBrut(int amount)
        {
            _stats.Comp?.ReduceHealth(amount);
        }

        public void Heal(int amount) => _stats.Comp?.IncreaseHealth(amount);
    }
}