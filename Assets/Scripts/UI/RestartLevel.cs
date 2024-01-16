using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class RestartLevel : MonoBehaviour
    {
        [SerializeField] private int _levelIndex;

        private void Awake() => _levelIndex = SceneManager.GetActiveScene().buildIndex;

        public void Restart() => SceneManager.LoadScene(_levelIndex);
    }
}
