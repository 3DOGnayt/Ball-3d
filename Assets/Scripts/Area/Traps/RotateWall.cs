using UnityEngine;

namespace Assets.Scripts.Area.Traps
{
    public class RotateWall : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _X;
        [SerializeField] private float _Y;
        [SerializeField] private float _Z;

        private void Update()
        {
            gameObject.transform.Rotate(_X, _Y  * _rotateSpeed * Time.deltaTime, _Z);
        }
    }
}
