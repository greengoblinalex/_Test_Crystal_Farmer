using _GAME.Common;
using UnityEngine;

namespace _GAME.Characters
{
    public class MinerRefs: MonoBehaviour
    {
        public bool isMinerRestoring;
        
        public Collider collider;
        public CollisionCatcher collisionCatcher;

        public EnumMinerStage minerStage;
        public EnumMinerColor minerColor;
        public Transform minerStageFullPrefab;
        public Transform minerStageMidPrefab;
        public Transform minerStageSmallPrefab;
    }
}