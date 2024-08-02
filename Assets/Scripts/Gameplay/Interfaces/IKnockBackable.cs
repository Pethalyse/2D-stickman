using UnityEngine;

namespace Pethalyse.Gameplay.Interfaces
{
    public interface IKnockBackable 
    {
        void KnockBack(Vector2 angle, float strength, int direction);
    }
}
