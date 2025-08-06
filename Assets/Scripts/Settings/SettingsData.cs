using System;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Settings
{
    [CreateAssetMenu(fileName = "SettingsData", menuName = "Scriptable Objects/SettingsData")]
    public class SettingsData : ScriptableObject
    {
        [SerializeField] private float _volume;
        public float Volume
        {
            get => _volume;
            set
            {
                _volume = value;
                OnVolumeChanged?.Invoke(_volume);
            }
        }
        public event Action<float> OnVolumeChanged;
    }
}
