using System;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Core
{
    public abstract class VariableReference<T> : ScriptableObject
    {
        [SerializeField] private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }

        public event Action<T> OnValueChanged;

        private void OnValidate()
        {
            Value = _value;
        }
    }
}
