using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public GameObject projectile;
    public GameObject aimTarget;
    public float fireRate;
    float curFireRate;
    public int maxAmmo;
    public int currAmmo;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curFireRate += Time.deltaTime;
        //can fire
        if(curFireRate > fireRate)
        {
            if(Input.GetMouseButtonDown(0))
            {
                fire();
            }
        }
    }


    void fire()
    {
        var shot = Instantiate(projectile, transform.position, Quaternion.identity, transform);
        var rb = shot.GetComponent<Rigidbody>();
        var bullet = shot.GetComponent<bullet>();

        // set direction 
        Vector3 dir = aimTarget.transform.position - transform.position;
        rb.velocity = dir * 10;
        //set shot details
        bullet.damage = damage;
        bullet.lifetime = 5;
        bullet.tag = "enemy";
    }
}
