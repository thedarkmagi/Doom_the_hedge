using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcherShot : MonoBehaviour
{
    public float damage;
    public float lifetime;
    public string targetTag;
    public float radius;
    public GameObject particleToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            kill();
        }
    }

    void kill()
    {
        Destroy(this.gameObject);
    }
    //pretty sure this isn't being using but gonna leave it for good measure xD
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(targetTag))
        {
            //Destroy(collision.collider.gameObject);
            //this will currently deal double damage if you get a direct hit
            var target = collision.gameObject.GetComponent<HpPool>();
            target.takeDamage(damage);
            aodHit();
            kill();
        }
        else if (collision.collider.CompareTag("enviroment"))
        {
            //Destroy(collision.collider.gameObject);
            //var target = collision.gameObject.GetComponent<HpPool>();
            //target.takeDamage(damage);
            aodHit();
            kill();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            //Destroy(collision.collider.gameObject);
            //this will currently deal double damage if you get a direct hit
            var target = other.gameObject.GetComponent<HpPool>();
            target.takeDamage(damage);
            aodHit();
            kill();
        }
        else if (other.CompareTag("enviroment"))
        {
            //Destroy(collision.collider.gameObject);
            //var target = collision.gameObject.GetComponent<HpPool>();
            //target.takeDamage(damage);
            aodHit();
            kill();
        }
    }
    void aodHit()
    {
        //if(particleToSpawn)
        //{

            Instantiate(particleToSpawn, transform.position, Quaternion.identity,null);
        //}
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius, Vector3.one);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.CompareTag(targetTag))
            {
                var target = hits[i].collider.gameObject.GetComponent<HpPool>();
                target.takeDamage(damage);
            }
        }
    }
}
