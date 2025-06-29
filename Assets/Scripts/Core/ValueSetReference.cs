using System;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Core
{
    public abstract class ValueSetReference<T> : ScriptableObject
    {
        public event Action<T> OnValueSet;
        public void SetValue(T value)
        {
            OnValueSet?.Invoke(value);
        }
    }
}
