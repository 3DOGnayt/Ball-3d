using UnityEngine;

namespace Assets.Scripts.Ability.RealisationAbility
{
    public class Jump : MonoBehaviour, IAbility
    {
        [SerializeField] private Transform _playerPosition;
        [SerializeField] private float _useCount;
        [SerializeField] private float _force;

        private Rigidbody player;

        public float UseCount { get => _useCount; set => _useCount = value; }

        private void Start() => player = _playerPosition.gameObject.GetComponent<Rigidbody>();

        public void ActivateAbility()
        {
            if (_useCount <= 0) return;
            player.AddForce(Vector3.up * _force, ForceMode.VelocityChange);
        }
    }
}
