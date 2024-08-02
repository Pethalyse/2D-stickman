using System.Collections.Generic;
using System.Linq;
using Pethalyse.Gameplay.Enum;
using Pethalyse.Gameplay.ScriptableObjects.Equipments;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Pethalyse.Gameplay.ScriptableObjects.EditorInspector
{
    [CustomEditor(typeof(EquipmentSo), true)]
    [CanEditMultipleObjects]
    public class EquipmentSoEditor : Editor
    {
        private static readonly List<object> AllStats = new();

        private EquipmentSo _dataSo;

        private bool _showAddStatsButtons;
        private bool _showForceButtons;
        private bool _showRemoveStatsButtons;

        protected virtual void OnEnable()
        {
            _dataSo = target as EquipmentSo;
        }

        public override void OnInspectorGUI()
        {
            _showAddStatsButtons = EditorGUILayout.Foldout(_showAddStatsButtons, "Add Stats");
            if (_showAddStatsButtons)
            {
                foreach (var e in AllStats.Where(e => _dataSo.SerializableStatsAffect.Get((EnumStats) e) == null).Where(e => GUILayout.Button(e.ToString())))
                {
                    _dataSo.AddStats((EnumStats)e);
                }
            }
            
            base.OnInspectorGUI();
            
            _showForceButtons = EditorGUILayout.Foldout(_showForceButtons, "Force Stats actions");
            if (_showForceButtons)
            {
                if (GUILayout.Button("Force Stats Names Update"))
                {
                    _dataSo.SerializableStatsAffect.ForEach(s => s.ChangeName());
                }
            }
            
            _showRemoveStatsButtons = EditorGUILayout.Foldout(_showRemoveStatsButtons, "Remove Stats");
            if (!_showRemoveStatsButtons) return;
            {
                foreach (var e in AllStats.Where(e => _dataSo.SerializableStatsAffect.Get((EnumStats) e) != null).Where(e => GUILayout.Button(e.ToString())))
                {
                    _dataSo.RemoveStats((EnumStats)e);
                }
            }

        }

        [DidReloadScripts]
        protected static void OnRecompile()
        {
            foreach (var stat in System.Enum.GetValues(typeof(EnumStats)))
            {
                AllStats.Add(stat);
            }
        }
    }
}

