using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pethalyse.Gameplay.Enum;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pethalyse.Gameplay.Serializable
{
    [Serializable]
    public class SerializableStats
    {
        [SerializeField, HideInInspector] private string n;
        [SerializeField, HideInInspector] private EnumStats enumStat;
        [SerializeField] private int value;
        public delegate void OnValueChangedDelegate(EnumStats enumStat);
        public event OnValueChangedDelegate OnValueChanged;
        
        public SerializableStats(EnumStats enumStat, int value = 0)
        {
            this.enumStat = enumStat;
            this.value = value;
            ChangeName();
        }

        public EnumStats GetStat() => enumStat;
        public int GetValue() => value;
        public void SetValue(int val)
        {
            value = val;
            InvokeValueChanged();
        }
        protected void InvokeValueChanged() => OnValueChanged?.Invoke(enumStat);

        public void ChangeName() => n = enumStat.ToString();
    }

    [Serializable]
    public class SerializableStatsBonus : SerializableStats
    {
        private int _bonus;
        private int Bonus
        {
            get => _bonus;
            set
            {
                _bonus = value;
                InvokeValueChanged();
            }
        }
        public SerializableStatsBonus(EnumStats enumStat, int value = 0) : base(enumStat, value){}
        public int GetBonus() => Bonus;
        public void AddBonus(int bonus) => Bonus += bonus;
        public void RemoveBonus(int bonus) => Bonus -= bonus;
        public int GetValueWithBonus() => GetValue() + Bonus;
    }

    /// <summary>
    ///     A list of objects composed of <see cref="SerializableStats"/>,
    ///     each object in the list must be of unique type
    /// </summary>
    /// <typeparam name="T"> where T : StatsSerializable </typeparam>
    [Serializable]
    public class ListSerializableStats<T> : IEnumerable<T>, ISerializationCallbackReceiver where T : SerializableStats
    {
        [FormerlySerializedAs("Stats")] [FormerlySerializedAs("items")] [SerializeField] private List<T> stats = new();

        /// <summary>
        ///     The "Add" method adds the element to the class list, however it checks if there already exists an object
        ///     in the list with the same type as the one we want to add, if yes then the method throw an Exception
        /// </summary>
        /// <param name="item"><see cref="T"/></param>
        /// <exception cref="Exception">Error, ListStats can't have items with same type</exception>
        public void Add(T item)
        {
            if (stats.Any(stat => stat.GetStat() == item.GetStat()))
            {
                throw new Exception("ListStats can't have items with same type");
            }
            
            stats.Add(item);
        }

        /// <summary>
        ///     The "Get" method returns the first element of the class list having the same type as the parameter,
        ///     otherwise if there is none it returns a null value
        /// </summary>
        /// <param name="type"><see cref="EnumStats"/></param>
        /// <returns> <see cref="T"/>, <see cref="Null"/></returns>
        public T Get(EnumStats type)
        {
            return stats.FirstOrDefault(stat => stat.GetStat() == type);
        }
        
        public void Clear()
        {
            stats.Clear();
        }

        public bool Contains(T item)
        {
            return stats.Contains(item);
        }

        public void Remove(EnumStats stat)
        {
            stats.Remove(stats.FirstOrDefault(item => item.GetStat() == stat));
        }

        public int Count => stats.Count;

        public T this[EnumStats type]
        {
            get => Get(type);
            set => stats[stats.IndexOf(Get(type))] = value; 
        }
        
        public void ForEach(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (var item in stats)
            {
                action(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return stats.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void OnBeforeSerialize()
        {
            if (stats.Any(stat => Get(stat.GetStat()) != stat))
            {
                throw new Exception("ListStats can't have items with same type");
            }
        }

        public void OnAfterDeserialize()
        {
            
        }
    }
}