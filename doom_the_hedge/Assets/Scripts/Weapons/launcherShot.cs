using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcherShot : bullet
{
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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit something");
        if (collision.collider.CompareTag(targetTag))
        {
            //Destroy(collision.collider.gameObject);
            var target = collision.gameObject.GetComponent<HpPool>();
            target.takeDamage(damage);
            kill();
        }
    }
}
