using UnityEngine;

namespace Pethalyse.Gameplay.Core.CoreComponents
{
    public class Experience : CoreComponent
    {
        [Header("Level")] 
        private int _level; 
        private int Level
        {
            get => _level;
            set
            {
                _level = value;
                OnLevelChanged?.Invoke(_level);
            }
        }
        public delegate void OnLevelChangedDelegate(int level);
        public event OnLevelChangedDelegate OnLevelChanged;
        private const int MaxLevel = 100;

        [Header("XP")] 
        private float _currentXp;
        private float CurrentXp
        {
            get => _currentXp;
            set
            {
                _currentXp = value;
                OnXpChanged?.Invoke(_currentXp, _xpBeforeNextLevel);
            }
        }
        private float _xpBeforeNextLevel;
        public delegate void OnXpChangedDelegate(float current, float next);
        public event OnXpChangedDelegate OnXpChanged;

        private void Start()
        {
            LevelUp(1);
        }
        
        private void LevelUp(int level)
        {
            if (Level >= MaxLevel) return;
            Level = level;
            SetXpBeforeLevel();
        }

        private void GainXp(int naturalXpInt, int levelDefeatedInt)
        {
            if (Level >= MaxLevel) return;
            var naturalXp = (float)naturalXpInt;
            var levelDefeated = (float)levelDefeatedInt;
            CurrentXp += naturalXp * levelDefeated / 5* Mathf.Pow((2 * levelDefeated + 10) / (levelDefeated + Level + 10), 2.5f) + 1;

            if (CurrentXp >= _xpBeforeNextLevel)
            {
                LevelUp(Level+1);
            }
        }

        private void SetXpBeforeLevel()
        {
            if (Level >= MaxLevel) return;
            _xpBeforeNextLevel = Mathf.Pow(Level+1, 3);
        }
    }
}