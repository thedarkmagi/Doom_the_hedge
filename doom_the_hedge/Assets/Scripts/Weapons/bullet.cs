using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damage;
    public float lifetime;
    public string targetTag;
    public GameObject hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime<0)
        {
            kill();
        }
    }

    void kill()
    {
        

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit something");
        if(collision.collider.CompareTag(targetTag))
        {
            //Destroy(collision.collider.gameObject);
            var target = collision.gameObject.GetComponent<HpPool>();
            target.takeDamage(damage);
            if (targetTag == "enemy")
                Instantiate(hit, transform.position, Quaternion.identity);
            kill();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            //Destroy(collision.collider.gameObject);
            var target = other.gameObject.GetComponent<HpPool>();
            target.takeDamage(damage);
            kill();
        }
        else if (other.CompareTag("enviroment"))
        {
            if (targetTag == "enemy")
               Instantiate(hit, transform.position, Quaternion.identity);
            kill();
        }
    }
}
