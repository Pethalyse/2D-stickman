using System;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData
{
    [Serializable]
    public class AttackInputHold : AttackData
    {
        [field: SerializeField] public bool IsHoldAttack { get; private set; }
    }
}