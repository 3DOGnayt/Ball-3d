using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class WinOrDiedMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _menu = null;
        [SerializeField] private Button _restart = null;
        [SerializeField] private RestartLevel _restartLevel;

        private void Awake() => _restart.onClick.AddListener(Restart);

        private void Restart()
        {
            _menu.SetActive(false);
            Time.timeScale = 1f;
            _restartLevel.Restart();
        }
    }
}