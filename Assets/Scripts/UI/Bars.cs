using Assets.Scripts.Core;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class Bars : MonoBehaviour
    {
        [SerializeField] private TMP_Text _hp;
        [SerializeField] private TMP_Text _speed;
        [SerializeField] private Player _player;

        private void Update()
        {
            SetBars();
        }

        public void SetBars()
        {
            _hp.text = $"HP - {_player.HealthPoint}";
            _speed.text = $"Speed - {_player.SpeedPoint}";
        }
    }
}
