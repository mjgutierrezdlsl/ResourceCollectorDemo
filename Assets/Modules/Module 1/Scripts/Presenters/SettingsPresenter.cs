using System;
using UnityEngine;
using UnityEngine.UI;

namespace DLSL.ResourceCollectorDemo.Module1.Presenters
{
    public class SettingsPresenter : MonoBehaviour
    {
        [SerializeField] private SettingsModel _settings;
        [SerializeField] private Slider _volumeSlider;

        private void Awake()
        {
            _volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        }

        private void OnDestroy()
        {
            _volumeSlider.onValueChanged.RemoveListener(OnVolumeSliderChanged);
        }

        private void OnVolumeSliderChanged(float value)
        {
            _settings.VolumeSetting.Value = value;
        }

        private void OnEnable()
        {
            if (_volumeSlider.value != _settings.VolumeSetting.Value)
            {
                _volumeSlider.value = _settings.VolumeSetting.Value;
            }

        }
    }
}
