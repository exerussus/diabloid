using UnityEngine;

namespace Resources.Scripts.Tools
{
    public class RigidbodyPreset
    {
        public static void SetDefaultSettings(Rigidbody rigidbody, float mass)
        {
            rigidbody.freezeRotation = true;
            rigidbody.mass = mass;
        }
    }
}