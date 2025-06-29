using DLSL.ResourceCollectorDemo.References;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Models
{
    [CreateAssetMenu(fileName = "SettingsModel", menuName = "MVP/Models/SettingsModel")]
    public class SettingsModel : ScriptableObject
    {
        [field: SerializeField] public FloatReference VolumeSetting { get; private set; }
    }
}
