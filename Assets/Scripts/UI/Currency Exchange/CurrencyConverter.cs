using Game.UI.CommonElements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.CurrencyExchange
{
    public class CurrencyConverter : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _input;
        [SerializeField] private TextMeshProUGUI _output;

        [SerializeField] private Counter _exchangeRateCounter;
        [SerializeField] private TextMeshProUGUI _maxValueText;

        public int ExchangeRate { get; private set; }
        public int InputMax { get; private set; }

        public int Input { get; private set; }
        public int Output { get; private set; }


        public void SetExchangeRate(int value)
        {
            if (value <= 0)
                throw new System.Exception("Incorrect exchange rate");

            ExchangeRate = value;
            SetInput(Input);

            _exchangeRateCounter.SetValue(value);
        }

        public void SetInputMax(int value)
        {
            InputMax = value;
            SetInput(Input);

            _maxValueText.SetText(InputMax.ToString());
        }


        public void OnInputChanged(string value)
        {
            if (!int.TryParse(value, out var inputValue) || inputValue < 0)
            {
                SetInput(0);
                return;
            }

            SetInput(inputValue);
        }


        public void SetInput(int value)
        {
            var inputValue = Mathf.Clamp(value, 0, InputMax);

            Output = inputValue / ExchangeRate;
            Input = Output * ExchangeRate;

            UpdateVisuals();
        }



        private void UpdateVisuals()
        {
            _input.SetTextWithoutNotify(Input.ToString());
            _output.SetText(Output.ToString());
        }
    }
}