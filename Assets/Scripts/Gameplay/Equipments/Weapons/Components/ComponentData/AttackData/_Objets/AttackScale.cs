using System;
using Pethalyse.Gameplay.Enum;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData
{
    [Serializable]
    public class AttackScale : AttackActive
    {
        [field: Header("values")]
        [field: SerializeField] public EnumDamageType ValueType { get; private set; }
        [field: SerializeField] public int Percent { get; private set; }
    }
}