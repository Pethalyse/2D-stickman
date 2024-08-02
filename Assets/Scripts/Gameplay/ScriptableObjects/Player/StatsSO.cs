using UnityEngine;

namespace Pethalyse.Gameplay.ScriptableObjects.Player
{
    [CreateAssetMenu(menuName = "Stats", fileName = "[Stats] ")]
    public class StatsSo : ScriptableObject
    {
        //LES BASES STATS DU PERSONNAGE

        [Header("Life")] 
        public int pv;

        [Header("Damage")] 
        public int force;
        public int power;

        [Header("Resistances")] 
        public int armor;
        public int resistance;

        [Header("Speed")] 
        public int speed = 10;
    }
}