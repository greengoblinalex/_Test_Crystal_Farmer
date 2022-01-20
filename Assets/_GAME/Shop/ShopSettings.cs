using UnityEngine;

namespace _GAME.Shop
{
    [CreateAssetMenu(fileName = "ShopSetting", menuName = "GAME settings/ShopSettings", order = 0)]
    public class ShopSettings : ScriptableObject
    {
        public int redPrice;
        public int greenPrice;
        public int bluePrice;
        public int upgradeInventoryPrice;
        public int upgradeInventoryPlace;
    }
}