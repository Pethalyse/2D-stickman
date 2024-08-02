using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData
{
    [Serializable]
    public class AttackActionHitBox : AttackData
    {
        [field: Header("HitBox")]
        [field: SerializeField] public Rect HitBox { get; private set; }
        [field: Header("Layer")]
        [field: SerializeField] public LayerMask DetectableLayers { get; private set; }
        
        [field: Header("Debug")]
        public bool debug;
    }
}