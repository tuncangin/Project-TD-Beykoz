using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent myAgent;
    public Transform objectToFollow;

    public int Health = 100;

    public void GetDamage(int DamageAmount)
    {
        Health -= DamageAmount;
        
        if (Health <= 0)
        {
           KillMe();
           Debug.Log("Enemy Died");
        }
    }

    private void KillMe()
    {
        //Pool varsa pool a dön
        Destroy(gameObject);
    }
    
    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        objectToFollow = GameObject.FindWithTag("TargetPosition").transform;
    }

    private void Update()
    {
        myAgent.SetDestination(objectToFollow.position);
    }
}
