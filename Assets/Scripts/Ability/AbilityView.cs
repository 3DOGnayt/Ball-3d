using Assets.Scripts.Ability;
using Assets.Scripts.Ability.RealisationAbility;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class AbilityView : MonoBehaviour
    {
        [SerializeField] private Button[] _abilityButton;
        [Space(10)]
        [SerializeField] private AbilityBase[] _ability;

        public AbilityBase[] AbilityBases => _ability;
        public Button[] Buttons => _abilityButton;

        [SerializeField] private AbilityController _abilityController;

        //private void Awake()
        //{
        //    _abilityButton[0].onClick.AddListener(FirstAbility);
        //    _abilityButton[1].onClick.AddListener(SecondAbility);
        //}

        public void Start()
        {
            foreach (var abilityButton in _abilityButton)
                abilityButton.image.fillAmount = 1f;
        }

        //private void FirstAbility()
        //{
        //    OnUseAbility(0, AbilityName.Blink);
        //}

        //private void SecondAbility() => OnUseAbility(1, AbilityName.Jump);

        public void OnUseAbility(int numberAability, AbilityName abilityName)
        {
            if (!_abilityButton[numberAability].interactable) return;

            var abilityButton = _abilityButton[numberAability];
            abilityButton.interactable = false;
            abilityButton.transform.localScale = new Vector3(0.98f, 0.98f, 1f);
            var cooldown = _ability[numberAability].GetAbilityByName(abilityName).Cooldown;

            //_ability[numberAability].GetAbilityByName(abilityName).UseCount -= 1;
            _abilityController.Blink.UseCount -= 1;

            abilityButton.StartCoroutine(ButtonCooldown(abilityButton, cooldown, abilityName, numberAability));
        }

        private IEnumerator ButtonCooldown(Button abilityButton, float cooldown, AbilityName abilityName, int numberAability)
        {
            for (float i = cooldown; i > 0;)
            {
                var deltaTime = Time.deltaTime;
                i -= deltaTime;

                ChangeAbilityButton(abilityButton, i, cooldown);
                
                yield return null;
            }
            
            _abilityController.Blink.UseCount += 1;
            //_ability[numberAability].GetAbilityByName(abilityName).UseCount += 1;

            abilityButton.interactable = true;
            abilityButton.transform.localScale = new Vector3(1f, 1f, 1f);
            abilityButton.image.fillAmount = 1f;
        }

        private void ChangeAbilityButton(Button abilityButton, float currentTime, float cooldown)
        {
            abilityButton.image.fillAmount = currentTime / cooldown;
        }
    }
}