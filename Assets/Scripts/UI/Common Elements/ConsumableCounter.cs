using UnityEngine;

namespace Game.UI.CommonElements
{
    public class ConsumableCounter : MonoBehaviour
    {
        [SerializeField] private Counter _counter;
        [SerializeField] private GameModel.ConsumableTypes _consumableType;


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
            _counter.SetValue(GetConsumable());
        }



        private int GetConsumable()
        {
            try
            {
                var count = GameModel.GetConsumableCount(_consumableType);
                return count;
            }
            catch
            {
                return -1;
            }
        }
    }
}