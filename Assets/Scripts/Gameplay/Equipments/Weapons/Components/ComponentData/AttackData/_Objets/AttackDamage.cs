using System;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData
{
    [Serializable]
    public class AttackDamage : AttackScale
    {
        [field:Header("Damage reduced by resistances or not")]
        [field: Space(-10)]
        [field: Header("(false = reduced, true = not reduced)")]
        [field: Space(5)]

        [field: SerializeField] public bool IsBrutDamage { get; private set; }
    }
}