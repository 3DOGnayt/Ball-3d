using UnityEngine;

public class Died : MonoBehaviour
{    
    private int _damage = 1000;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ITakeDamage>(out var takeDamage))
        {
            takeDamage.Takedamage(_damage);
        }
    }
}