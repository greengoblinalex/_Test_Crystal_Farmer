using UnityEngine;

namespace _GAME.Characters
{
    public class CharacterMiningLogic : MonoBehaviour
    {
        private CharactersFeature _charactersFeature;
        private MinersFeature _minersFeature;
        private static readonly int IsMining = Animator.StringToHash("isMining");

        private void Awake()
        {
            _charactersFeature = FindObjectOfType<CharactersFeature>();
            _minersFeature = FindObjectOfType<MinersFeature>();
        }

        private void Update()
        {
            foreach (var minerPrefab in _minersFeature.minerPrefabs)
            {
                minerPrefab.collisionCatcher.OnTriggerEnterEvent += CharacterEnter;
                minerPrefab.collisionCatcher.OnTriggerExitEvent += CharacterExit;
            }
            
            if (_charactersFeature.characterPrefab.nearestMiner 
                && _charactersFeature.characterPrefab.nearestMiner.minerStage == EnumMinerStage.Small)
                _charactersFeature.characterPrefab.animator.SetBool(IsMining, false);

            if (_charactersFeature.redCrystalsCount + _charactersFeature.greenCrystalsCount +
                _charactersFeature.blueCrystalsCount >= _charactersFeature.maxCrystals)
                _charactersFeature.characterPrefab.animator.SetBool(IsMining, false);
        }

        private void CharacterEnter(Collider collider)
        {
            FindDiggingMiner();
            _charactersFeature.hitCounter = 0;
            _charactersFeature.characterPrefab.animator.SetBool(IsMining, true);
        }
        
        private void CharacterExit(Collider collider)
        {
            _charactersFeature.hitCounter = 0;
            _charactersFeature.characterPrefab.animator.SetBool(IsMining, false);

            _charactersFeature.characterPrefab.nearestMiner = null;
        }

        private void FindDiggingMiner()
        {
            var nearestDist = float.MaxValue;
            _charactersFeature.characterPrefab.nearestMiner = null;

            foreach (var minerPrefab in _minersFeature.minerPrefabs)
            {
                if (Vector3.Distance(_charactersFeature.characterPrefab.rigidbody.transform.position,
                    minerPrefab.transform.position) < nearestDist)
                {
                    nearestDist = Vector3.Distance(_charactersFeature.characterPrefab.rigidbody.transform.position, 
                        minerPrefab.transform.position);
                    
                    _charactersFeature.characterPrefab.nearestMiner = minerPrefab;
                }
            }
        }
    }
}