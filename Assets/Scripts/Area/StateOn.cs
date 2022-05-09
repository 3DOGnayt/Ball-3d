using UnityEngine;

public class StateOn : MonoBehaviour
{
    [SerializeField] private GameObject _menu = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            _menu.SetActive(true);
        }        
    }
}
