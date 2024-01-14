using System;

namespace Assets.Scripts.Ability
{
    [Serializable]
    public class AbilityParameters
    {
        public AbilityName AbilityName;
        public float Cooldown;
        public float UseCount;
    }
}
