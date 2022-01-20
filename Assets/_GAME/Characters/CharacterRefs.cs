using Unity.Collections;
using UnityEngine;

namespace _GAME.Characters
{
    public class CharacterRefs : MonoBehaviour
    {
        public Joystick joystick;
        public Rigidbody rigidbody;
        public SkinnedMeshRenderer meshRenderer;
        public Animator animator;
        
        [ReadOnly] public MinerRefs nearestMiner;
    }
}