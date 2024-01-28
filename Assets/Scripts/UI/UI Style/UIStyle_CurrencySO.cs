using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UIStyle
{
    /// <summary>
    /// Container for currency visual data
    /// </summary>
    [CreateAssetMenu(menuName = "UI Style/Currency")]
    public class UIStyle_CurrencySO : ScriptableObject
    {
        [field: SerializeField] public Sprite Icon { get; private set; }

        [field: SerializeField] public Color PrimaryColor { get; private set; }
        [field: SerializeField] public Color TextColor { get; private set; }
    }
}