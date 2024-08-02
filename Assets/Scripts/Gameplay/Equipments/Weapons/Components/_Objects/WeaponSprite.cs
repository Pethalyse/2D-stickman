using System;
using System.Linq;
using Pethalyse.Gameplay.Enum;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components
{
    public class WeaponSprite : WeaponComponent<WeaponSpriteData, AttackSprites>
    {
        // private SpriteRenderer _baseSpriteRenderer;
        // private SpriteRenderer _weaponSpriteRenderer;
        
        // private int _currentWeaponSpriteIndex;

        protected override void Start()
        {
            base.Start();
            
            // _weaponSpriteRenderer = Weapon.WeaponSpriteGameObject.GetComponent<SpriteRenderer>();
            
            EventHandler.OnEnterAttackPhase += HandleEnterAttackPhase;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            EventHandler.OnEnterAttackPhase -= HandleEnterAttackPhase;
        }

        private void HandleEnterAttackPhase(EnumAttackPhases phase)
        {
            // _currentWeaponSpriteIndex = 0;
            
        }

        // private void HandleBaseSpriteChange(SpriteRenderer sr)
        // {
        //     if (!IsAttackActive)
        //     {
        //         _weaponSpriteRenderer.sprite = null;
        //         return;
        //     }
        //
        //     if (_currentWeaponSpriteIndex >= _currentPhaseSprites.Length)
        //     {
        //         Debug.LogWarning($"{Weapon.name} weapon sprites length mismatch");
        //         return;
        //     }
        //     
        //     _weaponSpriteRenderer.sprite =
        //         _currentPhaseSprites[_currentWeaponSpriteIndex];
        //     _currentWeaponSpriteIndex++;
        // }

        protected override void HandleEnter()
        {
            base.HandleEnter();
            // _currentWeaponSpriteIndex = 0;
        } 
    }
    
}