using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Area
{
    public class ZeroHp : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _deadZone;

        private void Update() => Zero();

        public void Zero()
        {
            if (_player.HealthPoint > 0) return;
            _deadZone.SetActive(true);
        }
    }
}
