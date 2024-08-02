using System;
using Pethalyse.Gameplay.Enum;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData
{
    [Serializable]
    public class AttackSprites : AttackData
    { 
        [field: SerializeField] public PhaseSprites[] PhaseSprites { get; private set; }
    }

    [Serializable]
    public struct PhaseSprites : ISerializationCallbackReceiver
    {
        [SerializeField, HideInInspector] private string n;
        [field: Header("Sprites for each state of this animation")]
        [field: SerializeField] public EnumAttackPhases Phase { get; private set; }
        // [field: SerializeField] public Sprite[] Sprites { get; private set; }
        
        public void OnBeforeSerialize()
        {
            n = Phase.ToString();
        }

        public void OnAfterDeserialize()
        {
            n = Phase.ToString();
        }
    }
}