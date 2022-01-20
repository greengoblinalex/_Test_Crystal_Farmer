using _GAME.Characters;
using TMPro;
using UnityEngine;

namespace _GAME.Shop
{
    public class ShopZoneLogic : MonoBehaviour
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
            _shopFeature.shopZoneRefs.collisionCatcher.OnTriggerEnterEvent += CharacterEnter;
        }

        private void CharacterEnter(Collider collider)
        {
            _charactersFeature.goldCount += _charactersFeature.redCrystalsCount * _shopFeature.settings.redPrice 
                                            + _charactersFeature.greenCrystalsCount * _shopFeature.settings.greenPrice 
                                            + _charactersFeature.blueCrystalsCount * _shopFeature.settings.bluePrice;
            
            _charactersFeature.redCrystalsCount = 0;
            _charactersFeature.greenCrystalsCount = 0;
            _charactersFeature.blueCrystalsCount = 0;
        }
    }
}