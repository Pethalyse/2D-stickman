using UnityEngine;

namespace Pethalyse.Env.Events
{
    public abstract class EventShowDescription : EventMouseOver
    {
        [SerializeField] protected DescriptionObject descriptionObject;
    }
}