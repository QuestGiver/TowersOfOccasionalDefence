using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Spawner spawner;
    public Transform destination;
    public float damage = 10;
    public float Hp = 50;
    // Use this for initialization
    void Start()
    {

        spawner = GameObject.FindGameObjectWithTag("Player").GetComponent<Spawner>();

        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();

        }

        
        if (!agent.isOnNavMesh)
        {
            Debug.Log("connect to mesh please");
        }

        
        if (destination == null)
        {
            destination = GameObject.FindGameObjectWithTag("Target").transform;
        }
        else
        {
            agent.destination = destination.position;
           
        }

        transform.forward = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (agent.destination == null)
        //{
        //    agent.destination = destination.position;
        //}
        if (!agent.pathPending)
        {
            agent.destination = destination.position;
        }


        if (Hp <= 0)
        {
            Destroy(gameObject);
            spawner.livingEnemies--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Tower" || collision.collider.tag == "Target")
        {
            collision.collider.GetComponent<TowerScript>().HpCurrent -= 10;
            Destroy(gameObject);
            spawner.livingEnemies--;
        }
    }
}
