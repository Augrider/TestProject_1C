using UnityEngine;
using UnityEngine.UI;

namespace Game.UIStyle
{
    /// <summary>
    /// Sets currency style for provided components
    /// </summary>
    public class UIStyle_Currency : MonoBehaviour
    {
        [SerializeField] private UIStyle_CurrencySO _currencyStyle;

        [SerializeField] private Image _iconImage;

        [SerializeField] private MaskableGraphic[] _primaryColorGraphics;
        [SerializeField] private MaskableGraphic[] _textColorGraphics;


        void Start()
        {
            UpdateGraphics();
        }


        /// <summary>
        /// Refresh icon and colors
        /// </summary> 
        [ContextMenu("Update Graphics")]
        public void UpdateGraphics()
        {
            if (_currencyStyle is null)
                throw new System.Exception("Provided Currency style is null!");

            if (_iconImage)
                _iconImage.sprite = _currencyStyle.Icon;

            foreach (var graphic in _primaryColorGraphics)
                graphic.color = _currencyStyle.PrimaryColor;

            foreach (var graphic in _textColorGraphics)
                graphic.color = _currencyStyle.TextColor;
        }


        public void SetCurrencyStyle(UIStyle_CurrencySO currencyStyle)
        {
            _currencyStyle = currencyStyle;
            UpdateGraphics();
        }
    }
}