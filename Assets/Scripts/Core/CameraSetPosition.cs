using UnityEngine;

namespace Assets.Scripts.Core
{
    public class CameraSetPosition : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _player;
        [SerializeField] private float _position;

        private void Update()
        {
            _camera.position = _player.position + new Vector3(0, _position, 0);
        }
    }
}
