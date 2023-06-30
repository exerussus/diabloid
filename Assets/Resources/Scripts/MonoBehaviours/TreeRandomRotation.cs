
using UnityEngine;
using Random = UnityEngine.Random;

namespace Resources.Scripts.MonoBehaviours
{
    public class TreeRandomRotation : MonoBehaviour
    {
        [SerializeField] private Transform _treeTransform;
        [Range(0, 5f)] [SerializeField] private float rotationX;
        [Range(0, 5f)] [SerializeField] private float rotationZ;
        [Range(0f, 360f)] [SerializeField] private float rotationY = 360f;

        private void OnEnable()
        {
            if (_treeTransform != null)
            {
                var rotation = new Vector3(Random.Range(-rotationX, rotationX), 
                                           Random.Range(0, rotationY), 
                                           Random.Range(-rotationZ, rotationZ));
                var position = _treeTransform.position;
                _treeTransform.position = new Vector3(position.x, Random.Range(-0.2f, 0f), position.z);
                _treeTransform.rotation = new Quaternion();
                _treeTransform.Rotate(rotation);
            }
        }
    }
}