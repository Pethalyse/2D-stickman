using Pethalyse.Gameplay.Characters.Player.Inputs;
using Pethalyse.Gameplay.Characters.Player.States.SubStates;
using Pethalyse.Gameplay.Equipments.Weapons;
using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Player.StateMachine
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerInputsHandler))]
    [RequireComponent(typeof(AnimationEventHandler))]
    public class Player : MonoBehaviour
    {
        //Components
        #region Components
        public Core.Core Core { get; private set; }
        public Animator Anim { get; private set; }
        public PlayerInputsHandler InputsHandler { get; private set; }
        public AnimationEventHandler EventHandler { get; private set; }
        #endregion
        
        //Scripts
        #region State Variables
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerAttackState AttackState { get; private set; }
        #endregion

        private Weapon _weapon;

        private RuntimeAnimatorController _playerAnimatorController;
        
        #region Unity CallBack Functions

        private void Awake()
        {
            //Components
            Anim = GetComponent<Animator>();
            InputsHandler = GetComponent<PlayerInputsHandler>();
            Core = GetComponentInChildren<Core.Core>();
            EventHandler = GetComponent<AnimationEventHandler>();

            _weapon = transform.GetComponentInChildren<Weapon>();
            _weapon.SetCore(Core);
            
            //Scripts
            StateMachine = new PlayerStateMachine();
            //States
            IdleState = new PlayerIdleState(this, "idle");
            MoveState = new PlayerMoveState(this, "move");
            AttackState = new PlayerAttackState(this, "attack", _weapon);

            _playerAnimatorController = Anim.runtimeAnimatorController;
        }

        private void Start()
        {
            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            Core.LogicUpdate();
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }

        #endregion
        
        public void ChangePlayerAnimator(RuntimeAnimatorController newAnim)
        {
            Anim.runtimeAnimatorController = newAnim;
        }
        
        public void ResetPlayerAnimator()
        {
            ChangePlayerAnimator(_playerAnimatorController);
        }
        
    }
}