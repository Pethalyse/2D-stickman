using System;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData
{
    [Serializable]
    public class WeaponKnockBackData : WeaponComponentData<AttackKnockBack>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(KnockBack);
        }
    }
}