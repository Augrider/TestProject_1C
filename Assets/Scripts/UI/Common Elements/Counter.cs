using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.UI.CommonElements
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textObject;


        public void SetValue(int value)
        {
            textObject.SetText(value.ToString());
        }
    }
}