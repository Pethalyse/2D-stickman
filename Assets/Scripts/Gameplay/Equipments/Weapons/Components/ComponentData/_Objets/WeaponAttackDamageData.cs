using System;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData
{
    [Serializable]
    public class WeaponAttackDamageData : WeaponComponentData<AttackDamage>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(WeaponDamage);
        }
    }
}