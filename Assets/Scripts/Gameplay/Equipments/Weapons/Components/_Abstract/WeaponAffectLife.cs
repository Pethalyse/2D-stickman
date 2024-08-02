using System.Collections.Generic;
using Pethalyse.Gameplay.Core;
using Pethalyse.Gameplay.Core.CoreComponents;
using Pethalyse.Gameplay.Enum;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;
using Pethalyse.Gameplay.Interfaces;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components
{
    
    public abstract class DefaultWeaponAffectLife<T1> : WeaponAffectLife<T1, AttackScale> where T1 : WeaponComponentData<AttackScale>
    {
    }
    public abstract class WeaponAffectLife<T1, T2> : WeaponDetectedCollider<T1, T2> where T1 : WeaponComponentData<T2> where T2 : AttackScale
    {
        private CoreComp<Stats> _stats;

        protected override void Awake()
        {
            base.Awake();
            _stats = new CoreComp<Stats>(Core);
        }

        protected override void HandleDetectedCollider2D(Collider2D[] colliders)
        {
            base.HandleDetectedCollider2D(colliders);
            foreach (var item in colliders)
            {
                if(CurrentAttackData.Percent <= 0) continue;
                var calculatedValues =
                    _stats.Comp.CalculateDamage(CurrentAttackData.ValueType, CurrentAttackData.Percent);
                AffectLife(item, calculatedValues);
            }
        }

        protected abstract void AffectLife(Collider2D item, int calculatedDamage);
    }
}