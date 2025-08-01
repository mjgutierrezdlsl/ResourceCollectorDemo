using UnityEngine;
using UnityEngine.UI;

namespace DLSL.ResourceCollectorDemo
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField] SettingsData _settings;

        [Header("UI")]
        [SerializeField] private Slider _volumeSlider;

        public void ChangeVolume(float value)
        {
            _settings.Volume = value;
            _settings.OnVolumeChanged?.Invoke(_settings.Volume);
        }

        private void Start()
        {
            _volumeSlider.value = _settings.Volume;
        }
    }
}