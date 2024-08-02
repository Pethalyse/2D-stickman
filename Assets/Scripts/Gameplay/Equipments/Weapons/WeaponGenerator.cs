using System;
using System.Collections.Generic;
using System.Linq;
using Pethalyse.Gameplay.Equipments.Weapons.Components;
using Pethalyse.Gameplay.ScriptableObjects.Equipments.Weapons;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons
{
    [RequireComponent(typeof(Weapon))]
    public class WeaponGenerator : MonoBehaviour
    {
        [SerializeField] private WeaponSo data;
        private Weapon _weapon;
        private Animator _anim;

        private List<WeaponComponent> _componentsAlreadyOnWeapon = new();
        private readonly List<WeaponComponent> _componentsAddedToWeapon = new();
        private List<Type> _componentDependencies = new();

        private void Awake()
        {
            _weapon = GetComponent<Weapon>();
            _anim = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            GenerateWeapon(data);
        }

        public void GenerateWeapon(WeaponSo dataWeapon)
        {
            _weapon.SetData(dataWeapon);
            
            _componentsAlreadyOnWeapon.Clear(); 
            _componentsAddedToWeapon.Clear();
            _componentDependencies.Clear();

            _componentsAlreadyOnWeapon = GetComponents<WeaponComponent>().ToList();
            _componentDependencies = dataWeapon.GetAllDependencies();

            foreach (var dependency in _componentDependencies)
            {
                if (_componentsAddedToWeapon.FirstOrDefault(component => component.GetType() == dependency))
                    continue;

                var weaponComponent =
                    _componentsAlreadyOnWeapon.FirstOrDefault(component => component.GetType() == dependency);

                if (weaponComponent == null)
                {
                    weaponComponent = gameObject.AddComponent(dependency) as WeaponComponent;
                }

                if (weaponComponent != null)
                {
                    weaponComponent.Init();
                    _componentsAddedToWeapon.Add(weaponComponent);
                }
                else
                {
                    Debug.LogWarning($"Component of type {dependency} failed to be added to {name}");
                }
            }

            var componentsToRemove = _componentsAlreadyOnWeapon.Except(_componentsAddedToWeapon);
            
            foreach (var weaponComponent in componentsToRemove)
            {
                Destroy(weaponComponent);
            }
        }
    }
}