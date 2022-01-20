using UnityEngine;

namespace _GAME.Characters
{
    public class CharacterAnimationEvents: MonoBehaviour
    {
        private CharactersFeature _charactersFeature;
        private MinersFeature _minersFeature;

        private void Awake()
        {
            _charactersFeature = FindObjectOfType<CharactersFeature>();
            _minersFeature = FindObjectOfType<MinersFeature>();
        }
        
        private void MineEvent()
        {
            _charactersFeature.hitCounter += 1;
            if (_charactersFeature.hitCounter >= 3)
            {
                AddCrystals();
                _minersFeature.OnMineChanged?.Invoke();
                _charactersFeature.hitCounter = 0;
            }
        }

        private void AddCrystals()
        {
            if (_charactersFeature.characterPrefab.nearestMiner.minerColor == EnumMinerColor.Red)
                _charactersFeature.redCrystalsCount += _charactersFeature.settings.addRedCrystals;
            
            if (_charactersFeature.characterPrefab.nearestMiner.minerColor == EnumMinerColor.Green)
                _charactersFeature.greenCrystalsCount += _charactersFeature.settings.addGreenCrystals;
            
            if (_charactersFeature.characterPrefab.nearestMiner.minerColor == EnumMinerColor.Blue)
                _charactersFeature.blueCrystalsCount += _charactersFeature.settings.addBlueCrystals;
        }
    }
}