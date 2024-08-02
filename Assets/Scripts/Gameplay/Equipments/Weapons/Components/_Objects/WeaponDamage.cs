using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;
using Pethalyse.Gameplay.Interfaces;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components
{
    public class WeaponDamage : WeaponAffectLife<WeaponAttackDamageData, AttackDamage>
    {
        protected override void AffectLife(Collider2D item, int calculatedDamage)
        {
            if (!item.gameObject.TryGetComponent<IDamageable>(out var damageable)) return;
            
            if(CurrentAttackData.IsBrutDamage)
                damageable.DamageBrut(calculatedDamage);
            else
                damageable.Damage(calculatedDamage, CurrentAttackData.ValueType);

        }
    }
}