using UnityEngine;

namespace _GAME.Characters
{
    [CreateAssetMenu(fileName = "CharactersSettings", menuName = "GAME settings/CharactersSettings", order = 0)]
    public class CharactersSettings : ScriptableObject
    {
        public float playerSpeed;
        
        public int addRedCrystals;
        public int addGreenCrystals;
        public int addBlueCrystals;
    }
}