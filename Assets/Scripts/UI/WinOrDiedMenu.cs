using UnityEngine;
using UnityEngine.UI;

public class WinOrDiedMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu = null;
    [SerializeField] private Button _restart = null;

    private void Awake()
    {
        _restart.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        _menu.SetActive(false);
        Time.timeScale = 1f;        
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}