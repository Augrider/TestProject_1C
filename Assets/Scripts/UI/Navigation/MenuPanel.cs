using UnityEngine;
using UnityEngine.Events;

namespace Game.UI.Navigation
{
    /// <summary>
    /// Base class for UI screens
    /// </summary> 
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private UnityEvent _panelRefreshed;


        public void ToggleActive(bool value)
        {
            gameObject.SetActive(value);

            Refresh();
        }

        public void Refresh()
        {
            _panelRefreshed?.Invoke();

            OnRefresh();
        }



        protected virtual void OnRefresh() { }
    }
}