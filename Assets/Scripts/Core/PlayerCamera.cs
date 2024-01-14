using UnityEngine;

namespace Assets.Scripts.Core
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _maxDistance;
        [SerializeField] private float _lookFloor;

        private void Start() => _camera = Camera.main;

        private void Update() => LookAtMouse();

        public Vector3 LookAtMouse()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(_camera.transform.position, ray.direction * 20f, Color.green);

            Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _layerMask);
            Vector3 groundHit = hit.point;
            _player.LookAt(new Vector3(groundHit.x, groundHit.y + _lookFloor, groundHit.z));
            return hit.point;
        }
    }
}
