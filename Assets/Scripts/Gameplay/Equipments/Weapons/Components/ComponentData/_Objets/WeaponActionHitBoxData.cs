using System;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData
{
    [Serializable]
    public class WeaponActionHitBoxData : WeaponComponentData<AttackActionHitBox>
    { 
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(ActionHitBox);
        }
    }
}