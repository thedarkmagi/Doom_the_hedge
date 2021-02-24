using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public gun Gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if can be fired
        if (Gun.tick())
        {
            if (Input.GetMouseButton(0))
            {
                Gun.fire();
            }
        }
        //reload
        if (Input.GetKey(KeyCode.R))
        {
            Gun.reload();
        }
    }
}
