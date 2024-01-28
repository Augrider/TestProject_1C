using Game.Model;
using UnityEngine;

namespace Game.UI.CommonElements
{
    public class CurrencyCounter : MonoBehaviour
    {
        [SerializeField] private Counter _counter;
        [SerializeField] private CurrencyType _currencyType;


        void OnEnable()
        {
            Refresh();
            GameModel.ModelChanged += Refresh;
        }

        void OnDisable()
        {
            GameModel.ModelChanged -= Refresh;
        }


        public void Refresh()
        {
            _counter.SetValue(GameModelExtensions.GetCurrency(_currencyType));
        }
    }
}