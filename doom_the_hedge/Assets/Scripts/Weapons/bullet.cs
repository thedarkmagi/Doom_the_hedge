using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damage;
    public float lifetime;
    public string tag;
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
        if(collision.collider.CompareTag(tag))
        {
            //Destroy(collision.collider.gameObject);
            var target = collision.gameObject.GetComponent<HpPool>();
            target.takeDamage(damage);
            kill();
        }
    }
}
