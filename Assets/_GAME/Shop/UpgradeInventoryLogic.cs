using System;
using _GAME.Characters;
using UnityEngine;

namespace _GAME.Shop
{
    public class UpgradeInventoryLogic : MonoBehaviour
    {
        private CharactersFeature _charactersFeature;
        private ShopFeature _shopFeature;

        private void Awake()
        {
            _charactersFeature = FindObjectOfType<CharactersFeature>();
            _shopFeature = FindObjectOfType<ShopFeature>();
        }

        private void Update()
        {
            _shopFeature.upgradeInventoryButton.onClick.AddListener(UpgradeInventory);
        }

        private void UpgradeInventory()
        {
            if(_charactersFeature.goldCount >= _shopFeature.settings.upgradeInventoryPrice)
            {
                _charactersFeature.goldCount = _charactersFeature.goldCount - _shopFeature.settings.upgradeInventoryPrice;
                _charactersFeature.maxCrystals += _shopFeature.settings.upgradeInventoryPlace;
            }
        }
    }
}