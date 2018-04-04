using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform destination;
    public float damage = 10;
    public float Hp = 50;
    // Use this for initialization
    void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();

        }

        if (destination == null)
        {
            destination = GameObject.FindGameObjectWithTag("Target").transform;
        }
        else
        {
            agent.destination = destination.position;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.destination == null)
        {
            agent.destination = destination.position;
        }

        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Tower")
        {
            collision.collider.GetComponent<TowerScript>().HpCurrent -= 10;
            Destroy(gameObject);
        }
    }
}
