using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUP : MonoBehaviour
{

    public int amountofHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<HpPool>().HP += amountofHealth;
            if (other.GetComponent<HpPool>().HP > 100)
            {
                other.GetComponent<HpPool>().HP = 100;
            }
            Destroy(gameObject);
        }
    }
}
