using UnityEngine;

namespace DLSL.ResourceCollectorDemo
{
    public abstract class ControllerInput : MonoBehaviour
    {
        public Vector2 Direction { get; protected set; }
    }
}