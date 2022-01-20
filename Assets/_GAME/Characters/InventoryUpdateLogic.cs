using System;
using UnityEngine;

namespace _GAME.Characters
{
    public class InventoryUpdateLogic: MonoBehaviour
    {
        private CharactersFeature _charactersFeature;
        private MinersFeature _minersFeature;

        private void Awake()
        {
            _charactersFeature = FindObjectOfType<CharactersFeature>();
            _minersFeature = FindObjectOfType<MinersFeature>();
        }

        private void Update()
        {
            _charactersFeature.redCrystals.text = "Red: " + _charactersFeature.redCrystalsCount;
            _charactersFeature.greenCrystals.text = "Green: " + _charactersFeature.greenCrystalsCount;
            _charactersFeature.blueCrystals.text = "Blue: " + _charactersFeature.blueCrystalsCount;
            _charactersFeature.gold.text = "Gold: " + _charactersFeature.goldCount;
        }
    }
}