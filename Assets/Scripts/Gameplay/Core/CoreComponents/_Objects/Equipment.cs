using System.Collections.Generic;
using JetBrains.Annotations;
using Pethalyse.Gameplay.Enum;
using Pethalyse.Gameplay.ScriptableObjects.Equipments;
using Pethalyse.Gameplay.ScriptableObjects.Equipments.Armors;
using Pethalyse.Gameplay.ScriptableObjects.Equipments.Weapons;
using UnityEngine;

namespace Pethalyse.Gameplay.Core.CoreComponents
{
    public class Equipment : CoreComponent
    {
        private CoreComp<Stats> _stats;
        
        [Header("Equipments")] 
        private readonly Dictionary<EnumEquipment, EquipmentSo> _equipments = new()
        {
            {EnumEquipment.Weapon, null},
            {EnumEquipment.Helmet, null},
            {EnumEquipment.Talisman, null},
            {EnumEquipment.Chestplate, null},
            {EnumEquipment.Pants, null},
            {EnumEquipment.Boots, null}
        };
        public delegate void OnEquipmentChangedDelegate(EnumEquipment stat);
        public event OnEquipmentChangedDelegate OnEquipmentChanged;

        protected override void Awake()
        {
            base.Awake();
            _stats = new CoreComp<Stats>(Core);
        }

        public void ChangeEquipment(EnumEquipment type, EquipmentSo equipment)
        {
            UpdateStats(_equipments[type], equipment);
            ChangeEquipmentDictionary(type, equipment);
        }

        private void UpdateStats(EquipmentSo lastEquipment, EquipmentSo newEquipment)
        {
            if(lastEquipment)
                lastEquipment.SerializableStatsAffect.ForEach(r => _stats.Comp?.RemoveBonus(r));
            
            if(newEquipment)
                newEquipment.SerializableStatsAffect.ForEach(r => _stats.Comp?.AddBonus(r));
        }

        private void ChangeEquipmentDictionary(EnumEquipment type, EquipmentSo equip)
        {
            _equipments[type] = equip;
            OnEquipmentChanged?.Invoke(type);
        }

        [CanBeNull] public EquipmentSo GetEquipment(EnumEquipment equip) => _equipments[equip];
        [CanBeNull] public WeaponSo GetWeapon() => (WeaponSo)GetEquipment(EnumEquipment.Weapon);
        [CanBeNull] public HelmetSo GetHelmet() => (HelmetSo)GetEquipment(EnumEquipment.Helmet);
        [CanBeNull] public TalismanSo GetTalisman() => (TalismanSo)GetEquipment(EnumEquipment.Talisman);
        [CanBeNull] public ChestplateSo GetChestplate() => (ChestplateSo)GetEquipment(EnumEquipment.Chestplate);
        [CanBeNull] public PantsSo GetPants() => (PantsSo)GetEquipment(EnumEquipment.Pants);
        [CanBeNull] public BootsSo GetBoots() => (BootsSo)GetEquipment(EnumEquipment.Boots);
    }
}