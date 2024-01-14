using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Player : MonoBehaviour, ITakeDamage, ITakeHp, ISpeed
    {
        [SerializeField] private float _hp = 100;
        [SerializeField] private float _speed = 4;

        public float HealthPoint => _hp;
        public float SpeedPoint => _speed;

        private bool _isAlive = true;

        public void Speed(float speed) => _speed += speed;

        private void CheckIsAlive()
        {
            if (_hp <= 0) _isAlive = false;
        }

        public void Takedamage(float damage)
        {
            if (!_isAlive) return;
            else _hp -= damage;
            CheckIsAlive();
        }

        public void TakeHp(float health)
        {
            if (!_isAlive) return;
            else _hp += health;
        }
    }
}