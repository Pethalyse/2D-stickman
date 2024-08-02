using System;
using Pethalyse.Gameplay.Characters;
using Pethalyse.Gameplay.Enum;
using Pethalyse.Gameplay.ScriptableObjects.Player;
using Pethalyse.Gameplay.Serializable;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pethalyse.Gameplay.Core.CoreComponents
{
    public class Stats : CoreComponent
    {
        private CoreComp<Experience> _experience;
        
        [SerializeField] private StatsSo baseStats;
        
        private readonly ListSerializableStats<SerializableStatsBonus> _listSerializableStats = new()
        {
            new SerializableStatsBonus(EnumStats.Pv),
            new SerializableStatsBonus(EnumStats.Force),
            new SerializableStatsBonus(EnumStats.Power),
            new SerializableStatsBonus(EnumStats.Armor),
            new SerializableStatsBonus(EnumStats.Resistance),
            new SerializableStatsBonus(EnumStats.CriticalChance),
            new SerializableStatsBonus(EnumStats.CriticalDamage),
            new SerializableStatsBonus(EnumStats.Speed)
        };
        
        private int _currentCurrentLife;
        private int CurrentLife
        {
            get => _currentCurrentLife;
            set
            {
                _currentCurrentLife = value;
                OnLifeChanged?.Invoke(_listSerializableStats[EnumStats.Pv].GetValueWithBonus(),_currentCurrentLife);
            }
        }
        public delegate void OnLifeChangedDelegate(int lifeMax,int life);
        public event OnLifeChangedDelegate OnLifeChanged;

        protected override void Awake()
        {
            base.Awake();
            _experience = new CoreComp<Experience>(Core);
        }

        private void OnEnable()
        {
            Invoke(nameof(Enable), 0.1f);
        }
        
        private void Enable()
        {
            _experience.Comp.OnLevelChanged += OnLevelChangedSetNewStats;
        }

        private void OnDisable()
        {
            _experience.Comp.OnLevelChanged -= OnLevelChangedSetNewStats;
        }

        private void Start()
        {
            _listSerializableStats[EnumStats.CriticalChance].SetValue(0);
            _listSerializableStats[EnumStats.CriticalDamage].SetValue(150);
            _listSerializableStats[EnumStats.Speed].SetValue(baseStats.speed);
        }
        
        private void OnLevelChangedSetNewStats(int level)
        {
            _listSerializableStats[EnumStats.Pv].SetValue(2 * baseStats.pv * level / 100 + level + 10);
            _listSerializableStats[EnumStats.Force].SetValue(2 * baseStats.force * level / 100 + 5);
            _listSerializableStats[EnumStats.Power].SetValue(2 * baseStats.power * level / 100 + 5);
            _listSerializableStats[EnumStats.Armor].SetValue(2 * baseStats.armor * level / 100 + 5);
            _listSerializableStats[EnumStats.Resistance].SetValue(2 * baseStats.resistance * level / 100 + 5);
        }

        private int GetDamageByType(EnumDamageType type)
        {
            return type switch
            {
                EnumDamageType.Physic => GetStat(EnumStats.Force).GetValueWithBonus(),
                EnumDamageType.Magic => GetStat(EnumStats.Power).GetValueWithBonus(),
                _ => 0
            };
        }
        
        private int GetResistanceByType(EnumDamageType type)
        {
            return type switch
            {
                EnumDamageType.Physic => GetStat(EnumStats.Armor).GetValueWithBonus(),
                EnumDamageType.Magic => GetStat(EnumStats.Resistance).GetValueWithBonus(),
                _ => 0
            };
        }
        
        public void AddBonus(SerializableStats serializableStat) => _listSerializableStats[serializableStat.GetStat()].AddBonus(serializableStat.GetValue());
        public void RemoveBonus(SerializableStats serializableStat) => _listSerializableStats[serializableStat.GetStat()].RemoveBonus(serializableStat.GetValue());
        public SerializableStatsBonus GetStat(EnumStats enumStat) => _listSerializableStats[enumStat];

        public void ReduceHealth(int amount)
        {
            CurrentLife -= amount;

            if (CurrentLife > 0) return;
            CurrentLife = 0;
            Debug.Log("Player Dead");
        }
        
        public void IncreaseHealth(int amount)
        {
            CurrentLife = Math.Clamp(_currentCurrentLife + amount, 0, GetStat(EnumStats.Pv).GetValueWithBonus());
        }

        public int CalculateDamage(EnumDamageType damageType, int percent)
        {
            //TODO: Algo for calculate the damage deal by a type *percent
            return 0;
        }

        public int CalculateReduction(EnumDamageType damageType, int amount)
        {
            //TODO: Algo for calculate the damage after reduction
            return 0;
        }
    }
}