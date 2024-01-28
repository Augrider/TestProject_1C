using UnityEngine;
using UnityEngine.Events;

namespace Game.UI.CommonElements
{
    public class ModelChangeEvents : MonoBehaviour
    {
        [SerializeField] private UnityEvent _modelChanged;
        [SerializeField] private UnityEvent<GameModel.OperationResult> _operationComplete;


        void OnEnable()
        {
            GameModel.ModelChanged += InvokeModelChanged;
            GameModel.OperationComplete += InvokeOperationComplete;
        }

        void OnDisable()
        {
            GameModel.ModelChanged -= InvokeModelChanged;
            GameModel.OperationComplete -= InvokeOperationComplete;
        }


        private void InvokeModelChanged() => _modelChanged?.Invoke();
        private void InvokeOperationComplete(GameModel.OperationResult result) => _operationComplete?.Invoke(result);
    }
}