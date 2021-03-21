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

    public float reloadTime;
    public float currReloadTime;
    public float radius;
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
    private Animator anim;
    float starttimer=0;
    public bool reloaded;
    public bool reloading=true;
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
        currentGun.currReloadTime -= Time.deltaTime;
        if(currentGun.currReloadTime<0)
        {
            reloaded = true;
            if (targetTag == "enemy")
            {
                currentGun.the_gun.GetComponent<Animator>().SetBool("reload", false);
                
            }
        }
         if(currentGun.currAmmo <1)
        {

            if (targetTag == "enemy")
            {
                currentGun.the_gun.GetComponent<Animator>().SetBool("reload", true);

                if (currentGun.the_gun.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("reload"))
                {
                    reloading = true;

                }
                else if (reloading)
                {
                    
                    reloading = false;                
                }
                                
            }
            
        }
          if  (reloading)
            {
                reload();
                 reloading = false;
            
        }

    }

    public bool isFinishedReloading()
    {
        return reloaded && currentGun.currReloadTime < 0;
    }

    public bool tick()
    {
        bool result = false;
        currentGun.curFireRate += Time.deltaTime;
        //can fire
        if (currentGun.curFireRate > currentGun.fireRate)
        {
            result = true;
            result = reloaded;
        }


        return result;
    }

    public void changeWeapon(int wepIndex)
    {
        //for (int i = 0; i < weapons.Count; i++)
        //{
        //    weapons[i].the_gun.SetActive(false);

        //    if ((wepIndex < weapons.Count))
        //    {

        //        currentGun = weapons[wepIndex];
        //        currentGun.the_gun.SetActive(true);
        //        if (targetTag == "enemy")
        //        {
        //            currentGun.the_gun.GetComponent<Animator>().SetBool("reload", true);
        //        }
        //    }
        //}
        foreach (gunData guns in weapons)
        {
            guns.the_gun.SetActive(false);

            if ((wepIndex < weapons.Count))
            {

                currentGun = weapons[wepIndex];
                currentGun.the_gun.SetActive(true);
                if (targetTag == "enemy")
                {
                    currentGun.the_gun.GetComponent<Animator>().SetBool("reload", true);
                }
            }

        }



    }

    public void fire()
    {
        if (currentGun.currAmmo > 0)
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
            currentGun.curFireRate = 0;
        }
        else if (targetTag != "enemy")
                reload();

        
    }

    public void reload()
    {
        
        //play anim or whatever reload delay
        reloaded = false;
        currentGun.currReloadTime = currentGun.reloadTime;
        currentGun.currAmmo = currentGun.maxAmmo;
    }

    void fire_rifle()
    {
        var shot = Instantiate(currentGun.projectile, currentGun.the_gun.transform.position, Quaternion.identity, null);
        var rb = shot.GetComponent<Rigidbody>();
        var bullet = shot.GetComponent<bullet>();

        // set direction 

        Vector3 dir = currentGun.aimTarget.transform.position - transform.position;
        rb.velocity = dir * currentGun.velocity;
        if (targetTag == "enemy")
        {
            shot.transform.rotation = currentGun.the_gun.transform.rotation;

        }
        //set shot details
        bullet.damage = currentGun.damage;
        bullet.lifetime = currentGun.lifetime;
        bullet.targetTag = targetTag;

        currentGun.currAmmo--;
    }

    void fire_shotgun()
    {
        //var shot = Instantiate(currentGun.projectile, transform.position, Quaternion.identity, transform);
        currentGun.projectile.SetActive(true);
        //var rb = shot.GetComponent<Rigidbody>();
        var bullet = currentGun.projectile.GetComponent<shotgunBlast>();
        bullet.fire();
        bullet._collider.enabled = true;
        // set direction 

        //set shot details
        bullet.damage = currentGun.damage;
        bullet.lifetime = currentGun.lifetime;
        bullet.targetTag = targetTag;
        currentGun.currAmmo--;
    }

    void fire_launcher()
    {
        var shot = Instantiate(currentGun.projectile, currentGun.the_gun.transform.position, Quaternion.identity, null);
        var rb = shot.GetComponent<Rigidbody>();
        var bullet = shot.GetComponent<launcherShot>();

        // set direction 
        Vector3 dir = currentGun.aimTarget.transform.position - transform.position;
        rb.velocity = dir * currentGun.velocity;
        //set shot details
        bullet.damage = currentGun.damage;
        bullet.lifetime = currentGun.lifetime;
        bullet.targetTag = targetTag;
        bullet.radius = currentGun.radius;
        currentGun.currAmmo--;
       
    }
}
