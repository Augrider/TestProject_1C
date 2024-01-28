using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI.Navigation
{
    /// <summary>
    /// Component that handles requests to change menu
    /// </summary> 
    public class MenuNavigation : MonoBehaviour
    {
        private MenuPanel _current;


        void OnEnable()
        {
            MenuNavigationSender.PanelChangeRequested += ChangePanel;
            MenuNavigationSender.CloseCurrentPanelRequested += CloseCurrent;
        }

        void OnDisable()
        {
            MenuNavigationSender.PanelChangeRequested -= ChangePanel;
            MenuNavigationSender.CloseCurrentPanelRequested -= CloseCurrent;
        }



        private void CloseCurrent()
        {
            ChangePanel(null);
        }

        private void ChangePanel(MenuPanel panel)
        {
            _current?.ToggleActive(false);
            panel?.ToggleActive(true);

            _current = panel;
        }
    }
}