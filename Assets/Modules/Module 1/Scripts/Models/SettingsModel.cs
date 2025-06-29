using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module1
{
    [CreateAssetMenu(fileName = "SettingsModel", menuName = "MVP/Models/SettingsModel")]
    public class SettingsModel : ScriptableObject
    {
        [field: SerializeField] public FloatReference VolumeSetting { get; private set; }
    }
}
