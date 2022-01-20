using System;
using System.Collections.Generic;
using UnityEngine;

namespace _GAME.Characters
{
    public class MinersFeature : MonoBehaviour
    {
        public Action OnMineChanged;
        
        public List<MinerRefs> minerPrefabs = new List<MinerRefs>();
    }
}