

using UnityEngine;

namespace Source.ECS.Components
{
    public struct MoveComponent
    {
        public Transform Transform;

        public float MovementSpeed;

        public float IsMoving;
    }
}
