using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components
{
    [RequireComponent(typeof(Weapon))]
    public abstract class WeaponComponent : MonoBehaviour
    {
        protected Weapon Weapon;

        protected AnimationEventHandler EventHandler;
        protected Core.Core Core => Weapon.Core;

        protected bool IsAttackActive;

        protected virtual void Awake()
        {
            Weapon = GetComponent<Weapon>();
        }

        protected virtual void Start()
        {
            EventHandler = Weapon.EventHandler;
            Weapon.OnEnter += HandleEnter;
            Weapon.OnExit += HandleExit;
        }

        protected virtual void HandleEnter()
        {
            IsAttackActive = true;
        }

        protected virtual void HandleExit()
        {
            IsAttackActive = false;
        }
        
        protected virtual void OnDestroy()
        {
            Weapon.OnEnter -= HandleEnter;
            Weapon.OnExit -= HandleExit;
        }
        
        public virtual void Init(){}
    }

    public abstract class WeaponComponent<T1, T2> : WeaponComponent where T1 : WeaponComponentData<T2> where T2 : AttackData
    {
        protected T1 Data;
        protected T2 CurrentAttackData;

        public override void Init()
        {
            base.Init();

            Data = Weapon.Data.GetData<T1>();
        }

        protected override void HandleEnter()
        {
            base.HandleEnter();

            CurrentAttackData = Data.AttackData[Weapon.CurrentWeaponAttackIndex];
        }
    }
}