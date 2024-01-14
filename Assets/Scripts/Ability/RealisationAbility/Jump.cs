using UnityEngine;

namespace Assets.Scripts.Ability.RealisationAbility
{
    public class Jump : MonoBehaviour, IAbility
    {
        [SerializeField] private float _useCount;

        public float UseCount { get => _useCount; set => _useCount = value; }

        public void ActivateAbility()
        {
            if (_useCount <= 0) return;
        }
    }
}
