using Assets.Scripts.Ability.RealisationAbility;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Ability
{
    public class AbilityController : MonoBehaviour
    {       
        [SerializeField] private GameObject _blink;
        [SerializeField] private GameObject _jump;
        [SerializeField] private AbilityView _abilityView;

        private Blink blink;
        private Jump jump;

        public Blink Blink => blink;
        public Jump Jump => jump;

        private void Start()
        {
            blink = _blink.GetComponent<Blink>();
            var useCount1 = _abilityView.AbilityBases[0].GetAbilityByName(AbilityName.Blink).UseCount;
            blink.UseCount = useCount1;

            jump = _jump.GetComponent<Jump>();
            var useCount2 = _abilityView.AbilityBases[1].GetAbilityByName(AbilityName.Jump).UseCount;
            jump.UseCount = useCount2;
        }        

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (!_abilityView.Buttons[0].interactable && blink.UseCount <= 0) return;
                blink.ActivateAbility();
                _abilityView.OnUseAbility(0, AbilityName.Blink);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (!_abilityView.Buttons[1].interactable && jump.UseCount <= 0) return;
                jump.ActivateAbility();
                _abilityView.OnUseAbility(1, AbilityName.Jump);
            }            
        }
    }
}
