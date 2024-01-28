using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Model
{
    public enum CurrencyType { Credit, Coin };


    public static class GameModelExtensions
    {
        public static int GetCurrency(CurrencyType currencyType)
        {
            switch (currencyType)
            {
                case CurrencyType.Credit:
                    return GameModel.CreditCount;

                case CurrencyType.Coin:
                    return GameModel.CoinCount;
            }

            return default;
        }
    }
}