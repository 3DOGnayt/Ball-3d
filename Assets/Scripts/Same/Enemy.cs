using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int _hp = 40;
    [SerializeField] private Transform[] waypoints;
    
    private bool _isAlive = true;     
    private bool _PlayerCheck = false;     
    private int _Currentwpi;
    private NavMeshAgent _navMeshAgent = null;
    private GameObject _target = null;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();       
    }    

    private void Start()
    {
        _target = GameObject.Find("Player");
        _navMeshAgent.SetDestination(waypoints[0].position);
    }

    private void Update()
    {
        if (_PlayerCheck)
            _navMeshAgent.SetDestination(_target.transform.position);
        else if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _Currentwpi = (_Currentwpi + 1) % waypoints.Length;
            _navMeshAgent.SetDestination(waypoints[_Currentwpi].position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCheck(other);
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerCheck(other);
    }

    private void PlayerCheck(Collider other)
    {
        if (other.CompareTag("Player"))
            _PlayerCheck = !_PlayerCheck;
    }

    public void Takedamage(int damage)
    {
        if (_isAlive)
        {
            _hp -= damage;
            if (_hp <= 0)
                Death();
        }
    }

    private void Death()
    {
        _isAlive = false;
        Destroy(gameObject);    
    }
}