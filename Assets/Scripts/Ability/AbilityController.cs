using Assets.Scripts.Ability.RealisationAbility;
using Assets.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Ability
{
    public class AbilityController : MonoBehaviour
    {       
        [SerializeField] private GameObject _blink;
        [SerializeField] private GameObject _jump;
        [SerializeField] private AbilityView _abilityView;

        private Blink blink1;
        private Jump jump1;

        public Blink Blink => blink1;

        private void Start()
        {
            blink1 = _blink.GetComponent<Blink>();
            var useCount1 = _abilityView.AbilityBases[0].GetAbilityByName(AbilityName.Blink).UseCount;
            blink1.UseCount = useCount1;

            var jump = _jump.GetComponent<Jump>();
            var useCount2 = _abilityView.AbilityBases[1].GetAbilityByName(AbilityName.Jump).UseCount;
            jump.UseCount = useCount2;
        }        

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //var blink = _blink.GetComponent<Blink>();
                //var useCount = _abilityView.AbilityBases[0].GetAbilityByName(AbilityName.Blink).UseCount;
                //blink1.UseCount = useCount;

                if (!_abilityView.Buttons[0].interactable && blink1.UseCount <= 0) return;
                blink1.ActivateAbility();
                _abilityView.OnUseAbility(0, AbilityName.Blink);

            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                var jump = _jump.GetComponent<Jump>();
                var useCount = _abilityView.AbilityBases[1].GetAbilityByName(AbilityName.Jump).UseCount;
                jump.UseCount = useCount;

                if (!_abilityView.Buttons[1].interactable) return;
                _abilityView.OnUseAbility(1, AbilityName.Jump);
                jump.ActivateAbility();

            }            
        }
    }
}
