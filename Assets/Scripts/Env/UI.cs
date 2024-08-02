using System;
using Pethalyse.Env.Inputs;
using Pethalyse.Env.StatsProfile;
using UnityEngine;

namespace Pethalyse.Env
{
    [RequireComponent(typeof(UIInputsHandler))]
    public class UI : MonoBehaviour
    {
        public UIInputsHandler InputsHandler { get; private set; }

        private UIStatsProfile _uiStatsProfile;

        private void Awake()
        {
            InputsHandler = GetComponent<UIInputsHandler>();

            _uiStatsProfile = GetComponentInChildren<UIStatsProfile>(true);
        }

        private void Update()
        {
            CheckStatsProfile();
        }

        private void CheckStatsProfile()
        {
            _uiStatsProfile.gameObject.SetActive(InputsHandler.StatsProfileInput);
        }
    }
}