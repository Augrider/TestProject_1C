using Game.UI.Navigation;
using UnityEngine;

namespace Game.UI.CurrencyExchange
{
    public class CurrencyExchangePanel : MenuPanel
    {
        [SerializeField] private CurrencyConverter _currencyConverter;


        protected override void OnRefresh()
        {
            _currencyConverter.SetExchangeRate(GameModel.CoinToCreditRate);
            _currencyConverter.SetInputMax(GameModel.CoinCount);

            _currencyConverter.SetInput(0);
        }


        public void ConfirmExchange()
        {
            if (_currencyConverter.Output <= 0)
                return;

            GameModel.ConvertCoinToCredit(_currencyConverter.Input);
        }
    }
}