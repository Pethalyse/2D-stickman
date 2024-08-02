using System;
using System.Collections.Generic;
using System.Linq;
using Pethalyse.Gameplay.Equipments.Weapons.Components;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData;
using UnityEngine;

namespace Pethalyse.Gameplay.ScriptableObjects.Equipments.Weapons
{
    [CreateAssetMenu(menuName = "Equipment/Weapon", fileName = "[Weapon] ", order = 0)]
    public class WeaponSo : EquipmentSo
    {
        [field : Header("Weapon Data")] 
        [field: SerializeField] public int NumberOfAttacks { get; private set; }
        
        [field: SerializeReference] public List<WeaponComponentData> ComponentDataList { get; private set; }

        public T GetData<T>()
        {
            return ComponentDataList.OfType<T>().FirstOrDefault();
        }

        public List<Type> GetAllDependencies()
        {
            return ComponentDataList.Select(component => component.ComponentDependency).ToList();
        }

        public void AddComponent(WeaponComponentData comp)
        {
            if (ComponentDataList.FirstOrDefault(c => c.GetType() == comp.GetType()) != null) return;
                ComponentDataList.Add(comp);
        }

        public void RemoveComponent(Type t) =>
            ComponentDataList.RemoveAll(c => c.GetType() == t);
        
        public void SetComponentsName() => ComponentDataList.ForEach(c => c.ChangeName());
        public void SetAttacksName() => ComponentDataList.ForEach(c => c.SetAttackDataNames());
        public void InitializeAttackData() => ComponentDataList.ForEach(c => c.InitializeAttackData(NumberOfAttacks));
    }
}