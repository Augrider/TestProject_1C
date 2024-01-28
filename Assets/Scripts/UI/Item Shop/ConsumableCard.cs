using Game.Model;
using Game.UI.CommonElements;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.ItemShop
{
    /// <summary>
    /// Handles consumable card visuals
    /// </summary>
    public class ConsumableCard : MonoBehaviour
    {
        //TODO: Set visuals from file
        //TODO: Change currency style
        [SerializeField] private GameModel.ConsumableTypes _consumableType;

        [Header("Card components")]
        [SerializeField] private Counter _priceCounter;
        [SerializeField] private Button _buyButton;


        void OnEnable()
        {
            Refresh();
        }


        /// <summary>
        /// Refresh data, price and ability to buy
        /// </summary>
        public void Refresh()
        {
            var currencyType = GetCurrencyType(_consumableType);
            var price = GetPrice(_consumableType, currencyType);

            _priceCounter.SetValue(price);

            _buyButton.interactable = GameModelExtensions.GetCurrency(currencyType) >= price;
        }


        public void RequestBuy()
        {
            switch (GetCurrencyType(_consumableType))
            {
                case CurrencyType.Credit:
                    GameModel.BuyConsumableForSilver(_consumableType);
                    return;

                case CurrencyType.Coin:
                    GameModel.BuyConsumableForGold(_consumableType);
                    return;
            }
        }



        /// <summary>
        /// Get price in provided currency for a provided consumable type 
        /// </summary>
        private int GetPrice(GameModel.ConsumableTypes consumableType, CurrencyType currencyType)
        {
            if (consumableType is GameModel.ConsumableTypes.None)
                return default;

            var priceConfig = GameModel.ConsumablesPrice[consumableType];

            switch (currencyType)
            {
                case CurrencyType.Credit:
                    return priceConfig.CreditPrice;

                case CurrencyType.Coin:
                    return priceConfig.CoinPrice;
            }

            return default;
        }

        /// <summary>
        /// Get price currency type for a provided consumable type
        /// </summary>
        private CurrencyType GetCurrencyType(GameModel.ConsumableTypes consumableType)
        {
            if (consumableType is GameModel.ConsumableTypes.None)
                return default;

            var priceConfig = GameModel.ConsumablesPrice[consumableType];

            if (priceConfig.CoinPrice > 0)
                return CurrencyType.Coin;

            if (priceConfig.CreditPrice > 0)
                return CurrencyType.Credit;

            return default;
        }
    }
}