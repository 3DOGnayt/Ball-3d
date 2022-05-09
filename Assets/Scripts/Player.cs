using System;
using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage, ITakeHp, ISpeed
{
    //[SerializeField] private GameObject _diedMenu = null;
    [Space]
    [SerializeField] private float _speed = 4;
    [SerializeField] private int _hp = 100;

    private bool _isAlive = true;
    private Vector3 _direction = Vector2.zero;

    public event Action<int> _takeHp;

    void Update()
    {
        Move();
                
        _direction.z = Input.GetAxis("Vertical");
        _direction.x = Input.GetAxis("Horizontal");                 
    }
    
    private void Move()
    {
        var speed = _direction * (_speed * Time.fixedDeltaTime);
        transform.Translate(speed);
    }
      
    public void Takedamage(int damage)
    {
        if (_isAlive == true)
        {
            _hp -= damage;
            //if (_hp <= 0)
            //    Death();
        }
    }
    
    //private void Death()
    //{        
    //    _isAlive = false;
    //    Time.timeScale = 0f;
    //    _diedMenu.SetActive(true);
    //}

    public void Speed(float speed)
    {
        try
        {
            _speed += speed;
        }
        catch (Exception e) when (_speed < 0 || _speed > 8)
        {
            Debug.Log($"{e.Message}");
        }
    }

    public void TakeHp(int health)
    {
        _hp += health;
        if (_takeHp != null)
        {
            _takeHp(_hp);
        }         
    }     
}