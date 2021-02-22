using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HpPool hp; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp.HP<0)
        {
            kill();
        }

        
    }

    private void LateUpdate()
    {
        transform.forward = new Vector3(Camera.main.transform.forward.x,
            transform.forward.y, Camera.main.transform.forward.z);
    }


    void kill()
    {
        Destroy(this.gameObject);
    }
}
