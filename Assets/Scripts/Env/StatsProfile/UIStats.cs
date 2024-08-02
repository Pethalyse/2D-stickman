using System;
using Pethalyse.Gameplay.Core.CoreComponents;
using Pethalyse.Gameplay.Enum;
using Pethalyse.Manager;
using TMPro;
using UnityEngine;

namespace Pethalyse.Env.StatsProfile
{
    public class UIStats : OnEnableMiseAJour
    {
        private Stats _playerStats;
        
        [Header("Stats Name Text")] 
        [SerializeField] private TextMeshProUGUI pvTxt;
        [SerializeField] private TextMeshProUGUI forceTxt;
        [SerializeField] private TextMeshProUGUI powerTxt;
        [SerializeField] private TextMeshProUGUI armorTxt;
        [SerializeField] private TextMeshProUGUI resistanceTxt;
        [SerializeField] private TextMeshProUGUI critChanceTxt;
        [SerializeField] private TextMeshProUGUI critDamageTxt;
        
        [Header("Stats Value Text")] 
        [SerializeField] private TextMeshProUGUI pvVal;
        [SerializeField] private TextMeshProUGUI forceVal;
        [SerializeField] private TextMeshProUGUI powerVal;
        [SerializeField] private TextMeshProUGUI armorVal;
        [SerializeField] private TextMeshProUGUI resistanceVal;
        [SerializeField] private TextMeshProUGUI critChanceVal;
        [SerializeField] private TextMeshProUGUI critDamageVal;

        private void Awake()
        {
            _playerStats = PlayerManager.Instance.GetPlayer().GetComponent<Stats>();
            
            pvTxt.text = "Vie";
            forceTxt.text = "Force";
            powerTxt.text = "Puissance";
            armorTxt.text = "Armure";
            resistanceTxt.text = "Résistance";
            critChanceTxt.text = "Chance de coup critique";
            critDamageTxt.text = "Dégats critique";
        }

        protected override void Enable()
        {
            base.Enable();
            _playerStats.GetStat(EnumStats.Pv).OnValueChanged += OnStatsValueChanged;
            _playerStats.GetStat(EnumStats.Force).OnValueChanged += OnStatsValueChanged;
            _playerStats.GetStat(EnumStats.Power).OnValueChanged += OnStatsValueChanged;
            _playerStats.GetStat(EnumStats.Armor).OnValueChanged += OnStatsValueChanged;
            _playerStats.GetStat(EnumStats.Resistance).OnValueChanged += OnStatsValueChanged;
            _playerStats.GetStat(EnumStats.CriticalChance).OnValueChanged += OnStatsValueChanged;
        }

        private void OnDisable()
        {
            _playerStats.GetStat(EnumStats.Pv).OnValueChanged -= OnStatsValueChanged;
            _playerStats.GetStat(EnumStats.Force).OnValueChanged -= OnStatsValueChanged;
            _playerStats.GetStat(EnumStats.Power).OnValueChanged -= OnStatsValueChanged;
            _playerStats.GetStat(EnumStats.Armor).OnValueChanged -= OnStatsValueChanged;
            _playerStats.GetStat(EnumStats.Resistance).OnValueChanged -= OnStatsValueChanged;
            _playerStats.GetStat(EnumStats.CriticalChance).OnValueChanged -= OnStatsValueChanged;
            _playerStats.GetStat(EnumStats.CriticalDamage).OnValueChanged -= OnStatsValueChanged;
        }
        

        private void OnStatsValueChanged(EnumStats enumStat)
        {
            //Debug.Log($"Invoke : {stat} : {_playerStatsComponent.GetStat(stat).GetValueWithBonus()}");
            switch (enumStat)
            {
                case EnumStats.Pv:
                    ChangerValText(pvVal, EnumStats.Pv);
                    break;
                case EnumStats.Force:
                    ChangerValText(forceVal, EnumStats.Force);
                    break;
                case EnumStats.Power:
                    ChangerValText(powerVal, EnumStats.Power);
                    break;
                case EnumStats.Armor:
                    ChangerValText(armorVal, EnumStats.Armor);
                    break;
                case EnumStats.Resistance:
                    ChangerValText(resistanceVal, EnumStats.Resistance);
                    break;
                case EnumStats.CriticalChance:
                    ChangerValText(critChanceVal, EnumStats.CriticalChance);
                    break;
                case EnumStats.CriticalDamage:
                    ChangerValText(critDamageVal, EnumStats.CriticalDamage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enumStat), enumStat, null);
            }
        }
        
        private void ChangerValText(TMP_Text txt, EnumStats enumStat)
        {
            var stats = _playerStats.GetStat(enumStat);
            txt.color = stats.GetBonus() > 0 ? Color.red : stats.GetBonus() < 0 ? Color.blue : Color.black;
            txt.text =  $"{stats.GetValueWithBonus()}";
        }

        protected override void MiseAJour()
        {
            OnStatsValueChanged(EnumStats.Pv);
            OnStatsValueChanged(EnumStats.Force);
            OnStatsValueChanged(EnumStats.Power);
            OnStatsValueChanged(EnumStats.Armor);
            OnStatsValueChanged(EnumStats.Resistance);
            OnStatsValueChanged(EnumStats.CriticalDamage);
            OnStatsValueChanged(EnumStats.CriticalChance);
        }
    }
}