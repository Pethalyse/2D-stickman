using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData;
using Pethalyse.Gameplay.Equipments.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons.Components
{
    public class InputHold : WeaponComponent<WeaponInputHoldData, AttackInputHold>
    {
        private Animator _anim;

        private bool _input;
        
        protected override void Awake()
        {
            base.Awake();

            _anim = GetComponentInChildren<Animator>();

            Weapon.OnCurrentInputChange += HandleCurrentInputChange;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Weapon.OnCurrentInputChange -= HandleCurrentInputChange;

        }

        private void SetAnimatorParameter()
        {
            _anim.SetBool("hold", _input);
        }

        private void HandleCurrentInputChange(bool newInput)
        {
            _input = newInput;
            SetAnimatorParameter();
        }

    }
}