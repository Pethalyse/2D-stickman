using System;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData
{
    [Serializable]
    public class WeaponSpriteData : WeaponComponentData<AttackSprites>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(WeaponSprite);
        }
    }
}