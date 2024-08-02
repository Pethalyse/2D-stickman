using System.Collections.Generic;
using System.Linq;
using Pethalyse.Gameplay.Core.CoreComponents;
using UnityEngine;

namespace Pethalyse.Gameplay.Core
{
    public class Core : MonoBehaviour
    {
        private readonly List<CoreComponent> _coreComponents = new();

        public void LogicUpdate()
        {
            _coreComponents.ForEach(c => c.LogicUpdate());
        }

        public void AddComponent(CoreComponent component)
        {
            if(!_coreComponents.Contains(component))
                _coreComponents.Add(component);
        }

        private T GetCoreComponent<T>() where T : CoreComponent
        {
            var comp = _coreComponents.OfType<T>().FirstOrDefault();

            if (comp == null)
            {
                Debug.LogWarning($"{typeof(T)} not found on {transform.parent.name}");
            }

            return comp;
        }

        public T GetCoreComponent<T>(ref T value) where T : CoreComponent
        {
            value = GetCoreComponent<T>();
            return value;
        }

    }
}