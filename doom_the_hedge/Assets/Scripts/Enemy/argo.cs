using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class argo : MonoBehaviour
{
    public bool agrroed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Destroy(collision.collider.gameObject);
            agrroed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agrroed = false;
        }
    }
}


