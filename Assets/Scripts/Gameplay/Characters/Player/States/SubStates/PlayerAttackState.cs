using Pethalyse.Gameplay.Characters.Player.States.SuperStates;
using Pethalyse.Gameplay.Enum;
using Pethalyse.Gameplay.Equipments.Weapons;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Player.States.SubStates
{
    public class PlayerAttackState : PlayerAbilityState
    {
        private readonly Weapon _weapon;
        public PlayerAttackState(StateMachine.Player player, string animBoolName, Weapon weapon) : base(player, animBoolName)
        {
            _weapon = weapon;
            _weapon.SetEventHandler(Player.EventHandler);
            _weapon.OnExit += ExitHandler;
        }
        
        public override void Enter()
        {
            Player.ChangePlayerAnimator(_weapon.Data.AnimatorController);
            Player.Anim.SetInteger("index", _weapon.CurrentWeaponAttackIndex);
            base.Enter();
            _weapon.Enter();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            _weapon.CurrenInput = Player.InputsHandler.AttackInputs;
        }

        private void ExitHandler()
        {
            Player.ResetPlayerAnimator();
            AnimationFinishTrigger();
            IsAbilityDone = true;
        }
        
    }
}