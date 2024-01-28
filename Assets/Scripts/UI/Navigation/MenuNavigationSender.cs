using System;
using UnityEngine;

namespace Game.UI.Navigation
{
    /// <summary>
    /// Sends panel change requests
    /// </summary>
    public class MenuNavigationSender : MonoBehaviour
    {
        public static event Action<MenuPanel> PanelChangeRequested;
        public static event Action CloseCurrentPanelRequested;


        public void RequestPanelChange(MenuPanel target)
        {
            PanelChangeRequested?.Invoke(target);
        }

        public void RequestCloseCurrentPanel()
        {
            CloseCurrentPanelRequested?.Invoke();
        }
    }
}