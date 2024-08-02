using Pethalyse.Gameplay.Characters.Player;
using Pethalyse.Gameplay.Characters.Player.StateMachine;
using UnityEngine;

namespace Pethalyse.Manager
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;
        [SerializeField] private Player player;
        private void Awake()
        {
            Instance = this;
        }

        public Player GetPlayer() => player;
    }
}