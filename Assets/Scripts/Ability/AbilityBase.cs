using System;
using UnityEngine;

namespace Assets.Scripts.Ability
{
    [CreateAssetMenu(fileName = "Ability", menuName = "AbilityList")]
    public class AbilityBase : ScriptableObject
    {
        [SerializeField] private AbilityParameters[] abilities;

        public AbilityParameters GetAbilityByName(AbilityName abilityName)
        {
            foreach (var ability in abilities)
            {
                if (ability.AbilityName != abilityName) continue;
                return ability;
            }
            throw new Exception($"There is no ability with name: {abilityName}");
        }
    }
}