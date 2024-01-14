using UnityEngine;

public class Traps : MonoBehaviour
{
    private int _damage = 10;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 10, 2) - 1, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ITakeDamage>(out var takeDamage))
        {
            takeDamage.Takedamage(_damage);
        }
    }
}
