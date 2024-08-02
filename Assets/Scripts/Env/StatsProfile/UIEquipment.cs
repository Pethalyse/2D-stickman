using System;
using Pethalyse.Gameplay.Core.CoreComponents;
using Pethalyse.Gameplay.Enum;
using Pethalyse.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Pethalyse.Env.StatsProfile
{
    public class UIEquipment : OnEnableMiseAJour
    {
        private Equipment _playerEquipment;
        
        [Header("Equipment Img")]
        [SerializeField] private Image weaponImg;
        [SerializeField] private Image helmetImg;
        [SerializeField] private Image talismanImg;
        [SerializeField] private Image chestplateImg;
        [SerializeField] private Image pantsImg;
        [SerializeField] private Image bootsImg;

        private void Awake()
        {
            _playerEquipment = PlayerManager.Instance.GetPlayer().GetComponent<Equipment>();
        }

        protected override void Enable()
        {
            base.Enable();
            _playerEquipment.OnEquipmentChanged += OnPlayerEquipmentChanged;
        }

        private void OnDisable()
        {
            _playerEquipment.OnEquipmentChanged -= OnPlayerEquipmentChanged;
        }

        private void OnPlayerEquipmentChanged(EnumEquipment stat)
        {
            ChangeEquipmentSprite(stat);
        }

        private void Start()
        {
            MiseAJour();
        }

        private void ChangeEquipmentSprite(EnumEquipment equip)
        {
            //Debug.Log($"Invoke : {equip} : {_playerEquipmentComponent.GetEquipment(equip)?.equipmentName}");
            switch (equip)
            {
                case EnumEquipment.Weapon:
                    weaponImg.sprite = _playerEquipment.GetWeapon()
                        ? _playerEquipment.GetWeapon()?.Sprite
                        : DefaultImgManager.Instance.GetWeapon();
                    break;
                case EnumEquipment.Helmet:
                    helmetImg.sprite = _playerEquipment.GetHelmet()
                        ? _playerEquipment.GetHelmet()?.Sprite
                        : DefaultImgManager.Instance.GetHelmet();
                    break;
                case EnumEquipment.Talisman:
                    talismanImg.sprite = _playerEquipment.GetTalisman()
                        ? _playerEquipment.GetTalisman()?.Sprite
                        : DefaultImgManager.Instance.GetTalisman();
                    break;
                case EnumEquipment.Chestplate:
                    chestplateImg.sprite = _playerEquipment.GetChestplate()
                        ? _playerEquipment.GetChestplate()?.Sprite
                        : DefaultImgManager.Instance.GetChestplate();
                    break;
                case EnumEquipment.Pants:
                    pantsImg.sprite = _playerEquipment.GetPants()
                        ? _playerEquipment.GetPants()?.Sprite
                        : DefaultImgManager.Instance.GetPants();
                    break;
                case EnumEquipment.Boots:
                    bootsImg.sprite = _playerEquipment.GetBoots()
                        ? _playerEquipment.GetBoots()?.Sprite
                        : DefaultImgManager.Instance.GetBoots();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(equip), equip, null);
            }
        }

        protected override void MiseAJour()
        {
            OnPlayerEquipmentChanged(EnumEquipment.Weapon);
            OnPlayerEquipmentChanged(EnumEquipment.Helmet);
            OnPlayerEquipmentChanged(EnumEquipment.Talisman);
            OnPlayerEquipmentChanged(EnumEquipment.Chestplate);
            OnPlayerEquipmentChanged(EnumEquipment.Pants);
            OnPlayerEquipmentChanged(EnumEquipment.Boots);
        }
    }
}