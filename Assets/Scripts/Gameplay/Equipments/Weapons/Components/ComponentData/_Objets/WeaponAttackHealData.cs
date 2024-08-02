using System;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData
{
    [Serializable]
    public class WeaponAttackHealData : WeaponComponentData<AttackScale>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(WeaponHeal);
        }
    }
}