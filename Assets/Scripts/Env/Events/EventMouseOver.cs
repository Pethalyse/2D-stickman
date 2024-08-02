using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Pethalyse.Env.Events
{
    public abstract class EventMouseOver : MonoBehaviour
    {
        protected bool IsMouseOverMe()
        {
            var pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = Mouse.current.position.value
            };

            var raycastResultList = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
            for (var i = 0; i < raycastResultList.Count; i++)
            {
                if (raycastResultList[i].gameObject.GetComponent<EventMouseOver>() == this) continue;
                raycastResultList.RemoveAt(i);
                i--;
            }

            return raycastResultList.Count > 0;
        }
    }
}