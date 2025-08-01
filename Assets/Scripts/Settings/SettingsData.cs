using System;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo
{
    [CreateAssetMenu(fileName = "SettingsData", menuName = "Scriptable Objects/SettingsData")]
    public class SettingsData : ScriptableObject
    {
        public float Volume;
        public Action<float> OnVolumeChanged;
    }
}
