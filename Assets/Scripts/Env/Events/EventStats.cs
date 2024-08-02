using System.Collections;
using Pethalyse.Gameplay.Characters;
using Pethalyse.Gameplay.Core.CoreComponents;
using Pethalyse.Gameplay.Enum;
using Pethalyse.Manager;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pethalyse.Env.Events
{
    public class EventStats : EventShowDescription
    {
        private Stats _playerStats;
        [FormerlySerializedAs("stat")] [SerializeField] private EnumStats enumStat;

        private float _width;

        private static EventStats _busy;

        private void Start()
        {
            _playerStats = PlayerManager.Instance.GetPlayer().GetComponent<Stats>();
            StartCoroutine(nameof(GetWidth));
        }

        private IEnumerator GetWidth()
        {
            yield return new WaitForEndOfFrame(); 
            _width = transform.GetComponent<RectTransform> ().sizeDelta.x;
        }

        private void FixedUpdate()
        {
            if (IsMouseOverMe())
            {
                _busy = this;
                var stats = _playerStats.GetStat(enumStat);
                var color = stats.GetBonus() > 0 ? Color.red.ToHexString() : Color.blue.ToHexString();
                var signe = stats.GetBonus() > 0 ? "+" : "";
                var bonus = stats.GetBonus() != 0 ? "<br>" + $"<color=#{color}>{signe}{stats.GetBonus()} </color>" : "";
                var txt =
                    $"{stats.GetValue()}" + bonus;
                descriptionObject.ChangeText(txt);
                descriptionObject.ChangePosition(transform.position + new Vector3(_width * 2 + 15, 0));
                descriptionObject.Active();
            }
            else if(_busy == this)
            {
                descriptionObject.Inactive();
                _busy = null;
            }
                
        }

        private void OnDisable()
        {
            if (_busy != this) return;
            descriptionObject.Inactive();
            _busy = null;
        }
    }
}