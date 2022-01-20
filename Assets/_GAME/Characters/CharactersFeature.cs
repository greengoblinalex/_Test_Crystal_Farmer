using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _GAME.Characters
{
    public class CharactersFeature : MonoBehaviour
    {
        public int maxCrystals = 30;

        public int redCrystalsCount;
        public int greenCrystalsCount;
        public int blueCrystalsCount;
        public int goldCount;

        public TextMeshProUGUI redCrystals;
        public TextMeshProUGUI greenCrystals;
        public TextMeshProUGUI blueCrystals;
        public TextMeshProUGUI gold;
        
        public CharacterRefs characterPrefab;
        public CharactersSettings settings;

        public int hitCounter;
    }
}