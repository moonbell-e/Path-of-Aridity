using UnityEngine;
using UnityEngine.UI;

namespace Battle.Resolve
{
    public delegate void ValueChanged(int value);
    
    public class ResolveBar : MonoBehaviour
    {
        public event ValueChanged ResolveChanged;
        [SerializeField]
        private Slider _resolveBar;
        [SerializeField]
        private int _resolve;

        private void Awake() 
        {
            _resolve = 50;
            ChangeResolve(0);
        }

        public void ChangeResolve(int value)
        {
            _resolve += value;
            if(_resolve > 100) _resolve = 100;
            if(_resolve < 0) _resolve = 0;
            _resolveBar.value = _resolve;
            ResolveChanged?.Invoke(_resolve);
        }
    }
}

