using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData
{
    [Serializable]
    public abstract class AttackData
    {
        [SerializeField, HideInInspector] private string name;

        public void SetAttackName(int i) => name = $"Attack {i}";
    }
}