using Pethalyse.Gameplay.Serializable;
using UnityEngine;
using UnityEngine.UI;

namespace Pethalyse.Env.StatsProfile
{
    public class UIPlayerImg : MonoBehaviour
    {
        // private SpriteManager _spriteManager;
        //
        // [Header("Player Img")] 
        // [SerializeField] private Image playerImg;

        // private void Awake()
        // {
        //     _spriteManager = PlayerManager.Instance.GetPlayer().GetSpriteManager();
        // }
        //
        // private void Start()
        // {
        //     MiseAJour();
        // }
        //
        // protected override void Enable()
        // {
        //     base.Enable();
        //     _spriteManager.OnSpriteChanged += SpriteManagerOnOnSpriteChanged;
        // }
        //
        // private void OnDisable()
        // {
        //     _spriteManager.OnSpriteChanged -= SpriteManagerOnOnSpriteChanged;
        // }
        //
        // private void SpriteManagerOnOnSpriteChanged(Sprite sprite)
        // {
        //     playerImg.sprite = sprite;
        // }
        //
        // protected override void MiseAJour()
        // {
        //     SpriteManagerOnOnSpriteChanged(_spriteManager.GetSpriteRenderer().sprite);
        // }
    }
}