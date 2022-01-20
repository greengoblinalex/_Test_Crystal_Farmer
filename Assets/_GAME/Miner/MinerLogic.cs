using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace _GAME.Characters
{
    public class MinerLogic : MonoBehaviour
    {
        private CharactersFeature _charactersFeature;
        private MinersFeature _minersFeature;

        private Coroutine _coroutine;
        private MinerRefs _currentMiner;
        
        private void Awake()
        {
            _charactersFeature = FindObjectOfType<CharactersFeature>();
            _minersFeature = FindObjectOfType<MinersFeature>();
        }

        private void OnEnable()
        {
            _minersFeature.OnMineChanged += Mining;
        }

        private void OnDisable()
        {
            _minersFeature.OnMineChanged -= Mining;
        }

        private void Update()
        {
            foreach (var minerPrefab in _minersFeature.minerPrefabs)
            {
                if (!minerPrefab.isMinerRestoring)
                    MinerRestore(minerPrefab);
                
                MinerStagePrefab(minerPrefab);
            }
        }

        private void Mining()
        {
            var minerPrefab = _charactersFeature.characterPrefab.nearestMiner;
            if (minerPrefab.minerStage != EnumMinerStage.Small)
            {
                if (minerPrefab.minerStage == EnumMinerStage.Mid)
                    minerPrefab.minerStage = EnumMinerStage.Small;

                if (minerPrefab.minerStage == EnumMinerStage.Full)
                    minerPrefab.minerStage = EnumMinerStage.Mid;
            }
        }

        private void MinerStagePrefab(MinerRefs minerPrefab)
        {
            if (minerPrefab.minerStage == EnumMinerStage.Full)
            {
                minerPrefab.minerStageFullPrefab.gameObject.SetActive(true);
                minerPrefab.minerStageMidPrefab.gameObject.SetActive(false);
                minerPrefab.minerStageSmallPrefab.gameObject.SetActive(false);
            }
            
            if (minerPrefab.minerStage == EnumMinerStage.Mid)
            {
                minerPrefab.minerStageFullPrefab.gameObject.SetActive(false);
                minerPrefab.minerStageMidPrefab.gameObject.SetActive(true);
                minerPrefab.minerStageSmallPrefab.gameObject.SetActive(false);
            }
            
            if (minerPrefab.minerStage == EnumMinerStage.Small)
            {
                minerPrefab.minerStageFullPrefab.gameObject.SetActive(false);
                minerPrefab.minerStageMidPrefab.gameObject.SetActive(false);
                minerPrefab.minerStageSmallPrefab.gameObject.SetActive(true);
            }
        }
        
        private void MinerRestore(MinerRefs minerPrefab)
        {
            if (minerPrefab.minerStage != EnumMinerStage.Full)
            {
                minerPrefab.isMinerRestoring = true;

                DOVirtual.DelayedCall(5, () =>
                {
                    if (minerPrefab.minerStage == EnumMinerStage.Mid
                        && _charactersFeature.characterPrefab.nearestMiner != minerPrefab)
                        minerPrefab.minerStage = EnumMinerStage.Full;

                    if (minerPrefab.minerStage == EnumMinerStage.Small
                        && _charactersFeature.characterPrefab.nearestMiner != minerPrefab)
                        minerPrefab.minerStage = EnumMinerStage.Mid;

                    minerPrefab.isMinerRestoring = false;
                });
            }
        }
    }
}