using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float damage = 10;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<NavMeshAI>().Hp -= 10;
    }
}
