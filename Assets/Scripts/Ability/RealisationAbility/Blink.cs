using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Ability.RealisationAbility
{
    public class Blink : MonoBehaviour, IAbility
    {
        [SerializeField] private Transform _playerPosition;
        [SerializeField] private PlayerCamera _lookPoint;
        [SerializeField] private float _useCount;

        public float UseCount { get => _useCount; set => _useCount = value; }

        public void ActivateAbility()
        {
            if (_useCount <= 0) return;
            else
            _playerPosition.position = new Vector3(
                _lookPoint.LookAtMouse().x,
                _lookPoint.LookAtMouse().y,
                _lookPoint.LookAtMouse().z);
        }
    }
}
