using System;
using Pethalyse.Gameplay.Core;
using Pethalyse.Gameplay.Core.CoreComponents;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components
{
    public class ActionHitBox : WeaponComponent<WeaponActionHitBoxData, AttackActionHitBox>
    {
        public event Action<Collider2D[]> OnDetectedCollider2D;
        
        private CoreComp<Movement> _movement;
        
        private Vector2 _offset;

        private Collider2D[] _detected;
        
        protected override void Start()
        {
            base.Start();
            EventHandler.OnAttackAction += HandleAttackAction;

            _movement = new CoreComp<Movement>(Core);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            EventHandler.OnAttackAction -= HandleAttackAction;
        }
        
        private void HandleAttackAction()
        {
            //TODO : INIT OFFSET WITH PLAYER LOOKING MOUSE
            // _offset.Set(
            //   transform.position.x + CurrentAttackData.HitBox.x * _movement.Comp.FacingDirection,
            //   transform.position.y + CurrentAttackData.HitBox.y
            // );
            var filter = new ContactFilter2D
            {
                layerMask = Data.AttackData[Weapon.CurrentWeaponAttackIndex].DetectableLayers
            };
            Physics2D.OverlapBox(_offset, CurrentAttackData.HitBox.size, 0f,
                filter, _detected);

            if (_detected.Length == 0) return;
            
            OnDetectedCollider2D?.Invoke(_detected);
        }

        private void OnDrawGizmosSelected()
        {
            if (Data == null) return;

            foreach (var item in Data.AttackData)
            {
                if (!item.debug) continue;
                Gizmos.DrawWireCube(transform.position + (Vector3)item.HitBox.center, item.HitBox.size);
            }
        }
    }
}