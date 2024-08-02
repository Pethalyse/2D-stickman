﻿using UnityEngine;

namespace Pethalyse.Gameplay.Characters.Enemy.States.Data
{
    [CreateAssetMenu(fileName = "[EnemyStun] ", menuName = "Entity/State Data/Stun State")]
    public class DStunState : ScriptableObject
    {
        public float stunTime = 3f;

        public float stunKnockbackTime = 0.2f;
        public float stunKnockbackSpeed = 20f;
        public Vector2 stunKnockbackAngle;
    }
}
