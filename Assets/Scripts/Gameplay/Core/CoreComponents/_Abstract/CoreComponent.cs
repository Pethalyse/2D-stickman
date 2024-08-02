using System;
using Pethalyse.Gameplay.Interfaces;
using UnityEngine;

namespace Pethalyse.Gameplay.Core.CoreComponents
{
    public abstract class CoreComponent : MonoBehaviour, ILogicUpdate
    {
        protected Core Core;

        protected virtual void Awake()
        {
            Core = transform.GetComponentInParent<Core>();
            if(!Core) {Debug.LogError("There is no Core on the parent");}
            
            Core.AddComponent(this);
        }

        public virtual void LogicUpdate()
        {
            
        }
    }
}