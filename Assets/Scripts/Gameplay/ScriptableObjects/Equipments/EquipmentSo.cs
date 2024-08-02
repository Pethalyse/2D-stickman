using Pethalyse.Gameplay.Enum;
using Pethalyse.Gameplay.Serializable;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pethalyse.Gameplay.ScriptableObjects.Equipments
{
    public abstract class EquipmentSo : ScriptableObject
    {
        [field : Header("Descriptions")] 
        [field: SerializeField] public string EquipmentName { get; private set; }
        [field: SerializeField] public string EquipmentDescription { get; private set; }
        [field: SerializeField] public EnumRarity EnumRarity { get; private set; }

        [field : Header("Visual")] 
        [field: SerializeField] public RuntimeAnimatorController AnimatorController { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        
        [field : Header("Stats")] 
        [field: SerializeField] public ListSerializableStats<SerializableStats> SerializableStatsAffect { get; private set; }

        public void AddStats(EnumStats stat)
        {
            SerializableStatsAffect.Add(new SerializableStats(stat));
        }
        
        public void RemoveStats(EnumStats stat)
        {
            SerializableStatsAffect.Remove(stat);
        }
            
    }
}