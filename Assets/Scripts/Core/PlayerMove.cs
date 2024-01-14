using UnityEngine;

namespace Assets.Scripts.Core
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private Vector3 _direction = Vector2.zero;

        private void Update() => Move();

        private void Move()
        {
            var speed = _direction * (_player.SpeedPoint * Time.fixedDeltaTime);
            transform.Translate(speed);

            _direction.z = Input.GetAxis("Vertical");
            _direction.x = Input.GetAxis("Horizontal");
        }
    }
}
