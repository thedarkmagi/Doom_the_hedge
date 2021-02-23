using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct gunData
{
    public string name;
    public gunTypes type;
    public GameObject the_gun;
    public GameObject projectile;
    public GameObject aimTarget;
    public float fireRate;
    public float curFireRate;
    public int maxAmmo;
    public int currAmmo;
    public float damage;
    public float velocity;
    public float lifetime;
}

public enum gunTypes
{
    shotgun,
    rifle,
    launcher
}


public class gun : MonoBehaviour
{
    //public GameObject projectile;
    //public GameObject aimTarget;
    //public float fireRate;
    //float curFireRate;
    //public int maxAmmo;
    //public int currAmmo;
    //public float damage;
    public string targetTag;
    public List<gunData> weapons;
    public gunData currentGun;
    public int currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        currentGun = weapons[currentWeapon];
        if(currentGun.type ==gunTypes.shotgun)
        {
            //currentGun.projectile.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentGun.curFireRate += Time.deltaTime;
        //can fire
        if (currentGun.curFireRate > currentGun.fireRate)
        {
            if(Input.GetMouseButtonDown(0))
            {
                fire();
            }
        }
    }
    void fire()
    {
        switch (currentGun.type)
        {
            case gunTypes.shotgun:
                fire_shotgun();
                break;
            case gunTypes.rifle:
                fire_rifle();
                break;
            case gunTypes.launcher:
                fire_launcher();
                break;
            default:
                break;
        }
    }

    void fire_rifle()
    {
        var shot = Instantiate(currentGun.projectile, transform.position, Quaternion.identity, transform);
        var rb = shot.GetComponent<Rigidbody>();
        var bullet = shot.GetComponent<bullet>();

        // set direction 
        Vector3 dir = currentGun.aimTarget.transform.position - transform.position;
        rb.velocity = dir * currentGun.velocity;
        //set shot details
        bullet.damage = currentGun.damage;
        bullet.lifetime = currentGun.lifetime;
        bullet.targetTag = targetTag;
    }

    void fire_shotgun()
    {
        //var shot = Instantiate(currentGun.projectile, transform.position, Quaternion.identity, transform);
        currentGun.projectile.SetActive(true);
        //var rb = shot.GetComponent<Rigidbody>();
        var bullet = currentGun.projectile.GetComponent<shotgunBlast>();
        bullet._collider.enabled = true;
        // set direction 

        //set shot details
        bullet.damage = currentGun.damage;
        bullet.lifetime = currentGun.lifetime;
        bullet.targetTag = targetTag;
    }

    void fire_launcher()
    {
        var shot = Instantiate(currentGun.projectile, transform.position, Quaternion.identity, transform);
        var rb = shot.GetComponent<Rigidbody>();
        var bullet = shot.GetComponent<bullet>();

        // set direction 
        Vector3 dir = currentGun.aimTarget.transform.position - transform.position;
        rb.velocity = dir * currentGun.velocity;
        //set shot details
        bullet.damage = currentGun.damage;
        bullet.lifetime = currentGun.lifetime;
        bullet.targetTag = targetTag;
    }
}
