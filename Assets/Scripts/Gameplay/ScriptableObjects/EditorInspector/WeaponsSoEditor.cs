using System;
using System.Collections.Generic;
using System.Linq;
using Pethalyse.Gameplay.Enum;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData;
using Pethalyse.Gameplay.ScriptableObjects.Equipments.Weapons;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Pethalyse.Gameplay.ScriptableObjects.EditorInspector
{
    [CustomEditor(typeof(WeaponSo), true)]
    [CanEditMultipleObjects]
    public class WeaponsSoEditor : EquipmentSoEditor
    {
        private static List<Type> _allComponents = new();

        private WeaponSo _dataWeaponSo;
        
        private bool _showAddComponentsButtons;
        private bool _showForceWeaponButtons;
        private bool _showRemoveComponentsButtons;

        protected override void OnEnable()
        {
            base.OnEnable();
            _dataWeaponSo = target as WeaponSo;
        }
        
        public override void OnInspectorGUI()
        {
            _showAddComponentsButtons = EditorGUILayout.Foldout(_showAddComponentsButtons, "Add Component");
            if (_showAddComponentsButtons)
            {
                foreach (var e in _allComponents.Where(e => _dataWeaponSo.ComponentDataList.TrueForAll(c => c.GetType() != e)).Where(e => GUILayout.Button(e.Name)))
                {
                    if(Activator.CreateInstance(e) is not WeaponComponentData comp)
                        return;
                    
                    comp.InitializeAttackData(_dataWeaponSo.NumberOfAttacks);
                    _dataWeaponSo.AddComponent(comp);
                    
                    EditorUtility.SetDirty(_dataWeaponSo);
                }
            }
            
            base.OnInspectorGUI();
            
            _showForceWeaponButtons = EditorGUILayout.Foldout(_showForceWeaponButtons, "Force Component actions");
            if (_showForceWeaponButtons)
            {
                if (GUILayout.Button("Set Number of Attacks"))
                {
                    _dataWeaponSo.InitializeAttackData();
                }
                if (GUILayout.Button("Force Components Names Update"))
                {
                    _dataWeaponSo.SetComponentsName();
                }
                if (GUILayout.Button("Force Attacks Names Update"))
                {
                    _dataWeaponSo.SetAttacksName();
                }
            }
            
            _showRemoveComponentsButtons = EditorGUILayout.Foldout(_showRemoveComponentsButtons, "Remove Component");
            if (!_showRemoveComponentsButtons) return;
            {
                foreach (var e in _allComponents.Where(e => _dataWeaponSo.ComponentDataList.Exists(c => c.GetType() == e)).Where(e => GUILayout.Button(e.Name)))
                {
                    _dataWeaponSo.RemoveComponent(e);
                }
            }

        }
        
        [DidReloadScripts]
        private static void OnRecompileWeapons()
        {   
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(assembly => assembly.GetTypes());
            var filteredTypes = types.Where(
                type => type.IsSubclassOf(typeof(WeaponComponentData)) && !type.ContainsGenericParameters && type.IsClass
            );
            _allComponents = filteredTypes.ToList();
        }
    }
}