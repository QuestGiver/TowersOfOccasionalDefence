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
    public int searchRange = 1000;
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
        //Kobery code
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        

        if(target != null)
        {
            if (timer >= fireRate)
            {
                GameObject missile = Instantiate(projectile, transform.position + new Vector3(0, 5, 0), transform.rotation);
                missile.GetComponent<Rigidbody>().AddForce((target.position - missile.transform.position).normalized * projectileSpeed * Time.deltaTime,ForceMode.Impulse);
                Destroy(missile, 3);
                timer = 0;
            }
        }
        else
        {
            SearchForTarget();
        }
    }


    public void SearchForTarget()
    {
        Collider[] neighbours = Physics.OverlapSphere(transform.position, searchRange, 1 << 9);
        Debug.Log("start search");
        foreach (Collider guy in neighbours)
        {
            if (guy != null)
            {
                if (guy.tag == "Enemy")
                {



                    target = guy.transform;
                    Debug.Log("end search");
                    break;

                }
                else
                {
                    Debug.Log("found incorrect object");
                }
            }
        }
    }
}
