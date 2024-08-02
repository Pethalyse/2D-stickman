using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components
{
    public abstract class WeaponDetectedCollider<T1, T2> : WeaponComponent<T1, T2> where T1 : WeaponComponentData<T2> where T2 : AttackActive
    {
        private ActionHitBox _hitBox;

        protected override void Awake()
        {
            base.Awake();

            _hitBox = GetComponent<ActionHitBox>();
            if(!_hitBox) Debug.LogWarning($"Action Hit Box component not in {transform.name} and it's needed for the component {typeof(T1)}");
        }
        
        protected override void Start()
        {
            base.Start();

            _hitBox.OnDetectedCollider2D += HandleDetectedCollider2D;
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();

            _hitBox.OnDetectedCollider2D -= HandleDetectedCollider2D;
        }

        protected virtual void HandleDetectedCollider2D(Collider2D[] colliders)
        {
            if(CurrentAttackData.Inactive) return;
        }
    }
}