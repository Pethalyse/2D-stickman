using UnityEngine;
using UnityEngine.InputSystem;

namespace Pethalyse.Env.Inputs
{
    public class UIInputsHandler : MonoBehaviour
    {
        public bool StatsProfileInput { get; private set; }

        public void OnStatsProfileInput(InputAction.CallbackContext context)
        {
            Debug.Log(StatsProfileInput);
            if (context.started)
                StatsProfileInput = !StatsProfileInput;
        }
    }
}