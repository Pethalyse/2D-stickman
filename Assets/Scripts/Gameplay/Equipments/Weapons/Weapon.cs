using System;
using Pethalyse.Gameplay.Characters.Player.States.SubStates;
using Pethalyse.Gameplay.ScriptableObjects.Equipments.Weapons;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pethalyse.Gameplay.Equipments.Weapons
{
    public class Weapon : MonoBehaviour
    {
        public WeaponSo Data { get; private set; }
        // public GameObject BaseGameObject { get; private set; }
        public GameObject WeaponSpriteGameObject { get; private set; }
        
        protected PlayerAttackState State;

        public AnimationEventHandler EventHandler { get; private set; }
        
        public int CurrentWeaponAttackIndex
        {
            get => _currentWeaponAttackIndex; 
            private set => _currentWeaponAttackIndex = value >= Data.NumberOfAttacks ? 0 : value;
        }
        private int _currentWeaponAttackIndex;

        private bool _currentInput;
        public bool CurrenInput
        {
            get => _currentInput;
            set
            {
                if (_currentInput == value) return;
                _currentInput = value;
                OnCurrentInputChange?.Invoke(_currentInput);
            }
        }

        public event Action<bool> OnCurrentInputChange;

        public event Action OnEnter;
        public event Action OnExit;
        
        public Core.Core Core { get; private set; }
        
        private void Awake()
        {
            // BaseGameObject = transform.Find("Base").gameObject;
            WeaponSpriteGameObject = transform.Find("WeaponSprite").gameObject;
        }

        public virtual void Enter()
        {
            OnEnter?.Invoke();
        }

        public virtual void Exit()
        {
            OnExit?.Invoke();
        }

        private void Start()
        {
            EventHandler.OnFinish += Exit;
        }

        private void OnDestroy()
        {
            EventHandler.OnFinish -= Exit;
        }
        
        public void SetData(WeaponSo data) => Data = data;
        public void SetCore(Core.Core core) => Core = core;

        public void ChangeAttackIndex(int i) => CurrentWeaponAttackIndex = i;

        public void SetEventHandler(AnimationEventHandler eventHandler) => EventHandler = eventHandler;
    }
}