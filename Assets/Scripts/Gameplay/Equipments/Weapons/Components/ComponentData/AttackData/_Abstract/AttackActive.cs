using System;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData
{
    [Serializable]
    public abstract class AttackActive : AttackData
    {
        [field: Header("Is the component for this attack will be used or not")]
        [field: Space(-10)]
        [field: Header("(false = active, true = inactive)")]
        [field: Space(5)]
        [field: SerializeField] public bool Inactive { get; private set; }
    }
}