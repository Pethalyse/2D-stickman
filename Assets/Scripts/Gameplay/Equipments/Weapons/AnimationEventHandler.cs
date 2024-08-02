using System;
using Pethalyse.Gameplay.Enum;
using Unity.VisualScripting;
using UnityEngine;

namespace Pethalyse.Gameplay.Equipments.Weapons
{
    public class AnimationEventHandler : MonoBehaviour
    {
        public event Action OnFinish; 
        private void AnimationFinishTrigger() => OnFinish?.Invoke();

        public event Action OnAttackAction;
        private void OnAttackActionTrigger() => OnAttackAction?.Invoke();

        public event Action<EnumAttackPhases> OnEnterAttackPhase;
        private void OnEnterAttackPhaseTrigger(EnumAttackPhases phase) => OnEnterAttackPhase?.Invoke(phase);
    }
}