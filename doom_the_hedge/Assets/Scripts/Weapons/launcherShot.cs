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
        float yfromground;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up*-1), out hit, Mathf.Infinity, 0))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            yfromground = hit.distance;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1) * 1000, Color.white);
            //Debug.Log("Did not Hit");
            yfromground = transform.position.y;
        }
    
            Instantiate(particleToSpawn, new Vector3(transform.position.x, yfromground + 3, transform.position.z), Quaternion.identity,null);
        
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
