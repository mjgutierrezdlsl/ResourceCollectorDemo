using UnityEngine;

namespace DLSL.ResourceCollectorDemo
{
    public class AIInput : ControllerInput
    {
        private void Start()
        {
            Direction = transform.right;
        }
    }
}