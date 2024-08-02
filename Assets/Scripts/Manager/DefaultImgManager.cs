using UnityEngine;

namespace Pethalyse.Manager
{
    public class DefaultImgManager : MonoBehaviour
    {
        public static DefaultImgManager Instance;
        [SerializeField] private Sprite defaultWeapon;
        [SerializeField] private Sprite defaultHelmet;
        [SerializeField] private Sprite defaultTalisman;
        [SerializeField] private Sprite defaultChestplate;
        [SerializeField] private Sprite defaultPants;
        [SerializeField] private Sprite defaultBoots;
        private void Awake()
        {
            Instance = this;
        }

        public Sprite GetWeapon() => defaultWeapon;
        public Sprite GetHelmet() => defaultHelmet;
        public Sprite GetTalisman() => defaultTalisman;
        public Sprite GetChestplate() => defaultChestplate;
        public Sprite GetPants() => defaultPants;
        public Sprite GetBoots() => defaultBoots;
    }
}