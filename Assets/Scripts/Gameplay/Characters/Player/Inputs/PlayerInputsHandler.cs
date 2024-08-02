using Pethalyse.Gameplay.Enum;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pethalyse.Gameplay.Characters.Player.Inputs
{
    public class PlayerInputsHandler : MonoBehaviour
    {
        #region Move Variables
        public Vector2 RawMovementInput { get; private set; }
        public int NormInputX { get; private set; }
        public int NormInputY { get; private set; }
        #endregion

        #region Attack Variables

        public bool AttackInputs { get; private set; }

        #endregion
        
        public void OnMoveInput(InputAction.CallbackContext context)
        {
            RawMovementInput = context.ReadValue<Vector2>();
            
            NormInputX = Mathf.RoundToInt(RawMovementInput.x);
            NormInputY = Mathf.RoundToInt(RawMovementInput.y);
        }

        public void OnAttackInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AttackInputs = true;
            }

            if (context.canceled)
            {
                AttackInputs = false;
            }
        }
        
    }
}