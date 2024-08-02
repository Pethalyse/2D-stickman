using System;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData
{
    [Serializable]
    public abstract class WeaponComponentData
    {
        [SerializeField, HideInInspector] private string n;
        public Type ComponentDependency { get; protected set; }

        protected WeaponComponentData()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            SetComponentDependency();
            ChangeName();
        }

        protected abstract void SetComponentDependency();
        
        public void ChangeName() => n = GetType().Name;
        public abstract void SetAttackDataNames();
        public abstract void InitializeAttackData(int i);
    }

    [Serializable]
    public abstract class WeaponComponentData<T> : WeaponComponentData where T : AttackData.AttackData
    {
        [SerializeField] private T[] attackData;
        public T[] AttackData { get => attackData; private set => attackData = value; }

        public override void SetAttackDataNames()
        {
            for (var i = 0; i < AttackData.Length; i++)
            {
                AttackData[i].SetAttackName(i + 1);
            }
        }

        public override void InitializeAttackData(int i)
        {
            var oldLen = AttackData?.Length ?? 0;
            
            if(oldLen == i)
                return;
            
            Array.Resize(ref attackData, i);

            if (oldLen < i)
            {
                for (var l = oldLen; l < attackData.Length; l++)
                {
                    var newObj = Activator.CreateInstance(typeof(T)) as T;
                    attackData[l] = newObj;
                }
            }
            
            SetAttackDataNames();
        }
    }
}