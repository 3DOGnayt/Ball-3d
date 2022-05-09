using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 60;

    private int _damage = 0;

    public void Init(int damage) 
    {                                                
        _damage = damage;                        
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ITakeDamage>(out var takeDamage))
        {
            takeDamage.Takedamage(_damage); 
        }
    }
}