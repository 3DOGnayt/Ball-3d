using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Rotate(0, 0.8f, 0f);
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 0.5f) + 0.5f, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ISpeed>(out var iTakeSpeed))
        {
            iTakeSpeed.Speed(_speed); 
            Destroy(gameObject);
        }
    }
}