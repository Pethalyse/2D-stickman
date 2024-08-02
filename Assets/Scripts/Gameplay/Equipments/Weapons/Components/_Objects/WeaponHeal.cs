using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData;
using Pethalyse.Gameplay.Interfaces;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components
{
    public class WeaponHeal : DefaultWeaponAffectLife<WeaponAttackHealData>
    {
        protected override void AffectLife(Collider2D item, int calculatedDamage)
        {
            if (!item.gameObject.TryGetComponent<IHealable>(out var healable)) return;

            healable.Heal(calculatedDamage);
        }
    }
}