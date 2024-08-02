using System;
using UnityEngine;

namespace Pethalyse.Env
{
    public abstract class OnEnableClass : MonoBehaviour
    {
        private void OnEnable() => Invoke(nameof(Enable), 0.1f);
        protected abstract void Enable();
    }

    public abstract class OnEnableMiseAJour : OnEnableClass
    {
        protected abstract void MiseAJour();
        protected override void Enable() => MiseAJour();
    }
}