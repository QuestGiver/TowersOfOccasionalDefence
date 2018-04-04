using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{

    public Transform target;
    public float HpMax = 100;
    public float HpCurrent;
    public GameObject projectile;
    public float projectileSpeed;
    public float fireRate = 0.5f;
    float timer;
    public float maxTowerRange = 40;
    // Use this for initialization
    void Start()
    {
        timer = fireRate;
        HpCurrent = HpMax;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxTowerRange);
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (target == null)
        {

            int searchRange = 1;
            Collider[] neighbours = Physics.OverlapSphere(transform.position, searchRange);
                    Debug.Log("start search");
            foreach (Collider guy in neighbours)
            {

                if (guy != null)
                {
                    if (guy.tag == "Enemy")
                    {

                        Gizmos.DrawWireSphere(transform.position, searchRange);

                        target = guy.transform;
                        searchRange = 1;
                        Debug.Log("end search");


                    }
                    else
                    {
                        Debug.Log("found incorrect object");
                    }
                }
            }

            if (target == null)
            {
                if (searchRange < maxTowerRange)
                {
                    searchRange += 2;
                }

            }

        }
        else
        {
            if (timer >= fireRate)
            {
                GameObject missile = Instantiate(projectile, transform.position, transform.rotation);
                missile.GetComponent<Rigidbody>().AddForce((target.position - transform.position).normalized * projectileSpeed * Time.deltaTime);
                timer = 0;
            }
        }
    }
}
