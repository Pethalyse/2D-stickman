using System;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData
{
    [Serializable]
    public class WeaponInputHoldData : WeaponComponentData<AttackInputHold>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(InputHold);
        }
    }
}