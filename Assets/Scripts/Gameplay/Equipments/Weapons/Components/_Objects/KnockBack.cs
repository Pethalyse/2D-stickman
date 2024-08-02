using Pethalyse.Gameplay.Core;
using Pethalyse.Gameplay.Core.CoreComponents;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;
using Pethalyse.Gameplay.Interfaces;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components
{
    public class KnockBack : WeaponComponent<WeaponKnockBackData, AttackKnockBack>
    {
        private ActionHitBox _hitBox;

        private CoreComp<Movement> _movement;
        
        
        protected override void Start()
        {
            base.Start();

            _hitBox = GetComponent<ActionHitBox>();

            _hitBox.OnDetectedCollider2D += HandleDetectCollider2D;

            _movement = new CoreComp<Movement>(Core);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            _hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;
        }
        
        private void HandleDetectCollider2D(Collider2D[] colliders)
        {
            foreach (var item in colliders)
            {
                if (item.TryGetComponent(out IKnockBackable knockBackable))
                {
                    knockBackable.KnockBack(CurrentAttackData.Angle, CurrentAttackData.Strength, _movement.Comp.FacingDirection);
                }
            }
        }
    }
}
